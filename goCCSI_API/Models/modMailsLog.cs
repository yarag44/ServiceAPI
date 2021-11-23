using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goCCSI_API.Models
{
    public class modMailsLog
    {
        public int idMailLog { get; set; }

        public int idMail { get; set; }

        public int idStatus { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public DateTime InsertDate { get; set; }

        public int idUserInsert { get; set; }
    }

    public class modMailsLogID
    {

        public int idMailLog { get; set; }

    }

    public class modMailsLogSelectParams
    {
        public int Option { get; set; }

        public int idMail { get; set; }
    }

    public class modMailsLogSelect
    {
        public int idMailLog { get; set; }

        public int idMail { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public DateTime InsertDate { get; set; }

        public int idUserInsert { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string MotherLastName { get; set; }

    }

}
