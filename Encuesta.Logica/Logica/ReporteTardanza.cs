using Encuesta.Logica.data;
using System;
using Encuesta.Logica.Models;
using System.Data;

namespace Encuesta.Logica.Logica
{
    public class ReporteTardanza
    {
        private DReporteAsistencia dReporte = new DReporteAsistencia();
        private DateTime fecha_desde { get; set; }
        private DateTime fecha_hasta { get; set; }

        public ReporteTardanza(DateTime p_fecha_desde, DateTime p_fecha_hasta)
        {
            fecha_desde = p_fecha_desde;
            fecha_hasta = p_fecha_hasta;
        }
        public int generateDocument(int totalMinuto)
        {
            var listTardanza = dReporte.getTardanza(fecha_desde, fecha_hasta, totalMinuto);
            foreach (var item in listTardanza)
            {
                createDocuementByUsuario(item);
            }
            return listTardanza.Count;
        }
        private void createDocuementByUsuario(pr_sel_reporte_asistencia_Result item)
        {
            var dataSet = new DataSet();
            var asistencia = dReporte.getReporteByUsuario(fecha_desde, fecha_hasta, item.usuario);
            dataSet.Tables.Add(getTableCuerpo(asistencia,item));
            dataSet.Tables.Add(getTableDetail(item));
            new DocumentoLogica(dataSet,item);
        }
        private DataTable getTableCuerpo(reporte_asistencia asistencia, pr_sel_reporte_asistencia_Result item)
        {
            var correlativo = new DCorrelativo().getCorrelativo("INF");
            var table = new DataTable("cuerpo");
            string[] columns = { "NombreEmpleado", "FechaDesde", "FechaHasta", "CantidaMinuto", "HoraEntrada", "FechaCabecera","Correlativo","Anio" };
            for(int i = 0; i < columns.Length; i++)
            {
                table.Columns.Add(columns[i]);
            }
            var dataRow = table.NewRow();
            dataRow["NombreEmpleado"] = asistencia.Usuario;
            dataRow["FechaDesde"] = fecha_desde.ToShortDateString();
            dataRow["FechaHasta"] = fecha_hasta.ToShortDateString();
            dataRow["CantidaMinuto"] = item.Total_Minuto.ToString();
            dataRow["HoraEntrada"] = asistencia.Hora_Ingreso_Est.ToString();
            dataRow["FechaCabecera"] = "Santiago de Surco, "+DateTime.Now.ToLongDateString().Split(',')[1];
            dataRow["Correlativo"] = string.Format("{0}{1}", new string('0', 3 - correlativo.numero.ToString().Length), correlativo.numero);
            dataRow["Anio"] = DateTime.Now.Year;
            table.Rows.Add(dataRow);
            return table;
        }
        private DataTable getTableDetail(pr_sel_reporte_asistencia_Result item)
        {
            var tableDetail = new DataTable("detail");
            string[] columns = {"Fecha","HoraIngreso","HoraMarcado"};
            for (int i = 0; i < columns.Length; i++)
            {
                tableDetail.Columns.Add(columns[i]);
            }
            var listAsistenciaByUsuario = dReporte.getAsistenciaByUsuario(item,fecha_desde,fecha_hasta);
            foreach (var list in listAsistenciaByUsuario)
            {
                var dataRow = tableDetail.NewRow();
                dataRow["Fecha"] = Convert.ToDateTime(list.Fecha_Asistencia).ToShortDateString();
                dataRow["HoraIngreso"] = string.Format("{0} a.m.", list.Hora_Ingreso_Est);
                dataRow["HoraMarcado"] = string.Format("{0} a.m.", list.Hora_Ingreso_Marcado);
                tableDetail.Rows.Add(dataRow);
            }
            return tableDetail;
        }
    }
}
