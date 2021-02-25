using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesStatistics.Models
{
    public class User : IdentityUser
    {
        //Here you can add new fields for the user
        //But we have enough functionality from IdentityUser
    }
}
