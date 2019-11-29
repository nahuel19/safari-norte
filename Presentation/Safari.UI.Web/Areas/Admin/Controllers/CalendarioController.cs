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
                
                events.Add(new CitaViewModel()
                {
                    id = c.Id,
                    title = "Pacient." + c.PacienteId.ToString(),
                    start = c.Fecha.AddHours(-6).AddDays(1).ToString("yyyy-MM-dd hh:mm "),
                    end = c.Fecha.AddHours(-6).AddMinutes(30).ToString("yyyy-MM-dd hh:mm"),
                    allDay = false
                });
            }


            //for (var i = 1; i <= 5; i++)
            //{
            //    events.Add(new CitaViewModel()
            //    {
            //        id = i,
            //        title = "Event " + i,
            //        start = start.ToString(),
            //        end = end.ToString(),
            //        allDay = false
            //    });

            //    start = start.AddDays(7);
            //    end = end.AddDays(7);
            //}


            return Json(events.ToArray(), JsonRequestBehavior.AllowGet);
        }
    }
}