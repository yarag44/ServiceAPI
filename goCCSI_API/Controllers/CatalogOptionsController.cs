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
    public class CatalogOptionsController : Controller
    {
        [HttpPost]
        [Route("SelectCatalogOptions")]
        public async Task<IActionResult> SelectCatalogOptions(modCatalogOptionsSelectParams pCatalogOption)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                List<modCatalogOptionsSelect> cPermission = bLayer.SelectCatalogOptions(pCatalogOption);

                return await Task.Run(() => Ok(cPermission));

            }

        }


        [HttpPost]
        [Route("SelectCatalogOptionsManyCatalogs")]
        public async Task<IActionResult> SelectCatalogOptionsManyCatalogs(modCatalogOptionsManyCatalogsParams pCatalogOption)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                List<modCatalogOptionsSelect> cPermission = bLayer.SelectCatalogOptionsManyCatalogs(pCatalogOption);

                return await Task.Run(() => Ok(cPermission));

            }

        }




    }
}
