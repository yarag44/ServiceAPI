using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goCCSI_API.Models
{
    public class modRoles
    {

        public int idRole { get; set; }

        public string Role { get; set; }

        public int idPersonnalInsert { get; set; }


    }


    public class modRolesParams
    {

        public int Option { get; set; }

        public int IdRole { get; set; }

        public string Role { get; set; }



    }





}
