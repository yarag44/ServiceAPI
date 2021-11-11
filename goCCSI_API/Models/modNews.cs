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

        public string PersonnalInsert { get; set; }


        public int idViewDeptos { get; set; }

        public int idViewPositions { get; set; }

        public bool IsPendingPublish { get; set; }

        public DateTime ExpirationDate { get; set; }


        public bool  IsReject { get; set; }


    }

    public class modidNews
    {
        public int idNews { get; set; }

    }



    public class modQtyPinToTop
    {
        public int QTY { get; set; }

    }


    public class modQtyPinToTopParams
    {
        public int Option { get; set; }

        public int idDepartment { get; set; }


        public int idNews { get; set; }

    }






    public class modNewsParams
    {

        public int Option { get; set; }

        public int idNews { get; set; }

        public string Title { get; set; }


    }

    public class modNewsSelectFilterParams
    {

        public int Option { get; set; }

        public int idWritter { get; set; }


    }

    public class modNewsSelectWithFilterParams
    {

        public int Option { get; set; }

        public int idWritter { get; set; }

        public int Top { get; set; }

    }





    public class modNewsSelectFilterResult
    {

        public int idPersonnal { get; set; }

        public string Name { get; set; }


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


        public int idViewDeptos { get; set; }

        public int idViewPositions { get; set; }

        public bool IsPendingPublish { get; set; }

        public string ExpirationDate { get; set; }

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

    public class modNewsRelationCatalog
    {

        public int idCatalog { get; set; }

        public int idCatalogOptions { get; set; }

        public string OptionValue { get; set; }


    }




    public class modNewsRelationParams
    {

        public int Option { get; set; }

        public int IdNews { get; set; }


    }

    public class modNewsRelationAllCatalogsParams
    {

        
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



    public class NegateAuthorizationParams
    {

        public int idNews { get; set; }

        public bool isPendingPublish { get; set; }



    }



}
