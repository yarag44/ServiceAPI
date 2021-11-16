using goCCSI_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace goCCSI_API.Controllers
{


    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("[controller]")]
    public class PersonnalController : Controller
    {


        private readonly IConfiguration config;

        public PersonnalController(IConfiguration _config)
        {

            config = _config;

        }

        [HttpPost]
        [Route("UpdatePersonnalPassword")]
        public async Task<IActionResult> UpdatePersonnalPassword(modPersonnalPasswordParams pPer)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                modPersonnalPasswordID cPerID = bLayer.UpdatePersonnalPassword(pPer);

                return await Task.Run(() => Ok(cPerID));

            }

        }


        [HttpPost]
        [Route("SelectPersonnalServices")]
        public async Task<IActionResult> SelectPersonnalServices(modPersonalServicesParams pPer)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                List<modPersonalServices> lstPersonnalServices = bLayer.SelectPersonnalServices(pPer);

                return await Task.Run(() => Ok(lstPersonnalServices));

            }


        }


        [HttpPost]
        [Route("InsertDeletePersonnalServices")]
        public async Task<IActionResult> InsertDeletePersonnalServices(modPersonalServicesParams pPer)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                modPersonnalID cPerID = bLayer.InsertDeletePersonnalServices(pPer);

                return await Task.Run(() => Ok(cPerID));

            }


        }





        [HttpPost]
        [Route("Select_CatPersonnalFilters")]
        public async Task<IActionResult> Select_CatPersonnalFilters(modPersonnalFiltersParams pPer)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                List<modPersonnal> lstPersonnal = bLayer.Select_CatPersonnalFilters(pPer);

                return await Task.Run(() => Ok(lstPersonnal));

            }


        }


        [HttpPost]
        [Route("InsertDeletePersonnalRoles")]
        public async Task<IActionResult> InsertDeletePersonnalRoles(modPersonnalRolesParams pPer)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                modPersonnalRolesID cPerID = bLayer.InsertDeletePersonnalRoles(pPer);

                return await Task.Run(() => Ok(cPerID));

            }

        }





        [HttpPost]
        [Route("SelectPersonnalRoles")]
        public async Task<IActionResult> SelectPersonnalRoles(modPersonnalRolesParams pPer)
        {
            
            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                List<modPersonnalRoles> lstPerRoles = bLayer.SelectPersonnalRoles(pPer);

                return await Task.Run(() => Ok(lstPerRoles));

            }

        }



        [HttpPost]
        [Route("Select_PhotosPersonnalByCriteria")]
        public async Task<IActionResult> Select_PhotosPersonnalByCriteria(modPersonnalPhotosParams pPer)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                modPersonnalPhotosResult cPhoto = bLayer.Select_PhotosPersonnalByCriteria(pPer);

                return await Task.Run(() => Ok(cPhoto));

            }

        }











    }
}
