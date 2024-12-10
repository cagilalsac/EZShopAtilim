using BLL.Controllers.Bases;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class UsersController : MvcController
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Login(UserModel user)
        {
            return Json(user);
        }
    }
}
