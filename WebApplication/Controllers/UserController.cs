using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class UserController : Controller
    {
        AddressUserContext db;

        public UserController(AddressUserContext context)
        {
            db = context;
        }

        [HttpGet("User")]
        public ActionResult Index()
        {
            if (User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value == "creator")
            {
                IEnumerable<User> list = db.Users.ToList();
                list = list.Where(user => user.role != "creator").OrderBy(user => user.user_id);
                return View(list);
            }

            return NotFound();
        }

        [HttpGet]
        public ActionResult Active(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User address = db.Users.Find(id);
            if (address != null)
            {
                return View(address);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult Active(User user)
        {
            User curUser = db.Users.Find(user.user_id);
            curUser.active = user.active;
            db.Entry(curUser).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult GetUserData(int id)
        {
            IEnumerable<Address> list;
            User user = db.Users.Find(id);
            if (user.role == "admin")
            {
                list = db.Addresses.ToList();
            }
            else
            {
                list = (from r in db.Addresses
                    join c in db.AddressUsers on r.address_id equals c.address_id
                    where c.user_id == id
                    select r).AsEnumerable();
            }

            return View(list);
        }
    }
}