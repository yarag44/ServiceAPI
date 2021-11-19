using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goCCSI_API.Models
{
    public class modMails
    {
        public int idMail { get; set; }

        public int idPersonnalSent { get; set; }

        public int idPersonnalReceive { get; set; }

        public int idAssignArea { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public int idStatus { get; set; }

        public int idUserInsert { get; set; }

        public int idUserLastModify { get; set; }

        public bool Active { get; set; }

        public DateTime InsertDate { get; set; }

        public DateTime LastModifyDate { get; set; }

    }

    public class modMailsParams
    {

        public int idCenter { get; set; }

        public int idMail { get; set; }

        public int idPersonnalSent { get; set; }

        public int idPersonnalReceive { get; set; }

        public int idAssignArea { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public int idStatus { get; set; }

        public int idUserInsert { get; set; }

        public int idUserLastModify { get; set; }

        public bool Active { get; set; }


    }

    public class modMailsID
    {

        public int idMail { get; set; }

    }


    public class modMailsSelectParams
    {

        public int Option { get; set; }

        public int idPersonnalSent { get; set; }

        public int idPersonnalReceive { get; set; }

        public int idAssignArea { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public int idStatus { get; set; }

        public bool Active { get; set; }

    }

    public class modMailsSelect
    {
        public int idMail { get; set; }

        public int idPersonnalSent { get; set; }

        public string SenderName { get; set; }

        public string SenderLastName { get; set; }

        public string SenderMotherLastName { get; set; }

        public int idPersonnalReceive { get; set; }

        public string ReceiverName { get; set; }

        public string ReceiverLastName { get; set; }

        public string ReceiverMotherLastName { get; set; }

        public int idAssignArea { get; set; }

        public string AssignArea { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public int idStatus { get; set; }

        public string Status { get; set; }

        public int idUserInsert { get; set; }

        public int idUserLastModify { get; set; }

        public bool Active { get; set; }

        public DateTime InsertDate { get; set; }

        public DateTime LastModifyDate { get; set; }
    }
}
