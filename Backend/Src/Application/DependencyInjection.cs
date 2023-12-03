using Application.Interfaces.AuthorizationService;
using Application.Interfaces.DataService;
using Application.Interfaces.PaymentService;
using Application.Services.AuthorizationService;
using Application.Services.DataService;
using Application.Services.PaymentService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IShopCartService, ShopCartService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IAuthorizationService, AuthorizationService>();
            services.AddScoped<IPaymentService, PaymentService>();
            
            return services;
        }
    }
}
