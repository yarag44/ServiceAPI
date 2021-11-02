using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goCCSI_API.Models
{
    public class modRolesPermissionsParams
    {

        public int Option { get; set; }

        public int IdRole { get; set; }

        public int idPermission { get; set; }


    }


    public class modRolesPermissions
    {

        
        public int IdRole { get; set; }

        public int idPermission { get; set; }


    }

    public class modRolesPermissionsID
    {

        public int idRolePermission { get; set; }


    }









}
