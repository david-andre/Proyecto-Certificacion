using BEUCertificacion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoCertificacion.Models
{
    public class PedidoView
    {
        public Cliente Cliente { set; get; }
        public DetallePedido DetalleTitles { set; get; }
        public List<Servicio> Servicios { set; get; }

        [Display(Name = "Fecha de Ejecución")]
        public DateTime FechaPedido { get; set; }
        public string Costo { get; set; }
    }
}