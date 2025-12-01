using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Address { get; set; } = "";
        public DateTime DateOfBirth { get; set; }

        public String PasswordHash { get; set; } = "";

        // Navigation
        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
 