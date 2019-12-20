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
    public class TipoServicioApiController : Controller
    {
        public ActionResult Index()
        {
            var p = new TipoServicioApiProcess();
            return View(p.ToList());
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(TipoServicio tipoServicio)
        {
            try
            {
                var p = new TipoServicioApiProcess();
                p.Add(tipoServicio);

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
            var p = new TipoServicioApiProcess();
            TipoServicio tipoServicio = p.ReadBy(id.Value);
            if (tipoServicio == null)
            {
                return HttpNotFound();
            }
            return View(tipoServicio);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var p = new TipoServicioApiProcess();
            TipoServicio tipoServicio = p.ReadBy(id.Value);
            if (tipoServicio == null)
            {
                return HttpNotFound();
            }
            return View(tipoServicio);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoServicio tipoServicio)
        {
            if (ModelState.IsValid)
            {
                var p = new TipoServicioApiProcess();
                p.Update(tipoServicio);
                return RedirectToAction("Index");
            }
            return View(tipoServicio);
        }



        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var p = new TipoServicioApiProcess();
            TipoServicio tipoServicio = p.ReadBy(id.Value);
            if (tipoServicio == null)
            {
                return HttpNotFound();
            }
            return View(tipoServicio);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var p = new TipoServicioApiProcess();

            TipoServicio tipoServicio = p.ReadBy(id);
            p.Delete(tipoServicio);
            return RedirectToAction("Index");
        }
    }
}