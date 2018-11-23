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
        public ActionResult Index(bool? isAll, string str, string message)
        {
            ViewBag.Message = message;

            List<UserViewModel> users = new List<UserViewModel>();

            if (isAll == null || isAll == true || str == "")
            {
                foreach (var item in db.GetUsers())
                {
                    users.Add(ConvertToUserViewModel(item));
                }
            }
            else
            {
                List<int> range = new List<int>();

                try
                {
                    range = SplitStr(str);
                }
                catch (System.FormatException)
                {
                    return RedirectToAction("Index", new { message = "Use just '-' and ',' to choose users!" });
                }

                int i = 1;

                foreach (var item in db.GetUsers())
                {
                    if (range.Contains(i))
                    {
                        users.Add(ConvertToUserViewModel(item));
                    }

                    i++;
                }
            }

            ViewBag.Users = users;

            return View();
        }

        [HttpGet]
        public ActionResult UserForm(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", new { message = "Choose user!" });
            }
            else
            {
                if (id == 0)
                {
                    return View(new UserViewModel() { IsRegistered = false });
                }

                var model = db.GetUser((int)id);

                return View(ConvertToUserViewModel(model));
            }
        }

        [HttpPost]
        public ActionResult UserForm(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.IsRegistered)
                {
                    if (db.Update(ConvertToUser(model)))
                    {
                        return RedirectToAction("Index");
                    }

                    return RedirectToAction("Index", new { message = "The user was not found in the database!" });
                }

                db.Add(ConvertToUser(model));

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", new { message = "Choose user!" });
            }
            else
            {
                if (db.Delete((int)id))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", new { message = "The user is already deleted!" });
                }
            }
        }

        private User ConvertToUser(UserViewModel model)
        {
            return new User()
            {
                Id = model.Id,
                Name = model.Name,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
                Age = model.Age,
                Phone = model.Phone,
                Address = model.Address
            };
        }

        private UserViewModel ConvertToUserViewModel(User model)
        {
            return new UserViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
                Age = model.Age,
                Phone = model.Phone,
                Address = model.Address,
                IsRegistered = true
            };
        }

        private List<int> SplitStr(string str)
        {
            string[] parts = str.Split(new char[] { ' ', ',' }, System.StringSplitOptions.RemoveEmptyEntries);

            List<int> range = new List<int>();

            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i].Contains("-"))
                {
                    if (parts[i].Length > 1)
                    {
                        string[] parts2 = parts[i].Split(new char[] { '-' }, System.StringSplitOptions.RemoveEmptyEntries);

                        for (int j = System.Convert.ToInt32(parts2[0]); j <= System.Convert.ToInt32(parts2[parts2.Length - 1]); j++)
                        {
                            range.Add(j);
                        }
                    }
                    else if (i > 0 && i < parts.Length - 1)
                    {
                        for (int j = System.Convert.ToInt32(parts[i - 1]); j < System.Convert.ToInt32(parts[i + 1]); j++)
                        {
                            range.Add(j);
                        }
                    }
                }
                else
                {
                    range.Add(System.Convert.ToInt32(parts[i]));
                }
            }

            return range;
        }
    }
}