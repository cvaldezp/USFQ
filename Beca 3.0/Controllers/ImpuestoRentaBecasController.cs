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
    public class ImpuestoRentaBecasController : Controller
    {
        private SolicitudInicialContext db = new SolicitudInicialContext();
        private SolicitudInicialContext db2 = new SolicitudInicialContext();

        // GET: ImpuestoRentaBecas
        public ActionResult Index()
        {
            var nameUser = User.Identity.Name;

            //entities.PRC_SOLI_INICIAL_BECA3(nameUser);

            var inpBuscar = nameUser;

            var SoliID = (from h in db.AnalisisInicialBecas
                          where h.EmailEstudiante == inpBuscar //&& h.Estado == "Enviado"
                          select h.SolicitudID).FirstOrDefault();



            var IDImpuRenta = (from h in db.ImpuestoRentaBeca3
                              where h.SolicitudID == SoliID //&& h.Estado == "Enviado"
                              select h.ImpuestoRentaID).FirstOrDefault();

            if (IDImpuRenta == 0)
            {
                return RedirectToAction("Create", "ImpuestoRentaBecas");
            }
            else
            {
                return RedirectToAction("Edit", "ImpuestoRentaBecas", new { id = IDImpuRenta });
            }


            
        }

        // GET: ImpuestoRentaBecas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImpuestoRentaBeca3 impuestoRentaBeca3 = db.ImpuestoRentaBeca3.Find(id);
            if (impuestoRentaBeca3 == null)
            {
                return HttpNotFound();
            }
            return View(impuestoRentaBeca3);
        }

        public ActionResult Informacionenviada()
        {            
            return View();
        }

        // GET: ImpuestoRentaBecas/Create
        public ActionResult Create()
        {
            ViewBag.SolicitudID = new SelectList(db.AnalisisInicialBecas, "SolicitudID", "Cedula");
            return View();
        }

        // POST: ImpuestoRentaBecas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ImpuestoRentaID,SolicitudID,Formulario102Padre,Formulario104Padre,Comprobante107Padre,Formulario102Madre,Formulario104Madre,Comprobante107Madre,TotalFormularioPadre,TotalFormularioMadre")] ImpuestoRentaBeca3 impuestoRentaBeca3)
        {
            AnalisisInicialBeca Solicitud = new AnalisisInicialBeca();



            var nameUser = User.Identity.Name;
            var inpBuscar = nameUser;

            var IDEstudiante = (from h in db.AnalisisInicialBecas
                                where h.EmailEstudiante == inpBuscar //&& h.Estado == "Ingresada"
                                select h.SolicitudID).FirstOrDefault();

            int IDSolicitud = Convert.ToInt32(IDEstudiante);

            int EstuID = int.Parse(IDEstudiante.ToString());

            Solicitud = db.AnalisisInicialBecas.Find(IDSolicitud);

            Solicitud.Estado = "Enviado";
            Solicitud.SolicitudID = EstuID;
            //db2.Entry(Solicitud).State = EntityState.Modified;
            db2.SaveChanges();

            if (ModelState.IsValid)
            {
                impuestoRentaBeca3.SolicitudID = EstuID;
                db.ImpuestoRentaBeca3.Add(impuestoRentaBeca3);
                db.SaveChanges();
                return RedirectToAction("Informacionenviada");
            }

            ViewBag.SolicitudID = new SelectList(db.AnalisisInicialBecas, "SolicitudID", "Cedula", impuestoRentaBeca3.SolicitudID);
            return View(impuestoRentaBeca3);
        }

        // GET: ImpuestoRentaBecas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImpuestoRentaBeca3 impuestoRentaBeca3 = db.ImpuestoRentaBeca3.Find(id);
            if (impuestoRentaBeca3 == null)
            {
                return HttpNotFound();
            }
            ViewBag.SolicitudID = new SelectList(db.AnalisisInicialBecas, "SolicitudID", "Cedula", impuestoRentaBeca3.SolicitudID);
            return View(impuestoRentaBeca3);
        }

        // POST: ImpuestoRentaBecas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ImpuestoRentaID,SolicitudID,Formulario102Padre,Formulario104Padre,Comprobante107Padre,Formulario102Madre,Formulario104Madre,Comprobante107Madre,TotalFormularioPadre,TotalFormularioMadre")] ImpuestoRentaBeca3 impuestoRentaBeca3)
        {
            AnalisisInicialBeca Solicitud = new AnalisisInicialBeca();

            

            var nameUser = User.Identity.Name;
            var inpBuscar = nameUser;

            var IDEstudiante = (from h in db.AnalisisInicialBecas
                                where h.EmailEstudiante == inpBuscar //&& h.Estado == "Ingresada"
                                select h.SolicitudID).FirstOrDefault();

            int IDSolicitud = Convert.ToInt32(IDEstudiante);

            int EstuID = int.Parse(IDEstudiante.ToString());

            Solicitud = db.AnalisisInicialBecas.Find(IDSolicitud);

            Solicitud.Estado = "Enviado";
            Solicitud.SolicitudID = EstuID;
            //db2.Entry(Solicitud).State = EntityState.Modified;
            db2.SaveChanges();


            if (ModelState.IsValid)
            {
                impuestoRentaBeca3.SolicitudID = EstuID;
                db.Entry(impuestoRentaBeca3).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Informacionenviada");
            }
            ViewBag.SolicitudID = new SelectList(db.AnalisisInicialBecas, "SolicitudID", "Cedula", impuestoRentaBeca3.SolicitudID);
            return View(impuestoRentaBeca3);
        }

        // GET: ImpuestoRentaBecas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImpuestoRentaBeca3 impuestoRentaBeca3 = db.ImpuestoRentaBeca3.Find(id);
            if (impuestoRentaBeca3 == null)
            {
                return HttpNotFound();
            }
            return View(impuestoRentaBeca3);
        }

        // POST: ImpuestoRentaBecas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImpuestoRentaBeca3 impuestoRentaBeca3 = db.ImpuestoRentaBeca3.Find(id);
            db.ImpuestoRentaBeca3.Remove(impuestoRentaBeca3);
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
