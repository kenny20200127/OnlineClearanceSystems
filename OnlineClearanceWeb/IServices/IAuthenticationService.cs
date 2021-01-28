using OnlineClearanceCore.Core.Entities;
using OnlineClearanceCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineClearanceWeb.IServices
{
    public interface IAuthenticationService
    {
        Task<ResponseModel<User>> SignInUserAsync(string email, string password, string client);
        Task SignOutUserAsync();
    }
}
