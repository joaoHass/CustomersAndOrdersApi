using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    public class User
    {
        public int Id { get; set; }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (value == null)
                    throw new ArgumentNullException("User name cannot be set null");
            }
        }
    }
}
