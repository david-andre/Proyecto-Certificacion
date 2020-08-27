using BEUCertificacion;
using BEUCertificacion.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace WebApiCertificacion.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class PedidosController : ApiController
    {
        public IHttpActionResult Post(Pedido pedido)
        {
            try
            {
                PedidoBLL.Create(pedido);
                return Content(HttpStatusCode.Created, "Pedido creado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        public IHttpActionResult Put(Pedido pedido)
        {
            try
            {
                PedidoBLL.Update(pedido);
                return Content(HttpStatusCode.OK, "Pedido actualizado correctamente");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult GetOne(int id)
        {
            try
            {
                Pedido result = PedidoBLL.Get(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Content(HttpStatusCode.OK, result);

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        public IHttpActionResult GetByClient(int id)
        {
            try
            {
                List<Pedido> result = PedidoBLL.List(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Content(HttpStatusCode.OK, result);

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }


        public IHttpActionResult Delete(int id)
        {
            try
            {
                PedidoBLL.Delete(id);
                return Ok("Pedido eliminado correctamente");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}