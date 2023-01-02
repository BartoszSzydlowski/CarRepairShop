using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairShop.Application.Identity.ViewModels
{
    public class TokenViewModel
    {
        public string Token { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
