using MVCCrud.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCEntityCrud.DAL
{
    public class Login_DAL
    {
        public bool ValidateLogin(Login login)
        {
            using (var context = new DbContext())
            {
                return context.Login.Any(e => e.Username == login.Username && e.Password == login.Password);
            }
        }

    }
}