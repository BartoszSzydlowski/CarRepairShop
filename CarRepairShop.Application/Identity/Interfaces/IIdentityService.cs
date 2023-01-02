using CarRepairShop.Application.Common;
using CarRepairShop.Application.Identity.Requests;
using CarRepairShop.Application.Identity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairShop.Application.Identity.Interfaces
{
    public interface IIdentityService
    {
        Task<Response<TokenViewModel>> Login(LoginRequest request);
    }
}
