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
using WebApiCertificacion.Models;

namespace WebApiCertificacion.Controllers
{
    [System.Web.Http.AllowAnonymous]
    [System.Web.Http.RoutePrefix("api/login")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class UsuariosController : ApiController
    {
            [System.Web.Http.HttpPost]
            [System.Web.Http.Route("authenticate")]
            public IHttpActionResult Authenticate(Usuario usuario)
            {
                if (usuario == null)
                    throw new HttpResponseException(HttpStatusCode.BadRequest);

                usuario = UsuarioBLL.Validate(usuario);
                if (usuario != null)
                {
                    return Ok(new
                    {
                        user = usuario,
                        token = TokenGenerator.GenerateTokenJwt(usuario)
                    });
                }
                else
                {
                    return Unauthorized();
                }
        }

        public IHttpActionResult Post(Usuario usuario)
        {
            try
            {
                UsuarioBLL.Create(usuario);
                return Content(HttpStatusCode.Created, "Usuario creado correctamente");
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
                List<Usuario> todos = UsuarioBLL.List();
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        public IHttpActionResult Put(Usuario usuario)
        {
            try
            {
                UsuarioBLL.Update(usuario);
                return Content(HttpStatusCode.OK, "Usuario actualizado correctamente");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        public IHttpActionResult Get(int id)
        {
            try
            {
                Usuario result = UsuarioBLL.Get(id);
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
    }
}