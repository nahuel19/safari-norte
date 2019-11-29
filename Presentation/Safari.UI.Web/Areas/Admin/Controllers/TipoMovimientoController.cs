using Safari.Entities;
using Safari.Services.Contracts;
using Safari.UI.Process;
using Safari.UI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Safari.UI.Web.Areas.Admin.Controllers
{
    public class TipoMovimientoController : Controller
    {
        private IService<TipoMovimiento> _tipoMovimientoService;
        private TipoMovimientoProcess db;

        public TipoMovimientoController(IService<TipoMovimiento> tipoMovimientoService)
        {
            _tipoMovimientoService = tipoMovimientoService;
            db = new TipoMovimientoProcess(_tipoMovimientoService);
        }

        public TipoMovimientoController()
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
            TipoMovimiento tipoMovimiento = db.Find(id);
            if (tipoMovimiento == null)
            {
                return HttpNotFound();
            }
            return View(tipoMovimiento);
        }


        public ActionResult Create()
        {
            return View();
        }


        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoMovimiento tipoMovimiento)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Add(tipoMovimiento);
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

            return View(tipoMovimiento);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            TipoMovimiento tipoMovimiento = db.Find(id);

            if (tipoMovimiento == null)
            {
                return HttpNotFound();
            }
            return View(tipoMovimiento);
        }


        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoMovimiento tipoMovimiento)
        {
            if (ModelState.IsValid)
            {
                db.Edit(tipoMovimiento);
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
            TipoMovimiento tipoMovimiento = db.Find(id);
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
            TipoMovimiento tipoMovimiento = db.Find(id);
            db.Remove(tipoMovimiento);
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