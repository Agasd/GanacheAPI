using Ganache.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ganache.API.Data
{
    public interface IUserRepository
    {
        Task<User> GetUserInfo(String username);
    }
}
