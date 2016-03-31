using System;
using System.Configuration;
using System.IO;

namespace Encuesta.Logica.Logica
{
    public class Utils
    {
        public string createFolder(string pathAux)
        {
            var pathRoot = ConfigurationManager.AppSettings["ruta_archivo"].ToString();
            try
            {
                string path = string.Format("{0}{1}/{2}/", pathRoot, DateTime.Now.Year, pathAux);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                return path;
            }
            catch (Exception ex)
            {
                throw(new Exception(ex.Message));
            }
        }
    }
}
