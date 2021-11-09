using goCCSI_API.Interfaces;
using goCCSI_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace goCCSI_API.BL
{
    public class BL: InterfacesGOCCSI
    {
        
        DL.DL dLayer;

        public BL()
        {
            dLayer = new DL.DL();
        }

        public int InsertClockDateTime(modClockDateTime pClock)
        {
            return dLayer.InsertClockDateTime(pClock);
        }

        public modNews InsertNew(modNewsParamsInsert pNews)
        {

            return dLayer.InsertNew(pNews);
        }

        public List<modSelectClockDateTime> SelectClockdateTime(modSelectClockDateTime pClock)
        {
            return dLayer.SelectClockdateTime(pClock);
        }

        public List<modNews> SelectNews(modNewsParams pNews)
        {
            return dLayer.SelectNews(pNews);
        }

        public List<modPersonnal> SelectPersonnal(modLogin plogin)
        {
            return dLayer.SelectPersonnal(plogin);

        }

        public modPersonnalPasswordID UpdatePersonnalPassword(modPersonnalPasswordParams cPer)
        {
            return dLayer.UpdatePersonnalPassword(cPer);
        }


        public modNews InsertUpdateNew(modNewsParamsInsertUpdate pNews)
        {

            return dLayer.InsertUpdateNew(pNews);

        }

        public modidNews DeleteNews(modDeleteNewsParams pNews)
        {

            return dLayer.DeleteNews(pNews);

        }


        public modPermission InsertUpdatePermissions(modPermissionParams pPermission)
        {

            return dLayer.InsertUpdatePermissions(pPermission);

        }

        public List<modPermissionSelect> SelectPermissions(modPermissionSelectParams pPermission)
        {
            return dLayer.SelectPermissions(pPermission);

        }

        public modidPermission DeletePermission(modDeletePermissionParams pPermission)
        {

            return dLayer.DeletePermission(pPermission);

        }


        public List<modPermissionsCatalogSelect> SelectPermissionsCatalog(modPermissionsCatalogSelect pPermissionCatalog)
        {
            return dLayer.SelectPermissionsCatalog(pPermissionCatalog);

        }

        public List<modPermissionsDetail> SelectPermissionsDetail(modPermissionDetailParams pPermissionDetail)
        {
            return dLayer.SelectPermissionsDetail(pPermissionDetail);

        }

        public modPermissionDetailID InsertDeletePermissionsDetail(modPermissionDetailParams pPermissionDetail)
        {
            return dLayer.InsertDeletePermissionsDetail(pPermissionDetail);
        }



        public List<modNewsRelation> SelectNewsRelations(modNewsRelationParams pNews)
        {
            return dLayer.SelectNewsRelations(pNews);
        }

        public List<modNewsRelationCatalog> SelectNewsRelationsAllCatalogs(modNewsRelationAllCatalogsParams pNews)
        {
            return dLayer.SelectNewsRelationsAllCatalogs(pNews);
        }

        public modNewsRelation AddNewsRelations(modAddNewsRelationParams pNews)
        {
            return dLayer.AddNewsRelations(pNews);

        }


        public bool RemoveNewsRelations(modRemoveNewsRelationParams pNews)
        {
            return dLayer.RemoveNewsRelations(pNews);
        }


        public List<modCatalogOptionsSelect> SelectCatalogOptions(modCatalogOptionsSelectParams pCatalogOption)
        {
            return dLayer.SelectCatalogOptions(pCatalogOption);

        }


        public List<modCatalogOptionsSelect> SelectCatalogOptionsManyCatalogs(modCatalogOptionsManyCatalogsParams pCatalogOption)
        {
            return dLayer.SelectCatalogOptionsManyCatalogs(pCatalogOption);
        }

        public bool Update_ViewsNews(modOperViewsNewsParams pNews)
        {
            return dLayer.Update_ViewsNews(pNews);

        }


        public ViewsNews Select_ViewsNews(modOperViewsNewsParams pNews)
        {
            return dLayer.Select_ViewsNews(pNews);
        }


        public bool Update_VersionNews(modOperViewsNewsParams pNews)
        {
            return dLayer.Update_VersionNews(pNews);

        }

        public VersionsNews Select_VersionNews(modOperViewsNewsParams pNews)
        {
            return dLayer.Select_VersionNews(pNews);

        }





        public List<modPersonalServices> SelectPersonnalServices(modPersonalServicesParams cPer)
        {

            return dLayer.SelectPersonnalServices(cPer);

        }

        public modPersonnalID InsertDeletePersonnalServices(modPersonalServicesParams pPer)
        {

            return dLayer.InsertDeletePersonnalServices(pPer);

        }


    

        public List<modServicesPermissions> SelectServicesPermissions(modServicesPermissionParams cServ)
        {
            return dLayer.SelectServicesPermissions(cServ);
        }


        public modServicesPermissionID InsertDeleteServicesPermissions(modServicesPermissionParams cServ)
        {
            return dLayer.InsertDeleteServicesPermissions(cServ);
        }




        public modServicesID InsertUpdateServices(modServicesParams pServices)
        {
            return dLayer.InsertUpdateServices(pServices);
        }


        public List<modServicesSelectReturn> SelectServices(modServicesSelect pServices)
        {
            return dLayer.SelectServices(pServices);
        }


        public modServicesID DeleteServices(modDeleteServicesParams pServices)
        {

            return dLayer.DeleteServices(pServices);

        }



        public List<modPersonnal> Select_CatPersonnalFilters(modPersonnalFiltersParams pPer)
        {
            return dLayer.Select_CatPersonnalFilters(pPer);
        }


        public modPersonnalRolesID InsertDeletePersonnalRoles(modPersonnalRolesParams cPer)
        {
            return dLayer.InsertDeletePersonnalRoles(cPer);
        }


        public List<modPersonnalRoles> SelectPersonnalRoles(modPersonnalRolesParams cPer)
        {

            return dLayer.SelectPersonnalRoles(cPer);
        }

        
        public List<modRoles> SelectRoles(modRolesParams pRoles)
        {

            return dLayer.SelectRoles(pRoles);

        }

        public modRolesID InsertUpdateRoles(modRolesParams pRoles)
        {
            return dLayer.InsertUpdateRoles(pRoles);
        }

        public modRolesID DeleteRoles(modDeleteRolesParams pRoles)
        {

            return dLayer.DeleteRoles(pRoles);

        }

        public List<modRolesServices> SelectRolesServices(modRolesServicesParams pRoles)
        {
            return dLayer.SelectRolesServices(pRoles);
        }

        public modRolesServicesID InsertDeleteRolesServices(modRolesServicesParams pRoles)
        {
            return dLayer.InsertDeleteRolesServices(pRoles);
        }


        public List<modNewsSelectFilterResult> SelectFiltersNews(modNewsSelectFilterParams pNews)
        {

            return dLayer.SelectFiltersNews(pNews);

        }

        public List<modNews> SelectNewsWithFilters(modNewsSelectWithFilterParams pNews)
        {
            return dLayer.SelectNewsWithFilters(pNews);
        }


        public List<modSelectPermissionByIdPersonnalResult> SelectPermissionsByIdPersonnal(modSelectPermissionByIdPersonnalParams cData)
        {
            return dLayer.SelectPermissionsByIdPersonnal(cData);

        }


        public List<modSelectServicesByIdPersonnalResult> SelectServicesByIdPersonnal(modSelectPermissionByIdPersonnalParams cData)
        {
            return dLayer.SelectServicesByIdPersonnal(cData);

        }

        public List<modSelectRolesByIdPersonnalResult> SelectRolesByIdPersonnal(modSelectPermissionByIdPersonnalParams cData)
        {

            return dLayer.SelectRolesByIdPersonnal(cData);
        }


        public modidNews NegateAuthorizationNews(NegateAuthorizationParams cNew)
        {
            return dLayer.NegateAuthorizationNews(cNew);
        }



        }



        public class BLFunction
    {

        public List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        public T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name.ToUpper() == column.ColumnName.ToUpper())
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }


        public void CopierProperty<TParent, TChild>(TParent parent, TChild child)
        {
            var parentProperties = parent.GetType().GetProperties();
            var childProperties = child.GetType().GetProperties();

            foreach (var parentProperty in parentProperties)
            {
                foreach (var childProperty in childProperties)
                {
                    if (parentProperty.Name == childProperty.Name && parentProperty.PropertyType == childProperty.PropertyType)
                    {
                        childProperty.SetValue(child, parentProperty.GetValue(parent));
                        break;
                    }
                }
            }
        }

    }


}
