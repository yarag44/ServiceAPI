using goCCSI_API.Models;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class MailController : Controller
    {
        [HttpPost]
        [Route("InsertUpdateMails")]
        public async Task<IActionResult> InsertUpdateMails(modMailsParams pMails)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                 modMailsID MailsID = bLayer.InsertUpdateMails(pMails);

                return await Task.Run(() => Ok(MailsID));

            }


        }

        [HttpPost]
        [Route("SelectMails")]
        public async Task<IActionResult> SelectSMails(modMailsSelectParams pMails)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                List<modMailsSelect> lstMails = bLayer.SelectMails(pMails);

                return await Task.Run(() => Ok(lstMails));

            }


        }
    }
}
