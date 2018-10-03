using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Beca_3._0.Models;

namespace Beca_3._0.Controllers
{
    public class EgresosFamiliaresBecasController : Controller
    {
        private SolicitudInicialContext db = new SolicitudInicialContext();

        // GET: EgresosFamiliaresBecas
        public ActionResult Index()
        {
            var nameUser = User.Identity.Name;

            //entities.PRC_SOLI_INICIAL_BECA3(nameUser);

            var inpBuscar = nameUser;

            var SoliID = (from h in db.AnalisisInicialBecas
                          where h.EmailEstudiante == inpBuscar //&& h.Estado == "Enviado"
                          select h.SolicitudID).FirstOrDefault();



            var IDEgresos = (from h in db.EgresosFamiliaresBeca3
                              where h.SolicitudID == SoliID //&& h.Estado == "Enviado"
                              select h.EgresosFamiliaresID).FirstOrDefault();

            if (IDEgresos == 0)
            {
                return RedirectToAction("Create", "EgresosFamiliaresBecas");
            }
            else
            {
                return RedirectToAction("Edit", "EgresosFamiliaresBecas", new { id = IDEgresos });
            }

            
        }

        // GET: EgresosFamiliaresBecas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EgresosFamiliaresBeca3 egresosFamiliaresBeca3 = db.EgresosFamiliaresBeca3.Find(id);
            if (egresosFamiliaresBeca3 == null)
            {
                return HttpNotFound();
            }
            return View(egresosFamiliaresBeca3);
        }

        // GET: EgresosFamiliaresBecas/Create
        public ActionResult Create()
        {
            ViewBag.SolicitudID = new SelectList(db.AnalisisInicialBecas, "SolicitudID", "Cedula");
            return View();
        }

        // POST: EgresosFamiliaresBecas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EgresosFamiliaresID,SolicitudID,Alimentacion,Educacion,Salud,Vestimenta,Arriendo,GastosBasicos,SeguroPrivado,CuotaPrestamos,Restaurantes,Entretenimiento,Viajes,CompraEquipos,OtrosEgresos,DescuentoRol,Totalegresos,TotalOtrosEgresos,TotalDescuentosRol")] EgresosFamiliaresBeca3 egresosFamiliaresBeca3)
        {
            var nameUser = User.Identity.Name;
            var inpBuscar = nameUser;

            var IDEstudiante = (from h in db.AnalisisInicialBecas
                                where h.EmailEstudiante == inpBuscar && h.Estado == "Ingresada"
                                select h.SolicitudID).FirstOrDefault();

            int EstuID = int.Parse(IDEstudiante.ToString());

            if (ModelState.IsValid)
            {
                egresosFamiliaresBeca3.SolicitudID = EstuID;
                db.EgresosFamiliaresBeca3.Add(egresosFamiliaresBeca3);
                db.SaveChanges();
                return RedirectToAction("Index", "ImpuestoRentaBecas");
            }

            ViewBag.SolicitudID = new SelectList(db.AnalisisInicialBecas, "SolicitudID", "Cedula", egresosFamiliaresBeca3.SolicitudID);
            return View(egresosFamiliaresBeca3);
        }

        // GET: EgresosFamiliaresBecas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EgresosFamiliaresBeca3 egresosFamiliaresBeca3 = db.EgresosFamiliaresBeca3.Find(id);
            if (egresosFamiliaresBeca3 == null)
            {
                return HttpNotFound();
            }
            ViewBag.SolicitudID = new SelectList(db.AnalisisInicialBecas, "SolicitudID", "Cedula", egresosFamiliaresBeca3.SolicitudID);
            return View(egresosFamiliaresBeca3);
        }

        // POST: EgresosFamiliaresBecas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EgresosFamiliaresID,SolicitudID,Alimentacion,Educacion,Salud,Vestimenta,Arriendo,GastosBasicos,SeguroPrivado,CuotaPrestamos,Restaurantes,Entretenimiento,Viajes,CompraEquipos,OtrosEgresos,DescuentoRol,Totalegresos,TotalOtrosEgresos,TotalDescuentosRol")] EgresosFamiliaresBeca3 egresosFamiliaresBeca3)
        {
            var nameUser = User.Identity.Name;
            var inpBuscar = nameUser;

            var IDEstudiante = (from h in db.AnalisisInicialBecas
                                where h.EmailEstudiante == inpBuscar && h.Estado == "Ingresada"
                                select h.SolicitudID).FirstOrDefault();

            int EstuID = int.Parse(IDEstudiante.ToString());


            if (ModelState.IsValid)
            {
                egresosFamiliaresBeca3.SolicitudID = EstuID;
                db.Entry(egresosFamiliaresBeca3).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "ImpuestoRentaBecas");
            }
            ViewBag.SolicitudID = new SelectList(db.AnalisisInicialBecas, "SolicitudID", "Cedula", egresosFamiliaresBeca3.SolicitudID);
            return View(egresosFamiliaresBeca3);
        }

        // GET: EgresosFamiliaresBecas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EgresosFamiliaresBeca3 egresosFamiliaresBeca3 = db.EgresosFamiliaresBeca3.Find(id);
            if (egresosFamiliaresBeca3 == null)
            {
                return HttpNotFound();
            }
            return View(egresosFamiliaresBeca3);
        }

        // POST: EgresosFamiliaresBecas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EgresosFamiliaresBeca3 egresosFamiliaresBeca3 = db.EgresosFamiliaresBeca3.Find(id);
            db.EgresosFamiliaresBeca3.Remove(egresosFamiliaresBeca3);
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
