using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goCCSI_API.Models
{
    public class modCatalogOptions
    {
        public int idCatalogOptions { get; set; }
        public int idCatalog { get; set; }
        public string OptionValue { get; set; }
        public bool Active { get; set; }
        public bool ActiveSystem { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime LastModifyDate { get; set; }
        public int idPersonnalInsert { get; set; }
        public int idPersonnalLastModify { get; set; }

    }

    public class modCatalogOptionsSelectParams
    {
        public int Option { get; set; }
        public int idCatalog { get; set; }
        public int idCatalogOptions { get; set; }

        public int idCatalogOptions { get; set; }


    }

    public class modCatalogOptionsSelect
    {
        public int idCatalogOptions { get; set; }
        public int idCatalog { get; set; }
        public string OptionValue { get; set; }
        public bool Active { get; set; }

    }





    public class modCatalogOptionsManyCatalogsParams
    {
        public int Option { get; set; }
        public string idCatalogs { get; set; }

    }





}
