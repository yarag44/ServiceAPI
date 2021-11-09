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
    public class PermissionCatalogController : Controller
    {
        [HttpPost]
        [Route("SelectPermissionsCatalog")]
        public async Task<IActionResult> SelectPermissionsCatalog(modPermissionsCatalogSelect pPermissionsCatalog)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                List<modPermissionsCatalogSelect> cPermissionCatalog = bLayer.SelectPermissionsCatalog(pPermissionsCatalog);

                return await Task.Run(() => Ok(cPermissionCatalog));

            }

        }
    }
}
