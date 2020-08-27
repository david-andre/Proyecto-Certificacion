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
    public class DetallePedidosController : ApiController
    {
        public IHttpActionResult Post(DetallePedido detalle)
        {
            try
            {
                DetallePedidoBLL.Create(detalle);
                return Content(HttpStatusCode.Created, "DetallePedido creado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /*public IHttpActionResult Put(DetallePedido detalle)
        {
            try
            {
                DetallePedidoBLL.Update(detalle);
                return Content(HttpStatusCode.OK, "DetallePedido actualizado correctamente");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/

        public IHttpActionResult Get()
        {
            try
            {
                List<DetallePedido> todos = DetallePedidoBLL.List();
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        public IHttpActionResult GetOne(int id)
        {
            try
            {
                DetallePedido result = DetallePedidoBLL.Get(id);
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


        public IHttpActionResult GetByPedido(int id)
        {
            try
            {
                List<DetallePedido> result = DetallePedidoBLL.List(id);
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


        /*public IHttpActionResult Delete(int id)
        {
            try
            {
                DetallePedidoBLL.Delete(id);
                return Ok("DetallePedido eliminado correctamente");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }*/
    }
}