using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goCCSI_API.Models
{
    public class modLogPrivacy
    {

        public int idLogPrivacy { get; set; }

        public int idPersonnal { get; set; }

        public DateTime InsertDate { get; set; }

        public bool Active { get; set; }

    }

    public class modLogPrivacyParams
    {
        public int Option { get; set; }
        public int idPersonnal { get; set; }

    }

    public class modLogPrivacyID
    {

        public int idLogPrivacy { get; set; }

    }

}
