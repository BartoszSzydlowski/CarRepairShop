using CarRepairShop.Application.Common;
using CarRepairShop.Application.Identity.Interfaces;
using CarRepairShop.Application.Identity.Requests;
using CarRepairShop.Application.Identity.ViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;

namespace CarRepairShop.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public IdentityService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }

        public async Task<Response<TokenViewModel>> Login(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Email);
            var result = await _userManager.CheckPasswordAsync(user, request.Password);

            if (user != null && result)
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.MobilePhone, user.PhoneNumber ?? ""),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                //var userRoles = await _userManager.GetRolesAsync(user);
                //foreach (var userRole in userRoles)
                //{
                //    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                //}

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    expires: DateTime.Now.AddHours(2),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return new Response<TokenViewModel>
                {
                    Data = new TokenViewModel
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        ExpirationDate = token.ValidTo
                    }
                };
            }
            throw new AuthenticationException();
        }

        public async Task<BaseResponse> Register(RegisterRequest request)
        {
            var userExists = await _userManager.FindByNameAsync(request.Email);
            if (userExists != null)
            {
                throw new ValidationException("User already exists");
            }

            if (request.Password == request.ConfirmPassword)
            {
                var user = new ApplicationUser()
                {
                    Email = request.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = request.Email,
                    PhoneNumber = request.PhoneNumber
                };

                var result = await _userManager.CreateAsync(user, request.Password);
                if (!result.Succeeded)
                {
                    throw new Exception("Failed to create user");
                }

                return new BaseResponse();
            }

            throw new ValidationException("Passwords don't match");
        }
    }
}