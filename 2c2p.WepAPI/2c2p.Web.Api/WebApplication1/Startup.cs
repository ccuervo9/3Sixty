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
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using DataAccess.Context;

namespace WebApi2c2p
{
    public class Startup
    {
        public  IConfiguration Configuration   { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            AddSwagger(services);
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddHttpContextAccessor();

            //DB context and conection string definition
            services.AddDbContext<AppDbContext>(options =>
                           options.UseSqlServer(Configuration["ConnectionStrings:DefaultValue"]));
            services.AddAutoMapper(typeof(Startup));
            SingletonDependency(services);
            services.AddControllers();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "3Sixty V1");
            });


        }


        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"P2CP {groupName}",
                    Version = groupName,
                    Description = "API Gateway 3Sixty",
                    Contact = new OpenApiContact
                    {
                        Name = "3Sixty",
                        Email = string.Empty,
                        Url = new Uri("https://foo.com/"),
                    }
                });
            });
        }

        /// <summary>
        /// Singleton Dependencies to read and get controller and layers
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        private static void SingletonDependency(IServiceCollection services)
        {     

            //Authorize
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IUserService, UserService>();

            //Inquiry
            services.AddSingleton<ITransactionListRepository, TransactionListRepository>();
            services.AddSingleton<ITransactionListService, TransactionListService>();

            services.AddSingleton<ITransactionStatusRepository, TransactionStatusRepository>();
            services.AddSingleton<ITransactionStatusService, TransactionStatusService>();

            //Payment
            services.AddSingleton<IPaymentService, PaymentService>();
            services.AddSingleton<IPaymentRepository, PaymentRepository>();

            services.AddSingleton<IPrePaymentUIRepository, PrePaymentUIRepository>();
            services.AddSingleton<IPrePaymentUIService, PrePaymentUIService>();

            //PaymentAPM
            services.AddSingleton<IPaymentAPMRepository, PaymentAPMRepository>();
            services.AddSingleton<IPaymentAPMService, PaymentAPMService>();

            //Refund
            services.AddSingleton<IRefundRepository, RefundRepository>();
            services.AddSingleton<IRefundService, RefundService>();

            //Settlement
            services.AddSingleton<ISettlementRepository, SettlementRepository>();
            services.AddSingleton<ISettlementService, SettlementService>();

            //Void
            services.AddSingleton<IVoidRepository, VoidRepository>();
            services.AddSingleton<IVoidService, VoidService>();
        }
    }

}