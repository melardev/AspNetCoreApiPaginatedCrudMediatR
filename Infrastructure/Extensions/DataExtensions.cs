﻿using ApiCrudPaginationMediatR.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiCrudPaginationMediatR.Infrastructure.Extensions
{
    public static class DataExtensions
    {
        public static void AddDb(this IServiceCollection services, IConfiguration configuration)
        {
            /*
             services.AddDbContext<ApplicationDbContext>(options =>
      options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<MyContext>(options=>options.UseSqlServer(Configuration
                ["ConnectionStrings:DefaultConnection"]));
            */
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(configuration.GetSection("DataSources:SQLite:ConnectionString").Value));
        }
    }
}