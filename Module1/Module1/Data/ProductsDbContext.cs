using Microsoft.EntityFrameworkCore;
using Module1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module1.Data
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext>options): base(options)
        {

        }
        public DbSet<ProductV2> Products { get; set; }
    }
}
