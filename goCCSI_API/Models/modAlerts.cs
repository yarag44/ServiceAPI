using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goCCSI_API.Models
{
    public class modAlerts
    {

        public int idAlert { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Description { get; set; }

        public bool PinToTop { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string CompleteName { get; set; }

        public int idPersonnal { get; set; }


    }

    public class modAlertsParams
    {

        public int Option { get; set; }

        public int idAlert { get; set; }



    }


    public class modAlertsAddRelParams
    {

        public int Option { get; set; }

        public int idAlert { get; set; }

        public int idRelation { get; set; }


    }

    public class modAlertsInsertUpdParams
    {


        public int idAlert { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Description { get; set; }

        public bool PinToTop { get; set; }

        public int idViewAreas { get; set; }

        public int idViewPositions { get; set; }


        public string ExpirationDate { get; set; }

        public int idPersonnalInsert { get; set; }




    }


    public class modAlertsReturn
    {

        public int idAlert { get; set; }


    }



    public class modAlertsCatRel
    {

        public int idCatalog { get; set; }
        public int value { get; set; }

        public string label { get; set; }


    }

    public class modAlertsCatRelParams
    {
        public int Option { get; set; }

    }




    }
