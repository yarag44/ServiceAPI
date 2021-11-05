using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goCCSI_API.Models
{
    public class modServicesPermissions
    {

        public int idService { get; set; }

        public int idPermission { get; set; }

        public string Permission { get; set; }

        public int idPermissionType { get; set; }

        public string permissionType { get; set; }

        public int idPersonnalLastModify { get; set; }

    }


    public class modServicesPermissionParams
    {

        public int Option { get; set; }

        public int idService { get; set; }

        public int idPermission { get; set; }



    }


    public class modServicesPermissionID
    {

        public int IdServicePermission { get; set; }

    }



}
