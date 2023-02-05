﻿using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceLogin
    {
        bool IsUserDisabled(string email);
        User SignIn(string username, string password);

    }
}
