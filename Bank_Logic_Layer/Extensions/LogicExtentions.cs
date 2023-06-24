using Bank_Logic_Layer.Abstractions;
using Bank_Logic_Layer.Implementations;
using Bank_Logic_Layer.Logics;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Logic_Layer.Extensions
{
    public static class LogicExtentions
    {
       public static void LogicServices(this IServiceCollection services)
       {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<CustomerLogic>();
            services.AddScoped<CardTypeLogic>();
            services.AddScoped<CardUserLogic>();
       }
    }
}
