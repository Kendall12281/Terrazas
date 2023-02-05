using Infraestructure.Model;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceLogin : IServiceLogin
    {
        public bool IsUserDisabled(string email)
        {
            IRepositoryLogin respository = new RepositoryLogin();
            return respository.IsUserDisabled(email);
        }

        public User SignIn(string username, string password)
        {
            IRepositoryLogin respository = new RepositoryLogin();
            return respository.SignIn(username, password);
        }
    }
}
