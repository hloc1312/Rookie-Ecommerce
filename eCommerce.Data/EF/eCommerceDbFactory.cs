using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace eCommerce.Data.EF
{
    class eCommerceDbFactory : IDesignTimeDbContextFactory<eCommerceDbContext>
    {

        public eCommerceDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsetting.json")
               .Build();

            var connectString = configuration.GetConnectionString("eCommerceDb");

            var optionsBuilder = new DbContextOptionsBuilder<eCommerceDbContext>();
            optionsBuilder.UseSqlServer(connectString);
            return new eCommerceDbContext(optionsBuilder.Options);
            
        }
    }

}
