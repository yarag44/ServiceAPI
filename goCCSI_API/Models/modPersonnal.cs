using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goCCSI_API.Models
{
    public class modPersonnal
    {

        public int idPersonnal { get; set; }

        //public int idPersonnal_Boss { get; set; }

        public string NoEmployee { get; set; }

        public int idCenter { get; set; }

        public string Center { get; set; }

        public string Name { get; set; }

        //public string LastName { get; set; }

        //public string MotherLastName { get; set; }
        public string Supervisor { get; set; }

        public int idDepartment { get; set; }

        public string Department { get; set; }

        public int idPersonnalType { get; set; }

        public string PersonnalType { get; set; }

        public int idState { get; set; }

        public string State { get; set; }

        public string RFC { get; set; }

        public string Password { get; set; }


    }




    public class modPersonalServicesParams
    {

        public int Option { get; set; }

        public int idPersonnal { get; set; }

        public int idService { get; set; }



    }

    public class modPersonalServices
    {

        
        public int idPersonnal { get; set; }

        public int idService { get; set; }



    }


    public class modPersonnalID
    {

        public int idPersonnalService { get; set; }



    }





}
