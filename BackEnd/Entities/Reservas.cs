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
    
    public partial class Reservas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reservas()
        {
            this.Operacion = new HashSet<Operacion>();
        }
    
        public int Reserva_ID { get; set; }
        public System.DateTime Fecha { get; set; }
        public int Usuario_ID { get; set; }
        public int Servicio_ID { get; set; }
        public string Consentimiento { get; set; }
        public System.DateTime Horario { get; set; }
        public int Cantidad_Personas { get; set; }
        public string Tipo_Pago { get; set; }
        public double Total { get; set; }
        public string Observacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operacion> Operacion { get; set; }
        public virtual Usuarios Usuarios { get; set; }
        public virtual Servicio Servicio { get; set; }
    }
}
