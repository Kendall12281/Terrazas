using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Security
{
    public class Session
    {
        public static User userSigned = new User();
        public static void CreateSession(User user)
        {
            userSigned.Active = user.Active;
            userSigned.Email = user.Email;
            userSigned.IdRol = user.IdRol;
        }

        public static void DeleteSession(User user)
        {
            userSigned = null;
        }
    }
}