using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication_MVC_Working.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Environment = GetConfigSettings("Environment");

            return View();
        }

         
        public static string GetConfigSettings(string key)
        {
            try
            {
                string value = ConfigurationManager.AppSettings[key].ToString();
                if (value.Length == 0)
                {
                    throw new ApplicationException("key is not exists in config file");
                }
                return (value);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error while trying to get value from config file - " + key + ". " + ex.Message);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}