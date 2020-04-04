﻿using Microsoft.EntityFrameworkCore;

namespace WebApplication.Models
{
    public class UserContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
            //  Database.EnsureCreated();
        }
    }
}