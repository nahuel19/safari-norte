using Safari.Entities;
using Safari.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Safari.UI.Web.Areas.Admin.Controllers
{
    public class EspecieApiController : Controller
    {
        // GET: Admin/EspecieApi
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var p = new EspecieApiProcess();
            var lista = p.ToList();

            ViewBag.CurrentSort = sortOrder;

            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var especie = from s in lista select s;

            if (!string.IsNullOrEmpty(searchString))
            {
                especie = especie.Where(s => s.Nombre.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "name_desc":
                    especie = especie.OrderByDescending(s => s.Nombre);
                    break;
                default:
                    especie = especie.OrderBy(s => s.Nombre);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(especie.ToPagedList(pageNumber, pageSize));
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
        public ActionResult DeleteConfirmed(Especie especie)
        {
            var p = new EspecieApiProcess();
            
            //Especie especie = p.ReadBy(id);
            p.Delete(especie);
            return RedirectToAction("Index");
        }


    }
}