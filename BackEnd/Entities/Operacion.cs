//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BackEnd.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Operacion
    {
        public int Operacion_ID { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public int Reserva_ID { get; set; }
        public int Colaborador_ID { get; set; }
    
        public virtual Colaboradores Colaboradores { get; set; }
        public virtual Reservas Reservas { get; set; }
    }
}
