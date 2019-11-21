using Safari.Entities;
using Safari.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Safari.UI.Web.Controllers
{
    public class MedicoApiController : Controller
    {

        public ViewResult Index(/*string sortOrder, string currentFilter, string searchString, int? page*/)
        {
            var eap = new MedicoApiProcess();
            var lista = eap.ToList();

            //ViewBag.CurrentSort = sortOrder;

            //ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";


            //if (searchString != null)
            //    page = 1;
            //else
            //    searchString = currentFilter;


            //ViewBag.CurrentFilter = searchString;


            //var medicos = from m in lista select m;

            //if (!string.IsNullOrEmpty(searchString))
            //    medicos = medicos.Where(s => s.Apellido.ToLower().Contains(searchString.ToLower()) || s.Nombre.ToLower().Contains(searchString.ToLower()));

            //switch (sortOrder)
            //{
            //    case "name_desc":
            //        medicos = medicos.OrderByDescending(s => s.Apellido);
            //        break;
            //    case "Date":
            //        medicos = medicos.OrderBy(s => s.FechaNacimiento);
            //        break;
            //    default:
            //        medicos = medicos.OrderBy(s => s.Apellido);
            //        break;
            //}


            ////return View(clientes.ToList());
            //int pageSize = 10;
            //int pageNumber = (page ?? 1);
            //return View(medicos.ToPagedList(pageNumber, pageSize));
            return View(lista);
        }

        // GET: Especie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Especie/Create
        [HttpPost]
        public ActionResult Create(Medico medico)
        {
            try
            {
                var ep = new MedicoApiProcess();
                ep.Create(medico);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}