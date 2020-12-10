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

        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime Fecha { get; set; }

        [Display(Name = "Colaborador")]
        public int Colaborador_ID { get; set; }

        [Display(Name = "Observación")]
        [DataType(DataType.Text)]
        public string Observacion { get; set; }

    }
}