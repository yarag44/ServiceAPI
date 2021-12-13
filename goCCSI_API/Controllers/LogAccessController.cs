using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using goCCSI_API.Models;
using Microsoft.AspNetCore.Authorization;

namespace goCCSI_API.Controllers
{


    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class LogAccessController : Controller
    {

        private readonly IConfiguration config;



        public LogAccessController(IConfiguration _config)
        {

            config = _config;

        }


        [HttpPost]
        [Route("Insert_LogAccess")]
        public async Task<IActionResult> Insert_LogAccess(modLogAccessParams pLogAccess)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                modLogAccessReturn cLog   = bLayer.Insert_LogAccess(pLogAccess);

                return await Task.Run(() => Ok(cLog));

            }


        }






    }
}
