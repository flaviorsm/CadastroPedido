using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using sce.entity;
using sce.model;

namespace sce.web.Controllers
{
    public class ItemPedidoesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: ItemPedidoes
        public ActionResult Index()
        {
            var itemPedido = db.ItemPedido.Include(i => i.Pedido).Include(i => i.Produto);
            return View(itemPedido.ToList());
        }

        // GET: ItemPedidoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemPedido itemPedido = db.ItemPedido.Find(id);
            if (itemPedido == null)
            {
                return HttpNotFound();
            }
            return View(itemPedido);
        }

        // GET: ItemPedidoes/Create
        public ActionResult Create()
        {
            ViewBag.PedidoID = new SelectList(db.Pedido, "PedidoID", "CPF");
            ViewBag.ItemPedidoID = new SelectList(db.Produto, "ProdutoID", "Codigo");
            return View();
        }

        // POST: ItemPedidoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemPedidoID,Quantidade,PrecoUnitario,ProdutoID,PedidoID")] ItemPedido itemPedido)
        {
            if (ModelState.IsValid)
            {
                db.ItemPedido.Add(itemPedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PedidoID = new SelectList(db.Pedido, "PedidoID", "CPF", itemPedido.PedidoID);
            ViewBag.ItemPedidoID = new SelectList(db.Produto, "ProdutoID", "Codigo", itemPedido.ItemPedidoID);
            return View(itemPedido);
        }

        // GET: ItemPedidoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemPedido itemPedido = db.ItemPedido.Find(id);
            if (itemPedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.PedidoID = new SelectList(db.Pedido, "PedidoID", "CPF", itemPedido.PedidoID);
            ViewBag.ItemPedidoID = new SelectList(db.Produto, "ProdutoID", "Codigo", itemPedido.ItemPedidoID);
            return View(itemPedido);
        }

        // POST: ItemPedidoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemPedidoID,Quantidade,PrecoUnitario,ProdutoID,PedidoID")] ItemPedido itemPedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemPedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PedidoID = new SelectList(db.Pedido, "PedidoID", "CPF", itemPedido.PedidoID);
            ViewBag.ItemPedidoID = new SelectList(db.Produto, "ProdutoID", "Codigo", itemPedido.ItemPedidoID);
            return View(itemPedido);
        }

        // GET: ItemPedidoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemPedido itemPedido = db.ItemPedido.Find(id);
            if (itemPedido == null)
            {
                return HttpNotFound();
            }
            return View(itemPedido);
        }

        // POST: ItemPedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemPedido itemPedido = db.ItemPedido.Find(id);
            db.ItemPedido.Remove(itemPedido);
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
