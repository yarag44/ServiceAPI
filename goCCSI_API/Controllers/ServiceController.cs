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
    public class ServiceController : Controller
    {

        private readonly IConfiguration config;


        public ServiceController(IConfiguration _config)
        {
            config = _config;
        }



        [HttpPost]
        [Route("InsertDeleteServicesPermissions")]
        public async Task<IActionResult> InsertDeleteServicesPermissions(modServicesPermissionParams pServices)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                modServicesPermissionID ServicesPermissionID = bLayer.InsertDeleteServicesPermissions(pServices);

                return await Task.Run(() => Ok(ServicesPermissionID));

            }


        }



        [HttpPost]
        [Route("SelectServicesPermissions")]
        public async Task<IActionResult> SelectServicesPermissions(modServicesPermissionParams pServices)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                List<modServicesPermissions> lstServices = bLayer.SelectServicesPermissions(pServices);

                return await Task.Run(() => Ok(lstServices));

            }


        }







        [HttpPost]
        [Route("InsertUpdateServices")]
        public async Task<IActionResult> InsertUpdateServices(modServicesParams pServices)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                modServicesID ServicesID = bLayer.InsertUpdateServices(pServices);

                return await Task.Run(() => Ok(ServicesID));

            }


        }



        [HttpPost]
        [Route("SelectServices")]
        public async Task<IActionResult> SelectServices(modServicesSelect pServices)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                List<modServicesSelectReturn> lstServices = bLayer.SelectServices(pServices);

                return await Task.Run(() => Ok(lstServices));

            }


        }


        [HttpPost]
        [Route("DeleteServices")]
        public async Task<IActionResult> DeleteServices(modDeleteServicesParams pServices)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                modServicesID cService = bLayer.DeleteServices(pServices);

                return await Task.Run(() => Ok(cService));

            }


        }





    }
}
