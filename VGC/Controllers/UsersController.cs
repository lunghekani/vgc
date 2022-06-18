using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VGC;
using VGC.Models;

namespace VGC.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UsersController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Users> objList = _db.User;
            return View(objList);
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Users obj)
        {
            if (ModelState.IsValid)
            {
                _db.User.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET - EDIT
        public IActionResult Edit(int? UserId)
        {
            if (UserId == null || UserId == 0)
            {
                return NotFound();
            }
            var obj = _db.User.Find(UserId);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Users obj)
        {
            if (ModelState.IsValid)
            {
                _db.User.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET - DELETE
        public IActionResult Delete(int? UserId)
        {
            if (UserId == null || UserId == 0)
            {
                return NotFound();
            }
            var obj = _db.User.Find(UserId);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? UserId)
        {
            var obj = _db.User.Find(UserId);
            if (obj == null)
            {
                return NotFound();
            }

            _db.User.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
