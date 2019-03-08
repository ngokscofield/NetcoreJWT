using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MISA.Demo.JWT.Authen;
using NetCore.Jwt;

namespace MISA.Demo.JWT
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
			services.AddHttpClient<MyAuthClient>(client => {
				client.BaseAddress = new Uri("https://localhost:44332");
			});
			services.AddAuthentication(NetCoreJwtDefaults.SchemeName).AddNetCoreJwt(options =>
			{
				options.Secret = "x5skHBc1IrPJRh5Q3vi3tKtmk53E3e2aVtV0J50ZwjwrnyJJki9g0COjCeIM6P1xehhjscBopXDemqzpTG7ufB5iXORSsMLC";
				// you can configure other options here too
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseMvc();
			app.UseAuthentication();
		}
	}
}
