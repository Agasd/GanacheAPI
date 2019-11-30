using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ganache.API.Models
{
    public class UserViewModel
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public int credit { get; set; }

        public UserViewModel(User user)
        {
            this.id = user.Id;
            this.username = user.Username;
            this.email = user.Email;
            this.credit = user.Credit;
        }
    }
}