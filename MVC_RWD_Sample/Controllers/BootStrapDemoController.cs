using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_RWD_Sample.Controllers
{
    public class BootStrapDemoController : Controller
    {
        public ActionResult Normal_Web_No_RWD()
        {
            //測試無bootstrap RWD的CSS:
            return View();
        }

        // GET: BootStrapDemo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ch1_Container()
        {
            return View();
        }

        public ActionResult Ch2_FlexBox()
        {
            return View();
        }

        public ActionResult Ch3_Text_H1_To_H5()
        {
            return View();
        }        

        public ActionResult Ch4_Table()
        {
            return View();
        }

        public ActionResult Ch5_Image()
        {
            return View();
        }

        public ActionResult Ch6_Jumbotron()
        {
            return View();
        }

        public ActionResult Ch7_Alert()
        {
            return View();
        }
    }
}