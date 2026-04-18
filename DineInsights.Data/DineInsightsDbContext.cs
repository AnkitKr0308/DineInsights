using DineInsights.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DineInsights.Data
{
    public class DineInsightsDbContext : DbContext
    {
        public DineInsightsDbContext(DbContextOptions<DineInsightsDbContext> options):base(options)
        {
            
        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
