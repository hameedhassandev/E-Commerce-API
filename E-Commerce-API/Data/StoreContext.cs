﻿using E_Commerce_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<Product> Products { get; set; }    
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }

    }
}