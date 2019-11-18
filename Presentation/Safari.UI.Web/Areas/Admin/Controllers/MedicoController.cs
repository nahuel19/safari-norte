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
    public class MedicoController : Controller
    {
        private IService<Medico> _medicoService;
        private MedicoProcess db;

        public MedicoController(IService<Medico> medicoService)
        {
            _medicoService = medicoService;
            db = new MedicoProcess(_medicoService);
        }

        public MedicoController()
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
            Medico medico = db.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }


        public ActionResult Create()
        {
            return View();
        }


        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Medico medico)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Add(medico);
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

            return View(medico);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }


        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Edit(medico);
                return RedirectToAction("Index");
            }
            return View(medico);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medico medico = db.Find(id);
            db.Remove(medico);
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