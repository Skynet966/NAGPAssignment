using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NAGP.Services.ProviderAPI.Service;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NAGP.Services.ProviderAPI
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NAGP.Services.Provider", Version = "v1" });
            });
            services.AddSingleton<IHostedService, HostedServiceDiscovery>();

            services.AddHttpClient<IOrderService, OrderService>(o =>
            o.BaseAddress = new Uri(Configuration["OrderAPIURL"]))
                .SetHandlerLifetime(TimeSpan.FromMinutes(10))
                .AddPolicyHandler(GetCircuitBreakerPolicy());

            services.AddHttpClient<ICustomerService, CustomerService>(o =>
            o.BaseAddress = new Uri(Configuration["CustomerAPIURL"]))
                .SetHandlerLifetime(TimeSpan.FromMinutes(10))
                .AddPolicyHandler(GetCircuitBreakerPolicy());

            services.AddHttpClient<IServiceService, ServiceService>(o =>
            o.BaseAddress = new Uri(Configuration["ServiceAPIURL"]))
                .SetHandlerLifetime(TimeSpan.FromMinutes(10))
                .AddPolicyHandler(GetCircuitBreakerPolicy());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NAGP.Services.Provider v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(5, TimeSpan.FromSeconds(60));
        }
    }
}
