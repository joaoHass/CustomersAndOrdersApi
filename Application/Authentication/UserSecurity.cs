using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Users;

namespace Application.Authentication
{
    public class UserSecurity
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Password { get; set; }
    }
}
