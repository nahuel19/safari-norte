using Safari.Entities;
using Safari.UI.Process;
using Safari.UI.Web.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Safari.UI.Web.Areas.Admin.Controllers
{
    public class ClienteApiController : Controller
    {
        public ActionResult Index()
        {
            var p = new ClienteApiProcess();
            return View(p.ToList());
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                var p = new ClienteApiProcess();
                p.Add(cliente);
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
            return View(cliente);
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var p = new ClienteApiProcess();
            Cliente cliente = new Cliente();
            cliente.Pacientes = new List<Paciente>();
            cliente = p.ReadBy(id.Value);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var p = new ClienteApiProcess();
            Cliente cliente = p.ReadBy(id.Value);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var p = new ClienteApiProcess();
                p.Update(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }



        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var p = new ClienteApiProcess();
            Cliente cliente = p.ReadBy(id.Value);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var p = new ClienteApiProcess();

            Cliente cliente = p.ReadBy(id);
            p.Delete(cliente);
            return RedirectToAction("Index");
        }


        public ActionResult AgregarMascota(int id)
        {
            var obj = new Paciente();

            var db = new ClienteApiProcess();
            var dueño = db.ReadBy(id);

            obj.Cliente = dueño;
            obj.ClienteId = dueño.Id;


            EspecieApiProcess eap = new EspecieApiProcess();

            var especies = eap.ToList();
            var listEspecies = new SelectList(especies, "Id", "Nombre");
            ViewData["Especies"] = listEspecies;


            return View(obj);
        }

        [HttpPost]
        public ActionResult AgregarMascota(Paciente collection)
        {


            try
            {
                //HttpPostedFileBase FileBase = Request.Files[0];
                //WebImage image = new WebImage(FileBase.InputStream);

                //collection.ImagePet = image.GetBytes();

                var pp = new PacienteApiProcess();

                pp.Add(collection);
                return RedirectToAction("Index");
            }

            catch (DataException ex)
            {

                return View();
            }

        }
    }
}