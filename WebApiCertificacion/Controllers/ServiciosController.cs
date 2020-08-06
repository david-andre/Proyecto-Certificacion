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
    public class ServiciosController : ApiController
    {
        public IHttpActionResult Post(Servicio servicio)
        {
            try
            {
                ServicioBLL.Create(servicio);
                return Content(HttpStatusCode.Created, "Servicio creado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        public IHttpActionResult Put(Servicio servicio)
        {
            try
            {
                ServicioBLL.Update(servicio);
                return Content(HttpStatusCode.OK, "Servicio actualizado correctamente");

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
                List<Servicio> todos = ServicioBLL.List();
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
                    Servicio result = ServicioBLL.Get(id);
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

        public IHttpActionResult GetByBussiness(int id)
        {
            try
            {
                List<Servicio> result = ServicioBLL.List(id);
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
                ServicioBLL.Delete(id);
                return Ok("Servicio eliminado correctamente");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}