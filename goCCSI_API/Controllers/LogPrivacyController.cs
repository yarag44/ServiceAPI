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
        [Route("SelectLogPrivacy")]
        public async Task<IActionResult> SelectLogPrivacy(modLogPrivacyParams pLogPrivacy)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                List<modLogPrivacy> lsLogPrivacy = bLayer.SelectLogPrivacy(pLogPrivacy);

                return await Task.Run(() => Ok(lsLogPrivacy));

            }


        }


        [HttpPost]
        [Route("InsertLogPrivacy")]
        public async Task<IActionResult> InsertLogPrivacy(modLogPrivacyParams pLogPrivacy)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                modLogPrivacyID cLog = bLayer.InsertLogPrivacy(pLogPrivacy);

                return await Task.Run(() => Ok(cLog));

            }


        }
    }
}
