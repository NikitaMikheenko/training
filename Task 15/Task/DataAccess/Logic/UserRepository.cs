using DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Logic
{
    public class UserRepository
    {
        public void Add(User model)
        {
            using (var db = new UserContext())
            {
                db.Users.Add(model);

                db.SaveChanges();
            }
        }

        public bool Update(User model)
        {
            using (var context = new UserContext())
            {
                var user = context.Users.Find(model.Id);

                if (user != null)
                {
                    user.Name = model.Name;
                    user.MiddleName = model.MiddleName;
                    user.LastName = model.LastName;
                    user.Age = model.Age;
                    user.Phone = model.Phone;
                    user.Address = model.Address;

                    context.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool Delete(int id)
        {
            using (var db = new UserContext())
            {
                var user = db.Users.Find(id);

                if (user != null)
                {
                    db.Users.Remove(user);

                    db.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public User GetUser(int id)
        {
            using (var db = new UserContext())
            {
                var user = db.Users.Find(id);

                return user;
            }
        }

        public IEnumerable<User> GetUsers()
        {
            using (var db = new UserContext())
            {
                var users = db.Users.ToList();

                return users;
            }
        }
    }
}
