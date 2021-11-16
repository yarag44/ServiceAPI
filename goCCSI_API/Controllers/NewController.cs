using goCCSI_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goCCSI_API.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class NewController : Controller
    {
        private readonly IConfiguration config;

        public NewController()
        {

        }



        [HttpPost]
        [Route("SelectNews")]

        public async Task<IActionResult> SelectNews(modNewsParams pNews)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Error 404");
            }
            else
            {
                BL.BL bLayer = new BL.BL();
                List<modNews> lstNews = bLayer.SelectNews(pNews);
                return await Task.Run(() => Ok(lstNews));

            }


        }


        [HttpPost]
        [Route("SelectNewsView")]

        public async Task<IActionResult> SelectNewsView(modNewsViewParams pNews)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Error 404");
            }
            else
            {
                BL.BL bLayer = new BL.BL();
                List<modNews> lstNews = bLayer.SelectNewsView(pNews);
                return await Task.Run(() => Ok(lstNews));

            }


        }






        [HttpPost]
        [Route("SelectNewsWithFilters")]

        public async Task<IActionResult> SelectNewsWithFilters(modNewsSelectWithFilterParams pNews)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Error 404");
            }
            else
            {
                BL.BL bLayer = new BL.BL();
                List<modNews> lstNews = bLayer.SelectNewsWithFilters(pNews);
                return await Task.Run(() => Ok(lstNews));

            }


        }







        [HttpPost]
        [Route("SelectFiltersNews")]

        public async Task<IActionResult> SelectFiltersNews(modNewsSelectFilterParams pNews)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Error 404");
            }
            else
            {
                BL.BL bLayer = new BL.BL();
                List<modNewsSelectFilterResult> lstPersonnal = bLayer.SelectFiltersNews(pNews);
                return await Task.Run(() => Ok(lstPersonnal));

            }


        }





        [HttpPost]
        [Route("InsertNew")]
        public async Task<IActionResult> InsertNew(modNewsParamsInsert pNews)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                modNews cNews = bLayer.InsertNew(pNews);

                return await Task.Run(() => Ok(cNews));

            }







        }



        [HttpPost]
        [Route("NegateAuthorizationNews")]
        public async Task<IActionResult> NegateAuthorizationNews(NegateAuthorizationParams pNew)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                modidNews cNews = bLayer.NegateAuthorizationNews(pNew);

                return await Task.Run(() => Ok(cNews));

            }







        }











        [HttpPost]
        [Route("InsertUpdateNew")]
        public async Task<IActionResult> InsertUpdateNew(modNewsParamsInsertUpdate pNews)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                modNews cNews = bLayer.InsertUpdateNew(pNews);

                return await Task.Run(() => Ok(cNews));

            }







        }





        [HttpPost]
        [Route("DeleteNews")]
        public async Task<IActionResult> DeleteNews(modDeleteNewsParams pNews)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                modidNews cNews = bLayer.DeleteNews(pNews);

                return await Task.Run(() => Ok(cNews));

            }


        }


        [HttpPost]
        [Route("SelectNewsRelations")]

        public async Task<IActionResult> SelectNewsRelations(modNewsRelationParams pNews)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Error 404");
            }
            else
            {
                BL.BL bLayer = new BL.BL();
                List<modNewsRelation> lstRelations = bLayer.SelectNewsRelations(pNews);
                return await Task.Run(() => Ok(lstRelations));

            }


        }



        [HttpPost]
        [Route("SelectNewsRelationsAllCatalogs")]

        public async Task<IActionResult> SelectNewsRelationsAllCatalogs(modNewsRelationAllCatalogsParams pNews)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Error 404");
            }
            else
            {
                BL.BL bLayer = new BL.BL();
                List<modNewsRelationCatalog> lstRelations = bLayer.SelectNewsRelationsAllCatalogs(pNews);
                return await Task.Run(() => Ok(lstRelations));

            }


        }







        [HttpPost]
        [Route("AddNewsRelations")]

        public async Task<IActionResult> AddNewsRelations(modAddNewsRelationParams pNews)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Error 404");
            }
            else
            {
                BL.BL bLayer = new BL.BL();
                modNewsRelation idRelation = bLayer.AddNewsRelations(pNews);
                return await Task.Run(() => Ok(idRelation));

            }


        }


        [HttpPost]
        [Route("RemoveNewsRelations")]
        public async Task<IActionResult> RemoveNewsRelations(modRemoveNewsRelationParams pNews)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Error 404");
            }
            else
            {
                BL.BL bLayer = new BL.BL();
                bool bResult = bLayer.RemoveNewsRelations(pNews);
                return await Task.Run(() => Ok(bResult));

            }

        }












        [HttpPost]
        [Route("Update_ViewsNews")]
        public async Task<IActionResult> Update_ViewsNews(modOperViewsNewsParams pNews)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Error 404");
            }
            else
            {
                BL.BL bLayer = new BL.BL();
                bool bResult = bLayer.Update_ViewsNews(pNews);
                return await Task.Run(() => Ok(bResult));

            }

        }



        [HttpPost]
        [Route("Select_ViewsNews")]
        public async Task<IActionResult> Select_ViewsNews(modOperViewsNewsParams pNews)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Error 404");
            }
            else
            {
                BL.BL bLayer = new BL.BL();
                ViewsNews itm = bLayer.Select_ViewsNews(pNews);
                return await Task.Run(() => Ok(itm));

            }

        }



        [HttpPost]
        [Route("Update_VersionNews")]
        public async Task<IActionResult> Update_VersionNews(modOperViewsNewsParams pNews)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Error 404");
            }
            else
            {
                BL.BL bLayer = new BL.BL();
                bool bResult = bLayer.Update_VersionNews(pNews);
                return await Task.Run(() => Ok(bResult));

            }

        }




        [HttpPost]
        [Route("Select_VersionNews")]
        public async Task<IActionResult> Select_VersionNews(modOperViewsNewsParams pNews)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Error 404");
            }
            else
            {

                BL.BL bLayer = new BL.BL();
                VersionsNews itm = bLayer.Select_VersionNews(pNews);
                return await Task.Run(() => Ok(itm));

            }

        }



        [HttpPost]
        [Route("Select_PinToTopQTY")]
        public async Task<IActionResult> Select_PinToTopQTY(modQtyPinToTopParams pNews)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Error 404");
            }
            else
            {

                BL.BL bLayer = new BL.BL();
                modQtyPinToTop itm = bLayer.Select_PinToTopQTY(pNews);
                return await Task.Run(() => Ok(itm));

            }

        }







        [HttpPost]
        [Route("Select_ImageFromIdNews")]
        public async Task<IActionResult> Select_ImageFromIdNews(modidNews pNews)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                modNewImage cNews = bLayer.Select_ImageFromIdNews(pNews);

                return await Task.Run(() => Ok(cNews));

            }







        }



        [HttpPost]
        [Route("Select_ActiveNewsPermissions")]
        public async Task<IActionResult> Select_ActiveNewsPermissions()
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                List<modNewsActivePermissions> cNews = bLayer.Select_ActiveNewsPermissions();

                return await Task.Run(() => Ok(cNews));

            }







        }













    }
}
