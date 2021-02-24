using Microsoft.EntityFrameworkCore;
using SalesStatistics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesStatistics.Data
{
    public class SalesDbContext : DbContext
    {
        public DbSet<Sale> Sales { get; set; }

        public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options)
        {

        }
    }
}
