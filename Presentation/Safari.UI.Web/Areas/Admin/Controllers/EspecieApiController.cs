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
    public class EspecieApiController : Controller
    {
        // GET: Admin/EspecieApi
        public ActionResult Index()
        {
            var p = new EspecieApiProcess();
            return View(p.ToList());
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Especie especie)
        {
            try
            {
                var p = new EspecieApiProcess();
                p.Add(especie);

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
            var p = new EspecieApiProcess();
            Especie especie = p.ReadBy(id.Value);
            if (especie == null)
            {
                return HttpNotFound();
            }
            return View(especie);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var p = new EspecieApiProcess();
            Especie especie = p.ReadBy(id.Value);
            if (especie == null)
            {
                return HttpNotFound();
            }
            return View(especie);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] Especie especie)
        {
            if (ModelState.IsValid)
            {
                var p = new EspecieApiProcess();
                p.Update(especie);
                return RedirectToAction("Index");
            }
            return View(especie);
        }



        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var p = new EspecieApiProcess();
            Especie especie = p.ReadBy(id.Value);
            if (especie == null)
            {
                return HttpNotFound();
            }
            return View(especie);
        }

        // POST: Especie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var p = new EspecieApiProcess();
            
            Especie especie = p.ReadBy(id);
            p.Delete(especie);
            return RedirectToAction("Index");
        }


    }
}