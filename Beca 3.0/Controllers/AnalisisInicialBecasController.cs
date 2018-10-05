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
    public class AnalisisInicialBecasController : Controller
    {
        private SolicitudInicialContext db = new SolicitudInicialContext();

        // GET: AnalisisInicialBecas
        [Authorize]
        public ActionResult Index()
        {

            Asis_FinanEntities1 entities = new Asis_FinanEntities1();

           

            var nameUser = User.Identity.Name;

            entities.PRC_SOLI_INICIAL_BECA3(nameUser);

            var inpBuscar = nameUser;

            var ControlporEstado = (from h in db.AnalisisInicialBecas
                                    where h.EmailEstudiante == inpBuscar //&& h.Estado == "Enviado"
                                    select h.Estado).FirstOrDefault();

         

            var IDSolicitud = (from h in db.AnalisisInicialBecas
                               where h.EmailEstudiante == inpBuscar //&& h.Estado == "Enviado"
                               select h.SolicitudID).FirstOrDefault();

         


            if (ControlporEstado == "Enviado")
            {
                return RedirectToAction("SolicitudEnProceso");                
            }
            else { 
                if (IDSolicitud == 0)
                {
                    return RedirectToAction("Create", "AnalisisInicialBecas");
                }
                else
                {
                    return RedirectToAction("Edit", "AnalisisInicialBecas", new { id = IDSolicitud });
                }
            }

            //return View(db.AnalisisInicialBecas.ToList());
        }

        // GET: AnalisisInicialBecas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnalisisInicialBeca analisisInicialBeca = db.AnalisisInicialBecas.Find(id);
            if (analisisInicialBeca == null)
            {
                return HttpNotFound();
            }
            return View(analisisInicialBeca);
        }

        public ActionResult SolicitudEnProceso()
        {
            return View();
        }

        // GET: AnalisisInicialBecas/Create
        [Authorize]
        public ActionResult Create()
        {
            var SIoNOList = new SelectList(new[] { "SI", "NO" });
            ViewBag.ListaSIoNO = SIoNOList;

            var CiudadesList = new SelectList(new[] { "Quito", "Guayaquil", "Cuenca", "Loja" });
            ViewBag.Listaciudades = CiudadesList;

            var TipoResidenciaList = new SelectList(new[] { "Propia", "Alquilada" });
            ViewBag.ListaResidencia = TipoResidenciaList;

            var EstadocivilList = new SelectList(new[] { "SOLTERO", "CASADO", "DIVORCIADO", "UNION LIBRE" });
            ViewBag.ListaEstadocivil = EstadocivilList;

            var NivelEducacionList = new SelectList(new[] { "PRIMARIA", "SECUNDARIA", "UNIVERSITARIA", "POST-GRADO", "DOCTORADO" });
            ViewBag.ListaNivelEducacion = NivelEducacionList;

            var nameUser = User.Identity.Name;
            var inpBuscar = nameUser;

            var ControlporEstado = (from h in db.AnalisisInicialBecas
                                    where h.EmailEstudiante == inpBuscar //&& h.Estado == "Enviado"
                                    select h.Estado).FirstOrDefault();


            var IDSolicitud = (from h in db.AnalisisInicialBecas
                               where h.EmailEstudiante == inpBuscar //&& h.Estado == "Enviado"
                               select h.SolicitudID).FirstOrDefault();

            if (IDSolicitud == 0)
            {
                return RedirectToAction("Create", "AnalisisInicialBecas");
            }
            else
            {
                return RedirectToAction("Edit", "AnalisisInicialBecas", new { id = IDSolicitud });
            }



            return View();
        }

        // POST: AnalisisInicialBecas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SolicitudID,Cedula,NombresCompletosEstudiante,FechasolicitudBeca,EmailEstudiante,NombreRepresentanteFinan,ApellidoRepresentanteFinan,NacionalidadRepresentanteFinan,EstadoCivilRF,ResidenciaPropia,GeneroRF,SectorRepresentanteFinan,CiudadRepresentanteFinan,TelefonoCelularRepresentanteFinan,TelefonoConvencionalRepresentanteFinan,LugarTrabajoActualRF,CargoTrabajoActualRF,DireccionTrabajoRF,NumeroAniosTrabajoActualRF,NivelEducacionRF,NombreConyuge,ApellidoConyuge,NacionalidadConyuge,EstadoCivilConyuge,ResidenciaPropiaConyuge,GeneroConyuge,SectorConyuge,CiudadConyuge,TelefonoCelularConyuge,TelefonoConvencionalConyuge,LugarTrabajoActualConyuge,CargoTrabajoActualConyuge,DireccionTrabajoConyuge,NumeroAniosTrabajoActualConyuge,NivelEducacionCulminadaConyuge,NumeroHijosConyuge,DependeAlguienMas,NombresDependientesAdicionales,ComentariosAicionales,Estado,MontoInterv,AniosTrabajoActualRF,AniosTrabajoActualConyuge,RefFamiliarRepFinanciero,CodBanner")] AnalisisInicialBeca analisisInicialBeca)
        {
            var nameUser = User.Identity.Name;
            

            var SIoNOList = new SelectList(new[] { "SI", "NO" });
            ViewBag.ListaSIoNO = SIoNOList;

            var CiudadesList = new SelectList(new[] { "Quito", "Guayaquil", "Cuenca", "Loja" });
            ViewBag.Listaciudades = CiudadesList;

            var TipoResidenciaList = new SelectList(new[] { "Propia", "Alquilada" });
            ViewBag.ListaResidencia = TipoResidenciaList;

            var EstadocivilList = new SelectList(new[] { "SOLTERO", "CASADO", "DIVORCIADO", "UNION LIBRE" });
            ViewBag.ListaEstadocivil = EstadocivilList;

            var NivelEducacionList = new SelectList(new[] { "PRIMARIA", "SECUNDARIA", "UNIVERSITARIA", "POST-GRADO", "DOCTORADO" });
            ViewBag.ListaNivelEducacion = NivelEducacionList;

            if (ModelState.IsValid)
            {
                analisisInicialBeca.EmailEstudiante = nameUser;
                analisisInicialBeca.Estado = "Ingresada";
                analisisInicialBeca.FechasolicitudBeca = Convert.ToString(DateTime.Now);
                db.AnalisisInicialBecas.Add(analisisInicialBeca);
                db.SaveChanges();
                return RedirectToAction("Index", "IngresosFamiliaresBecas");
            }

            return View(analisisInicialBeca);
        }

        // GET: AnalisisInicialBecas/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            var SIoNOList = new SelectList(new[] { "SI", "NO" });
            ViewBag.ListaSIoNO = SIoNOList;

            var CiudadesList = new SelectList(new[] { "Quito", "Guayaquil", "Cuenca", "Loja" });
            ViewBag.Listaciudades = CiudadesList;

            var TipoResidenciaList = new SelectList(new[] { "Propia", "Alquilada" });
            ViewBag.ListaResidencia = TipoResidenciaList;

            var EstadocivilList = new SelectList(new[] { "SOLTERO", "CASADO", "DIVORCIADO", "UNION LIBRE" });
            ViewBag.ListaEstadocivil = EstadocivilList;

            var NivelEducacionList = new SelectList(new[] { "PRIMARIA", "SECUNDARIA", "UNIVERSITARIA", "POST-GRADO", "DOCTORADO" });
            ViewBag.ListaNivelEducacion = NivelEducacionList;


            //var nameUser = User.Identity.Name;



            //var inpBuscar = nameUser;

            //var ControlporEstado = (from h in db.AnalisisInicialBecas
            //                        where h.EmailEstudiante == inpBuscar //&& h.Estado == "Enviado"
            //                        select h.Estado).FirstOrDefault();


            //var IDSolicitud = (from h in db.AnalisisInicialBecas
            //                   where h.EmailEstudiante == inpBuscar //&& h.Estado == "Enviado"
            //                   select h.SolicitudID).FirstOrDefault();


            //if (ControlporEstado == "Enviado")
            //{
            //    return RedirectToAction("SolicitudEnProceso");
            //}
            //else
            //{
            //    if (IDSolicitud == 0)
            //    {
            //        return RedirectToAction("Create", "AnalisisInicialBecas");
            //    }
            //    else
            //    {
            //        return RedirectToAction("Edit", "AnalisisInicialBecas", new { id = IDSolicitud });
            //    }

                
            //}

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnalisisInicialBeca analisisInicialBeca = db.AnalisisInicialBecas.Find(id);
            if (analisisInicialBeca == null)
            {
                return HttpNotFound();
            }
            return View(analisisInicialBeca);


        }

        // POST: AnalisisInicialBecas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SolicitudID,Cedula,NombresCompletosEstudiante,FechasolicitudBeca,EmailEstudiante,NombreRepresentanteFinan,ApellidoRepresentanteFinan,NacionalidadRepresentanteFinan,EstadoCivilRF,ResidenciaPropia,GeneroRF,SectorRepresentanteFinan,CiudadRepresentanteFinan,TelefonoCelularRepresentanteFinan,TelefonoConvencionalRepresentanteFinan,LugarTrabajoActualRF,CargoTrabajoActualRF,DireccionTrabajoRF,NumeroAniosTrabajoActualRF,NivelEducacionRF,NombreConyuge,ApellidoConyuge,NacionalidadConyuge,EstadoCivilConyuge,ResidenciaPropiaConyuge,GeneroConyuge,SectorConyuge,CiudadConyuge,TelefonoCelularConyuge,TelefonoConvencionalConyuge,LugarTrabajoActualConyuge,CargoTrabajoActualConyuge,DireccionTrabajoConyuge,NumeroAniosTrabajoActualConyuge,NivelEducacionCulminadaConyuge,NumeroHijosConyuge,DependeAlguienMas,NombresDependientesAdicionales,ComentariosAicionales,Estado,MontoInterv,AniosTrabajoActualRF,AniosTrabajoActualConyuge,RefFamiliarRepFinanciero,CodBanner")] AnalisisInicialBeca analisisInicialBeca)
        {
            var nameUser = User.Identity.Name;
            var SIoNOList = new SelectList(new[] { "SI", "NO" });
            ViewBag.ListaSIoNO = SIoNOList;

            var CiudadesList = new SelectList(new[] { "Quito", "Guayaquil", "Cuenca", "Loja" });
            ViewBag.Listaciudades = CiudadesList;

            var TipoResidenciaList = new SelectList(new[] { "Propia", "Alquilada" });
            ViewBag.ListaResidencia = TipoResidenciaList;

            var EstadocivilList = new SelectList(new[] { "SOLTERO", "CASADO", "DIVORCIADO", "UNION LIBRE" });
            ViewBag.ListaEstadocivil = EstadocivilList;

            var NivelEducacionList = new SelectList(new[] { "PRIMARIA", "SECUNDARIA", "UNIVERSITARIA", "POST-GRADO", "DOCTORADO" });
            ViewBag.ListaNivelEducacion = NivelEducacionList;

            if (ModelState.IsValid)
            {
                analisisInicialBeca.EmailEstudiante = nameUser;
                analisisInicialBeca.Estado = "Ingresada";
                analisisInicialBeca.FechasolicitudBeca = Convert.ToString(DateTime.Now);
                db.Entry(analisisInicialBeca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "IngresosFamiliaresBecas");
            }
            return View(analisisInicialBeca);
        }

        // GET: AnalisisInicialBecas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnalisisInicialBeca analisisInicialBeca = db.AnalisisInicialBecas.Find(id);
            if (analisisInicialBeca == null)
            {
                return HttpNotFound();
            }
            return View(analisisInicialBeca);
        }

        // POST: AnalisisInicialBecas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnalisisInicialBeca analisisInicialBeca = db.AnalisisInicialBecas.Find(id);
            db.AnalisisInicialBecas.Remove(analisisInicialBeca);
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
