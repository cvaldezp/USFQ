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
    public class RolDescuentoBecasController : Controller
    {
        private SolicitudInicialContext db = new SolicitudInicialContext();

        // GET: RolDescuentoBecas
        public ActionResult Index()
        {
            var rolDescuentoBecas3 = db.RolDescuentoBecas3.Include(r => r.EgresosFamiliaresBeca3);
            return View(rolDescuentoBecas3.ToList());
        }

        // GET: RolDescuentoBecas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolDescuentoBecas3 rolDescuentoBecas3 = db.RolDescuentoBecas3.Find(id);
            if (rolDescuentoBecas3 == null)
            {
                return HttpNotFound();
            }
            return View(rolDescuentoBecas3);
        }

        // GET: RolDescuentoBecas/Create
        public ActionResult Create(float AlimentacionParam, float EducacionParam, float SaludParam, float VestimentaParam, float ArriendoParam, float GastosBasicosParam, float SeguroPrivadoParam, float CuotaPrestamosParam, float RestaurantesParam, float EntretenimientoParam, float ViajesParam, float CompraEquiposParam, float OtrosEgresosParam, float DescuentoRolParam, float TotalegresosParam)
        {
            var nameUser = User.Identity.Name;
            var inpBuscar = nameUser;

            var IDSolicitud = (from h in db.AnalisisInicialBecas
                               where h.EmailEstudiante == inpBuscar //&& h.Estado == "Ingresada"
                               select h.SolicitudID).FirstOrDefault();

            var IDEgresos = (from h in db.EgresosFamiliaresBeca3
                             where h.SolicitudID == IDSolicitud //&& h.Estado == "Ingresada"
                             select h.EgresosFamiliaresID).FirstOrDefault();


            Asis_FinanEntities1 entities = new Asis_FinanEntities1();

            entities.PRC_ACTUALIZA_EGRESOS3(IDEgresos, AlimentacionParam, EducacionParam, SaludParam, VestimentaParam, ArriendoParam, GastosBasicosParam, SeguroPrivadoParam, CuotaPrestamosParam, RestaurantesParam, EntretenimientoParam, ViajesParam, CompraEquiposParam, OtrosEgresosParam, DescuentoRolParam, TotalegresosParam);

            ViewBag.EgresosFamiliaresID = new SelectList(db.EgresosFamiliaresBeca3, "EgresosFamiliaresID", "EgresosFamiliaresID");
            return View();
        }

        // POST: RolDescuentoBecas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DescuentoRolID,EgresosFamiliaresID,Descripcion,ValorOtrosEgresos")] RolDescuentoBecas3 rolDescuentoBecas3)
        {
            var nameUser = User.Identity.Name;

            Asis_FinanEntities1 entities = new Asis_FinanEntities1();

            entities.PRC_SOLI_INICIAL_BECA3(nameUser);

            var inpBuscar = nameUser;

            var SoliID = (from h in db.AnalisisInicialBecas
                          where h.EmailEstudiante == inpBuscar //&& h.Estado == "Enviado"
                          select h.SolicitudID).FirstOrDefault();



            var IDEgresos = (from h in db.EgresosFamiliaresBeca3
                             where h.SolicitudID == SoliID //&& h.Estado == "Enviado"
                             select h.EgresosFamiliaresID).FirstOrDefault();

            if (ModelState.IsValid)
            {
                rolDescuentoBecas3.EgresosFamiliaresID = IDEgresos;
                db.RolDescuentoBecas3.Add(rolDescuentoBecas3);
                db.SaveChanges();
                return RedirectToAction("Index", "EgresosFamiliaresBecas");
            }

            ViewBag.EgresosFamiliaresID = new SelectList(db.EgresosFamiliaresBeca3, "EgresosFamiliaresID", "EgresosFamiliaresID", rolDescuentoBecas3.EgresosFamiliaresID);
            return View(rolDescuentoBecas3);
        }

        // GET: RolDescuentoBecas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolDescuentoBecas3 rolDescuentoBecas3 = db.RolDescuentoBecas3.Find(id);
            if (rolDescuentoBecas3 == null)
            {
                return HttpNotFound();
            }
            ViewBag.EgresosFamiliaresID = new SelectList(db.EgresosFamiliaresBeca3, "EgresosFamiliaresID", "EgresosFamiliaresID", rolDescuentoBecas3.EgresosFamiliaresID);
            return View(rolDescuentoBecas3);
        }

        // POST: RolDescuentoBecas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DescuentoRolID,EgresosFamiliaresID,Descripcion,ValorOtrosEgresos")] RolDescuentoBecas3 rolDescuentoBecas3)
        {
            var nameUser = User.Identity.Name;

            Asis_FinanEntities1 entities = new Asis_FinanEntities1();
            entities.PRC_SOLI_INICIAL_BECA3(nameUser);

            var inpBuscar = nameUser;

            var SoliID = (from h in db.AnalisisInicialBecas
                          where h.EmailEstudiante == inpBuscar //&& h.Estado == "Enviado"
                          select h.SolicitudID).FirstOrDefault();



            var IDEgresos = (from h in db.EgresosFamiliaresBeca3
                             where h.SolicitudID == SoliID //&& h.Estado == "Enviado"
                             select h.EgresosFamiliaresID).FirstOrDefault();

            if (ModelState.IsValid)
            {
                rolDescuentoBecas3.EgresosFamiliaresID = IDEgresos;
                db.Entry(rolDescuentoBecas3).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "EgresosFamiliaresBecas");
            }
            ViewBag.EgresosFamiliaresID = new SelectList(db.EgresosFamiliaresBeca3, "EgresosFamiliaresID", "EgresosFamiliaresID", rolDescuentoBecas3.EgresosFamiliaresID);
            return View(rolDescuentoBecas3);
        }

        // GET: RolDescuentoBecas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolDescuentoBecas3 rolDescuentoBecas3 = db.RolDescuentoBecas3.Find(id);
            if (rolDescuentoBecas3 == null)
            {
                return HttpNotFound();
            }
            return View(rolDescuentoBecas3);
        }

        // POST: RolDescuentoBecas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RolDescuentoBecas3 rolDescuentoBecas3 = db.RolDescuentoBecas3.Find(id);
            db.RolDescuentoBecas3.Remove(rolDescuentoBecas3);
            db.SaveChanges();
            return RedirectToAction("Index", "EgresosFamiliaresBecas");
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
