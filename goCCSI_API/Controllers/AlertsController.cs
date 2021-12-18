using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using goCCSI_API.Models;

namespace goCCSI_API.Controllers
{


    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("[controller]")]
    public class AlertsController : Controller
    {
        private readonly IConfiguration config;
        public AlertsController(IConfiguration _config)
        {
            config = _config;
        }





        [HttpPost]
        [Route("InsertUpdateAlerts")]
        public async Task<IActionResult> InsertUpdateAlerts(modAlertsInsertUpdParams cAlertParams)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                modAlertsReturn obj = bLayer.InsertUpdateAlerts(cAlertParams);

                return await Task.Run(() => Ok(obj));

            }


        }


        [HttpPost]
        [Route("AddAlertsRelations")]
        public async Task<IActionResult> AddAlertsRelations(modAlertsAddRelParams cAlertParams)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                bool obj = bLayer.AddAlertsRelations(cAlertParams);

                return await Task.Run(() => Ok(obj));

            }


        }



        [HttpPost]
        [Route("RemoveAlertsRelations")]
        public async Task<IActionResult> RemoveAlertsRelations(modAlertsParams cAlertParams)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                bool obj = bLayer.RemoveAlertsRelations(cAlertParams);

                return await Task.Run(() => Ok(obj));

            }


        }





        [HttpPost]
        [Route("Select_Alerts")]
        public async Task<IActionResult> Select_Alerts(modAlertsParams cAlertParams)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                List<modAlerts> cAlerts = bLayer.Select_Alerts(cAlertParams);

                return await Task.Run(() => Ok(cAlerts));

            }

        }


        [HttpPost]
        [Route("SelectAlertsRelationsAllCatalogs")]
        public async Task<IActionResult> SelectAlertsRelationsAllCatalogs(modAlertsCatRelParams cAlertParams)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                List<modAlertsCatRel> cAlertsCat = bLayer.SelectAlertsRelationsAllCatalogs(cAlertParams);

                return await Task.Run(() => Ok(cAlertsCat));

            }

        }










    }
}
