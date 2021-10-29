using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goCCSI_API.Models
{
    public class modPersonnal
    {

        public int idPersonnal { get; set; }

        public int idPersonnal_Boss { get; set; }

        public string NoEmployee { get; set; }

        public int idLocation { get; set; }

        public int idCenter { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string MotherLastName { get; set; }

        public string RFC { get; set; }

        public string Password { get; set; }


    }
}
