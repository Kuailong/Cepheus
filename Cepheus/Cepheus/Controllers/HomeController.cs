using Cepheus.Entities;
using Cepheus.Infrastructure;
using Cepheus.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cepheus.Controllers
{
    public class HomeController : Controller
    {
        private Repository<User> _repository;
        private DbContext _context; 

        public HomeController()
        {
            this._context = new CepheusContext();
            this._repository = new Repository<User>(_context);
        }

        public ActionResult Index()
        {
            var model = new HomeModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(HomeModel model)
        {
            var existingUser = this._repository.Get(e => e.NameUser == model.User).FirstOrDefault();
            if (existingUser != null)
                return View("Invalid");

            var key = CriptoHelper.CreateKey(model.User, model.Password);

            var user = new User() { NameUser = model.User, Key = key };
            this._repository.Add(user);
            this._context.SaveChanges();

            return View("Done");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this._context.Dispose();
        }
    }
}
