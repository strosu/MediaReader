using MediaReaderServer.Controllers;
using MediaReaderServer.Repository;
using MediaReaderServer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace MediaReaderServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            RegisterServices(services);

            services.AddMvc(
                options => {
                    options.EnableEndpointRouting = false;
                });
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IArticleRepository, ArticleRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();
            app.UseRouting();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "Get",
                    template: "/Article/{id:int}",
                    defaults: new { controller = "Article", action = nameof(ArticleController.Get) });
                routes.MapRoute(
                    name: "default",
                    template: "/{controller}/{action}/{id?}",
                    defaults: new { controller = "Article" , action = nameof(ArticleController.ListAll) });
                    });
        }
    }
}
