using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
                    var user = db.User.Find(email);
                    if (user != null)
                    {

                        if (user.Active == true)
                        {
                            return false;
                        }
                    }
                        return true;
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public User SignIn(string username, string password)
        {
            try
            {
                using (MyContext db = new MyContext())
                {

                     return (from user in db.User where user.Email == username.Trim() && user.Password == password.Trim() select user).FirstOrDefault();

                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }
    }
}
