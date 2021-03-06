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
    [Authorize]
    public class RolesController : Controller
    {
        private readonly IConfiguration config;


        public RolesController(IConfiguration _config)
        {
            config = _config;
        }


        [HttpPost]
        [Route("SelectRoles")]
        public async Task<IActionResult> SelectRoles(modRolesParams pServices)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                List<modRoles> lstRoles = bLayer.SelectRoles(pServices);

                return await Task.Run(() => Ok(lstRoles));

            }


        }

        [HttpPost]
        [Route("InsertUpdateRoles")]
        public async Task<IActionResult> InsertUpdateRoles(modRolesParams pRoles)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                modRolesID RolesID = bLayer.InsertUpdateRoles(pRoles);

                return await Task.Run(() => Ok(RolesID));

            }


        }



        [HttpPost]
        [Route("DeleteRoles")]
        public async Task<IActionResult> DeleteRoles(modDeleteRolesParams pRoles)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                modRolesID cRoles = bLayer.DeleteRoles(pRoles);

                return await Task.Run(() => Ok(cRoles));

            }


        }




        [HttpPost]
        [Route("SelectRolesServices")]
        public async Task<IActionResult> SelectRolesServices(modRolesServicesParams pRoles)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                List<modRolesServices> lstRolesServices = bLayer.SelectRolesServices(pRoles);

                return await Task.Run(() => Ok(lstRolesServices));

            }


        }

        [HttpPost]
        [Route("InsertDeleteRolesServices")]
        public async Task<IActionResult> InsertDeleteRolesServices(modRolesServicesParams pRoles)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                modRolesServicesID RolesServicesID = bLayer.InsertDeleteRolesServices(pRoles);

                return await Task.Run(() => Ok(RolesServicesID));

            }


        }





    }
}
