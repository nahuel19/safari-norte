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
    public class MovimientoApiController : Controller
    {
        public ActionResult Index()
        {
            var p = new MovimientoApiProcess();
            return View(p.ToList());
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Movimiento movimiento)
        {
            try
            {
                var p = new MovimientoApiProcess();
                p.Add(movimiento);

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
            var p = new MovimientoApiProcess();
            Movimiento movimiento = p.ReadBy(id.Value);
            if (movimiento == null)
            {
                return HttpNotFound();
            }
            return View(movimiento);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var p = new MovimientoApiProcess();
            Movimiento movimiento = p.ReadBy(id.Value);
            if (movimiento == null)
            {
                return HttpNotFound();
            }
            return View(movimiento);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movimiento movimiento)
        {
            if (ModelState.IsValid)
            {
                var p = new MovimientoApiProcess();
                p.Update(movimiento);
                return RedirectToAction("Index");
            }
            return View(movimiento);
        }



        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var p = new MovimientoApiProcess();
            Movimiento movimiento = p.ReadBy(id.Value);
            if (movimiento == null)
            {
                return HttpNotFound();
            }
            return View(movimiento);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var p = new MovimientoApiProcess();

            Movimiento movimiento = p.ReadBy(id);
            p.Delete(movimiento);
            return RedirectToAction("Index");
        }
    }
}