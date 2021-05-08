using Microsoft.AspNetCore.Mvc;
using RegisterAndLoginApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterAndLoginApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessLogin(UserModel userModel)
        {
            if (userModel.UserName == "BillGates" && userModel.Password == "bigbucks")
            {
                return View("LoginSucces", userModel);
            }
            else
            {
                return View("LoginFailure", userModel);
            }
            
        }
    }
}
