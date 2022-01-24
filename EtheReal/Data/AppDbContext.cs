using EtheReal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EtheReal.Data
{
    public class AppDbContext:IdentityDbContext
    {

        public AppDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<CustomUser> CustomUsers { get; set; }
        public DbSet<Comment> Comments { get; set; }



    }
}
