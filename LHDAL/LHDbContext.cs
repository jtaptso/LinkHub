using LHBOL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace LHDAL
{
    public class LHDbContext : IdentityDbContext
    {
        public LHDbContext(DbContextOptions<LHDbContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            //Database.Migrate();
            Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=TAPTSO\\JTAPTSOSQLSERVER;Database=LinkHubDataBase;Trusted_Connection=True;");
        //}

        public DbSet<Category> Categories { get; set; }
        public DbSet<LHUrl> LHUrls { get; set; }
        public DbSet<LHUser> LHUsers { get; set; }
    }
}
