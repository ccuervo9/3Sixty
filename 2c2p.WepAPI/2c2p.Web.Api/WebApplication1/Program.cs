using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using WebApi2c2p.JWTAuthorize;
using Microsoft.OpenApi.Models;
using System;
using BussinesLogic.Interfaces.Authorize;
using BussinesLogic.Interfaces.Inquiry;
using BussinesLogic.Interfaces.Payment;
using BussinesLogic.Interfaces.PaymentAPM;
using BussinesLogic.Interfaces.Refund;
using BussinesLogic.Interfaces.Settlement;
using BussinesLogic.Interfaces.Void;
using BussinesLogic.Services.Authorize;
using BussinesLogic.Services.Payment;
using BussinesLogic.Services.PaymentAPM;
using BussinesLogic.Services.Void;
using DataAccess.Interfaces.Authorize;
using DataAccess.Interfaces.Inquiry;
using DataAccess.Interfaces.Payment;
using DataAccess.Interfaces.PaymentAPM;
using DataAccess.Interfaces.Refund;
using DataAccess.Interfaces.Settlement;
using DataAccess.Interfaces.Void;
using DataAccess.Repository.Authorize;
using DataAccess.Repository.Inquiry;
using DataAccess.Repository.Payment;
using DataAccess.Repository.PaymentAPM;
using DataAccess.Repository.Refund;
using DataAccess.Repository.Settlement;
using DataAccess.Repository.Void;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using AutoMapper;


namespace WebApi2c2p
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Jwt configuration starts here
            var jwtIssuer = builder.Configuration.GetSection("JwtConfig:Issuer").Get<string>();
            var jwtKey = builder.Configuration.GetSection("JwtConfig:Key").Get<string>();

            var jwtOptions = builder.Configuration
                .GetSection("JwtConfig")
                .Get<JwtOptions>();

            builder.Services.AddSingleton(jwtOptions);
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                 .AddJwtBearer(opts =>
                 {

                     //convert the string signing key to byte array
                     byte[] signingKeyBytes = Encoding.UTF8
                         .GetBytes(jwtOptions.Key);

                     opts.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuer = true,
                         ValidateAudience = true,
                         ValidateLifetime = true,
                         ValidateIssuerSigningKey = true,
                         ValidIssuer = jwtOptions.Issuer,
                         ValidAudience = jwtOptions.Audience,
                         IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
                     };
                 });
            //builder.Services.AddHttpClient<ILoginApiRepository, LoginApiRepository>(
            //        c => c.BaseAddress = new Uri("https://localhost:5001/"));
            builder.Services.AddControllers();
         

            builder.Services.AddEndpointsApiExplorer();

            //DB context and conection string definition
            builder.Services.AddDbContext<AppDbContext>(options =>
                           options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:DefaultValue").Get<string>()));

            builder.Services.AddSwaggerGen(setup =>
            {
                // Include 'SecurityScheme' to use JWT Authentication
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        { jwtSecurityScheme, Array.Empty<string>() }
                    });

            });

            ////Jwt configuration ends here
            SingletonDependency(builder.Services);

            var app = builder.Build();          

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.MapControllers();
       
 
            app.UseAuthorization();  
            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        /// <summary>
        /// Singleton Dependencies to read and get controller throug layers
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        private static void SingletonDependency(IServiceCollection services)
        {

            services.AddAutoMapper(typeof(Startup));

            //Authorize
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            //Inquiry
            services.AddScoped<ITransactionListRepository, TransactionListRepository>();
            services.AddScoped<ITransactionListService, TransactionListService>();

            //Payment
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentService, PaymentService>();

            //PaymentAPM
            services.AddScoped<IPaymentAPMRepository, PaymentAPMRepository>();
            services.AddScoped<IPaymentAPMService, PaymentAPMService>();

            //Refund
            services.AddScoped<IRefundRepository, RefundRepository>();
            services.AddScoped<IRefundService, RefundService>();

            //Settlement
            services.AddScoped<ISettlementRepository, SettlementRepository>();
            services.AddScoped<ISettlementService, SettlementService>();

            //Void
            services.AddScoped<IVoidRepository, VoidRepository>();
            services.AddScoped<IVoidService, VoidService>();
        }

    }
}
