using goCCSI_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goCCSI_API.Interfaces
{
   interface InterfacesGOCCSI
    {

        List<modPersonnal> SelectPersonnal(modLogin plogin);
        List<modPersonalServices> SelectPersonnalServices(modPersonalServicesParams cPer);





        modPersonnalRolesID InsertDeletePersonnalRoles(modPersonnalRolesParams cPer);
        List<modPersonnalRoles> SelectPersonnalRoles(modPersonnalRolesParams cPer);







        modPersonnalID InsertDeletePersonnalServices(modPersonalServicesParams pPer);

        List<modPersonnal> Select_CatPersonnalFilters(modPersonnalFiltersParams pPer);


        #region CLOCK

        int InsertClockDateTime(modClockDateTime pClock);

        List<modSelectClockDateTime> SelectClockdateTime(modSelectClockDateTime pClock);

        #endregion


        #region NEWS

        List<modNews> SelectNews(modNewsParams pNews);

        modNews InsertNew(modNewsParamsInsert pNews);

        modNews InsertUpdateNew(modNewsParamsInsertUpdate pNews);

        modidNews DeleteNews(modDeleteNewsParams pNews);


        List<modNewsRelation> SelectNewsRelations(modNewsRelationParams pNews);


        List<modNewsRelationCatalog> SelectNewsRelationsAllCatalogs(modNewsRelationAllCatalogsParams pNews);


        modNewsRelation AddNewsRelations(modAddNewsRelationParams pNews);

        bool RemoveNewsRelations(modRemoveNewsRelationParams pNews);

        
        
        
        
        
        bool Update_ViewsNews(modOperViewsNewsParams pNews);

        ViewsNews Select_ViewsNews(modOperViewsNewsParams pNews);


        bool Update_VersionNews(modOperViewsNewsParams pNews);

        VersionsNews Select_VersionNews(modOperViewsNewsParams pNews);


        #endregion



        #region ROLES


        List<modRoles> SelectRoles(modRolesParams pRoles);

        List<modRolesServices> SelectRolesServices(modRolesServicesParams cRoles);
        modRolesServicesID InsertDeleteRolesServices(modRolesServicesParams cRoles);

        #endregion




        #region SERVICE

        modServicesID InsertUpdateServices(modServicesParams pServices);
        List<modServicesSelectReturn> SelectServices(modServicesSelect pServices);


        modServicesPermissionID InsertDeleteServicesPermissions(modServicesPermissionParams cServ);
        List<modServicesPermissions> SelectServicesPermissions(modServicesPermissionParams cServ);


        modServicesID DeleteServices(modDeleteServicesParams pServ);



        #endregion




        #region PERMISSIOONS


        modPermission InsertUpdatePermissions(modPermissionParams pPermission);

        List<modPermissionSelect> SelectPermissions(modPermissionSelectParams pPermission);

        #endregion


        #region CATALOG_OPTIONS

        List<modCatalogOptionsSelect> SelectCatalogOptions(modCatalogOptionsSelectParams pCatalogOption);

        List<modCatalogOptionsSelect> SelectCatalogOptionsManyCatalogs(modCatalogOptionsManyCatalogsParams pCatalogOption);


        #endregion




    }
}
