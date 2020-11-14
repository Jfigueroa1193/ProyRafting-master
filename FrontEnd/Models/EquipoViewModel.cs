using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class EquipoViewModel
    {
        [Display(Name = "Identificador")]
        [Key]
        public int Equipo_ID { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public string Observacion { get; set; }
        public Nullable<int> Cantidad { get; set; }
    }
}