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
    using System.ComponentModel.DataAnnotations;

    public partial class Pedido
    {
        [ScaffoldColumn(false)]
        public int idpedido { get; set; }
        [Display(Name = "Fecha de Petición")]
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> fechaPeticion { get; set; }
        [Display(Name = "Estado")]
        public string estado { get; set; }
        [Display(Name = "Fecha de Ejecución")]
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> fechaEjecucion { get; set; }
        public Nullable<int> idservicio { get; set; }
        public Nullable<int> idcliente { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Servicio Servicio { get; set; }
    }
}
