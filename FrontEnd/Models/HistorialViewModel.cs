using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class HistorialViewModel
    {
        [Display(Name = "Identificador")]
        [Key]
        public int Historial_ID { get; set; }
        public System.DateTime Fecha { get; set; }
        public int Colaborador_ID { get; set; }
        public string Observacion { get; set; }

    }
}