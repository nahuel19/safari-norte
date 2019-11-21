using Safari.Entities;
using Safari.Services.Contracts;
using Safari.UI.Process;
using Safari.UI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Safari.UI.Web.Areas.Admin.Controllers
{
    
        public class PacienteController : Controller
        {
            private IService<Paciente> _pacienteService;
            private PacienteProcess db;

            public PacienteController(IService<Paciente> pacienteService)
            {
                _pacienteService = pacienteService;
                db = new PacienteProcess(_pacienteService);
            }

            public PacienteController()
            {

            }




            public ActionResult Index()
            {
                return View(db.ToList());
            }


            public ActionResult Details(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Paciente paciente = db.Find(id);
                if (paciente == null)
                {
                    return HttpNotFound();
                }
                return View(paciente);
            }


            public ActionResult Create()
            {
                
                return View();
            }


            // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
            // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(Paciente paciente)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        db.Add(paciente);
                        TempData["MessageViewBagName"] = new GenericMessageViewModel
                        {
                            Message = "Registro agregado a la base de datos.",
                            MessageType = GenericMessages.success
                        };
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {

                        TempData["MessageViewBagName"] = new GenericMessageViewModel
                        {
                            Message = ex.Message,
                            MessageType = GenericMessages.danger,
                            ConstantMessage = true
                        };
                    }
                }

                return View(paciente);
            }


            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Paciente paciente = db.Find(id);

               

                if (paciente == null)
                {
                    return HttpNotFound();
                }
                return View(paciente);
            }


            // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
            // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(Paciente paciente)
            {
                if (ModelState.IsValid)
                {
                    db.Edit(paciente);
                    return RedirectToAction("Index");
                }
                return View(paciente);
            }


            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                 Paciente paciente = db.Find(id);
                if (paciente == null)
                {
                    return HttpNotFound();
                }
                return View(paciente);
            }


            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                Paciente paciente = db.Find(id);
                db.Remove(paciente);
                return RedirectToAction("Index");
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    db = null;
                }
                base.Dispose(disposing);
            }
        }
    
}