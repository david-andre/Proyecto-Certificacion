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
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Servicio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Servicio()
        {
            this.DetallePedidoes = new HashSet<DetallePedido>();
        }

        [ScaffoldColumn(false)]
        public int idservicio { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El nombre es requerido"), MaxLength(100)]
        [Display(Name = "Servicio")]
        public string nombre { get; set; }
        [RegularExpression(@"^\d+\.\d{0,2}$", ErrorMessage = "El costo debe incluir una parte decimal")]
        [Range(0, 9999999999999999.99)]
        [Display(Name = "Costo")]
        public string costo { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "La descripción es requerida")]
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }
        [Display(Name = "Empresa")]
        public Nullable<int> idempresa { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<DetallePedido> DetallePedidoes { get; set; }
        [JsonIgnore]
        public virtual Empresa Empresa { get; set; }
    }
}
