using goCCSI_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goCCSI_API.Controllers
{
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
    }
}
