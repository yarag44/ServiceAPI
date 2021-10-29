using goCCSI_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace goCCSI_API.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly IConfiguration config;

        public LoginController(IConfiguration _config)
        {

            config = _config;

        }

        [HttpPost]
        [Route("GetToken")]
        public async Task<IActionResult> GetToken(modLogin login)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                var secretkey = config.GetValue<string>("secretkey");
                var key = Encoding.ASCII.GetBytes(secretkey);

                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, Convert.ToString(login.idPersonnal)));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddHours(24),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var createdToken = tokenHandler.CreateToken(tokenDescriptor);

                string bearer_token = tokenHandler.WriteToken(createdToken);

                return Ok(bearer_token);


            }


        }



        [HttpPost]
        [Route("SelectPersonnal")]
        public async Task<IActionResult> SelectPersonnal(modLogin login)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Error 404");

            }
            else
            {

                BL.BL bLayer = new BL.BL();

                List<modPersonnal> lstPersonnal = bLayer.SelectPersonnal(login);

                return await Task.Run(() => Ok(lstPersonnal));

            }


        }


    }
}
