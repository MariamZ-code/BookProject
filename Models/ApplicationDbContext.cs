﻿using BookProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Book.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
       
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {
            }
        

        public DbSet<Book> Books { get; set; }
    }
}
