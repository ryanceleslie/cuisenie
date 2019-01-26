using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Migrations
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MealPlannerContext>
    {
        public MealPlannerContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MealPlannerContext>();

            return new MealPlannerContext(builder.Options);
        }
    }
}
