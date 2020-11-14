using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class ClienteViewModel
    {
        [Display(Name = "Identificador")]
        [Key]
        public int Cliente_ID { get; set; }
        public string Nacionalidad { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
    }
}