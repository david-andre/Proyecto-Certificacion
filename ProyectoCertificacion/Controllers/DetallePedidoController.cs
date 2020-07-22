using BEUCertificacion;
using BEUCertificacion.Transactions;
using ProyectoCertificacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoCertificacion.Controllers
{
    public class DetallePedidoController : Controller
    {
        public ActionResult Index()
        {
            return View(PedidoBLL.List());
        }
        // GET: DetallePedido
        public ActionResult NuevoPedido()
        {
            PedidoView pv = new PedidoView();
            pv.Cliente = new Cliente();
            pv.Servicios = new List<Servicio>();
            pv.Costo = "0.00";
            Session["PedidoView"] = pv;
            ViewBag.idcliente = new SelectList(ClienteBLL.ListToNames(), "idcliente", "nombre");
            return View(pv);
        }

        [HttpPost]
        public ActionResult NuevoPedido(PedidoView pedidoView)
        {
            pedidoView = Session["PedidoView"] as PedidoView;
            var id = int.Parse(Request["idcliente"]);
            DateTime dateEjecucion = Convert.ToDateTime(Request["FechaPedido"]);
            string costo = Request["Costo"];
            Pedido pedido = new Pedido
            {
                fechaEjecucion = dateEjecucion,
                idcliente = id,
                costo = Convert.ToDecimal(costo)
            };
            PedidoBLL.Create(pedido);
            int ultimoPedido = PedidoBLL.List().Select(x => x.idpedido).Max();
            foreach (Servicio item in pedidoView.Servicios)
            {
                var detalle = new DetallePedido()
                {
                    idpedido = ultimoPedido,
                    idservicio = item.idservicio
                };
                DetallePedidoBLL.Create(detalle);
            }
            pedidoView = Session["PedidoView"] as PedidoView;
            ViewBag.idcliente = new SelectList(ClienteBLL.ListToNames(), "idcliente", "nombre");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddServicio()
        {
            ViewBag.idservicio = new SelectList(ServicioBLL.ListToNames(), "idservicio", "nombre");
            return View();
        }

        [HttpPost]
        public ActionResult AddServicio(Servicio s)
        {
            var pv = Session["PedidoView"] as PedidoView;
            var id = int.Parse(Request["idservicio"]);
            var costo = Convert.ToDecimal(pv.Costo);
            var servicio = ServicioBLL.Get(id);
            pv.Servicios.Add(servicio);
            costo += Convert.ToDecimal(servicio.costo) / 100;
            pv.Costo = Convert.ToString(costo);
            ViewBag.idcliente = new SelectList(ClienteBLL.ListToNames(), "idcliente", "nombre");
            ViewBag.idservicio = new SelectList(ServicioBLL.ListToNames(), "idservicio", "nombre");
            return View("NuevoPedido", pv);
        }
    }
}