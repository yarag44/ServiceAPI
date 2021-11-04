using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goCCSI_API.Models
{
    public class modServicesParams
    {

        public int idService { get; set; }

        public string Service { get; set; }

        public int idPersonnal { get; set; }


    }

    public class modServicesID
    {

        public int IdService { get; set; }


    }


    public class modServicesSelect
    {

        public int Option { get; set; }

        public int idService { get; set; }

        public string Service { get; set; }


    }

    public class modServicesSelectReturn
    {

        public int idService { get; set; }

        public string Service { get; set; }

        public int idPersonnalLastModify { get; set; }


    }

    public class modDeleteServicesParams
    {

        public int idService { get; set; }

        public int idPersonnalLastModify { get; set; }

    }


}
