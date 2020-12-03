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
        [Required(ErrorMessage = "Este campo es requerido.")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
             ErrorMessage = "Dirección de Correo electrónico incorrecta.")]
        [StringLength(100, ErrorMessage = "Longitud máxima 100")]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }

        
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(15, ErrorMessage = "Longitud entre 6 y 15 caracteres.",
                      MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Clave { get; set; }

        public int Rol_ID { get; set; }

        public string LoginErrorMessage { get; set; }
    }
}