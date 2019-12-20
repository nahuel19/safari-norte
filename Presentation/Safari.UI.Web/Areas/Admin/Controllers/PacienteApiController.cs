using Safari.Entities;
using Safari.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Safari.UI.Web.Areas.Admin.Controllers
{
    public class PacienteApiController : Controller
    {
        public ActionResult Index()
        {
            var p = new PacienteApiProcess();
            return View(p.ToList());
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Paciente paciente)
        {
            try
            {
                var p = new PacienteApiProcess();
                p.Add(paciente);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var p = new PacienteApiProcess();
            Paciente paciente = p.ReadBy(id.Value);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var p = new PacienteApiProcess();
            Paciente paciente = p.ReadBy(id.Value);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                var p = new PacienteApiProcess();
                p.Update(paciente);
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
            var p = new PacienteApiProcess();
            Paciente paciente = p.ReadBy(id.Value);
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
            var p = new PacienteApiProcess();

            Paciente paciente = p.ReadBy(id);
            p.Delete(paciente);
            return RedirectToAction("Index");
        }
    }
}