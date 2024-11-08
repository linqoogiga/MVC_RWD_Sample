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

        public ActionResult Ch01_Container()
        {
            return View();
        }

        public ActionResult Ch02_FlexBox()
        {
            return View();
        }

        public ActionResult Ch03_Text_H1_To_H5()
        {
            return View();
        }        

        public ActionResult Ch04_Table()
        {
            return View();
        }

        public ActionResult Ch05_Image()
        {
            return View();
        }

        public ActionResult Ch06_Jumbotron()
        {
            return View();
        }

        public ActionResult Ch07_Alert()
        {
            return View();
        }

        public ActionResult Ch08_Button()
        {
            return View();
        }

        public ActionResult Ch09_Badge()
        {
            return View();
        }

        public ActionResult Ch10_Progress_Bar()
        {
            return View();
        }

        public ActionResult Ch11_Spinner()
        {
            return View();
        }

        public ActionResult Ch12_Pagination()
        {
            return View();
        }

        public ActionResult Ch13_List_Group()
        {
            return View();
        }

        public ActionResult Ch14_Card()
        {
            return View();
        }

        public ActionResult Ch15_DropDownList()
        {
            return View();
        }
    }
}