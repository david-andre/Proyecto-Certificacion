//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BEUCertificacion
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pedido
    {
        public int idpedido { get; set; }
        public Nullable<System.DateTime> fechaPeticion { get; set; }
        public string estado { get; set; }
        public Nullable<System.DateTime> fechaEjecucion { get; set; }
        public Nullable<int> idservicio { get; set; }
        public Nullable<int> idcliente { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Servicio Servicio { get; set; }
    }
}
