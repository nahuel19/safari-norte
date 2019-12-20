using Safari.UI.Process;
using Safari.UI.Web.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Safari.UI.Web.Areas.Admin.Controllers
{
    public class CalendarioController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new CitaViewModel());
        }

        public JsonResult GetEvents(DateTime start, DateTime end)
        {
            //var viewModel = new CitaViewModel();
            var events = new List<object>();

            var citas = new CitaApiProcess().ToList();

            foreach(var c in citas)
            {
                var paciente = new PacienteApiProcess().ReadBy(c.PacienteId);
                var cliente = new ClienteApiProcess().ReadBy(paciente.ClienteId);
                
                events.Add(new CitaViewModel()
                {
                    id = c.Id,
                    title = cliente.Apellido.ToString(),
                    start = c.Fecha.AddDays(1).AddHours(-5).ToString("yyyy-MM-dd hh:mm "),
                    //end = c.Fecha.AddHours(-5).AddMinutes(30).ToString("yyyy-MM-dd hh:mm"),
                    allDay = false

                    
                });
            }

            return Json(events.ToArray(), JsonRequestBehavior.AllowGet);
        }
    }
}