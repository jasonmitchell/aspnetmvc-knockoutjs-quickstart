using System;
using System.Web.Mvc;
using Quickstart.Web.Models;

namespace Quickstart.Web.Controllers
{
    public class SampleController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SimpleModelLoading()
        {
            Person model = new Person
            {
                FirstName = "Jason",
                LastName = "Mitchell",
                EmailAddress = "contact@jason-mitchell.com",
                PhoneNumber = "0123456789",
                DateOfBirth = DateTime.Today.AddYears(-25)
            };

            return View(model);
        }
    }
}
