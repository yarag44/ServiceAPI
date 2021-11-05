using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goCCSI_API.Models
{
    public class modRolesServices
    {
        public int idRole { get; set; }

        public int idService { get; set; }

        public string Service { get; set; }

        public DateTime LastModifyDate { get; set; }

        public int idPersonnalLastModify { get; set; }
    }

    public class modRolesServicesParams
    {
        public int Option { get; set; }

        public int idRole { get; set; }

        public int idService { get; set; }

    }

    public class modRolesServicesID
    {
        public int IdRoleService { get; set; }

    }


}
