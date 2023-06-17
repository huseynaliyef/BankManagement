using Bank_Data_Layer.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Data_Layer.Extensions
{
    public static class DataExtension
    {
        public static void InjectDataBase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BankDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            //services.AddIdentity<IdentityUser, IdentityRole>(options =>
            //{
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireDigit = false;
            //    options.Password.RequireLowercase = false;
            //    options.Password.RequiredLength = 3;
            //    options.Password.RequireLowercase = false;
            //    options.Password.RequireUppercase = false;
            //}).AddEntityFrameworkStores<BankDbContext>().AddDefaultTokenProviders();
            
        }
    }
}
