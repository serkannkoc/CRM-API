using Company2.Models;
using Company2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company2.Services
{
    public class UserPermissionsService
    {
        private Company2Context _context;
        public UserPermissionsService(Company2Context context)
        {
            _context = context;
        }

        public void AddPermission(UserPermissionsVM userPermission)
        {
            var _userpermission = new UserPermission()
            {
                Type = userPermission.Type,
                CreatedAt = DateTime.Now,
                UpdatedAt = null,
                DeletedAt = null
            };
            _context.UserPermissions.Add(_userpermission);
            _context.SaveChanges();
        }
    }
}
