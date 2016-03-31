using System;
using Aspose.Words;
using System.Configuration;
using System.Data;
using Encuesta.Logica.Models;

namespace Encuesta.Logica.Logica
{
    public class DocumentoLogica
    {
        public DocumentoLogica(DataSet dataset, pr_sel_reporte_asistencia_Result item)
        {
            var pathTemplate = ConfigurationManager.AppSettings["ruta_template"].ToString();
            var pathLicence = ConfigurationManager.AppSettings["ruta_licence"].ToString(); 
            var pathRuta_archivo = new Utils().createFolder(DateTime.Now.ToString("yyyyMMdd"));
            try
            {
                Aspose.Words.License wordsLicense = new Aspose.Words.License();
                wordsLicense.SetLicense(pathLicence);

                LoadOptions loadOptions = new LoadOptions();
                loadOptions.LoadFormat = LoadFormat.Doc;

                Document doc = new Document(pathTemplate, loadOptions);
                doc.MailMerge.ExecuteWithRegions(dataset);

                doc.Save(pathRuta_archivo+"Informe_"+item.usuario+".docx");
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }
    }
}
