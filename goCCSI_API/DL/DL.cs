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
                        new SqlParameter("@idStatus", pNews.idStatus)

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








    }
}
