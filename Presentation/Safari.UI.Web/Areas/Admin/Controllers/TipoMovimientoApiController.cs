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
    public class TipoMovimientoApiController : Controller
    {
        public ActionResult Index()
        {
            var p = new TipoMovimientoApiProcess();
            return View(p.ToList());
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(TipoMovimiento tipoMovimiento)
        {
            try
            {
                var p = new TipoMovimientoApiProcess();
                p.Add(tipoMovimiento);

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
            var p = new TipoMovimientoApiProcess();
            TipoMovimiento tipoMovimiento = p.ReadBy(id.Value);
            if (tipoMovimiento == null)
            {
                return HttpNotFound();
            }
            return View(tipoMovimiento);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var p = new TipoMovimientoApiProcess();
            TipoMovimiento tipoMovimiento = p.ReadBy(id.Value);
            if (tipoMovimiento == null)
            {
                return HttpNotFound();
            }
            return View(tipoMovimiento);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoMovimiento tipoMovimiento)
        {
            if (ModelState.IsValid)
            {
                var p = new TipoMovimientoApiProcess();
                p.Update(tipoMovimiento);
                return RedirectToAction("Index");
            }
            return View(tipoMovimiento);
        }



        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var p = new TipoMovimientoApiProcess();
            TipoMovimiento tipoMovimiento = p.ReadBy(id.Value);
            if (tipoMovimiento == null)
            {
                return HttpNotFound();
            }
            return View(tipoMovimiento);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var p = new TipoMovimientoApiProcess();

            TipoMovimiento tipoMovimiento = p.ReadBy(id);
            p.Delete(tipoMovimiento);
            return RedirectToAction("Index");
        }
    }
}