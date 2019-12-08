using Ganache.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ganache.API.Dtos.User
{
    public class UserInfo
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public int Credit { get; set; }

        public Wallet[] Wallets { get; set; }
    }
}
