using Lab1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<GameLaunch> GameLaunches { get; set; }
        public DbSet<FirstGameLaunch> FirstGameLaunches { get; set; }
        public DbSet<StageStart> StageStarts { get; set; }
        public DbSet<StageEnd> StageEnds { get; set; }
        public DbSet<IngamePurchase> IngamePurchases { get; set; }
        public DbSet<CurrencyPurchase> CurrencyPurchases { get; set; }
    }
}
