using Prova_UCDB.DAO;
using Prova_UCDB.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Windows;

namespace Prova_UCDB.Controllers
{
    public class PedidoController : Controller
    {
        private Contexto db = new Contexto();
        private const int DENOMINADOR_CALCULO = 100;
         
        public ActionResult Index()
        {
            return View(db.Pedido.ToList());
        }
         
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
                return HttpNotFound();
            
            return View(pedido);
        }
         
        public ActionResult Create()
        {
            return View();
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, NomePedido, Valor, DataVencimento")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Pedido.Add(pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pedido);
        }
         
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
                return HttpNotFound();
            
            return View(pedido);
        }
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, NomePedido, Valor, DataVencimento")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pedido);
        }

        public ActionResult Desconto(int? id)
        {
            if (id == null) 
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); 

            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null) 
                return HttpNotFound();

            return View(pedido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Desconto([Bind(Include = "Id, NomePedido, Valor, DataVencimento, DescontoPercentual")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                double valorDesconto = (double)pedido.DescontoPercentual;
                double descontoCalculado = ((valorDesconto / DENOMINADOR_CALCULO) * pedido.Valor);
                if (descontoCalculado >= pedido.Valor)
                {
                    MessageBox.Show("Valor Desconto superior ou igual a 100%");
                    return View(pedido);
                }

                bool produtoEstaVencido = DateTime.Now > pedido.DataVencimento ? true : false;
                if (produtoEstaVencido)
                {
                    MessageBox.Show("Produto Vencido, não é possível aplicar desconto");
                    return View(pedido);
                }

                pedido.Valor = pedido.Valor - descontoCalculado; 
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pedido);
        }
         
        public ActionResult Delete(int? id)
        {
            if (id == null) 
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
           
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
                return HttpNotFound();

            return View(pedido);
        }
         
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido pedido = db.Pedido.Find(id);
            db.Pedido.Remove(pedido);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }
    }
}
