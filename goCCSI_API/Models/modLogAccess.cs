using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goCCSI_API.Models
{
    public class modLogAccess
    {


        public int LogAccess { get; set; }

        public int idPersonnal { get; set; }

        public int idPage { get; set; }

        public bool  IsFirstAccess { get; set; }



    }


    public class modLogAccessParams
    {

        public int idPersonnal { get; set; }

        public int idPage { get; set; }


        public int isFailedAccess { get; set; }

         

    }


    public class modLogAccessReturn
    {

        public int idLogAccess { get; set; }



    }







    }
