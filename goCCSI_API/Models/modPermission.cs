using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goCCSI_API.Models
{
    public class modPermission
    {

        public int idPermission { get; set; }

        public string Permission { get; set; }

        public int idPermissionType { get; set; }

        public int idPersonnalInsert { get; set; }


    }


    public class modPermissionParams
    {

        public int idPermission { get; set; }

        public string Permission { get; set; }

        public int idPermissionType { get; set; }

        public int idPersonnalInsert { get; set; }


    }



    public class modPermissionSelect
    {

        public int idPermission { get; set; }

        public string Permission { get; set; }

        public int idPermissionType { get; set; }

        public int idPersonnalInsert { get; set; }

        public int idPersonnalLastModify { get; set; }

        public string PermissionType { get; set; }


    }


    public class modPermissionSelectParams
    {

        public int Option { get; set; }
        public int idPermission { get; set; }
        public string Permission { get; set; }


    }
    public class modidPermission
    {
        public int idPermission { get; set; }

    }


    public class modDeletePermissionParams
    {
        public int idPermission { get; set; }

    }


    public class modSelectPermissionByIdPersonnalParams
    {
        public int Option { get; set; }

        public int IdPersonnal { get; set; }



    }


    public class modSelectPermissionByIdPersonnalResult
    {
        public int idPermission { get; set; }

        public string Permission { get; set; }


    }







}
