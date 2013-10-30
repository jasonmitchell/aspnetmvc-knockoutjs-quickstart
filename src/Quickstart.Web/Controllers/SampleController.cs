using System;
using System.Web.Mvc;
using Quickstart.Web.ActionResults;
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
            Person model = CreateModel();
            return View(model);
        }

        public ActionResult DynamicModelLoading()
        {
            Person model = CreateModel();
            return View(model);
        }

        public ActionResult DynamicModelLoadingWithClientSideFunctions()
        {
            Person model = CreateModel();
            return View(model);
        }

        public ActionResult AjaxModelLoading()
        {
            Person model = CreateRandomModel();

            if (Request.IsAjaxRequest())
            {
                return new JsonNetResult(model);
            }

            return View(model);
        }

        private static Person CreateModel()
        {
            return new Person
            {
                FirstName = "Jason",
                LastName = "Mitchell",
                EmailAddress = "contact@jason-mitchell.com",
                PhoneNumber = "0123456789",
                DateOfBirth = DateTime.Today.AddYears(-25)
            };
        }

        private static Person CreateRandomModel()
        {
            Random random = new Random();
            string[] firstNames = { "Jason", "John", "Dave", "Steve" };
            string[] lastNames = { "Mitchell", "Brown", "White", "Smith" };

            string firstName = firstNames[random.Next(firstNames.Length)];
            string lastName = lastNames[random.Next(lastNames.Length)];

            return new Person
            {
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = string.Format("{0}@{1}.com", firstName, lastName),
                PhoneNumber = random.Next(int.MaxValue).ToString("D10"),
                DateOfBirth = DateTime.Today.AddYears(random.Next(-50, -10))
            };
        }
    }
}
