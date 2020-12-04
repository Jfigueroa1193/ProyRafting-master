using BackEnd.Entities;
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
        [Display(Name = "Identificador")]
        public int Reserva_ID { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime Fecha { get; set; }

        [Display(Name = "Cliente")]
        public int Usuario_ID { get; set; }
        public IEnumerable<Usuarios> Usuarios { get; set; }

        [Display(Name = "Servicio")]
        public int Servicio_ID { get; set; }
        public IEnumerable<Servicio> Servicios { get; set; }
        public string Consentimiento { get; set; }
        public DateTime Horario { get; set; }

        [Display(Name = "Cantidad Personas")]
        public int Cantidad_Personas { get; set; }

        [Display(Name = "Tipo de Pago")]
        public string Tipo_Pago { get; set; }
        public double Total { get; set; }
        public string Observacion { get; set; }
    }
}