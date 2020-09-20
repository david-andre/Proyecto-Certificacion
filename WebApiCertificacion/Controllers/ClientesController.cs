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
    public class ClientesController : ApiController
    {
        public IHttpActionResult Post(Cliente cliente)
        {
            try
            {
                ClienteBLL.Create(cliente);
                return Content(HttpStatusCode.Created, "Cliente creado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Get()
        {
            try
            {
                List<Cliente> todos = ClienteBLL.List();
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        public IHttpActionResult Put(Cliente cliente)
        {
            try
            {
                ClienteBLL.Update(cliente);
                return Content(HttpStatusCode.OK, "Cliente actualizado correctamente");

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
                Cliente result = ClienteBLL.Get(id);
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

        public IHttpActionResult GetByUser(int id)
        {
            try
            {
                Cliente result = ClienteBLL.ListByUser(id);
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
                ClienteBLL.Delete(id);
                return Ok("Cliente eliminado correctamente");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}