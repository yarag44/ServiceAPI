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
    //[Authorize]
    public class PermissionDetailController : Controller
    {


        [HttpPost]
        [Route("SelectPermissionsDetail")]
        public async Task<IActionResult> SelectPermissionsDetail(modPermissionDetailParams pPermissionDetail)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                List<modPermissionsDetail> cPermissionDetail = bLayer.SelectPermissionsDetail(pPermissionDetail);

                return await Task.Run(() => Ok(cPermissionDetail));

            }

        }


        [HttpPost]
        [Route("InsertDeletePermissionsDetail")]
        public async Task<IActionResult> InsertDeletePermissionsDetail(modPermissionDetailParams pPermissionDetail)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                modPermissionDetailID cPermissionDetailID = bLayer.InsertDeletePermissionsDetail(pPermissionDetail);

                return await Task.Run(() => Ok(cPermissionDetailID));

            }

        }
    }
}
