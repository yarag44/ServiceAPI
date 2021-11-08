using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goCCSI_API.Models
{
    public class modRoles
    {

        public int IdRole { get; set; }

        public string Role { get; set; }

        public int IdPersonnalInsert { get; set; }


    }

    public class modRolesID
    {
        public int IdRole { get; set; }

    }


    public class modRolesParams
    {

        public int Option { get; set; }

        public int IdRole { get; set; }

        public string Role { get; set; }

        public int IdPersonnal { get; set; }

    }

    public class modDeleteRolesParams
    {

        public int IdRole { get; set; }

        public int IdPersonnal { get; set; }

    }





}
