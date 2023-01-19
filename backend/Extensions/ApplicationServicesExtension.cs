using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend._services;
using backend.Data;
using backend.interfaces;
using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore;

namespace backend.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration config)
        {
            services.AddDbContext<DContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            services.AddCors();
            services.AddScoped<ITokenservices, TokenServices>();

            return services;
        }
    }
}