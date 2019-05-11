using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBExamFinalWeb.Models;

namespace DBExamFinalWeb.Controllers
{
	public class LoginController : Controller
	{

		private DBFinalProjectWebEntities1 db = new DBFinalProjectWebEntities1();

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
			} catch (Exception e)
			{
				return View();
			}
		}

		public ActionResult Signup()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Signup([Bind(Include ="first_name, last_name, username, password, age, gender")]Users user)
		{
			try
			{
				if (ModelState.IsValid)
				{
					db.Users.Add(user);
					db.SaveChanges();
					return RedirectToAction("Index");
				}
			}
			catch (Exception e)
			{
				//Log the error (uncomment dex variable name and add a line here to write a log.
				ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
			}

			return View(user);
		}


	}

}