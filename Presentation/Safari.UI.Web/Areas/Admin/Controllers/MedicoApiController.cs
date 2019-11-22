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
    public class MedicoApiController : Controller
    {
        public ActionResult Index()
        {
            var p = new MedicoApiProcess();
            return View(p.ToList());
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Medico medico)
        {
            try
            {
                var p = new MedicoApiProcess();
                p.Add(medico);

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
            var p = new MedicoApiProcess();
            Medico medico = p.ReadBy(id.Value);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var p = new MedicoApiProcess();
            Medico medico = p.ReadBy(id.Value);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                var p = new MedicoApiProcess();
                p.Update(medico);
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
            var p = new MedicoApiProcess();
            Medico medico = p.ReadBy(id.Value);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // POST: Especie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var p = new MedicoApiProcess();

            Medico medico = p.ReadBy(id);
            p.Delete(medico);
            return RedirectToAction("Index");
        }

    }
}