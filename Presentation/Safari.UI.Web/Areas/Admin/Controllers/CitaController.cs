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
using PagedList;

namespace Safari.UI.Web.Areas.Admin.Controllers
{
    public class CitaController : Controller
    {
        private IService<Cita> _citaService;
        private CitaProcess db;

        public CitaController(IService<Cita> citaService)
        {
            _citaService = citaService;
            db = new CitaProcess(_citaService);
        }

        public CitaController()
        {

        }




        public ActionResult Index(int? page)
        {
            
            var lista = db.ToList();

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(lista.ToPagedList(pageNumber, pageSize));

            //return View(db.ToList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }


        public ActionResult Create()
        {
            //estados
            var cita = new Cita();
            SelectList list = new SelectList(cita.TipoEstado);
            ViewData["ListaEstados"] = list;

            //medicos
            MedicoApiProcess map = new MedicoApiProcess();

            var medicos = map.ToList();
            var listMedicos = new SelectList(medicos, "Id", "Nombre");
            ViewData["Medicos"] = listMedicos;

            //pacientes
            PacienteApiProcess pp = new PacienteApiProcess();

            var pacientes = pp.ToList();
            var listPacientes = new SelectList(pacientes, "Id", "Nombre");
            ViewData["Pacientes"] = listPacientes;


            //salas
            SalaApiProcess sp = new SalaApiProcess();

            var salas = sp.ToList();
            var listSalas = new SelectList(salas, "Id", "Nombre");
            ViewData["Salas"] = listSalas;

            //tipo servicios
            TipoServicioApiProcess tsp = new TipoServicioApiProcess();

            var tipoS = tsp.ToList();
            var listTS = new SelectList(tipoS, "Id", "Nombre");
            ViewData["TS"] = listTS;


            return View();
        }


        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cita cita)
        {
            try
            {
                var p = new CitaApiProcess();

                var existeTurno = p.ToList().Where(x => x.Fecha == cita.Fecha).FirstOrDefault();

                if (existeTurno == null)
                {
                    p.Add(cita);

                    TempData["MessageViewBagName"] = new GenericMessageViewModel
                    {
                        Message = "Registro agregado a la base de datos.",
                        MessageType = GenericMessages.success
                    };

                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MessageViewBagName"] = new GenericMessageViewModel
                    {
                        Message = "Horario NO disponible",
                        MessageType = GenericMessages.danger,
                        ConstantMessage = true
                    };
                    return View(cita);
                }

            }
            catch (Exception ex)
            {
                TempData["MessageViewBagName"] = new GenericMessageViewModel
                {
                    Message = ex.Message,
                    MessageType = GenericMessages.danger,
                    ConstantMessage = true
                };
                return View(cita);
            }
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Find(id);

            SelectList list = new SelectList(cita.TipoEstado);
            ViewData["ListaEstados"] = list;

            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }


        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cita cita)
        {
            if(ModelState.IsValid)
            {
                db.Edit(cita);
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
            Cita cita = db.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Cita cita)
        {
            //Cita cita = db.Find(id);
            cita.ChangedDate = null;
            db.Remove(cita);
            return RedirectToAction("Index", "CitaApi");
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