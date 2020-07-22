﻿using System;
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
    public class PedidosController : Controller
    {
        // GET: Pedidos
        public ActionResult Index()
        {
            return View(PedidoBLL.List());
        }

        // GET: Pedidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = PedidoBLL.Get(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: Pedidos/Create
        public ActionResult Create()
        {
            ViewBag.idcliente = new SelectList(ClienteBLL.ListToNames(), "idcliente", "nombre");
            return View();
        }

        // POST: Pedidos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idpedido,fechaPeticion,estado,fechaEjecucion,costo,idcliente")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                PedidoBLL.Create(pedido);
                return RedirectToAction("Index");
            }

            ViewBag.idcliente = new SelectList(ClienteBLL.ListToNames(), "idcliente", "nombre", pedido.idcliente);
            return View(pedido);
        }

        // GET: Pedidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = PedidoBLL.Get(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcliente = new SelectList(ClienteBLL.ListToNames(), "idcliente", "nombre", pedido.idcliente);
            return View(pedido);
        }

        // POST: Pedidos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idpedido,fechaPeticion,estado,fechaEjecucion,costo,idcliente")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                PedidoBLL.Update(pedido);
                return RedirectToAction("Index");
            }
            ViewBag.idcliente = new SelectList(ClienteBLL.ListToNames(), "idcliente", "nombre", pedido.idcliente);
            return View(pedido);
        }

        // GET: Pedidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = PedidoBLL.Get(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PedidoBLL.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
