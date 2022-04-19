using Microsoft.AspNetCore.Mvc;
using NAGP.Services.AdminAPI.Repositories;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NAGP.Services.AdminAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminRepository adminRepository;
        public AdminController()
        {
            adminRepository = new AdminRepository();
        }

        [HttpPost("Login")]
        public string Login(string username, string password)
        {
            return adminRepository.IsValidAdmin(username, password) ? "Welcome" : "Username or password not correct!!!";
        }
    }
}
