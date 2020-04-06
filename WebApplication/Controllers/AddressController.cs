using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Controllers
{ // [Route("address")]
    [Authorize]
    public class AddressController : Controller
    {
        AddressUserContext db;

        public AddressController(AddressUserContext db)
        {
            this.db = db;
        }

        [HttpGet("address")]
        public ActionResult Index(string sortBy, string search)
        {
            IEnumerable<Address> list;
            if (!UserIsAdmin())
            {
                //ViewBag.idSortParm = String.IsNullOrEmpty(sortBy) ? "id" : "";

                list = GetDataAddressesFromUser();
            }
            else
            {
                list = GetAllAddresses();
            }

            if (!String.IsNullOrEmpty(search))
            {
                list = SearchBy(search).ToList();
            }

            if (sortBy == "id" || String.IsNullOrEmpty(sortBy))
            {
                sortBy = "address_id";
            }

            list = list.OrderBy(o => o.GetType().GetProperty(sortBy)?.GetValue(o)).ToList();

            return View(list);
        }

        [HttpGet("address/{id:int}")]
        public ActionResult GetAddress(int id)
        {
            if (!UserHasAddress(id))
            {
                return NotFound();
            }

            var addressItem = GetAddressById(id);
            if (addressItem == null)
            {
                return NotFound();
            }

            return View(addressItem);
            //    return Content(db.Addresses.FirstOrDefault(s => s.address_id == id).ToString());
        }

        [HttpGet]
        public ActionResult EditAddress(int? id)
        {
            if (!(UserHasAddress(id) || UserIsAdmin()))
            {
                return NotFound();
            }

            if (id == null)
            {
                return NotFound();
            }

            Address address = GetAddressById(id);
            if (address != null)
            {
                return View(address);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult EditAddress(Address curAddress)
        {
            if (ModelState.IsValid)
            {
                Address oldAddress = GetAddressById(curAddress.address_id);
                oldAddress.address_id = curAddress.address_id;
                oldAddress.surname = curAddress.surname;
                oldAddress.address = curAddress.address;
                oldAddress.building = curAddress.building;
                oldAddress.rent = curAddress.rent;

                db.Entry(oldAddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(curAddress);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Address a)
        {
            if (db.Addresses.ToList().Exists(x => x.address_id == a.address_id))
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                db.AddressUsers.Add(new AddressUser
                {
                    address_id = a.address_id, user_id = GetUserId()
                });

                //a.AddressUsers.Add(new AddressUser{address_id = a.address_id, user_id = userId});
                db.Entry(a).State = EntityState.Added;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(a);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (!(UserHasAddress(id) || UserIsAdmin()))
            {
                return NotFound();
            }

            Address b = GetAddressById(id);
            if (b == null)
            {
                return NotFound();
            }

            return View(b);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Address b = GetAddressById(id);
            if (b == null)
            {
                return NotFound();
            }

            db.Addresses.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public HashSet<Address> SearchBy(string s)
        {
            var searchingObject = new HashSet<Address>();
            IEnumerable<Address> list;
            if (UserIsAdmin())
            {
                list = GetAllAddresses();
            }
            else
            {
                list = GetDataAddressesFromUser();
            }

            foreach (var obj in list)
            {
                var properties = obj.GetType().GetProperties();
                foreach (var prop in properties)
                {
                    if (Convert.ToString(prop.GetValue(obj)).Contains(s))
                    {
                        searchingObject.Add(obj);
                    }
                }
            }

            return searchingObject;
        }

        public int GetUserId()
        {
            string userEmail = User.Identity.Name;
            User user = db.Users.FirstOrDefault(u => u.email == userEmail);
            Debug.Assert(user != null, nameof(user) + " != null");
            return user.user_id;
        }

        public IEnumerable<Address> GetDataAddressesFromUser()
        {
            var list = (from r in db.Addresses
                join c in db.AddressUsers on r.address_id equals c.address_id
                where c.user_id == GetUserId()
                select r).AsEnumerable();
            return list;
        }

        public bool UserHasAddress(int? id)
        {
            AddressUser addressUser = db.AddressUsers.FirstOrDefault(u => u.address_id == id);
            if (addressUser == null)
            {
                return false;
            }

            return true;
        }

        public Address GetAddressById(int? id)
        {
            return db.Addresses.Find(id);
        }

        public IEnumerable<Address> GetAllAddresses()
        {
            return db.Addresses.ToList();
        }

        public bool UserIsAdmin()
        {
            return User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value == "admin";
        }
    }
}