using goCCSI_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using goCCSI_API.Interfaces;
using System.Data.SqlClient;
using System.Data;
using Core.MSSQL.SqlHelper;
using goCCSI_API.BL;

namespace goCCSI_API.DL
{
    public class DL: InterfacesGOCCSI
    {


        public string ConnectionDWP = "";

        public DL()
        {
            //DEVELOP
            //ConnectionDWP = @"Server=tcp:ccsidigitalworkplace.database.windows.net,1433;Initial Catalog=CCSIDigitalWorkPlace;Persist Security Info=False;User ID=ccsiadmin;Password=G3nerico01#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            //PRODUCTION
            ConnectionDWP = "Server=tcp:prod-goccsi-sql.database.windows.net,1433;Initial Catalog=Prod_GoCCSI_SQL;Persist Security Info=False;User ID=goCCSI2022;Password=goCCSI_prod2022#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout= 30;";

        }

        #region PERSONNAL

        public List<modPersonnal> SelectPersonnal(modLogin plogin)
        {
            List<modPersonnal> lstPersonnal = new List<modPersonnal>();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@OPTION", plogin.Option),
                new SqlParameter("@IDPERSONNAL", plogin.idPersonnal),
                new SqlParameter("@NOEMPLOYEE", plogin.NoEmployee),
                new SqlParameter("@IDLOCATION", plogin.idLocation),
                new SqlParameter("@IDCENTER", plogin.idCenter),
                new SqlParameter("@PASSWORD", plogin.Password)

            };

            DataTable dt = SqlHelper.ExecuteDataset(ConnectionDWP, CommandType.StoredProcedure, "per.SelectPersonnal", par).Tables[0];

            lstPersonnal = bFunc.ConvertDataTable<modPersonnal>(dt);

            return lstPersonnal;

        }
        public modPersonnalPasswordID UpdatePersonnalPassword(modPersonnalPasswordParams pPer)
        {

            modPersonnalPasswordID cPersonnalPassword = new modPersonnalPasswordID();

            SqlParameter[] par = new SqlParameter[]
                      {
                        new SqlParameter("@OPTION", pPer.Option),
                        new SqlParameter("@IDPERSONNAL", pPer.IdPersonnal),
                        new SqlParameter("@PASSWORD", pPer.Password)

                      };

            object objID = SqlHelper.ExecuteScalar(ConnectionDWP, CommandType.StoredProcedure, "per.UpdatePersonnalPassword", par);

            if (objID != null)
            {
                cPersonnalPassword.IdPersonnal = Convert.ToInt32(objID);

            }
            else
            {
                cPersonnalPassword.IdPersonnal = Convert.ToInt32(0);

            }
            return cPersonnalPassword;


        }

        //Select_CatPersonnalFilters
        public List<modPersonnal> Select_CatPersonnalFilters(modPersonnalFiltersParams pPer)
        {
            List<modPersonnal> lstPersonnal = new List<modPersonnal>();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@Option", pPer.Option),
                new SqlParameter("@NoEmployee", pPer.NoEmployee),
                new SqlParameter("@Name", pPer.Name),
                new SqlParameter("@IdCenter", pPer.IdCenter),
                new SqlParameter("@IdDepartment", pPer.IdDepartment),
                new SqlParameter("@IdPersonnaltype", pPer.IdPersonnalType)

            };

            DataTable dt = SqlHelper.ExecuteDataset(ConnectionDWP, CommandType.StoredProcedure, "per.Select_CatPersonnalFilters", par).Tables[0];

            lstPersonnal = bFunc.ConvertDataTable<modPersonnal>(dt);

