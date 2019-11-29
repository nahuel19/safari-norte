using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Safari.UI.Web.Areas.Admin.ViewModels
{
    public class CitaViewModel
    {
        public Int64 id { get; set; }

        public String title { get; set; }

        public String start { get; set; }

        public String end { get; set; }

        public bool allDay { get; set; }
    }

    
}