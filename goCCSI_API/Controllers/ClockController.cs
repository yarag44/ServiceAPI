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
    public class ClockController : Controller
    {
        private readonly IConfiguration config;


        [HttpPost]
        [Route("InsertClockDateTime")]

        public async Task<IActionResult> InsertClockDateTime(modClockDateTime pClock)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                int idClock = bLayer.InsertClockDateTime(pClock);

                return await Task.Run(() => Ok(idClock));

            }

        }




        [HttpPost]
        [Route("SelectClockDateTime")]
        public async Task<IActionResult> SelectClockDateTime(modSelectClockDateTimeParams clock)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                List<modSelectClockDateTime> lstClock = bLayer.SelectClockdateTime(clock);

                return await Task.Run(() => Ok(lstClock));

            }


        }


        [HttpPost]
        [Route("SelectCurrentDateTime")]
        public async Task<IActionResult> SelectCurrentDateTime(modSelectCurrentDateTimeParams clock)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                List<modSelectCurrentDateTime> lstClock = bLayer.SelectCurrentDateTime(clock);

                return await Task.Run(() => Ok(lstClock));

            }


        }


    }
}
