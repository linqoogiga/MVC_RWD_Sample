using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_RWD_Sample.Controllers
{
    public class JSChartController : Controller
    {
        // GET: JSChart
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Pie_Chart()
        {
            return View();
        }

        public ActionResult Pie_Chart_2()
        {
            return View();
        }

        public ActionResult Line_Chart()
        {
            return View();
        }

        public ActionResult Mix_Chart()
        {
            return View();
        }

        public ActionResult Bar_Chart_DataLabel()
        {
            return View();
        }

        public ActionResult Bar_Chart_Single()
        {
            return View();
        }        
    }
}