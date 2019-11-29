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
    public class PrecioApiController : Controller
    {
        public ActionResult Index()
        {
            var p = new PrecioApiProcess();
            return View(p.ToList());
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Precio precio)
        {
            try
            {
                var p = new PrecioApiProcess();
                p.Add(precio);

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
            var p = new PrecioApiProcess();
            Precio precio = p.ReadBy(id.Value);
            if (precio == null)
            {
                return HttpNotFound();
            }
            return View(precio);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var p = new PrecioApiProcess();
            Precio precio = p.ReadBy(id.Value);
            if (precio == null)
            {
                return HttpNotFound();
            }
            return View(precio);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Precio precio)
        {
            if (ModelState.IsValid)
            {
                var p = new PrecioApiProcess();
                p.Update(precio);
                return RedirectToAction("Index");
            }
            return View(precio);
        }



        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var p = new PrecioApiProcess();
            Precio precio = p.ReadBy(id.Value);
            if (precio == null)
            {
                return HttpNotFound();
            }
            return View(precio);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var p = new PrecioApiProcess();

            Precio precio = p.ReadBy(id);
            p.Delete(precio);
            return RedirectToAction("Index");
        }
    }
}