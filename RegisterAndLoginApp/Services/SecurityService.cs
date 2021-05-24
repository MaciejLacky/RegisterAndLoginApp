using RegisterAndLoginApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterAndLoginApp.Services
{
    public class SecurityService
    {
        public List<UserModel> users = new List<UserModel> { new UserModel {Id = 1, Password = "bigbucks", UserName = "BillGates" } };

        public bool IsValid(UserModel user)
        {
            foreach (var item in users)
            {
                if (user.Password == item.Password & user.UserName == item.UserName)
                {
                    return true;
                } 
            }

            return false;
         
        }
        
        
    }
}