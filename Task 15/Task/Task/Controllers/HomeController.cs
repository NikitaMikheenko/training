using System.Web.Mvc;
using Task.Models;
using DataAccess.Logic;
using DataAccess.Entities;
using System.Collections.Generic;

namespace Task.Controllers
{
    public class HomeController : Controller
    {
        private UserRepository db = new UserRepository();

        // GET: Home
        public ActionResult Index(bool? isAll, string range, string message)
        {
            ViewBag.Message = message;

            List<UserViewModel> users = new List<UserViewModel>();

            if (isAll == null || isAll == true)
            {
                foreach (var item in db.GetUsers())
                {
                    users.Add(new UserViewModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        MiddleName = item.MiddleName,
                        LastName = item.LastName,
                        Email = item.Email,
                        Password = item.Password,
                        Age = item.Age,
                        Phone = item.Phone,
                        Address = item.Address
                    });
                }
            }
            else
            {
                string[] only = range.Split(new char[] { ' ', ',', '-' }, System.StringSplitOptions.RemoveEmptyEntries);

                List<int> elements = new List<int>();

                foreach (var item in only)
                {
                    elements.Add(System.Convert.ToInt32(item));
                }

                int i = 1;

                foreach (var item in db.GetUsers())
                {
                    if (elements.Contains(i))
                    {
                        users.Add(new UserViewModel()
                        {
                            Id = item.Id,
                            Name = item.Name,
                            MiddleName = item.MiddleName,
                            LastName = item.LastName,
                            Email = item.Email,
                            Password = item.Password,
                            Age = item.Age,
                            Phone = item.Phone,
                            Address = item.Address
                        });
                    }

                    i++;
                }
            }

            ViewBag.Users = users;

            return View();
        }

        [HttpGet]
        public ActionResult UserForm()
        {
            ViewBag.Add = true;

            return View();
        }

        [HttpPost]
        public ActionResult UserForm(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home", new { message = "Choose user!"});
            }
            else
            {
                ViewBag.Add = false;

                var model = db.GetUser((int)id);

                return View(new UserViewModel()
                {
                    Name = model.Name,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password,
                    Age = model.Age,
                    Phone = model.Phone,
                    Address = model.Address
                });
            }
        }

        [HttpPost]
        public ActionResult Add(UserViewModel model)
        {
            db.Add(new User()
            {
                Name = model.Name,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
                Age = model.Age,
                Phone = model.Phone,
                Address = model.Address
            });

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(UserViewModel model)
        {
            if (db.Update(new User(){
                Id = model.Id,
                Name = model.Name,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
                Age = model.Age,
                Phone = model.Phone,
                Address = model.Address
            }))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Home", new { message = "The user was not found in the database!" });
            }
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home", new { message = "Choose user!" });
            }
            else
            {
                if (db.Delete((int)id))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", "Home", new { message = "The user is already deleted!" });
                }
            }
        }
    }
}