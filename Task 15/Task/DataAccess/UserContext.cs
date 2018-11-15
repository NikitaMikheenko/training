using DataAccess.Entities;
using System.Data.Entity;

namespace DataAccess
{
    class UserContext: DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
