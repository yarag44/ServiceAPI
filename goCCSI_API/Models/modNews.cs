using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goCCSI_API.Models
{
    public class modNews
    {

        public int idNews { get; set; }

        public string ImageNew { get; set; }

        public string ImageName { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string DescriptionNew { get; set; }

        public bool PinToTop { get; set; }

        public int OrderNew { get; set; }

        public DateTime LastModifyDate { get; set; }

        public int idPersonnalInsert { get; set; }


        public bool isDraft { get; set; }

        public bool idStatus { get; set; }


        public int Views { get; set; }

        public int Version { get; set; }




    }

    public class modidNews
    {
        public int idNews { get; set; }

    }



    public class modNewsParams
    {

        public int Option { get; set; }

        public int idNews { get; set; }

        public string Title { get; set; }


    }

    public class modNewsParamsInsertUpdate
    {

        public int idNew { get; set; }

        public string ImageNew { get; set; }

        public string ImageName { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string DescriptionNew { get; set; }

        public bool PinToTop { get; set; }

        public int OrderNew { get; set; }

        public int idPersonnalInsert { get; set; }

        public bool isDraft { get; set; }

        public bool idStatus { get; set; }


    }


    public class modNewsParamsInsert
    {


        public string ImageNew { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string DescriptionNew { get; set; }

        public bool PinToTop { get; set; }

        public int OrderNew { get; set; }

        public int idPersonnalInsert { get; set; }


    }

    public class modDeleteNewsParams
    {

        public int idNews { get; set; }

    }



    public class modNewsRelation
    {

        public int idCatalogOptions { get; set; }

        public string OptionValue { get; set; }


    }


    public class modNewsRelationParams
    {

        public int Option { get; set; }

        public int IdNews { get; set; }


    }



    public class modAddNewsRelationParams
    {

        public int Option { get; set; }

        public int IdNews { get; set; }

        public int IdRelation { get; set; }


    }

    public class modRemoveNewsRelationParams
    {

        public int Option { get; set; }

        public int IdNews { get; set; }



    }


    public class modOperViewsNewsParams
    {

        
        public int IdNews { get; set; }



    }



    public class ViewsNews
    {

        public int Views { get; set; }


    }


    public class VersionsNews
    {

        public int Version { get; set; }


    }

}
