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
    
    public partial class DetallePedido
    {
        public int iddetalle { get; set; }
        public Nullable<int> idpedido { get; set; }
        public Nullable<int> idservicio { get; set; }
        public Nullable<decimal> costo { get; set; }
    
        public virtual Pedido Pedido { get; set; }
        public virtual Servicio Servicio { get; set; }
    }
}
