using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class ReservaViewModel
    {
        [Key]
        public int Reserva_ID { get; set; }
        public DateTime Fecha { get; set; }
        public int Usuario_ID { get; set; }
        public int Servicio_ID { get; set; }
        public string Consentimiento { get; set; }
        public DateTime Horario { get; set; }
        public int Cantidad_Personas { get; set; }
        public string Tipo_Pago { get; set; }
        public double Total { get; set; }
        public string Observacion { get; set; }
    }
}