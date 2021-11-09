using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goCCSI_API.Models
{
    public class modPermissionsDetail
    {

        public int idPermissionDetail { get; set; }

        public int idPermission { get; set; }
        
        public string Permission { get; set; }

        public int idPermissionCatalog { get; set; }
        
        public string permissionType { get; set; }

    }

    public class modPermissionDetailParams
    {
        public int Option { get; set; }

        public int idPermission { get; set; }

        public int idPermissionCatalog { get; set; }

    }

    public class modPermissionDetailID
    {
        public int idPermissionDetail { get; set; }

    }
}
