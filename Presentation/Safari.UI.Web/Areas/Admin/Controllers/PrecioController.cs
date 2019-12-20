using Safari.Entities;
using Safari.Services.Contracts;
using Safari.UI.Process;
using Safari.UI.Web.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Safari.UI.Web.Areas.Admin.Controllers
{
    public class PrecioController : Controller
    {
        private IService<Precio> _precioService;
        private PrecioProcess db;

        public PrecioController(IService<Precio> precioService)
        {
            _precioService = precioService;
            db = new PrecioProcess(_precioService);
        }

        public PrecioController()
        {

        }




        public ActionResult Index()
        {
            return View(db.ToList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Precio precio = db.Find(id);
            if (precio == null)
            {
                return HttpNotFound();
            }
            return View(precio);
        }


        public ActionResult Create()
        {
            var tServicios = new TipoServicioApiProcess().ToList();
            var listServicios = new SelectList(tServicios, "Id", "Nombre");
            ViewData["TipoServicio"] = listServicios;

            return View();
        }


        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Precio precio)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Add(precio);
                    TempData["MessageViewBagName"] = new GenericMessageViewModel
                    {
                        Message = "Registro agregado a la base de datos.",
                        MessageType = GenericMessages.success
                    };
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    TempData["MessageViewBagName"] = new GenericMessageViewModel
                    {
                        Message = ex.Message,
                        MessageType = GenericMessages.danger,
                        ConstantMessage = true
                    };
                }
            }

            return View(precio);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Precio precio = db.Find(id);
            var tServicios = new TipoServicioApiProcess().ToList();
            var listServicios = new SelectList(tServicios, "Id", "Nombre");
            ViewData["TipoServicio"] = listServicios;

            if (precio == null)
            {
                return HttpNotFound();
            }
            return View(precio);
        }


        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Precio precio)
        {
            if (ModelState.IsValid)
            {
                db.Edit(precio);
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
            Precio precio = db.Find(id);
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
            Precio precio = db.Find(id);
            db.Remove(precio);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db = null;
            }
            base.Dispose(disposing);
        }
    }
}