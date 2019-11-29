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
    public class CitaApiController : Controller
    {
        public ActionResult Index()
        {
            var p = new CitaApiProcess();
            return View(p.ToList());
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Cita cita)
        {
            try
            {
                var p = new CitaApiProcess();
                p.Add(cita);

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
            var p = new CitaApiProcess();
            Cita cita = p.ReadBy(id.Value);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var p = new CitaApiProcess();
            Cita cita = p.ReadBy(id.Value);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cita cita)
        {
            if (ModelState.IsValid)
            {
                var p = new CitaApiProcess();
                p.Update(cita);
                return RedirectToAction("Index");
            }
            return View(cita);
        }



        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var p = new CitaApiProcess();
            Cita cita = p.ReadBy(id.Value);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var p = new CitaApiProcess();

            Cita cita = p.ReadBy(id);
            p.Delete(cita);
            return RedirectToAction("Index");
        }


        public JsonResult GetEvents()
        {
            var citas = new CitaApiProcess().ToList();



            var citasList = new List<object>();

            foreach (var i in citas)
            {
                citasList.Add(new
                {
                    id = i.Id,
                    title = "- " + i.Fecha.ToShortTimeString() + "-" + i.PacienteId,
                    start = i.Fecha.AddHours(-3),
                    
                });

            }

            return Json(citasList.ToArray(), JsonRequestBehavior.AllowGet);
        }

    }
}