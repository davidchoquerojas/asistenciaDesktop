using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Data;
using System.IO;
using Encuesta.Logica.Models;
using System.Collections.Generic;
using Encuesta.Logica.data;
using System.Linq;

namespace Encuesta.Logica.Logica
{
    public class CargaLogica
    {
        private string pathString { get; set; }
        private XSSFWorkbook book { get; set; }
        private ISheet sheet { get; set; }
        public DataTable data { get; set; }
        public Int32 totalSave { get; set; }
        public string messsage { get; set; } = ", Datos ya cargados para las fecha (s): ";
        public int existeDatosDB { get; set; }

        public CargaLogica(string path)
        {
            pathString = path;
        }

        public void readFile()
        {
            using (FileStream file = new FileStream(pathString, FileMode.Open, FileAccess.Read))
            {
                book = new XSSFWorkbook(file);
                sheet = book.GetSheetAt(0);
                loadToDatatable();
                saveInDatabase();
            }
        }

        private void saveInDatabase()
        {
            var listInique = listUniqueDate(data);
            var dReporteAsistencia = new DReporteAsistencia();
            try
            {

                var listAsistencia = new List<reporte_asistencia>();
                foreach (var item in listInique)
                {
                    if (dReporteAsistencia.existeDatosInDB(item))
                    {
                        messsage += string.Format("{0} - ", item.ToShortDateString());
                        existeDatosDB++;
                    }
                    else {
                        var resAsistencia = datatableGenerateList(item);
                        listAsistencia.AddRange(resAsistencia);
                    }
                }
                totalSave = dReporteAsistencia.saveData(listAsistencia);
            }
            catch (Exception ex)
            {
                throw(new Exception(ex.Message));
            }
        }

        private List<reporte_asistencia> datatableGenerateList(DateTime item)
        {
            var listTemp = new List<reporte_asistencia>();
            var tempDatatable = data.AsEnumerable()
                                .Where(x => x.Field<string>("Fecha_Asistencia") == item.ToShortDateString())
                                .CopyToDataTable();
            for (int i = 0; i < tempDatatable.Rows.Count; i++)
            {
                var reporte_asistencia = new reporte_asistencia()
                {
                    Empresa = tempDatatable.Rows[i][0].ToString(),
                    Usuario = tempDatatable.Rows[i][1].ToString(),
                    Fecha_Asistencia = Convert.ToDateTime(tempDatatable.Rows[i][2].ToString()).Date,
                    Hora_Ingreso_Est = tempDatatable.Rows[i][3].ToString(),
                    Hora_Ingreso_Marcado = tempDatatable.Rows[i][4].ToString(),
                    IP_Ingreso = tempDatatable.Rows[i][5].ToString(),
                    Diferencia_Ingreso = tempDatatable.Rows[i][6].ToString(),
                    Hora_Salida_Est = tempDatatable.Rows[i][7].ToString(),
                    Hora_Salida_Marcado = tempDatatable.Rows[i][8].ToString(),
                    IP_Salida = tempDatatable.Rows[i][9].ToString(),
                    Diferencia_Salida = tempDatatable.Rows[i][10].ToString(),
                    Fecha_Registro = DateTime.Now

                };
                listTemp.Add(reporte_asistencia);
            }
            return listTemp;
        }

        private List<DateTime> listUniqueDate(DataTable data)
        {
            var encontro = (from r in data.AsEnumerable()
                            select r[2]).Distinct().ToList();
            return encontro.Select(x => Convert.ToDateTime(x.ToString())).OrderBy(x=>x.ToShortDateString()).ToList();
        }

        public Boolean loadToDatatable()
        {
            data = new DataTable();
            try
            {
                System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
                IRow headerRow = sheet.GetRow(1);

                var colCount = headerRow.LastCellNum;
                var rowCount = sheet.LastRowNum;

                foreach (var item in headerRow.Cells)
                {
                    data.Columns.Add(item.StringCellValue.Replace(" ","_").Trim());
                }

                bool skipReadingHeaderRow = rows.MoveNext();

                while (rows.MoveNext())
                {
                    IRow row = (XSSFRow)rows.Current;
                    DataRow dr = data.NewRow();
                    for (int i = 0; i < colCount-1; i++)
                    {
                        ICell cell = row.Cells[i];
                        switch (cell.CellType)
                        {
                            case CellType.Formula:
                                dr[i] = cell.RichStringCellValue;
                                break;
                            default:
                                dr[i] = cell.ToString();
                                break;
                        }
                    }
                    data.Rows.Add(dr);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }
    }
}
