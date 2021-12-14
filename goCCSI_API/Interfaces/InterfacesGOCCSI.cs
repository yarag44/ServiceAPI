using goCCSI_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goCCSI_API.Interfaces
{
   interface InterfacesGOCCSI
    {
        #region PERSONNAL

        List<modPersonnal> SelectPersonnal(modLogin plogin);
        modPersonnalPasswordID UpdatePersonnalPassword(modPersonnalPasswordParams cPer);
        List<modPersonalServices> SelectPersonnalServices(modPersonalServicesParams cPer);


 
        modPersonnalRolesID InsertDeletePersonnalRoles(modPersonnalRolesParams cPer);
        List<modPersonnalRoles> SelectPersonnalRoles(modPersonnalRolesParams cPer);



        modPersonnalID InsertDeletePersonnalServices(modPersonalServicesParams pPer);
        List<modPersonnal> Select_CatPersonnalFilters(modPersonnalFiltersParams pPer);
        modPersonnalPhotosResult Select_PhotosPersonnalByCriteria(modPersonnalPhotosParams cPer);


        List<modPersonnalExtraInfoResult> SelectPersonnalExtraInfo(modPersonnalExtraInfoParams cPer);

        #endregion


        #region CLOCK

        int InsertClockDateTime(modClockDateTime pClock);

        List<modSelectClockDateTime> SelectClockdateTime(modSelectClockDateTimeParams pClock);

        #endregion


        #region NEWS

        List<modNews> SelectNews(modNewsParams pNews);

        List<modNewsSelectFilterResult> SelectFiltersNews(modNewsSelectFilterParams pNews);

        List<modNews> SelectNewsWithFilters(modNewsSelectWithFilterParams pNews);

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

        modidNews NegateAuthorizationNews(NegateAuthorizationParams cNew);

        modQtyPinToTop Select_PinToTopQTY(modQtyPinToTopParams cNew);


        modNewImage Select_ImageFromIdNews(modidNews pNews);

        List<modNewsActivePermissions> Select_ActiveNewsPermissions();

        List<modNews> SelectNewsView(modNewsViewParams pNews);



        #endregion


        #region ROLES

        modRolesID InsertUpdateRoles(modRolesParams cRoles);
        List<modRoles> SelectRoles(modRolesParams pRoles);
        modRolesID DeleteRoles(modDeleteRolesParams pRoles);

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


        #region PERMISSIONS


        modPermission InsertUpdatePermissions(modPermissionParams pPermission);

        List<modPermissionSelect> SelectPermissions(modPermissionSelectParams pPermission);

        List<modSelectPermissionByIdPersonnalResult> SelectPermissionsByIdPersonnal(modSelectPermissionByIdPersonnalParams cData);

        List<modSelectServicesByIdPersonnalResult> SelectServicesByIdPersonnal(modSelectPermissionByIdPersonnalParams cData);

        List<modSelectRolesByIdPersonnalResult> SelectRolesByIdPersonnal(modSelectPermissionByIdPersonnalParams cData);

        #endregion


        #region CATALOG_OPTIONS

        List<modCatalogOptionsSelect> SelectCatalogOptions(modCatalogOptionsSelectParams pCatalogOption);

        List<modCatalogOptionsSelect> SelectCatalogOptionsManyCatalogs(modCatalogOptionsManyCatalogsParams pCatalogOption);


        #endregion


        #region MAILS

        modMailsID InsertUpdateMails(modMailsParams pMails);

        List<modMailsSelect> SelectMails(modMailsSelectParams pMails);

        #endregion


        #region MAILS LOG

        List<modMailsLogSelect> SelectMailsLog(modMailsLogSelectParams pMailsLog);


        #endregion

        #region LOG ACCESS 


        modLogAccessReturn Insert_LogAccess(modLogAccessParams pLogAccess);


        #endregion


        #region

        List<modLogPrivacy> SelectLogPrivacy(modLogPrivacyParams pLogPrivacy);

        modLogPrivacyID InsertLogPrivacy(modLogPrivacyParams pLogPrivacy);

        #endregion


    }
}
