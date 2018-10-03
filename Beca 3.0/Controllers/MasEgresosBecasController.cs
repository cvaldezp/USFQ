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
    public class MasEgresosBecasController : Controller
    {
        private SolicitudInicialContext db = new SolicitudInicialContext();

        // GET: MasEgresosBecas
        public ActionResult Index()
        {
            var masEgresosBeca3 = db.MasEgresosBeca3.Include(m => m.EgresosFamiliaresBeca3);
            return View(masEgresosBeca3.ToList());
        }

        // GET: MasEgresosBecas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasEgresosBeca3 masEgresosBeca3 = db.MasEgresosBeca3.Find(id);
            if (masEgresosBeca3 == null)
            {
                return HttpNotFound();
            }
            return View(masEgresosBeca3);
        }

        // GET: MasEgresosBecas/Create
        public ActionResult Create(float AlimentacionParam,float EducacionParam, float SaludParam, float VestimentaParam, float ArriendoParam, float GastosBasicosParam, float SeguroPrivadoParam, float CuotaPrestamosParam, float RestaurantesParam, float EntretenimientoParam, float ViajesParam, float CompraEquiposParam, float OtrosEgresosParam, float DescuentoRolParam, float TotalegresosParam)
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

            entities.PRC_ACTUALIZA_EGRESOS3(IDEgresos, AlimentacionParam,  EducacionParam,  SaludParam,  VestimentaParam,  ArriendoParam,  GastosBasicosParam,  SeguroPrivadoParam,  CuotaPrestamosParam,  RestaurantesParam,  EntretenimientoParam,  ViajesParam,  CompraEquiposParam,  OtrosEgresosParam,  DescuentoRolParam,  TotalegresosParam);

            //EgresosFamiliaresBeca3 IDEstudiante = new EgresosFamiliaresBeca3();

            //IDEstudiante.SolicitudID = IDSolicitud;
            //IDEstudiante.Alimentacion = AlimentacionParam;
            //IDEstudiante.Educacion = EducacionParam;
            //IDEstudiante.Salud = SaludParam;
            //IDEstudiante.Vestimenta = VestimentaParam;
            //IDEstudiante.Arriendo = ArriendoParam;
            //IDEstudiante.GastosBasicos = GastosBasicosParam;
            //IDEstudiante.SeguroPrivado = SeguroPrivadoParam;
            //IDEstudiante.CuotaPrestamos = CuotaPrestamosParam;
            //IDEstudiante.Restaurantes = RestaurantesParam;
            //IDEstudiante.Entretenimiento = EntretenimientoParam;
            //IDEstudiante.Viajes = ViajesParam;
            //IDEstudiante.CompraEquipos = CompraEquiposParam;
            //IDEstudiante.OtrosEgresos = OtrosEgresosParam;
            //IDEstudiante.DescuentoRol = DescuentoRolParam;
            //IDEstudiante.Totalegresos = TotalegresosParam;


            //db.EgresosFamiliaresBeca3.Add(IDEstudiante);
            //db.Entry(IDEstudiante).State = EntityState.Modified;
            //db.SaveChanges();

            ViewBag.EgresosFamiliaresID = new SelectList(db.EgresosFamiliaresBeca3, "EgresosFamiliaresID", "EgresosFamiliaresID");
            return View();
        }

        // POST: MasEgresosBecas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OtroEgresoID,EgresosFamiliaresID,Descripcion,ValorOtrosEgresos")] MasEgresosBeca3 masEgresosBeca3)
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

            if (ModelState.IsValid)
            {
                masEgresosBeca3.EgresosFamiliaresID = IDEgresos;
                db.MasEgresosBeca3.Add(masEgresosBeca3);
                db.SaveChanges();
                return RedirectToAction("Index", "EgresosFamiliaresBecas");
            }

            ViewBag.EgresosFamiliaresID = new SelectList(db.EgresosFamiliaresBeca3, "EgresosFamiliaresID", "EgresosFamiliaresID", masEgresosBeca3.EgresosFamiliaresID);
            return View(masEgresosBeca3);
        }

        // GET: MasEgresosBecas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasEgresosBeca3 masEgresosBeca3 = db.MasEgresosBeca3.Find(id);
            if (masEgresosBeca3 == null)
            {
                return HttpNotFound();
            }
            ViewBag.EgresosFamiliaresID = new SelectList(db.EgresosFamiliaresBeca3, "EgresosFamiliaresID", "EgresosFamiliaresID", masEgresosBeca3.EgresosFamiliaresID);
            return View(masEgresosBeca3);
        }

        // POST: MasEgresosBecas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OtroEgresoID,EgresosFamiliaresID,Descripcion,ValorOtrosEgresos")] MasEgresosBeca3 masEgresosBeca3)
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

            if (ModelState.IsValid)
            {
                masEgresosBeca3.EgresosFamiliaresID = IDEgresos;
                db.Entry(masEgresosBeca3).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "EgresosFamiliaresBecas");
            }
            ViewBag.EgresosFamiliaresID = new SelectList(db.EgresosFamiliaresBeca3, "EgresosFamiliaresID", "EgresosFamiliaresID", masEgresosBeca3.EgresosFamiliaresID);
            return View(masEgresosBeca3);
        }

        // GET: MasEgresosBecas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasEgresosBeca3 masEgresosBeca3 = db.MasEgresosBeca3.Find(id);
            if (masEgresosBeca3 == null)
            {
                return HttpNotFound();
            }
            return View(masEgresosBeca3);
        }

        // POST: MasEgresosBecas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MasEgresosBeca3 masEgresosBeca3 = db.MasEgresosBeca3.Find(id);
            db.MasEgresosBeca3.Remove(masEgresosBeca3);
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
