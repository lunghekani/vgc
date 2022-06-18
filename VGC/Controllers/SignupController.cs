using Microsoft.AspNetCore.Mvc;
using VGC;
using VGC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VGC.Controllers
{
    public class SignupController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SignupController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Signup()
        {
            IEnumerable<Users> objList = _db.User;
            return View(objList);
        }

        //GET - Signup
        public IActionResult SignupUser()
        {
            return View();
        }

        //POST - Signup
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignupUser(Users obj)
        {
            if (ModelState.IsValid)
            {
                _db.User.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Signup");
            }
            return View(obj);
        }
    }
}