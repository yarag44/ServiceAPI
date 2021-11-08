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
            ConnectionDWP = @"Server=tcp:ccsidigitalworkplace.database.windows.net,1433;Initial Catalog=CCSIDigitalWorkPlace;Persist Security Info=False;User ID=ccsiadmin;Password=G3nerico01#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }

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




        public int InsertClockDateTime(modClockDateTime pClock)
        {

            SqlParameter[] par = new SqlParameter[]
                      {

                        new SqlParameter("@IDPERSONNAL", pClock.idPersonnal),
                        new SqlParameter("@IDSTATUS", pClock.idStatus)

                      };


            object idClock = SqlHelper.ExecuteScalar(ConnectionDWP, CommandType.StoredProcedure, "clk.InsertClockDateTime", par);

            if (idClock != null)
                return Convert.ToInt32(idClock);
            else
                return 0;



        }


        public List<modSelectClockDateTime> SelectClockdateTime(modSelectClockDateTime pClock)
        {
            List<modSelectClockDateTime> lstClock = new List<modSelectClockDateTime>();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@OPTION", pClock.Option),
                new SqlParameter("@IDPERSONNAL", pClock.idPersonnal),
                new SqlParameter("@IDSTATUS", pClock.idStatus),
                new SqlParameter("@STARTDATE", pClock.startDate),
                new SqlParameter("@ENDDATE", pClock.endDate),
                new SqlParameter("@IDCENTER", pClock.idCenter),
                new SqlParameter("@IDDEPARTMENT", pClock.idDepartment),
                new SqlParameter("@SEARCH", pClock.personnalNoEmployee),
                new SqlParameter("@IDCHECKTYPE", pClock.idStatus)

            };

            DataTable dt = SqlHelper.ExecuteDataset(ConnectionDWP, CommandType.StoredProcedure, "clk.SelectClockdateTime", par).Tables[0];

            lstClock = bFunc.ConvertDataTable<modSelectClockDateTime>(dt);

            return lstClock;

        }



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



        public modPermission InsertUpdatePermissions(modPermissionParams pPermission)
        {

            modPermission cPermission = new modPermission();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
                      {

                        new SqlParameter("@idPermission", pPermission.idPermission),
                        new SqlParameter("@Permission", pPermission.Permission),
                        new SqlParameter("@idPermissionType", pPermission.idPermissionType),
                        new SqlParameter("@idPersonnalInsert", pPermission.idPersonnalInsert)

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




        public List<modCatalogOptionsSelect> SelectCatalogOptions(modCatalogOptionsSelectParams pCatalogOption)
        {
            List<modCatalogOptionsSelect> lstCatalogOptions = new List<modCatalogOptionsSelect>();
            BLFunction bFunc = new BLFunction();

            SqlParameter[] par = new SqlParameter[]
            {

                new SqlParameter("@IDCATALOG", pCatalogOption.idCatalog)

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


    }
}
