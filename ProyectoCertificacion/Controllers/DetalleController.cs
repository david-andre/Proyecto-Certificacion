using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BEUCertificacion;

namespace ProyectoCertificacion.Controllers
{
    public class DetalleController : Controller
    {
        private Entities db = new Entities();

        // GET: Detalle
        public ActionResult Index()
        {
            var detallePedidoes = db.DetallePedidoes.Include(d => d.Pedido).Include(d => d.Servicio);
            return View(detallePedidoes.ToList());
        }

        // GET: Detalle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePedido detallePedido = db.DetallePedidoes.Find(id);
            if (detallePedido == null)
            {
                return HttpNotFound();
            }
            return View(detallePedido);
        }

        // GET: Detalle/Create
        public ActionResult Create()
        {
            ViewBag.idpedido = new SelectList(db.Pedidoes, "idpedido", "estado");
            ViewBag.idservicio = new SelectList(db.Servicios, "idservicio", "nombre");
            return View();
        }

        // POST: Detalle/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iddetalle,idpedido,idservicio")] DetallePedido detallePedido)
        {
            if (ModelState.IsValid)
            {
                db.DetallePedidoes.Add(detallePedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idpedido = new SelectList(db.Pedidoes, "idpedido", "estado", detallePedido.idpedido);
            ViewBag.idservicio = new SelectList(db.Servicios, "idservicio", "nombre", detallePedido.idservicio);
            return View(detallePedido);
        }

        // GET: Detalle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePedido detallePedido = db.DetallePedidoes.Find(id);
            if (detallePedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.idpedido = new SelectList(db.Pedidoes, "idpedido", "estado", detallePedido.idpedido);
            ViewBag.idservicio = new SelectList(db.Servicios, "idservicio", "nombre", detallePedido.idservicio);
            return View(detallePedido);
        }

        // POST: Detalle/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iddetalle,idpedido,idservicio")] DetallePedido detallePedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detallePedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idpedido = new SelectList(db.Pedidoes, "idpedido", "estado", detallePedido.idpedido);
            ViewBag.idservicio = new SelectList(db.Servicios, "idservicio", "nombre", detallePedido.idservicio);
            return View(detallePedido);
        }

        // GET: Detalle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePedido detallePedido = db.DetallePedidoes.Find(id);
            if (detallePedido == null)
            {
                return HttpNotFound();
            }
            return View(detallePedido);
        }

        // POST: Detalle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetallePedido detallePedido = db.DetallePedidoes.Find(id);
            db.DetallePedidoes.Remove(detallePedido);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
