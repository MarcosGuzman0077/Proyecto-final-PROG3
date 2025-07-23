using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class TerapeutasController : Controller
    {
        private SpaDbContext db = new SpaDbContext();

        // GET: Terapeutas
        public ActionResult Index()
        {
            return View(db.Terapeutas.ToList());
        }

        // GET: Terapeutas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terapeuta terapeuta = db.Terapeutas.Find(id);
            if (terapeuta == null)
            {
                return HttpNotFound();
            }
            return View(terapeuta);
        }

        // GET: Terapeutas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Terapeutas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TerapeutaID,Nombre")] Terapeuta terapeuta)
        {
            if (ModelState.IsValid)
            {
                db.Terapeutas.Add(terapeuta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(terapeuta);
        }

        // GET: Terapeutas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terapeuta terapeuta = db.Terapeutas.Find(id);
            if (terapeuta == null)
            {
                return HttpNotFound();
            }
            return View(terapeuta);
        }

        // POST: Terapeutas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TerapeutaID,Nombre")] Terapeuta terapeuta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(terapeuta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(terapeuta);
        }

        // GET: Terapeutas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terapeuta terapeuta = db.Terapeutas.Find(id);
            if (terapeuta == null)
            {
                return HttpNotFound();
            }
            return View(terapeuta);
        }

        // POST: Terapeutas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Terapeuta terapeuta = db.Terapeutas.Find(id);
            db.Terapeutas.Remove(terapeuta);
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
