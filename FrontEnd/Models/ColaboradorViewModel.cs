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
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }

        [Display(Name = "Rol")]
        public int Rol_ID { get; set; }
    }
}