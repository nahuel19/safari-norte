using Safari.Entities;
using Safari.Services.Contracts;
using Safari.UI.Process;
using Safari.UI.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Safari.UI.Web.Areas.Admin.Controllers
{
    public class ClienteController : Controller
    {
        private IService<Cliente> _clienteService;
        private ClienteProcess db;

        private IService<Paciente> _pacienteService;
        private PacienteProcess pp;

        public ClienteController(IService<Cliente> clienteService, IService<Paciente> pacienteService)
        {
            _clienteService = clienteService;
            db = new ClienteProcess(_clienteService);

            _pacienteService = pacienteService;
            pp = new PacienteProcess(_pacienteService);
        }

        public ClienteController()
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
            Cliente cliente = db.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }


        public ActionResult Create()
        {
            return View();
        }


        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Add(cliente);
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

            return View(cliente);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }


        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Edit(cliente);
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
            Cliente cliente = db.Find(id);
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
            Cliente cliente = db.Find(id);
            db.Remove(cliente);
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



        public ActionResult AgregarMascota(int id)
        {
            var obj = new Paciente();
            var dueño = db.Find(id);
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
            

            try {
                //HttpPostedFileBase FileBase = Request.Files[0];
                //WebImage image = new WebImage(FileBase.InputStream);

                //collection.ImagePet = image.GetBytes();

               
            
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