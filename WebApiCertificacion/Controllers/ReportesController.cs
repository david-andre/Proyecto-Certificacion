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
    public class ReportesController : ApiController
    {
        [System.Web.Http.Route("api/Reportes/GetByServicio")]
        public IHttpActionResult GetByServicio(int idUsuario,int month, int year)
        {
            try
            {
                List<GetDetallesByMonth_Result> todos = ReportesBLL.GetPedidosByMonth(idUsuario, month, year);
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
        [System.Web.Http.Route("api/Reportes/GetByEmpresa")]
        public IHttpActionResult GetByEmpresa(int idUsuario, int month, int year)
        {
            try
            {
                List<GetDetallesEmpresasByMonth_Result> todos = ReportesBLL.GetPedidosByEmpresa(idUsuario, month, year);
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        [System.Web.Http.Route("api/Reportes/GetMonto")]
        public IHttpActionResult GetMonto(int idUsuario)
        {
            try
            {
                List<GetMontoByServicio_Result> todos = ReportesBLL.GetMontosByServicio(idUsuario);
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        [System.Web.Http.Route("api/Reportes/GetReportePrueba")]
        public IHttpActionResult GetReportePrueba(int idUsuario, int month, int year)
        {
            try
            {
                List<reportePrueba_Result> todos = ReportesBLL.GetReportePrueba(idUsuario, month, year);
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}