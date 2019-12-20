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
using PagedList;

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




        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var p = new ClienteApiProcess();
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

            var cliente = from s in lista select s;

            if (!string.IsNullOrEmpty(searchString))
            {
                cliente = cliente.Where(s => s.Apellido.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "name_desc":
                    cliente = cliente.OrderByDescending(s => s.Apellido);
                    break;
                default:
                    cliente = cliente.OrderBy(s => s.Apellido);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(cliente.ToPagedList(pageNumber, pageSize));


            //return View(db.ToList());
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
                           
                pp.Add(collection);
                return RedirectToAction("Index");
            }

            catch (DataException ex)
            {
                
                return View();
            }

        }



        public ActionResult CtaCte(int id)
        {
            var movimientos = new MovimientoApiProcess().ToList();
            var movCliente = new List<Movimiento>();
            double tot = 0 ;

            foreach(var m in movimientos)
            {
                if(m.ClienteId == id)
                {
                    movCliente.Add(m);
                    
                    if(m.TipoMovimientoId == 1)
                    {
                        tot += m.Valor;
                    }
                    else if(m.TipoMovimientoId ==4)
                    {
                        tot += (m.Valor * -1);
                    }
                }

            }
            
            ViewData["Total"] = tot;

            Cliente cliente = db.Find(id);
            ViewData["Nombre"] = cliente.Nombre + " " + cliente.Apellido;


            return View(movCliente);
        }


    }
}