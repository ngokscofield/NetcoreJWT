using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MISA.Demo.JWT.Authen
{
	public class MyAuthClient
	{
		private readonly HttpClient httpClient;

		public MyAuthClient(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}
		
		public Dictionary<string, string> AuthorizeUser(string username, string password)
		{
			// use the httpClient send login and get confirmation from client's system
			if (username!="nnanh" || password != "12345") return null;
			else
			{
				var result = new Dictionary<string, string>();
				result["userName"] = "nnanh"; // get these values from the http request you have created above.
				result["passWord"] = "12345";
				return result;
			}
		}

	}
}
