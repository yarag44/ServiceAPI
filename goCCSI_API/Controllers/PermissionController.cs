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
    public class PermissionController : Controller
    {
        public PermissionController()
        {

        }


        [HttpPost]
        [Route("InsertUpdatePermissions")]
        public async Task<IActionResult> InsertUpdatePermissions(modPermissionParams pPermission)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                modPermission cPermission = bLayer.InsertUpdatePermissions(pPermission);

                return await Task.Run(() => Ok(cPermission));

            }

        }


        [HttpPost]
        [Route("SelectPermissions")]
        public async Task<IActionResult> SelectPermissions(modPermissionSelectParams pPermission)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                List<modPermissionSelect> cPermission = bLayer.SelectPermissions(pPermission);

                return await Task.Run(() => Ok(cPermission));

            }

        }

        [HttpPost]
        [Route("SelectPermissionsByIdPersonnal")]
        public async Task<IActionResult> SelectPermissionsByIdPersonnal(modSelectPermissionByIdPersonnalParams cData)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                List<modSelectPermissionByIdPersonnalResult> lstPermissions = bLayer.SelectPermissionsByIdPersonnal(cData);

                return await Task.Run(() => Ok(lstPermissions));

            }

        }










        [HttpPost]
        [Route("DeletePermission")]
        public async Task<IActionResult> DeletePermission(modDeletePermissionParams pPermission)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                modidPermission cPermission = bLayer.DeletePermission(pPermission);

                return await Task.Run(() => Ok(cPermission));

            }


        }


    }
}
