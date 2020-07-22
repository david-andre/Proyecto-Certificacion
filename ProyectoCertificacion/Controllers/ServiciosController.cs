using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BEUCertificacion;
using BEUCertificacion.Transactions;

namespace ProyectoCertificacion.Controllers
{
    public class ServiciosController : Controller
    {

        // GET: Servicios
        public ActionResult Index()
        {
            return View(ServicioBLL.List());
        }

        // GET: Servicios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio servicio = ServicioBLL.Get(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            return View(servicio);
        }

        // GET: Servicios/Create
        public ActionResult Create()
        {
            ViewBag.idempresa = new SelectList(EmpresaBLL.List(), "idempresa", "nombre");
            return View();
        }

        // POST: Servicios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idservicio,nombre,costo,descripcion,idempresa")] Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                ServicioBLL.Create(servicio);
                return RedirectToAction("Index");
            }

            ViewBag.idempresa = new SelectList(EmpresaBLL.List(), "idempresa", "nombre", servicio.idempresa);
            return View(servicio);
        }

        // GET: Servicios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio servicio = ServicioBLL.Get(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            ViewBag.idempresa = new SelectList(EmpresaBLL.List(), "idempresa", "nombre", servicio.idempresa);
            return View(servicio);
        }

        // POST: Servicios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idservicio,nombre,costo,descripcion,idempresa")] Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                ServicioBLL.Update(servicio);
                return RedirectToAction("Index");
            }
            ViewBag.idempresa = new SelectList(EmpresaBLL.List(), "idempresa", "nombre", servicio.idempresa);
            return View(servicio);
        }

        // GET: Servicios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio servicio = ServicioBLL.Get(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            return View(servicio);
        }

        // POST: Servicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServicioBLL.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
