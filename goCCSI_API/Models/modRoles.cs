using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goCCSI_API.Models
{
    public class modRolesParams
    {

        public int idRole { get; set; }

        public string Role { get; set; }

        public int idPersonnal { get; set; }


    }


    public class modRolesID
    {

        public int idRole { get; set; }

    }


    public class modRolesSelect
    {

        public int Option { get; set; }

        public int idRole { get; set; }

        public string Role { get; set; }


    }


    public class modRolesSelectReturn
    {

        public int idRole { get; set; }

        public string Role { get; set; }

        public int idPersonnalLastModify { get; set; }



    }



 }
