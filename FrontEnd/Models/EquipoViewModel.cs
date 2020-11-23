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
        [Required]
        [Key]
        public int Equipo_ID { get; set; }

        [Display(Name = "Nombre")]
        [StringLength(50, MinimumLength = 2)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Debe digitar el nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Estado")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Digite un estado")]
        public string Estado { get; set; }

        [Display(Name = "Anote si tiene observaciones")]
        [DataType(DataType.Text)]
        public string Observacion { get; set; }

        public Nullable<int> Cantidad { get; set; }
    }
}