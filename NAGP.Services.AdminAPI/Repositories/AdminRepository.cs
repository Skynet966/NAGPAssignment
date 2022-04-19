using NAGP.Services.AdminAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NAGP.Services.AdminAPI.Repositories
{
    public class AdminRepository
    {
        private readonly List<Admin> admins;

        public AdminRepository()
        {
            admins = new List<Admin>
            {
                new Admin { Id = 1, Name = "Satish", Username = "skynet", Password = "12345" },
                new Admin { Id = 1, Name = "Admin", Username = "admin", Password = "admin123" }
            };
        }
        public bool IsValidAdmin(string username, string password)
        {
            Admin admin= admins.FirstOrDefault(x => x.Username == username && x.Password == password);
            return admin != null;
        }
    }
}
