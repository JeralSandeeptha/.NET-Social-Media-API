﻿using Microsoft.EntityFrameworkCore;
using SocialMediaApiLastChance.Models;

namespace SocialMediaApiLastChance.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Admin> Admins { get; set; }
    }
}
