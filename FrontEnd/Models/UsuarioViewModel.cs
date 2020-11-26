using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class UsuarioViewModel
    {
        [Display(Name = "Identificador")]
        [Key]
        public int Usuario_ID { get; set; }

        [Display(Name = "Nacionalidad")]
        [DataType(DataType.Text)]
        public string Nacionalidad { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [DataType(DataType.Text)]
        public string NombreUsuario { get; set; }

        [Display(Name = "Apellidos")]
        [DataType(DataType.Text)]
        public string Apellidos { get; set; }

        [Display(Name = "Teléfono")]
        [StringLength(15, MinimumLength = 8)]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }

        [Display(Name = "Correo electrónico")]
        [RegularExpression(@"^[0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@(ua)\.(es)$",
         ErrorMessage = "El formato del correo es incorrecto. ejemplo@dominio.com")]
        public string Correo { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Clave { get; set; }

        public int Rol_ID { get; set; }

        public string LoginErrorMessage { get; set; }
    }
}