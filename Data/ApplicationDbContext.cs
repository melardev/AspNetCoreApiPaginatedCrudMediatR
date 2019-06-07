﻿using ApiCrudPaginationMediatR.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiCrudPaginationMediatR.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }
    }
}