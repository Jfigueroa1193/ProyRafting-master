using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class ColaboradorViewModel
    {
        [Display(Name = "Identificador")]
        [Key]
        public int Colaborador_ID { get; set; }

        [Display(Name = "Nombre")]
        [StringLength(50, MinimumLength = 2)]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [Display(Name = "Apellidos")]
        [StringLength(50, MinimumLength = 2)]
        [DataType(DataType.Text)]
        public string Apellidos { get; set; }

        [Display(Name = "Teléfono")]
        [StringLength(15, MinimumLength = 8)]
        public int Telefono { get; set; }

        [Display(Name = "Correo electrónico")]
        [RegularExpression(@"^[0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@(ua)\.(es)$",
         ErrorMessage = "El formato del correo es incorrecto. ejemplo@dominio.com")]
        public string Correo { get; set; }

        [Display(Name = "Rol")]
        public int Rol_ID { get; set; }
    }
}