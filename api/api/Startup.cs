using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
				app.Map("/getList", GetList);
			}

			 void GetList(IApplicationBuilder App)
			{
				List<string> lst = new List<string>();
				lst.Add("Cake");
				lst.Add("Candle");
				lst.Add("Chill");
				var passvalue = JsonConvert.SerializeObject(lst);

				App.Run(async (context) =>
				{
					await context.Response.WriteAsync(passvalue);
				});

			}

		}
    }
}
