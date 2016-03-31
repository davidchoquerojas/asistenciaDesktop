using System;
using Encuesta.Logica.Models;
using System.Linq;

namespace Encuesta.Logica.data
{
    public class DCorrelativo
    {
        public correlativo getCorrelativo(string type)
        {
            try
            {
                using (var db = new app_control())
                {
                    var correlativo = db.correlativo.Where(x => x.tipo_correlativo == type).First();
                    correlativo.numero++;
                    correlativo.fecha_actualizacion = DateTime.Now;
                    db.SaveChanges();
                    return correlativo;
                }
            }
            catch (Exception ex)
            {
                throw(new Exception(ex.Message,ex.InnerException));
            }
        }
    }
}
