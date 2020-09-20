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
    public class EmpresasController : ApiController
    {
        // GET: Empresas
        public IHttpActionResult Post(Empresa empresa)
        {
            try
            {
                EmpresaBLL.Create(empresa);
                return Content(HttpStatusCode.Created, "Empresa creado correctamente");
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
                List<Empresa> todos = EmpresaBLL.List();
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        public IHttpActionResult Put(Empresa empresa)
        {
            try
            {
                EmpresaBLL.Update(empresa);
                return Content(HttpStatusCode.OK, "Empresa actualizado correctamente");

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
                Empresa result = EmpresaBLL.Get(id);
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
                List<Empresa> result = EmpresaBLL.ListByUser(id);
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
                EmpresaBLL.Delete(id);
                return Ok("Empresa eliminado correctamente");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}