            return lstPersonnal;

        }

        public List<modPersonnalExtraInfoResult> SelectPersonnalExtraInfo(modPersonnalExtraInfoParams cPer)
        {
            List<modPersonnalExtraInfoResult> lstPersonnal = new List<modPersonnalExtraInfoResult>();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@OPTION", cPer.Option),
                new SqlParameter("@IDPERSONNAL", cPer.idPersonnal)

            };

            DataTable dt = SqlHelper.ExecuteDataset(ConnectionDWP, CommandType.StoredProcedure, "per.SelectPersonnalExtraInfo", par).Tables[0];

            lstPersonnal = bFunc.ConvertDataTable<modPersonnalExtraInfoResult>(dt);

            return lstPersonnal;
        }

        #endregion


        #region CLOCK

        public int InsertClockDateTime(modClockDateTime pClock)
        {

            SqlParameter[] par = new SqlParameter[]
                      {

                        new SqlParameter("@IDPERSONNAL", pClock.idPersonnal),
                         new SqlParameter("@IDCENTER", pClock.idCenter),
                        new SqlParameter("@IDSTATUS", pClock.idStatus)

                      };


            object idClock = SqlHelper.ExecuteScalar(ConnectionDWP, CommandType.StoredProcedure, "clk.InsertClockDateTime", par);

            if (idClock != null)
                return Convert.ToInt32(idClock);
            else
                return 0;



        }

        public List<modSelectClockDateTime> SelectClockdateTime(modSelectClockDateTimeParams pClock)
        {
            List<modSelectClockDateTime> lstClock = new List<modSelectClockDateTime>();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@OPTION", pClock.Option),
                new SqlParameter("@IDPERSONNAL", pClock.idPersonnal),
                new SqlParameter("@STARTDATE", pClock.startDate),
                new SqlParameter("@ENDDATE", pClock.endDate),
                new SqlParameter("@IDCENTER", pClock.idCenter),
                new SqlParameter("@IDDIVISIONS", pClock.idDivisions),
                new SqlParameter("@IDAREAS", pClock.idAreas),
                new SqlParameter("@IDBUSSINESSMODEL", pClock.idBussinessModel),
                new SqlParameter("@SEARCH", pClock.Search),
                new SqlParameter("@IDCHECKTYPE", pClock.idCheckType)

            };

            DataTable dt = SqlHelper.ExecuteDataset(ConnectionDWP, CommandType.StoredProcedure, "clk.SelectClockdateTime", par).Tables[0];

            lstClock = bFunc.ConvertDataTable<modSelectClockDateTime>(dt);

            return lstClock;

        }


        public List<modSelectCurrentDateTime> SelectCurrentDateTime(modSelectCurrentDateTimeParams pClock)
        {
            List<modSelectCurrentDateTime> lstClock = new List<modSelectCurrentDateTime>();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@IDCENTER", pClock.idCenter)

            };

            DataTable dt = SqlHelper.ExecuteDataset(ConnectionDWP, CommandType.StoredProcedure, "clk.SelectCurrentDateTimeByCenter", par).Tables[0];

            lstClock = bFunc.ConvertDataTable<modSelectCurrentDateTime>(dt);

            return lstClock;

        }

        #endregion


        #region NEWS

        public List<modNews> SelectNews(modNewsParams pNews)
        {
            List<modNews> lstNews = new List<modNews>();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@OPTION", pNews.Option),
                new SqlParameter("@IDNEWS", pNews.idNews),
                new SqlParameter("@TITLE", pNews.Title)


            };

            DataTable dt = SqlHelper.ExecuteDataset(ConnectionDWP, CommandType.StoredProcedure, "nws.SelectNews", par).Tables[0];

            lstNews = bFunc.ConvertDataTable<modNews>(dt);

            return lstNews;

        }

        public List<modNewsSelectFilterResult> SelectFiltersNews(modNewsSelectFilterParams pNews)
        {
            List<modNewsSelectFilterResult> lstPersonnal = new List<modNewsSelectFilterResult>();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
            {
                
                new SqlParameter("@Option", pNews.Option),
                new SqlParameter("@IdWritter", pNews.idWritter)
                
            };

            DataTable dt = SqlHelper.ExecuteDataset(ConnectionDWP, CommandType.StoredProcedure, "nws.SelectFiltersNews", par).Tables[0];

            lstPersonnal = bFunc.ConvertDataTable<modNewsSelectFilterResult>(dt);

            return lstPersonnal;

        }

        public List<modNews> SelectNewsWithFilters(modNewsSelectWithFilterParams pNews)
        {
            List<modNews> lstNews = new List<modNews>();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@OPTION", pNews.Option),
                new SqlParameter("@IdWritter", pNews.idWritter),
                new SqlParameter("@Top", pNews.Top),
                new SqlParameter("@Clasification", pNews.Clasification)
            };

            DataTable dt = SqlHelper.ExecuteDataset(ConnectionDWP, CommandType.StoredProcedure, "nws.SelectNewsWithFilters", par).Tables[0];

            lstNews = bFunc.ConvertDataTable<modNews>(dt);

            return lstNews;

        }

        public modNewImage Select_ImageFromIdNews(modidNews pNews)
        {
            modNewImage imageNew = new modNewImage();
            BLFunction bFunc = new BLFunction();
                      
            object objID = SqlHelper.ExecuteScalar(ConnectionDWP, CommandType.Text, "select nws.Select_ImageFromIdNews(" + Convert.ToString(pNews.idNews) + ")");

            if(objID != null)
            {
                imageNew.ImageNew = Convert.ToString(objID);
            }
            else
            {
                imageNew.ImageNew = "";
            }


            //lstNews = bFunc.ConvertDataTable<modNews>(dt);

            return imageNew;

        }

        public List<modNewsActivePermissions> Select_ActiveNewsPermissions()
        {
            List<modNewsActivePermissions> lstNews = new List<modNewsActivePermissions>();
            BLFunction bFunc = new BLFunction();

            DataTable dt = SqlHelper.ExecuteDataset(ConnectionDWP, CommandType.StoredProcedure, "nws.Select_ActiveNewsPermissions").Tables[0];

            lstNews = bFunc.ConvertDataTable<modNewsActivePermissions>(dt);

            return lstNews;

        }

        public List<modNews> SelectNewsView(modNewsViewParams pNews)
        {
            List<modNews> lstNews = new List<modNews>();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@OPTION", pNews.Option),
                new SqlParameter("@IDNEWS", pNews.idNews),
                new SqlParameter("@NEWS", pNews.news)


            };

            DataTable dt = SqlHelper.ExecuteDataset(ConnectionDWP, CommandType.StoredProcedure, "nws.SelectNewsView", par).Tables[0];

            lstNews = bFunc.ConvertDataTable<modNews>(dt);

            return lstNews;

        }

        public modNews InsertNew(modNewsParamsInsert pNews)
        {

            modNews cNew = new modNews();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
                      {

                        new SqlParameter("@ImageNew", pNews.ImageNew),
                        new SqlParameter("@Title", pNews.Title),
                        new SqlParameter("@Subtitle", pNews.SubTitle),
                        new SqlParameter("@DescriptionNew", pNews.DescriptionNew),
                        new SqlParameter("@PinToTop", pNews.PinToTop),
                        new SqlParameter("@OrderNew", pNews.OrderNew),
                        new SqlParameter("@idPersonnalInsert", pNews.idPersonnalInsert)

                      };


            object idNews = SqlHelper.ExecuteScalar(ConnectionDWP, CommandType.StoredProcedure, "nws.InsertNew", par);

            if (idNews != null)
            {
                cNew.idNews = Convert.ToInt32(idNews);
                bFunc.CopierProperty(pNews, cNew);
            }
            else
            {
                cNew.idNews = 0;
                bFunc.CopierProperty(pNews, cNew);
            }
            return cNew;


        }

        public modNews InsertUpdateNew(modNewsParamsInsertUpdate pNews)
        {

            modNews cNew = new modNews();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
                      {

                        new SqlParameter("@idNew", pNews.idNew),
                        new SqlParameter("@ImageNew", pNews.ImageNew),
                        new SqlParameter("@ImageName", pNews.ImageName),
                        new SqlParameter("@Title", pNews.Title),
                        new SqlParameter("@Subtitle", pNews.SubTitle),
                        new SqlParameter("@DescriptionNew", pNews.DescriptionNew),
                        new SqlParameter("@PinToTop", pNews.PinToTop),
                        new SqlParameter("@OrderNew", pNews.OrderNew),
                        new SqlParameter("@idPersonnalInsert", pNews.idPersonnalInsert),
                        new SqlParameter("@Isdraft", pNews.isDraft),
                        new SqlParameter("@idStatus", pNews.idStatus),
                        new SqlParameter("@idViewDeptos", pNews.idViewDeptos),
                        new SqlParameter("@idViewPositions", pNews.idViewPositions),
                        new SqlParameter("@isPendingPublish", pNews.IsPendingPublish),
                        new SqlParameter("@ExpirationDate", pNews.ExpirationDate),

                      };

            object idNews = SqlHelper.ExecuteScalar(ConnectionDWP, CommandType.StoredProcedure, "nws.InsertUpdateNew", par);

            if (idNews != null)
            {
                cNew.idNews = Convert.ToInt32(idNews);
                bFunc.CopierProperty(pNews, cNew);
            }
            else
            {
                cNew.idNews = 0;
                bFunc.CopierProperty(pNews, cNew);
            }
            return cNew;


        }

        public modidNews DeleteNews(modDeleteNewsParams pNews)
        {

            modidNews cidNew = new modidNews();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
                      {

                        new SqlParameter("@idNews", pNews.idNews),


                      };

            object idNews = SqlHelper.ExecuteScalar(ConnectionDWP, CommandType.StoredProcedure, "nws.DeleteNews", par);




            if (idNews != null)
            {
                cidNew.idNews = Convert.ToInt32(idNews);

            }
            else
            {
                cidNew.idNews = (0);
            }

            return cidNew;


        }

        public List<modNewsRelation> SelectNewsRelations(modNewsRelationParams pNews)
        {
            List<modNewsRelation> lstRelations = new List<modNewsRelation>();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@OPTION", pNews.Option),
                new SqlParameter("@IDNEWS", pNews.IdNews)
               
            };

            DataTable dt = SqlHelper.ExecuteDataset(ConnectionDWP, CommandType.StoredProcedure, "nws.SelectNewsRelations", par).Tables[0];

            lstRelations = bFunc.ConvertDataTable<modNewsRelation>(dt);

            return lstRelations;

        }

        public List<modNewsRelationCatalog> SelectNewsRelationsAllCatalogs(modNewsRelationAllCatalogsParams pNews)
        {
            List<modNewsRelationCatalog> lstRelations = new List<modNewsRelationCatalog>();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
            {
                
                new SqlParameter("@IDNEWS", pNews.IdNews)

            };

            DataTable dt = SqlHelper.ExecuteDataset(ConnectionDWP, CommandType.StoredProcedure, "nws.SelectNewsRelationsAllCatalogs", par).Tables[0];

            lstRelations = bFunc.ConvertDataTable<modNewsRelationCatalog>(dt);

            return lstRelations;

        }

        public modNewsRelation AddNewsRelations(modAddNewsRelationParams pNews)
        {

            modNewsRelation cRel = new modNewsRelation();

             SqlParameter[] par = new SqlParameter[]
                      {

                        new SqlParameter("@Option", pNews.Option),
                        new SqlParameter("@IdNews", pNews.IdNews),
                        new SqlParameter("@IdRelation", pNews.IdRelation)

                      };


            object idNews = SqlHelper.ExecuteScalar(ConnectionDWP, CommandType.StoredProcedure, "nws.AddNewsRelations", par);

            if (idNews != null)
            {
                cRel.idCatalogOptions = Convert.ToInt32(idNews);
                return cRel;
            }
            else
            {
                cRel.idCatalogOptions = 0;
                return cRel;
            }
            

        }

        public bool RemoveNewsRelations(modRemoveNewsRelationParams pNews)
        {



            SqlParameter[] par = new SqlParameter[]
                      {

                        new SqlParameter("@Option", pNews.Option),
                        new SqlParameter("@IdNews", pNews.IdNews)

                      };

            SqlHelper.ExecuteNonQuery(ConnectionDWP, CommandType.StoredProcedure, "nws.RemoveNewsRelations", par);

            return true;

        }

        #endregion


        #region PERMISSIONS

        public modPermission InsertUpdatePermissions(modPermissionParams pPermission)
        {

            modPermission cPermission = new modPermission();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
                      {

                        new SqlParameter("@idPermission", pPermission.idPermission),
                        new SqlParameter("@Permission", pPermission.Permission),
                        new SqlParameter("@Route", pPermission.Route),
                        new SqlParameter("@idControl", pPermission.idControl),
                        new SqlParameter("@idPermissionType", pPermission.idPermissionType),
                        new SqlParameter("@idPersonnalInsert", pPermission.idPersonnalInsert),
                        new SqlParameter("@Enable", pPermission.Enable),

                      };

            object idPermission = SqlHelper.ExecuteScalar(ConnectionDWP, CommandType.StoredProcedure, "per.InsertUpdatePermissions", par);

            if (idPermission != null)
            {
                cPermission.idPermission = Convert.ToInt32(idPermission);
                bFunc.CopierProperty(pPermission, cPermission);
            }
            else
            {
                cPermission.idPermission = 0;
                bFunc.CopierProperty(pPermission, cPermission);
            }
            return cPermission;


        }

        public List<modPermissionSelect> SelectPermissions(modPermissionSelectParams pPermission)
        {
            List<modPermissionSelect> lstPermissions = new List<modPermissionSelect>();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
            {

                new SqlParameter("@OPTION", pPermission.Option),
                new SqlParameter("@IDPERMISSION", pPermission.idPermission),
                new SqlParameter("@PERMISSION", pPermission.Permission)

            };

            DataTable dt = SqlHelper.ExecuteDataset(ConnectionDWP, CommandType.StoredProcedure, "per.SelectPermissions", par).Tables[0];

            lstPermissions = bFunc.ConvertDataTable<modPermissionSelect>(dt);

            return lstPermissions;

        }

        public modidPermission DeletePermission(modDeletePermissionParams pPermission)
        {

            modidPermission cidPermission = new modidPermission();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
                      {

                        new SqlParameter("@IDPERMISSION", pPermission.idPermission),


                      };

            object idPermission = SqlHelper.ExecuteScalar(ConnectionDWP, CommandType.StoredProcedure, "per.DeletePermission", par);




            if (idPermission != null)
            {
                cidPermission.idPermission = Convert.ToInt32(idPermission);

            }
            else
            {
                cidPermission.idPermission = (0);
            }

            return cidPermission;


        }

        #endregion



        public List<modCatalogOptionsSelect> SelectCatalogOptions(modCatalogOptionsSelectParams pCatalogOption)
        {
            List<modCatalogOptionsSelect> lstCatalogOptions = new List<modCatalogOptionsSelect>();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@OPTION", pCatalogOption.Option),
                new SqlParameter("@IDCATALOG", pCatalogOption.idCatalog),
                new SqlParameter("@IDCATALOGOPTIONS", pCatalogOption.idCatalogOptions)


            };

            DataTable dt = SqlHelper.ExecuteDataset(ConnectionDWP, CommandType.StoredProcedure, "per.SelectCatalogOptions", par).Tables[0];

            lstCatalogOptions = bFunc.ConvertDataTable<modCatalogOptionsSelect>(dt);

            return lstCatalogOptions;

        }

        public List<modCatalogOptionsSelect> SelectCatalogOptionsManyCatalogs(modCatalogOptionsManyCatalogsParams pCatalogOption)
        {
            List<modCatalogOptionsSelect> lstCatalogOptions = new List<modCatalogOptionsSelect>();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@OPTION", pCatalogOption.Option),
                new SqlParameter("@IDCATALOGS", pCatalogOption.idCatalogs)

            };

            DataTable dt = SqlHelper.ExecuteDataset(ConnectionDWP, CommandType.StoredProcedure, "per.SelectCatalogOptionsManyCatalogs", par).Tables[0];

            lstCatalogOptions = bFunc.ConvertDataTable<modCatalogOptionsSelect>(dt);

            return lstCatalogOptions;

        }




        public bool Update_ViewsNews(modOperViewsNewsParams pNews)
        {

            SqlParameter[] par = new SqlParameter[]
                    {

                       
                        new SqlParameter("@IdNews", pNews.IdNews)

                    };

            SqlHelper.ExecuteNonQuery(ConnectionDWP, CommandType.StoredProcedure, "nws.Update_ViewsNews", par);

            return true;

        }

        public ViewsNews Select_ViewsNews(modOperViewsNewsParams pNews)
        {


            ViewsNews cNews = new ViewsNews();

            SqlParameter[] par = new SqlParameter[]
                   {

                        new SqlParameter("@IdNews", pNews.IdNews)

                   };


            object objViews = SqlHelper.ExecuteScalar(ConnectionDWP, CommandType.StoredProcedure, "nws.Select_ViewsNews", par);

            if (objViews != null)
            {
                cNews.Views = Convert.ToInt32(objViews);
            }
            else
            {
                cNews.Views = Convert.ToInt32(0);
            }
            return cNews;


        }


        public bool Update_VersionNews(modOperViewsNewsParams pNews)
        {


            SqlParameter[] par = new SqlParameter[]
                 {


                        new SqlParameter("@IdNews", pNews.IdNews)

                 };

            SqlHelper.ExecuteNonQuery(ConnectionDWP, CommandType.StoredProcedure, "nws.Update_VersionNews", par);

            return true;


        }

        public VersionsNews Select_VersionNews(modOperViewsNewsParams pNews)
        {

            VersionsNews cNews = new VersionsNews();

            SqlParameter[] par = new SqlParameter[]
                   {

                        new SqlParameter("@IdNews", pNews.IdNews)

                   };


            object objVersion = SqlHelper.ExecuteScalar(ConnectionDWP, CommandType.StoredProcedure, "nws.Select_VersionNews", par);

            if (objVersion != null)
            {
                cNews.Version = Convert.ToInt32(objVersion);
            }
            else
            {
                cNews.Version = Convert.ToInt32(0);
            }
            return cNews;

        }



        public List<modPersonalServices> SelectPersonnalServices(modPersonalServicesParams cPer)
        {

            List<modPersonalServices> lstPersonnalServices = new List<modPersonalServices>();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
            {

                new SqlParameter("@OPTION", cPer.Option),
                new SqlParameter("@IDPERSONNAL", cPer.idPersonnal),
                new SqlParameter("@IDSERVICE", cPer.idService)

            };

            DataTable dt = SqlHelper.ExecuteDataset(ConnectionDWP, CommandType.StoredProcedure, "per.SelectPersonnalServices", par).Tables[0];

            lstPersonnalServices = bFunc.ConvertDataTable<modPersonalServices>(dt);

            return lstPersonnalServices;


        }
        public modPersonnalID InsertDeletePersonnalServices(modPersonalServicesParams cPer)
        {

            modPersonnalID cPersonnalService = new modPersonnalID();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
                      {

                        new SqlParameter("@OPTION", cPer.Option),
                        new SqlParameter("@IDPERSONNAL", cPer.idPersonnal),
                        new SqlParameter("@IDSERVICE", cPer.idService)

                      };

            object objID = SqlHelper.ExecuteScalar(ConnectionDWP, CommandType.StoredProcedure, "per.InsertDeletePersonnalServices", par);

            if (objID != null)
            {
                cPersonnalService.idPersonnalService = Convert.ToInt32(objID);
                //bFunc.CopierProperty(pPermission, cPermission);
            }
            else
            {
                cPersonnalService.idPersonnalService = Convert.ToInt32(0);
                //bFunc.CopierProperty(pPermission, cPermission);
            }
            return cPersonnalService;


        }




        //public modRolesPermissionsID InsertDeleteRolesPermissions(modRolesPermissionsParams pRolesPer)
        //{

        //    modRolesPermissionsID cRolePermission = new modRolesPermissionsID();

        //    SqlParameter[] par = new SqlParameter[]
        //              {

        //                new SqlParameter("@OPTION", pRolesPer.Option),
        //                new SqlParameter("@IDROLE", pRolesPer.IdRole),
        //                new SqlParameter("@IDPERMISSION", pRolesPer.idPermission)

        //              };

        //    object objID = SqlHelper.ExecuteScalar(ConnectionDWP, CommandType.StoredProcedure, "rol.InsertDeleteRolesPermissions", par);

        //    if (objID != null)
        //    {
        //        cRolePermission.idRolePermission = Convert.ToInt32(objID);

        //    }
        //    else
        //    {
        //        cRolePermission.idRolePermission = Convert.ToInt32(0);

        //    }
        //    return cRolePermission;


        //}
        //public List<modRolesPermissions> SelectRolesPermissions(modRolesPermissionsParams pRolesPer)
        //{

        //    List<modRolesPermissions> lstRolesPermissions = new List<modRolesPermissions>();
        //    BLFunction bFunc = new BLFunction();

        //    SqlParameter[] par = new SqlParameter[]
        //               {

        //                new SqlParameter("@OPTION", pRolesPer.Option),
        //                new SqlParameter("@IDROLE", pRolesPer.IdRole),
        //                new SqlParameter("@IDPERMISSION", pRolesPer.idPermission)

        //               };

        //    DataTable dt = SqlHelper.ExecuteDataset(ConnectionDWP, CommandType.StoredProcedure, "rol.SelectRolesPermissions", par).Tables[0];

        //    lstRolesPermissions = bFunc.ConvertDataTable<modRolesPermissions>(dt);

        //    return lstRolesPermissions;


        //}




        //public modServicesRolesID InsertDeleteServicesRoles(modServicesRolesParams pServRoles)
        //{

        //    modServicesRolesID cServRoles = new modServicesRolesID();

        //    SqlParameter[] par = new SqlParameter[]
        //              {

        //                new SqlParameter("@OPTION", pServRoles.Option),
        //                new SqlParameter("@IDSERVICE", pServRoles.idService),
        //                new SqlParameter("@IDROLE", pServRoles.idRole)

        //              };

        //    object objID = SqlHelper.ExecuteScalar(ConnectionDWP, CommandType.StoredProcedure, "ser.InsertDeleteRolesPermissions", par);

        //    if (objID != null)
        //    {
        //        cServRoles.IdServiceRole = Convert.ToInt32(objID);

        //    }
        //    else
        //    {
        //        cServRoles.IdServiceRole = Convert.ToInt32(0);

        //    }
        //    return cServRoles;


        //}
        //public List<modServicesRoles> SelectServicesRoles(modServicesRolesParams pServRoles)
        //{

        //    List<modServicesRoles> lstServicesRoles = new List<modServicesRoles>();
        //    BLFunction bFunc = new BLFunction();

        //    SqlParameter[] par = new SqlParameter[]
        //             {

        //                new SqlParameter("@OPTION", pServRoles.Option),
        //                new SqlParameter("@IDSERVICE", pServRoles.idService),
        //                new SqlParameter("@IDROLE", pServRoles.idRole)

        //             };

        //    DataTable dt = SqlHelper.ExecuteDataset(ConnectionDWP, CommandType.StoredProcedure, "ser.SelectServicesRoles", par).Tables[0];

        //    lstServicesRoles = bFunc.ConvertDataTable<modServicesRoles>(dt);

        //    return lstServicesRoles;


        //}




        //public modRolesID InsertUpdateRole(modRolesParams pRoles)
        //{

        //    modRolesID cRoles = new modRolesID();

        //    SqlParameter[] par = new SqlParameter[]
        //              {

        //                new SqlParameter("@IDROLE", pRoles.idRole),
        //                new SqlParameter("@ROLE", pRoles.Role),
        //                new SqlParameter("@IDPERSONNAL", pRoles.idPersonnal)

        //              };

        //    object objID = SqlHelper.ExecuteScalar(ConnectionDWP, CommandType.StoredProcedure, "rol.InsertUpdateRole", par);

        //    if (objID != null)
        //    {
        //        cRoles.idRole = Convert.ToInt32(objID);

        //    }
        //    else
        //    {
        //        cRoles.idRole = Convert.ToInt32(0);

        //    }
        //    return cRoles;


        //}
        //public List<modRolesSelectReturn> SelectRoles(modRolesSelect pRoles)
        //{

        //    List<modRolesSelectReturn> lstRoles = new List<modRolesSelectReturn>();
        //    BLFunction bFunc = new BLFunction();

        //    SqlParameter[] par = new SqlParameter[]
        //             {

        //                new SqlParameter("@OPTION", pRoles.Option),
        //                new SqlParameter("@IDROLE", pRoles.idRole),
        //                new SqlParameter("@ROLE", pRoles.Role)

        //             };

        //    DataTable dt = SqlHelper.ExecuteDataset(ConnectionDWP, CommandType.StoredProcedure, "rol.SelectRoles", par).Tables[0];

        //    lstRoles = bFunc.ConvertDataTable<modRolesSelectReturn>(dt);

        //    return lstRoles;


        //}



        public modPersonnalRolesID InsertDeletePersonnalRoles(modPersonnalRolesParams cPer)
        {

            modPersonnalRolesID cPersonnalRoleID = new modPersonnalRolesID();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
           {

                new SqlParameter("@OPTION", cPer.Option),
                new SqlParameter("@IDPERSONNAL", cPer.idPersonnal),
                new SqlParameter("@IDROLE", cPer.idRole)

           };

            object objID = SqlHelper.ExecuteScalar(ConnectionDWP, CommandType.StoredProcedure, "per.InsertDeletePersonnalRoles", par);

            if (objID != null)
            {
                cPersonnalRoleID.idPersonnalRole = Convert.ToInt32(objID);
                //bFunc.CopierProperty(pPermission, cPermission);
            }
            else
            {
                cPersonnalRoleID.idPersonnalRole = Convert.ToInt32(0);
                //bFunc.CopierProperty(pPermission, cPermission);
            }
            return cPersonnalRoleID;


        }

        public List<modPersonnalRoles> SelectPersonnalRoles(modPersonnalRolesParams cPer)
        {

            List<modPersonnalRoles> lstPersonnalRoles = new List<modPersonnalRoles>();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
            {

                new SqlParameter("@OPTION", cPer.Option),
                new SqlParameter("@IDPERSONNAL", cPer.idPersonnal),
                new SqlParameter("@IDROLE", cPer.idRole)

            };

            DataTable dt = SqlHelper.ExecuteDataset(ConnectionDWP, CommandType.StoredProcedure, "per.SelectPersonnalRoles", par).Tables[0];

            lstPersonnalRoles = bFunc.ConvertDataTable<modPersonnalRoles>(dt);

            return lstPersonnalRoles;


        }




        public modServicesPermissionID InsertDeleteServicesPermissions(modServicesPermissionParams cServ)
        {

            modServicesPermissionID cServicePermission = new modServicesPermissionID();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
                      {

                        new SqlParameter("@OPTION", cServ.Option),
                        new SqlParameter("@IDSERVICE", cServ.idService),
                        new SqlParameter("@IDPERMISSION", cServ.idPermission)

                      };

            object objID = SqlHelper.ExecuteScalar(ConnectionDWP, CommandType.StoredProcedure, "ser.InsertDeleteServicesPermissions", par);

            if (objID != null)
            {
                cServicePermission.IdServicePermission = Convert.ToInt32(objID);
                //bFunc.CopierProperty(pPermission, cPermission);
            }
            else
            {
                cServicePermission.IdServicePermission = Convert.ToInt32(0);
                //bFunc.CopierProperty(pPermission, cPermission);
            }
            return cServicePermission;


        }
        public List<modServicesPermissions> SelectServicesPermissions(modServicesPermissionParams cServ)
        {

            List<modServicesPermissions> lstServicesPermissions = new List<modServicesPermissions>();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
            {

                new SqlParameter("@OPTION", cServ.Option),
                new SqlParameter("@IDSERVICE", cServ.idService),
                new SqlParameter("@IDPERMISSION", cServ.idPermission)

            };

            DataTable dt = SqlHelper.ExecuteDataset(ConnectionDWP, CommandType.StoredProcedure, "ser.SelectServicesPermissions", par).Tables[0];

            lstServicesPermissions = bFunc.ConvertDataTable<modServicesPermissions>(dt);

            return lstServicesPermissions;


        }



        #region SERVICES

        public modServicesID InsertUpdateServices(modServicesParams pServices)
        {

            modServicesID cServices = new modServicesID();

            SqlParameter[] par = new SqlParameter[]
                      {

                        new SqlParameter("@IDSERVICE", pServices.idService),
                        new SqlParameter("@SERVICE", pServices.Service),
                        new SqlParameter("@IDPERSONNAL", pServices.idPersonnal)

                      };

            object objID = SqlHelper.ExecuteScalar(ConnectionDWP, CommandType.StoredProcedure, "ser.InsertUpdateServices", par);

            if (objID != null)
            {
                cServices.IdService = Convert.ToInt32(objID);

            }
            else
            {
                cServices.IdService = Convert.ToInt32(0);

            }
            return cServices;


        }
        public List<modServicesSelectReturn> SelectServices(modServicesSelect pServices)
        {

            List<modServicesSelectReturn> lstServices = new List<modServicesSelectReturn>();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
                     {

                        new SqlParameter("@OPTION", pServices.Option),
                        new SqlParameter("@IDSERVICE", pServices.idService),
                        new SqlParameter("@SERVICE", pServices.Service)

                     };


            DataTable dt = SqlHelper.ExecuteDataset(ConnectionDWP, CommandType.StoredProcedure, "ser.SelectServices", par).Tables[0];

            lstServices = bFunc.ConvertDataTable<modServicesSelectReturn>(dt);

            return lstServices;


        }
        public modServicesID DeleteServices(modDeleteServicesParams pServices)
        {

            modServicesID cidService = new modServicesID();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
                      {

                        new SqlParameter("@IDSERVICE", pServices.idService),
                        new SqlParameter("@IDPERSONNAL", pServices.idPersonnalLastModify)

                      };

            object idServices = SqlHelper.ExecuteScalar(ConnectionDWP, CommandType.StoredProcedure, "ser.DeleteServices", par);




            if (idServices != null)
            {
                cidService.IdService = Convert.ToInt32(idServices);

            }
            else
            {
                cidService.IdService = (0);
            }

            return cidService;


        }

        #endregion




        #region ROLES

        public List<modRoles> SelectRoles(modRolesParams pRoles)
        {

            List<modRoles> lstRoles = new List<modRoles>();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
                     {

                        new SqlParameter("@OPTION", pRoles.Option),
                        new SqlParameter("@IDROLE", pRoles.IdRole),
                        new SqlParameter("@ROLE", pRoles.Role)
                     };


            DataTable dt = SqlHelper.ExecuteDataset(ConnectionDWP, CommandType.StoredProcedure, "rol.SelectRoles", par).Tables[0];

            lstRoles = bFunc.ConvertDataTable<modRoles>(dt);

            return lstRoles;


        }

        public modRolesID InsertUpdateRoles(modRolesParams pRoles)
        {

            modRolesID cRoles = new modRolesID();

            SqlParameter[] par = new SqlParameter[]
                      {

                        new SqlParameter("@IDROLE", pRoles.IdRole),
                        new SqlParameter("@ROLE", pRoles.Role),
                        new SqlParameter("@IDPERSONNAL", pRoles.IdPersonnal)

                      };

            object objID = SqlHelper.ExecuteScalar(ConnectionDWP, CommandType.StoredProcedure, "rol.InsertUpdateRoles", par);

            if (objID != null)
            {
                cRoles.IdRole = Convert.ToInt32(objID);

            }
            else
            {
                cRoles.IdRole = Convert.ToInt32(0);

            }
            return cRoles;


        }

        public modRolesID DeleteRoles(modDeleteRolesParams pRoles)
        {

            modRolesID cidRole = new modRolesID();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
                      {

                        new SqlParameter("@IDROLE", pRoles.IdRole),
                        new SqlParameter("@IDPERSONNAL", pRoles.IdPersonnal)

                      };

            object idRoles = SqlHelper.ExecuteScalar(ConnectionDWP, CommandType.StoredProcedure, "rol.DeleteRoles", par);




            if (idRoles != null)
            {
                cidRole.IdRole = Convert.ToInt32(idRoles);

            }
            else
            {
                cidRole.IdRole = (0);
            }

            return cidRole;


        }

        public List<modRolesServices> SelectRolesServices(modRolesServicesParams cRoles)
        {

            List<modRolesServices> lstRolesServices = new List<modRolesServices>();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
            {

                new SqlParameter("@OPTION", cRoles.Option),
                new SqlParameter("@IDROLE", cRoles.idRole),
                new SqlParameter("@IDSERVICE", cRoles.idService)

            };

            DataTable dt = SqlHelper.ExecuteDataset(ConnectionDWP, CommandType.StoredProcedure, "rol.SelectRolesServices", par).Tables[0];

            lstRolesServices = bFunc.ConvertDataTable<modRolesServices>(dt);

            return lstRolesServices;


        }

        public modRolesServicesID InsertDeleteRolesServices(modRolesServicesParams cRoles)
        {

            modRolesServicesID cRolesServices = new modRolesServicesID();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
                      {

                        new SqlParameter("@OPTION", cRoles.Option),
                        new SqlParameter("@IDROLE", cRoles.idRole),
                        new SqlParameter("@IDSERVICE", cRoles.idService)

                      };

            object objID = SqlHelper.ExecuteScalar(ConnectionDWP, CommandType.StoredProcedure, "rol.InsertDeleteRolesServices", par);

            if (objID != null)
            {
                cRolesServices.IdRoleService = Convert.ToInt32(objID);
                //bFunc.CopierProperty(pPermission, cPermission);
            }
            else
            {
                cRolesServices.IdRoleService = Convert.ToInt32(0);
                //bFunc.CopierProperty(pPermission, cPermission);
            }
            return cRolesServices;


        }

        #endregion




        public List<modSelectPermissionByIdPersonnalResult> SelectPermissionsByIdPersonnal(modSelectPermissionByIdPersonnalParams cData)
        {

            List<modSelectPermissionByIdPersonnalResult> lstSelectPermissionsByIdPersonnal = new List<modSelectPermissionByIdPersonnalResult>();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
            {

                new SqlParameter("@OPTION", cData.Option),
                new SqlParameter("@IDPERSONNAL", cData.IdPersonnal)
                

            };

            DataTable dt = SqlHelper.ExecuteDataset(ConnectionDWP, CommandType.StoredProcedure, "per.SelectPermissionsByIdPersonnal", par).Tables[0];

            lstSelectPermissionsByIdPersonnal = bFunc.ConvertDataTable<modSelectPermissionByIdPersonnalResult>(dt);

            return lstSelectPermissionsByIdPersonnal;


        }

        public List<modSelectServicesByIdPersonnalResult> SelectServicesByIdPersonnal(modSelectPermissionByIdPersonnalParams cData)
        {

            List<modSelectServicesByIdPersonnalResult> lstSelectServicesByIdPersonnal = new List<modSelectServicesByIdPersonnalResult>();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
            {

                new SqlParameter("@OPTION", cData.Option),
                new SqlParameter("@IDPERSONNAL", cData.IdPersonnal)


            };

            DataTable dt = SqlHelper.ExecuteDataset(ConnectionDWP, CommandType.StoredProcedure, "per.SelectServicesByIdPersonnal", par).Tables[0];

            lstSelectServicesByIdPersonnal = bFunc.ConvertDataTable<modSelectServicesByIdPersonnalResult>(dt);

            return lstSelectServicesByIdPersonnal;


        }

        public List<modSelectRolesByIdPersonnalResult> SelectRolesByIdPersonnal(modSelectPermissionByIdPersonnalParams cData)
        {

            List<modSelectRolesByIdPersonnalResult> lstSelectRolesByIdPersonnal = new List<modSelectRolesByIdPersonnalResult>();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
            {

                new SqlParameter("@OPTION", cData.Option),
                new SqlParameter("@IDPERSONNAL", cData.IdPersonnal)

            };

            DataTable dt = SqlHelper.ExecuteDataset(ConnectionDWP, CommandType.StoredProcedure, "per.SelectRolesByIdPersonnal", par).Tables[0];

            lstSelectRolesByIdPersonnal = bFunc.ConvertDataTable<modSelectRolesByIdPersonnalResult>(dt);

            return lstSelectRolesByIdPersonnal;


        }



        public modidNews NegateAuthorizationNews(NegateAuthorizationParams cNew)
        {

           
            modidNews cid = new modidNews();

            
            SqlParameter[] par = new SqlParameter[]
            {

                new SqlParameter("@idnews", cNew.idNews),
                new SqlParameter("@pendingtopublish", cNew.isPendingPublish)

            };

            object objID = SqlHelper.ExecuteScalar(ConnectionDWP, CommandType.StoredProcedure, "nws.NegateAuthorizationNews", par);

            if (objID != null)
            {
                cid.idNews = Convert.ToInt32(objID);

            }
            else
            {
                cid.idNews = Convert.ToInt32(0);

            }

            return cid;


        }

        public modQtyPinToTop Select_PinToTopQTY(modQtyPinToTopParams cNew)
        {

            modQtyPinToTop cQty = new modQtyPinToTop();

            SqlParameter[] par = new SqlParameter[]
            {

                new SqlParameter("@Option", cNew.Option),
                new SqlParameter("@idDepartment", cNew.idDepartment),
                new SqlParameter("@idNews", cNew.idNews)

            };

            object objID = SqlHelper.ExecuteScalar(ConnectionDWP, CommandType.StoredProcedure, "nws.Select_PinToTopQTY", par);

            if (objID != null)
            {
                cQty.QTY = Convert.ToInt32(objID);

            }
            else
            {
                cQty.QTY = Convert.ToInt32(0);

            }

            return cQty;

        }


        public modPersonnalPhotosResult Select_PhotosPersonnalByCriteria(modPersonnalPhotosParams cPer)
        {

            modPersonnalPhotosResult cPhoto = new modPersonnalPhotosResult();

            SqlParameter[] par = new SqlParameter[]
            {

                new SqlParameter("@Option", cPer.Option),
                new SqlParameter("@idPersonnal", cPer.IdPersonnal),
                new SqlParameter("@Criteria", cPer.Criteria)

            };

            object objID = SqlHelper.ExecuteScalar(ConnectionDWP, CommandType.StoredProcedure, "per.Select_PhotosPersonnalByCriteria", par);

            if (objID != null)
            {
                cPhoto.Photo = Convert.ToString(objID);

            }
            else
            {
                cPhoto.Photo = Convert.ToString("");

            }

            return cPhoto;

        }



        #region MAILS

        public modMailsID InsertUpdateMails(modMailsParams pMail)
        {

            modMailsID cMail = new modMailsID();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
                      {

                        new SqlParameter("@IDCENTER", pMail.idCenter),
                        new SqlParameter("@IDMAIL", pMail.idMail),
                        new SqlParameter("@IDPERSONNALSENT", pMail.idPersonnalSent),
                        new SqlParameter("@IDPERSSONALRECEIVE", pMail.idPersonnalReceive),
                        new SqlParameter("@IDASSIGNAREA", pMail.idAssignArea),
                        new SqlParameter("@SUBJECT", pMail.Subject),
                        new SqlParameter("@BODY", pMail.Body),
                        new SqlParameter("@IDSTATUS", pMail.idStatus),
                        new SqlParameter("@ACTIVE", pMail.Active),

                      };

            object idMail = SqlHelper.ExecuteScalar(ConnectionDWP, CommandType.StoredProcedure, "mli.InsertUpdateMails", par);

            if (idMail != null)
            {
                cMail.idMail = Convert.ToInt32(idMail);
                bFunc.CopierProperty(pMail, cMail);
            }
            else
            {
                cMail.idMail = 0;
                bFunc.CopierProperty(pMail, cMail);
            }
            return cMail;


        }


        public List<modMailsSelect> SelectMails(modMailsSelectParams cMail)
        {

            List<modMailsSelect> lstMails = new List<modMailsSelect>();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
            {

                new SqlParameter("@OPTION", cMail.Option),
                new SqlParameter("@IDPERSONNALSENT", cMail.idPersonnalSent),
                new SqlParameter("@IDPERSSONALRECEIVE", cMail.idPersonnalReceive),
                new SqlParameter("@IDASSIGNAREA", cMail.idAssignArea),
                new SqlParameter("@SUBJECT", cMail.Subject),
                new SqlParameter("@BODY", cMail.Body),
                new SqlParameter("@IDSTATUS", cMail.idStatus),
                new SqlParameter("@ACTIVE", cMail.Active)


            };

            DataTable dt = SqlHelper.ExecuteDataset(ConnectionDWP, CommandType.StoredProcedure, "mli.SelectMails", par).Tables[0];

            lstMails = bFunc.ConvertDataTable<modMailsSelect>(dt);

            return lstMails;


        }

        #endregion



        #region MAILS LOG

        public List<modMailsLogSelect> SelectMailsLog(modMailsLogSelectParams cMailLog)
        {

            List<modMailsLogSelect> lstMailsLog = new List<modMailsLogSelect>();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
            {

                new SqlParameter("@OPTION", cMailLog.Option),
                new SqlParameter("@IDMAIL", cMailLog.idMail)


            };

            DataTable dt = SqlHelper.ExecuteDataset(ConnectionDWP, CommandType.StoredProcedure, "mli.SelectMailsLog", par).Tables[0];

            lstMailsLog = bFunc.ConvertDataTable<modMailsLogSelect>(dt);

            return lstMailsLog;


        }

        #endregion



        #region LOG ACCESS


        public modLogAccessReturn Insert_LogAccess(modLogAccessParams pLogAccess)
        {

            //modMailsID cMail = new modMailsID();
            //BLFunction bFunc = new BLFunction();

            modLogAccessReturn cLog = new modLogAccessReturn();
            cLog.idLogAccess = 0;

            SqlParameter[] par = new SqlParameter[]
                      {

                        new SqlParameter("@idPersonnal", pLogAccess.idPersonnal),
                        new SqlParameter("@idPage", pLogAccess.idPage),
                        new SqlParameter("@isFailedAccess", pLogAccess.isFailedAccess),

                      };

            object idLogAccess = SqlHelper.ExecuteScalar(ConnectionDWP, CommandType.StoredProcedure, "per.Insert_LogAccess", par);

           
            if( idLogAccess == null )
            {
                cLog.idLogAccess = 0; 

            }
            else
            {
                cLog.idLogAccess = Convert.ToInt32(idLogAccess);
                    

            }



            return cLog;


        }


        #endregion



        #region LOG PRIVACY

        public List<modLogPrivacy> SelectLogPrivacy(modLogPrivacyParams cLogPrivacy)
        {

            List<modLogPrivacy> lstLogPrivacy = new List<modLogPrivacy>();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
            {

                new SqlParameter("@OPTION", cLogPrivacy.Option),
                new SqlParameter("@IDPERSONNAL", cLogPrivacy.idPersonnal)


            };

            DataTable dt = SqlHelper.ExecuteDataset(ConnectionDWP, CommandType.StoredProcedure, "per.SelectLogPrivacy", par).Tables[0];

            lstLogPrivacy = bFunc.ConvertDataTable<modLogPrivacy>(dt);

            return lstLogPrivacy;


        }



        public modLogPrivacyID InsertLogPrivacy(modLogPrivacyParams cLogPrivacy)
        {

            modLogPrivacyID cLog = new modLogPrivacyID();
            cLog.idLogPrivacy = 0;

            SqlParameter[] par = new SqlParameter[]
                      {

                        new SqlParameter("@OPTION", cLogPrivacy.Option),
                        new SqlParameter("@IDPERSONNAL", cLogPrivacy.idPersonnal)

                      };

            object idLogPrivacy = SqlHelper.ExecuteScalar(ConnectionDWP, CommandType.StoredProcedure, "per.InsertLogPrivacy", par);


            if (idLogPrivacy == null)
            {
                cLog.idLogPrivacy = 0;

            }
            else
            {
                cLog.idLogPrivacy = Convert.ToInt32(idLogPrivacy);


            }



            return cLog;


        }

        #endregion





    }
}
