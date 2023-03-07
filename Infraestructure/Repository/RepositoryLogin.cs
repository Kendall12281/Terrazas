using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryLogin : IRepositoryLogin
    {
        public bool IsUserDisabled(string email)
        {
            try
            {
                using (MyContext db = new MyContext())
                {
                    if (db.User.Find(email).Active == true)
                    {
                        return false;
                    }
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public User SignIn(string username, string password)
        {
            try
            {
                using (MyContext db = new MyContext())
                {

                    var oUser = (from user in db.User
                                 where user.Email == username.Trim()
                                 && user.Password == password.Trim()
                                 select user).FirstOrDefault();

                    return oUser;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
