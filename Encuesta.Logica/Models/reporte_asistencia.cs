//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Encuesta.Logica.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class reporte_asistencia
    {
        public int id_reporte_asistencia { get; set; }
        public string Empresa { get; set; }
        public string Usuario { get; set; }
        public Nullable<System.DateTime> Fecha_Asistencia { get; set; }
        public string Hora_Ingreso_Est { get; set; }
        public string Hora_Ingreso_Marcado { get; set; }
        public string IP_Ingreso { get; set; }
        public string Diferencia_Ingreso { get; set; }
        public string Hora_Salida_Est { get; set; }
        public string Hora_Salida_Marcado { get; set; }
        public string IP_Salida { get; set; }
        public string Diferencia_Salida { get; set; }
        public Nullable<System.DateTime> Fecha_Registro { get; set; }
    }
}
