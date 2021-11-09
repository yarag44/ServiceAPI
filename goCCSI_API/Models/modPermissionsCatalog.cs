using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goCCSI_API.Models
{
    public class modPermissionsCatalog
    {
        public int idPermissionCatalog { get; set; }

        public string permissionType { get; set; }

        public bool Active { get; set; }

        public bool ActiveSystem { get; set; }

        public DateTime InsertDate { get; set; }

        public DateTime LastModifyDate { get; set; }
    }

    public class modPermissionsCatalogSelect
    {
        public int idPermissionCatalog { get; set; }

        public string permissionType { get; set; }

    }
}
