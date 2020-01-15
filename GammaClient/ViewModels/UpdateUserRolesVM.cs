using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GammaClient.ViewModels
{
    public class UpdateUserRolesVM
    {
        public string RoleId { get; set; }

        public List<AddUserRoleVM> UserRoles { get; set; }
    }
}
