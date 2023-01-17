using CarRepairShop.Application.Common.Responses;
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
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.MobilePhone, user.PhoneNumber ?? ""),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Surname, user.Surname),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var userRoles = await _userManager.GetRolesAsync(user);
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    claims: authClaims,
                    expires: DateTime.Now.AddHours(2),
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
            throw new AuthenticationException("Wrong username or password");
        }

        public async Task<BaseResponse> RegisterUser(RegisterRequest request)
        {
            return await Register(request, UserRoles.User);
        }

        public async Task<BaseResponse> RegisterAdmin(RegisterRequest request)
        {
            return await Register(request, UserRoles.Admin);
        }

        private async Task<BaseResponse> Register(RegisterRequest request, string userRole)
        {
            var userExists = await _userManager.FindByNameAsync(request.Email);
            if (userExists != null)
            {
                throw new ValidationException("User already exists");
            }

            if (string.IsNullOrEmpty(request.Name))
            {
                throw new ValidationException("Name is empty");
            }

            if (string.IsNullOrEmpty(request.Surname))
            {
                throw new ValidationException("Surname is empty");
            }

            if (request.Password == request.ConfirmPassword)
            {
                var user = new ApplicationUser()
                {
                    Email = request.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    Name = request.Name,
                    Surname = request.Surname
                };

                var result = await _userManager.CreateAsync(user, request.Password);
                if (!result.Succeeded)
                {
                    throw new Exception("Failed to create user");
                }

                if (!await _roleManager.RoleExistsAsync(userRole))
                {
                    await _roleManager.CreateAsync(new IdentityRole(userRole));
                }

                await _userManager.AddToRoleAsync(user, userRole);

                return new BaseResponse();
            }

            throw new ValidationException("Passwords don't match");
        }
    }
}