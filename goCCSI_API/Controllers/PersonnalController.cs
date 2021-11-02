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





    }
}
