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
    public class HijoDependienteBecasController : Controller
    {
        private SolicitudInicialContext db = new SolicitudInicialContext();

        // GET: HijoDependienteBecas
        public ActionResult Index()
        {
            var nameUser = User.Identity.Name;
            var inpBuscar = nameUser;

            var IDEstudiante = (from h in db.AnalisisInicialBecas
                                where h.EmailEstudiante == inpBuscar && h.Estado == "Ingresada"
                                select h.SolicitudID).FirstOrDefault();

            int EstuID = int.Parse(IDEstudiante.ToString());

            var hijoDependientes = from h in db.HijoDependienteBeca3 select h;
            hijoDependientes = hijoDependientes.Where(x => x.SolicitudID.Equals(EstuID));
            return View(hijoDependientes.ToList());


        }

        // GET: HijoDependienteBecas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HijoDependienteBeca3 hijoDependienteBeca3 = db.HijoDependienteBeca3.Find(id);
            if (hijoDependienteBeca3 == null)
            {
                return HttpNotFound();
            }
            return View(hijoDependienteBeca3);
        }

        // GET: HijoDependienteBecas/Create
        public ActionResult Create(string CedulaParam, string NombreEstudianteParam, string FechasolicitudBecaParam, string EmailEstudianteParam, string NombreRepresentanteFinanParam, string ApellidoRepresentanteFinanParam, string NacionalidadRepresentanteFinanParam, string EstadoCivilRFParam, string ResidenciaPropiaParam, string GeneroRFParam, string SectorRepresentanteFinanParam, string CiudadRepresentanteFinanParam, string TelefonoCelularRepresentanteFinanParam, string TelefonoConvencionalRepresentanteFinanParam, string LugarTrabajoActualRFParam, string CargoTrabajoActualRFParam, string DireccionTrabajoRFParam, int NumeroAniosTrabajoActualRFParam, string NivelEducacionRFParam, string NombreConyugeParam, string ApellidoConyugeParam, string NacionalidadConyugeParam, string EstadoCivilConyugeParam, string ResidenciaPropiaConyugeParam, string GeneroConyugeParam, string SectorConyugeParam, string CiudadConyugeParam, string TelefonoCelularConyugeParam, string TelefonoConvencionalConyugeParam, string LugarTrabajoActualConyugeParam, string CargoTrabajoActualConyugeParam, string DireccionTrabajoConyugeParam, int NumeroAniosTrabajoActualConyugeParam, string NivelEducacionCulminadaConyugeParam, int NumeroHijosConyugeParam, string DependeAlguienMasParam, string NombresDependientesAdicionalesParam, string ComentariosAicionalesParam, string EstadoParam, float MontoIntervParam, string AniosTrabajoActualRFParam, string RefFamiliarRepFinancieroParam, string AniosTrabajoActualConyugeParam, string CodBannerParam)
        {
            var nameUser = User.Identity.Name;
            var inpBuscar = nameUser;

            var IDSolicitud = (from h in db.AnalisisInicialBecas
                               where h.EmailEstudiante == inpBuscar //&& h.Estado == "Ingresada"
                               select h.SolicitudID).FirstOrDefault();

            AnalisisInicialBeca IDEstudiante = new AnalisisInicialBeca();

            IDEstudiante.SolicitudID = IDSolicitud;
            IDEstudiante.Cedula = CedulaParam;
            IDEstudiante.NombresCompletosEstudiante = NombreEstudianteParam;
            IDEstudiante.FechasolicitudBeca = FechasolicitudBecaParam;
            IDEstudiante.EmailEstudiante = nameUser;
            IDEstudiante.NombreRepresentanteFinan = NombreRepresentanteFinanParam;
            IDEstudiante.ApellidoRepresentanteFinan = ApellidoRepresentanteFinanParam;
            IDEstudiante.NacionalidadRepresentanteFinan = NacionalidadRepresentanteFinanParam;
            IDEstudiante.EstadoCivilRF = EstadoCivilRFParam;
            IDEstudiante.ResidenciaPropia = ResidenciaPropiaParam;
            IDEstudiante.GeneroRF = GeneroRFParam;
            IDEstudiante.SectorRepresentanteFinan = SectorRepresentanteFinanParam;
            IDEstudiante.CiudadRepresentanteFinan = CiudadRepresentanteFinanParam;
            IDEstudiante.TelefonoCelularRepresentanteFinan = TelefonoCelularRepresentanteFinanParam;
            IDEstudiante.TelefonoConvencionalRepresentanteFinan = TelefonoConvencionalRepresentanteFinanParam;
            IDEstudiante.LugarTrabajoActualRF = LugarTrabajoActualRFParam;
            IDEstudiante.CargoTrabajoActualRF = CargoTrabajoActualRFParam;
            IDEstudiante.DireccionTrabajoRF = DireccionTrabajoRFParam;
            IDEstudiante.NumeroAniosTrabajoActualRF = NumeroAniosTrabajoActualRFParam;
            IDEstudiante.NivelEducacionRF = NivelEducacionRFParam;
            IDEstudiante.NombreConyuge = NombreConyugeParam;
            IDEstudiante.ApellidoConyuge = ApellidoConyugeParam;
            IDEstudiante.NacionalidadConyuge = NacionalidadConyugeParam;
            IDEstudiante.EstadoCivilConyuge = EstadoCivilConyugeParam;
            IDEstudiante.ResidenciaPropiaConyuge = ResidenciaPropiaConyugeParam;
            IDEstudiante.GeneroConyuge = GeneroConyugeParam;
            IDEstudiante.SectorConyuge = SectorConyugeParam;
            IDEstudiante.CiudadConyuge = CiudadConyugeParam;
            IDEstudiante.TelefonoCelularConyuge = TelefonoCelularConyugeParam;
            IDEstudiante.TelefonoConvencionalConyuge = TelefonoConvencionalConyugeParam;
            IDEstudiante.LugarTrabajoActualConyuge = LugarTrabajoActualConyugeParam;
            IDEstudiante.CargoTrabajoActualConyuge = CargoTrabajoActualConyugeParam;
            IDEstudiante.DireccionTrabajoConyuge = DireccionTrabajoConyugeParam;
            IDEstudiante.NumeroAniosTrabajoActualConyuge = NumeroAniosTrabajoActualConyugeParam;
            IDEstudiante.NivelEducacionCulminadaConyuge = NivelEducacionCulminadaConyugeParam;
            IDEstudiante.NumeroHijosConyuge = NumeroHijosConyugeParam;
            IDEstudiante.DependeAlguienMas = DependeAlguienMasParam;
            IDEstudiante.NombresDependientesAdicionales = NombresDependientesAdicionalesParam;
            IDEstudiante.ComentariosAicionales = ComentariosAicionalesParam;
            IDEstudiante.AniosTrabajoActualRF = AniosTrabajoActualRFParam;
            IDEstudiante.RefFamiliarRepFinanciero = RefFamiliarRepFinancieroParam;
            IDEstudiante.AniosTrabajoActualConyuge = AniosTrabajoActualConyugeParam;
            IDEstudiante.CodBanner = CodBannerParam;


            IDEstudiante.Estado = "Ingresada";
            IDEstudiante.MontoInterv = MontoIntervParam;
            IDEstudiante.FechasolicitudBeca = Convert.ToString(DateTime.Now);

            db.Entry(IDEstudiante).State = EntityState.Modified;
            db.SaveChanges();

            ViewBag.SolicitudID = new SelectList(db.AnalisisInicialBecas, "SolicitudID", "Cedula");
            return View();
        }

        // POST: HijoDependienteBecas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HijoDependienteID,SolicitudID,NombresApellidos,InstitucionEsdudia,CostoAnualEstudio")] HijoDependienteBeca3 hijoDependienteBeca3)
        {
            var nameUser = User.Identity.Name;
            var inpBuscar = nameUser;

            var IDEstudiante = (from h in db.AnalisisInicialBecas
                                where h.EmailEstudiante == inpBuscar && h.Estado == "Ingresada"
                                select h.SolicitudID).FirstOrDefault();

            int EstuID = int.Parse(IDEstudiante.ToString());

            if (ModelState.IsValid)
            {
                hijoDependienteBeca3.SolicitudID = EstuID;
                db.HijoDependienteBeca3.Add(hijoDependienteBeca3);
                db.SaveChanges();
                return RedirectToAction("Index", "AnalisisInicialBecas");
            }

            ViewBag.SolicitudID = new SelectList(db.AnalisisInicialBecas, "SolicitudID", "Cedula", hijoDependienteBeca3.SolicitudID);
            return View(hijoDependienteBeca3);
        }

        // GET: HijoDependienteBecas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HijoDependienteBeca3 hijoDependienteBeca3 = db.HijoDependienteBeca3.Find(id);
            if (hijoDependienteBeca3 == null)
            {
                return HttpNotFound();
            }
            ViewBag.SolicitudID = new SelectList(db.AnalisisInicialBecas, "SolicitudID", "Cedula", hijoDependienteBeca3.SolicitudID);
            return View(hijoDependienteBeca3);
        }

        // POST: HijoDependienteBecas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HijoDependienteID,SolicitudID,NombresApellidos,InstitucionEsdudia,CostoAnualEstudio")] HijoDependienteBeca3 hijoDependienteBeca3)
        {
            var nameUser = User.Identity.Name;
            var inpBuscar = nameUser;

            var IDEstudiante = (from h in db.AnalisisInicialBecas
                                where h.EmailEstudiante == inpBuscar && h.Estado == "Ingresada"
                                select h.SolicitudID).FirstOrDefault();

            int EstuID = int.Parse(IDEstudiante.ToString());

            if (ModelState.IsValid)
            {
                hijoDependienteBeca3.SolicitudID = EstuID;
                db.Entry(hijoDependienteBeca3).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "AnalisisInicialBecas");
            }
            ViewBag.SolicitudID = new SelectList(db.AnalisisInicialBecas, "SolicitudID", "Cedula", hijoDependienteBeca3.SolicitudID);
            return View(hijoDependienteBeca3);
        }

        // GET: HijoDependienteBecas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HijoDependienteBeca3 hijoDependienteBeca3 = db.HijoDependienteBeca3.Find(id);
            if (hijoDependienteBeca3 == null)
            {
                return HttpNotFound();
            }
            return View(hijoDependienteBeca3);
        }

        // POST: HijoDependienteBecas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HijoDependienteBeca3 hijoDependienteBeca3 = db.HijoDependienteBeca3.Find(id);
            db.HijoDependienteBeca3.Remove(hijoDependienteBeca3);
            db.SaveChanges();
            return RedirectToAction("Index", "AnalisisInicialBecas");
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
