using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGeneration;
using RegisterAndLoginApp.Models;
using RegisterAndLoginApp.Services;
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
        [HttpGet]
        [CustomAuthorization]
        public  IActionResult PrivateSectionMustBeLoggedIn()
        {
            return Content("I am protected gay");
        }
       
        public IActionResult ProcessLogin(UserModel userModel)
        {
            

            SecurityService securityService = new SecurityService();
            if (securityService.IsValid(userModel))
            {
                HttpContext.Session.SetString("username", userModel.UserName);
                return View("LoginSucces", userModel);
            }
            else
            {
                HttpContext.Session.Remove("username");
                return View("LoginFailure", userModel);
            }
            
        }
    }
}
