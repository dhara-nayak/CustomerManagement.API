using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace CustomerManagement.Application.DTOs
{
    public class AddCustomerDto
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = ""; 
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Address { get; set; } = "";
        public DateTime DateOfBirth { get; set; }
       
        public string? Password { get; set; }
    }
}


 
//DTO - Keeps API contract seperate from domain, You can envolve domain without breaking public API.