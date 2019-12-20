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
    public class SalaApiController : Controller
    {
        public ActionResult Index()
        {
            var p = new SalaApiProcess();
            return View(p.ToList());
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Sala sala)
        {
            try
            {
                var p = new SalaApiProcess();
                p.Add(sala);

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
            var p = new SalaApiProcess();
            Sala sala = p.ReadBy(id.Value);
            if (sala == null)
            {
                return HttpNotFound();
            }
            return View(sala);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var p = new SalaApiProcess();
            Sala sala = p.ReadBy(id.Value);
            if (sala == null)
            {
                return HttpNotFound();
            }
            return View(sala);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sala sala)
        {
            if (ModelState.IsValid)
            {
                var p = new SalaApiProcess();
                p.Update(sala);
                return RedirectToAction("Index");
            }
            return View(sala);
        }



        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var p = new SalaApiProcess();
            Sala sala = p.ReadBy(id.Value);
            if (sala == null)
            {
                return HttpNotFound();
            }
            return View(sala);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var p = new SalaApiProcess();

            Sala sala = p.ReadBy(id);
            p.Delete(sala);
            return RedirectToAction("Index");
        }
    }

}