using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encuesta.Logica.data;
using Encuesta.Logica.Models;

namespace Encuesta.Logica.Logica
{
    public class CargaConsulta
    {
        public List<reporte_asistencia> listAsistencia = new List<reporte_asistencia>();
        public CargaConsulta(DateTime desde,DateTime hasta)
        {
            listAsistencia =  new DReporteAsistencia().consultaCarga(desde,hasta);
        }
    }
}
