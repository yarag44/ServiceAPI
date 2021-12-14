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
    [Authorize]
    public class LogPrivacyController : Controller
    {

        private readonly IConfiguration config;


        public LogPrivacyController(IConfiguration _config)
        {

            config = _config;

        }


        [HttpPost]
        [Route("SelectInsert_LogPrivacy")]
        public async Task<IActionResult> SelectInsert_LogPrivacy(modLogPrivacyParams pLogPrivacy)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                modLogPrivacy cLog = bLayer.SelectInsert_LogPrivacy(pLogPrivacy);

                return await Task.Run(() => Ok(cLog));

            }


        }
    }
}
