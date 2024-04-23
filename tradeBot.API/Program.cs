using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Nancy.Authentication.JwtBearer;
using NLog;
using tradeBot.API.Interfaces;
using tradeBot.API.Services;
using tradeBot.DAL.Database;

namespace tradeBot.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            if (!OperatingSystem.IsMacOS())
            {
                builder.WebHost.ConfigureKestrel(options =>
                {
                    options.ListenLocalhost(5427, o => o.Protocols = HttpProtocols.Http2);
                });
            }

            builder.Services.AddControllers();
            builder.Services.AddDbContext<ApplicationContext>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IOfferService, OfferService>();
            builder.Services.AddTransient<ITelegramService, TelegramService>();
            builder.Services.AddTransient<IAuthService, AuthService>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(opt =>
            {
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddCors(p => p.AddPolicy("corsapp",
                builder => { builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader(); }));
            

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.UseExceptionHandler(x => x.Run(async context =>
            {
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

                context.Response.Headers.ContentType = "application/json; charset=utf-8";

                await context.Response.WriteAsync(context.Features.Get<IExceptionHandlerPathFeature>().Error.Message);
            }));
            app.UseHsts();

            app.UseCors("corsapp");
            
            app.Run();
            
            Console.WriteLine("Hello world!");
        }
    }
}