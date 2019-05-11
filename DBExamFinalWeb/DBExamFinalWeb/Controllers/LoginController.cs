using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBExamFinalWeb.Controllers
{
    public class LoginController : Controller
    {

		private DBExamFinalWeb.Models.DBFinalProjectWebEntities1 db = new Models.DBFinalProjectWebEntities1();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public ActionResult Index(string username, string password)
		{
			List<string> usernameDB = null;
			List<string> passwordDB = null;
			usernameDB = db.Users.Where(x => x.username == username).Select(x => x.username).ToList();
			passwordDB = db.Users.Where(x => x.username == username).Select(x => x.password).ToList();
			try
			{
				if (username.Equals(usernameDB[0]) && password.Equals(passwordDB[0]))
				{

					return RedirectToAction("Index", "Home");
				}
				else
				{
					return View();
				}
			}catch(Exception e)
			{
				return View();
			}
		}

		public ActionResult Signup()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Signup(string first_name, string last_name, string username, string password, int age, string gender)
		{
			return View();
		}


	}

}