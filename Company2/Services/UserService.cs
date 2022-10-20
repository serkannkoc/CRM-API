using Company2.Models;
using Company2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company2.Services
{
    public class UserService
    {
        public Company2Context _context;
        public UserService(Company2Context context)
        {
            _context = context;
        }
        //public UserVM GetUserById(int userId)
        //{

        //    var _user = _context.Users.Where(n => n.Id == userId).Select(user => new UserVM()
        //    {
        //        Name = user.UserInformations.Select(n => n.Name).FirstOrDefault(),
        //        Surname = user.UserInformations.Select(n => n.Surname).FirstOrDefault(),
        //        Email = user.Email,
        //        Password = user.Password,
        //        FullAddress = user.UserInformations.Select(n => n.FullAddress).FirstOrDefault(),
        //        City = user.UserInformations.Select(n => n.City).FirstOrDefault(),
        //        Country = user.UserInformations.Select(n => n.Country).FirstOrDefault(),
        //        Type = user.UserPermission.Type,
        //        CreatedAt = user.CreatedAt,
        //        UpdatedAt = user.UpdatedAt
        //    }).FirstOrDefault();



        //    return _user;
        //}
        public User GetUserById(int userId)
        {

            var _user = _context.Users.Where(n => n.Id == userId).Select(user => new User()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                UserPermissionId = user.UserPermissionId,
                UserPermission = user.UserPermission,
                
                UserInformations = user.UserInformations,
                Sales = user.Sales,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                DeletedAt = user.DeletedAt

            }).FirstOrDefault();



            return _user;
        }
        public UserInformation UpdateUserInformationById(int userId,UserInformationVM userInformation) 
        {
            var _userInformation = _context.UserInformations.FirstOrDefault(n => n.UserId == userId);
            if(_userInformation != null) 
            {
                _userInformation.Name = userInformation.Name;
                _userInformation.Surname = userInformation.Surname;
                _userInformation.FullAddress = userInformation.FullAddress;
                _userInformation.City = userInformation.City;
                _userInformation.Country = userInformation.Country;
                _userInformation.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
            }
            return _userInformation;
        }
        public void DeleteUserInformationById(int userId) 
        {
            var _user = _context.UserInformations.FirstOrDefault(n => n.UserId == userId);
            if(_user != null) 
            {
                _context.UserInformations.Where(r => r.UserId == userId).FirstOrDefault().DeletedAt = DateTime.Now;
                _context.SaveChanges();
            }
        }
    }
}
