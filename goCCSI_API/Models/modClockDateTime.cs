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

    public class modSelectClockDateTimeParams
    {
        public int Option { get; set; }

        public int idPersonnal { get; set; }

        public string Search { get; set; }

        public string idDivisions { get; set; }

        public int idCenter { get; set; }

        public string idAreas { get; set; }

        public int idBussinessModel { get; set; }

        public int idCheckType { get; set; }

        public string startDate { get; set; }

        public string endDate { get; set; }

    }

    public class modSelectClockDateTime
    {
        public int idPersonnal { get; set; }

        public string noEmployee { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string MotherLastName { get; set; }

        public string CompleteName { get; set; }

        public int idDivision { get; set; }

        public string Division { get; set; }

        public int idCenter { get; set; }

        public string Center { get; set; }

        public int idArea { get; set; }

        public string Area { get; set; }

        public int idBussinessModel { get; set; }

        public string bussinessModel { get; set; }

        public DateTime CheckDateTime { get; set; }

        public string ClockTime { get; set; }

        public int idStatus { get; set; }

        public string checkType { get; set; }

        public string ClockDate { get; set; }

    }


}
