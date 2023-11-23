using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TrainingSheet.Application.Commands.ExerciseCommands.CreateExercise;
using TrainingSheet.Application.Validators;
using TrainingSheet.Core.Repositories;
using TrainingSheet.Infraestructure.Persistence;
using TrainingSheet.Infraestructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TrainingSheet.Core.Auth;
using TrainingSheet.Infraestructure.Auth;

namespace TrainingSheet.API
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

            services.AddDbContext<TrainingSheetDbContext>(opt => opt.UseInMemoryDatabase("TrainingSheetDb"));

            services.AddScoped<IExerciseRepository, ExerciseRepository>();
            services.AddScoped<IPractitionerRepository, PractitionerRepository>();
            services.AddScoped<ISheetRepository, SheetRepository>();
            services.AddScoped<IAuthService, AuthService>();

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
                //.AddJwtBearer(options =>
                //{
                //    options.TokenValidationParameters = new TokenValidationParameters
                //    {
                //        ValidateIssuer = false,
                //        ValidateAudience = false,
                //        ValidateLifetime = true,
                //        ValidateIssuerSigningKey = true,
                //        //ValidIssuer = Configuration["TokenConfigurations:Issuer"],
                //        //ValidAudience = Configuration["TokenConfigurations:Audience"],
                //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Secret-JWTKey"]))
                //    };
                //});


            services
                .AddControllers();


            services.AddValidatorsFromAssemblyContaining<ExerciseInputModelValidator>();

            services.AddMediatR(typeof(CreateExerciseCommand));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TrainingSheet.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TrainingSheet.API v1"));
            }

           

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
