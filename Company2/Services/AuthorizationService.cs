using Company2.Models;
using Company2.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Company2.Services
{
    public class AuthorizationService
    {
        private Company2Context _context;
        private IConfiguration _config;
        public AuthorizationService(Company2Context context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public void Register(RegisterVM register)
        {
            if (register.Hash.Equals(_context.PreRegistrations.Where(n => n.Email.Equals(register.Email)).Select(x => x.Hash).FirstOrDefault()))
            {
                if (_context.PreRegistrations.Where(n => n.Email.Equals(register.Email)).Select(x => x.EndDate).FirstOrDefault() > DateTime.Now)
                {
                    var _user = new User()
                    {
                        UserPermissionId = register.UserPermissionId,
                        Email = register.Email,
                        Password = register.Password,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = null,
                        DeletedAt = null,

                    };
                    _context.Users.Add(_user);
                    _context.SaveChanges();
                    var _userInformation = new UserInformation()
                    {
                        UserId = _user.Id,
                        Name = register.Name,
                        Surname = register.Surname,
                        FullAddress = register.FullAddress,
                        City = register.City,
                        Country = register.Country,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = null,
                        DeletedAt = null,
                    };
                    _context.UserInformations.Add(_userInformation);
                    _context.SaveChanges();
                    _context.PreRegistrations.Where(r => r.Hash.Equals(register.Hash)).FirstOrDefault().DeletedAt = DateTime.Now;
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Hash süreniz doldu tekrar preregister olun!");
                }

            }
            else
            {
                throw new Exception("Hash değeriniz veya email adresiniz eşleşmiyor. Tekrar deneyiniz.");
            }

        }

        public string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {       
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name,user.Id.ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        // With this method we check whether the username and password is correct.
        public User Authenticate(UserLoginVM userLogin)
        {
            var currentUser = _context.Users.FirstOrDefault(o => o.Email == userLogin.Email && o.Password == userLogin.Password);

            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
        }
    }
}
