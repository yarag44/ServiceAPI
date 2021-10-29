using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goCCSI_API.Models
{
    public class modClockDateTime
    {

        public int idPersonnal { get; set; }

        public int idStatus { get; set; }


    }

    public class modSelectClockDateTime
    {
        public int Option { get; set; }


        public int idPersonnal { get; set; }

        public DateTime CheckDateTime { get; set; }

        public string ClockTime { get; set; }

        public int idStatus { get; set; }





        public string ClockDate { get; set; }

    }


}
