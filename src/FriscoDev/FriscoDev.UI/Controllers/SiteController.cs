using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FriscoDev.UI.Controllers
{
    public class SiteController : BaseController
    {

        public SiteController()
        {
        }
        // GET: Site
        public ActionResult Index()
        {
           
            return View();
        }
    }
}