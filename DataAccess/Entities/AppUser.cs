using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class AppUser : IdentityUser
    {   //custom properties
        //public string? SecondName { get; set; }
        //public string? FirstName { get; set; }
        //public DateTime Birthdate { get; set; }
       // public ICollection<Order>? Orders { get; set; }
    }
}
