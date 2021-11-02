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
    public class RoleController : Controller
    {

        private readonly IConfiguration config;


        public RoleController(IConfiguration _config)
        {
            config = _config;
        }


        [HttpPost]
        [Route("InsertDeleteRolesPermissions")]
        public async Task<IActionResult> InsertDeleteRolesPermissions(modRolesPermissionsParams pRoles)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                modRolesPermissionsID RolesPermID = bLayer.InsertDeleteRolesPermissions(pRoles);

                return await Task.Run(() => Ok(RolesPermID));

            }


        }



        [HttpPost]
        [Route("InsertUpdateRole")]
        public async Task<IActionResult> InsertUpdateRole(modRolesParams pRoles)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                modRolesID RolesID = bLayer.InsertUpdateRole(pRoles);

                return await Task.Run(() => Ok(RolesID));

            }


        }




        [HttpPost]
        [Route("SelectRoles")]
        public async Task<IActionResult> SelectRoles(modRolesSelect pRoles)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                List<modRolesSelectReturn> lstRoles = bLayer.SelectRoles(pRoles);

                return await Task.Run(() => Ok(lstRoles));

            }


        }



        [HttpPost]
        [Route("SelectRolesPermissions")]
        public async Task<IActionResult> SelectRolesPermissions(modRolesPermissionsParams pRoles)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                List<modRolesPermissions> lstRolesPermissions = bLayer.SelectRolesPermissions(pRoles);

                return await Task.Run(() => Ok(lstRolesPermissions));

            }


        }





    }
}
