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

    public class ServiceController : Controller
    {

        private readonly IConfiguration config;


        public ServiceController(IConfiguration _config)
        {
            config = _config;
        }



        [HttpPost]
        [Route("InsertDeleteServicesRoles")]
        public async Task<IActionResult> InsertDeleteServicesRoles(modServicesRolesParams pServices)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                modServicesRolesID ServicesRolesID = bLayer.InsertDeleteServicesRoles(pServices);

                return await Task.Run(() => Ok(ServicesRolesID));

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
        [Route("SelectServicesRoles")]
        public async Task<IActionResult> SelectServicesRoles(modServicesRolesParams pServices)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                List<modServicesRoles> lstServices = bLayer.SelectServicesRoles(pServices);

                return await Task.Run(() => Ok(lstServices));

            }


        }



    }
}
