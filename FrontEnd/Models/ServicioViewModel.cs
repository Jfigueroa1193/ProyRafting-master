using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class ServicioViewModel
    {
        [Key]
        public int Servicio_ID { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
    }
}