using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Demo.JWT.Authen;
using MISA.Demo.JWT.Models;
using NetCore.Jwt;

namespace MISA.Demo.JWT.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
		private readonly MyAuthClient authClient;

		public AuthController(MyAuthClient authClient)
		{
			this.authClient = authClient;
		}
		[HttpPost]
		public ActionResult<string> Login([FromBody]Account account )
		{
			var result = authClient.AuthorizeUser(account.Username, account.Password);
			if (result == null) return BadRequest("invalid login");
			var claims = new List<Claim>();
			foreach (var r in result)
			{
				claims.Add(new Claim(r.Key, r.Value));
			}
			claims.Add(new Claim(ClaimTypes.Name, "nnanh")); // this can be later accessed using User.Identity.Name
			claims.Add(new Claim(ClaimTypes.NameIdentifier, "userId"));
			string token = HttpContext.GenerateBearerToken(claims);
			return token;
		}
	}
}