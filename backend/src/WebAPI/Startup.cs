using System;
using System.Text;
using Application.Common.Behaviours;
using Application.Common.Interfaces;
using Application.Common.Mapping;
using AutoMapper;
using FluentValidation;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebAPI.Common;

namespace WebAPI
{
    public class Startup
    {
        private IServiceCollection _services;
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(o =>
                o.UseInMemoryDatabase("AppDb"));
            
            services.AddScoped<IAppDbContext>(p => p.GetService<AppDbContext>());
            
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddMediatR(typeof(RequestValidationBehavior<,>).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetPreflightMaxAge(TimeSpan.FromDays(5)));
            });
            
            services
                .AddControllers()
                .AddNewtonsoftJson();
            
            // Fluent Validators
            AssemblyScanner.FindValidatorsInAssemblyContaining<IAppDbContext>().ForEach(pair =>
            {
                services.Add(ServiceDescriptor.Transient(pair.InterfaceType, pair.ValidatorType));
                services.Add(ServiceDescriptor.Transient(pair.ValidatorType, pair.ValidatorType));
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = AppInvalidModelStateResponse.Handle;
            });
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Orders List App API", Version = "v1" });
            });
            
            _services = services;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("AllowLocalhost");
                RegisteredServicesPage(app);
            }
            app.UseAppExceptionHandler();

            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Orders List App API v1"));
            
            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
        
        private void RegisteredServicesPage(IApplicationBuilder app)
        {
            app.Map("/services", builder => builder.Run(async context =>
            {
                var sb = new StringBuilder();
                sb.Append("<h1>Registered Services</h1>");
                sb.Append("<table><thead>");
                sb.Append("<tr><th>Type</th><th>Lifetime</th><th>Instance</th></tr>");
                sb.Append("</thead><tbody>");
                foreach (var svc in _services)
                {
                    sb.Append("<tr>");
                    sb.Append($"<td>{svc.ServiceType.FullName}</td>");
                    sb.Append($"<td>{svc.Lifetime}</td>");
                    sb.Append($"<td>{svc.ImplementationType?.FullName}</td>");
                    sb.Append("</tr>");
                }
                sb.Append("</tbody></table>");
                await context.Response.WriteAsync(sb.ToString());
            }));
        }
    }
}