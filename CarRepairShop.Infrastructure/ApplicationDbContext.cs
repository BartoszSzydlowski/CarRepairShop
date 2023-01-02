using CarRepairShop.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairShop.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

    }
}
