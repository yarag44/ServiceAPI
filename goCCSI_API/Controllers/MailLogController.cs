using goCCSI_API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goCCSI_API.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("[controller]")]

    public class MailLogController : Controller
    {
        [HttpPost]
        [Route("SelectMailsLog")]
        public async Task<IActionResult> SelectSMailsLog(modMailsLogSelectParams pMailsLog)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                List<modMailsLogSelect> lstMails = bLayer.SelectMailsLog(pMailsLog);

                return await Task.Run(() => Ok(lstMails));

            }


        }
    }
}
