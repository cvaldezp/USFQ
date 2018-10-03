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
    public class IngresosFamiliaresBecasController : Controller
    {
        private SolicitudInicialContext db = new SolicitudInicialContext();

        // GET: IngresosFamiliaresBecas
        public ActionResult Index()
        {
            Asis_FinanEntities1 entities = new Asis_FinanEntities1();



            var nameUser = User.Identity.Name;

            entities.PRC_SOLI_INICIAL_BECA3(nameUser);

            var inpBuscar = nameUser;

            var SoliID = (from h in db.AnalisisInicialBecas
                                    where h.EmailEstudiante == inpBuscar //&& h.Estado == "Enviado"
                                    select h.SolicitudID).FirstOrDefault();
            


            var IDIngresos = (from h in db.IngresosFamiliaresBecas3
                               where h.SolicitudID == SoliID //&& h.Estado == "Enviado"
                               select h.IngresosFamiliaresID).FirstOrDefault();

            if (IDIngresos == 0)
            {
                return RedirectToAction("Create", "IngresosFamiliaresBecas");
            }
            else
            {
                return RedirectToAction("Edit", "IngresosFamiliaresBecas", new { id = IDIngresos });
            }

            
        }

        // GET: IngresosFamiliaresBecas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IngresosFamiliaresBecas3 ingresosFamiliaresBecas3 = db.IngresosFamiliaresBecas3.Find(id);
            if (ingresosFamiliaresBecas3 == null)
            {
                return HttpNotFound();
            }
            return View(ingresosFamiliaresBecas3);
        }

        // GET: IngresosFamiliaresBecas/Create
        public ActionResult Create()
        {
            ViewBag.SolicitudID = new SelectList(db.AnalisisInicialBecas, "SolicitudID", "Cedula");
            return View();
        }

        // POST: IngresosFamiliaresBecas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IngresosFamiliaresID,SolicitudID,sueldoBrutoPadre,IngresosAdicionalesPadre,InversionesPadre,ArriendoPropiedadesPadre,SioNoRecibeAdicionalPadre,SioNoTrabajaRelDependenciaPadre,sueldoBrutoMadre,IngresosAdicionalesMadre,InversionesMadre,ArriendoPropiedadesMadre,SioNoRecibeAdicionalMadre,SioNoTrabajaRelDependenciaMadre,TotalIngresosPadre,TotalIngresosMadre")] IngresosFamiliaresBecas3 ingresosFamiliaresBecas3)
        {
            var nameUser = User.Identity.Name;
            var inpBuscar = nameUser;

            var IDEstudiante = (from h in db.AnalisisInicialBecas
                                where h.EmailEstudiante == inpBuscar && h.Estado == "Ingresada"
                                select h.SolicitudID).FirstOrDefault();

            int EstuID = int.Parse(IDEstudiante.ToString());

            if (ModelState.IsValid)
            {
                ingresosFamiliaresBecas3.SolicitudID = EstuID;
                db.IngresosFamiliaresBecas3.Add(ingresosFamiliaresBecas3);
                db.SaveChanges();
                return RedirectToAction("Index", "EgresosFamiliaresBecas");
            }

            ViewBag.SolicitudID = new SelectList(db.AnalisisInicialBecas, "SolicitudID", "Cedula", ingresosFamiliaresBecas3.SolicitudID);
            return View(ingresosFamiliaresBecas3);
        }

        // GET: IngresosFamiliaresBecas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IngresosFamiliaresBecas3 ingresosFamiliaresBecas3 = db.IngresosFamiliaresBecas3.Find(id);
            if (ingresosFamiliaresBecas3 == null)
            {
                return HttpNotFound();
            }
            ViewBag.SolicitudID = new SelectList(db.AnalisisInicialBecas, "SolicitudID", "Cedula", ingresosFamiliaresBecas3.SolicitudID);
            return View(ingresosFamiliaresBecas3);
        }

        // POST: IngresosFamiliaresBecas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IngresosFamiliaresID,SolicitudID,sueldoBrutoPadre,IngresosAdicionalesPadre,InversionesPadre,ArriendoPropiedadesPadre,SioNoRecibeAdicionalPadre,SioNoTrabajaRelDependenciaPadre,sueldoBrutoMadre,IngresosAdicionalesMadre,InversionesMadre,ArriendoPropiedadesMadre,SioNoRecibeAdicionalMadre,SioNoTrabajaRelDependenciaMadre,TotalIngresosPadre,TotalIngresosMadre")] IngresosFamiliaresBecas3 ingresosFamiliaresBecas3)
        {
            var nameUser = User.Identity.Name;
            var inpBuscar = nameUser;

            var IDEstudiante = (from h in db.AnalisisInicialBecas
                                where h.EmailEstudiante == inpBuscar && h.Estado == "Ingresada"
                                select h.SolicitudID).FirstOrDefault();

            int EstuID = int.Parse(IDEstudiante.ToString());

            if (ModelState.IsValid)
            {
                ingresosFamiliaresBecas3.SolicitudID = EstuID;
                db.Entry(ingresosFamiliaresBecas3).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "EgresosFamiliaresBecas");
            }
            ViewBag.SolicitudID = new SelectList(db.AnalisisInicialBecas, "SolicitudID", "Cedula", ingresosFamiliaresBecas3.SolicitudID);
            return View(ingresosFamiliaresBecas3);
        }

        // GET: IngresosFamiliaresBecas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IngresosFamiliaresBecas3 ingresosFamiliaresBecas3 = db.IngresosFamiliaresBecas3.Find(id);
            if (ingresosFamiliaresBecas3 == null)
            {
                return HttpNotFound();
            }
            return View(ingresosFamiliaresBecas3);
        }

        // POST: IngresosFamiliaresBecas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IngresosFamiliaresBecas3 ingresosFamiliaresBecas3 = db.IngresosFamiliaresBecas3.Find(id);
            db.IngresosFamiliaresBecas3.Remove(ingresosFamiliaresBecas3);
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
