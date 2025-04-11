using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Presistence.Data;

namespace Presistence
{
    public class DbInitializer : IDbInitializer
    {
        private readonly StoreDbContext _context;

        public DbInitializer(StoreDbContext context)
        {
            _context = context;
        }
        
        public  async Task InitializeAsync()
        {
            //create database if doesnt exist && Applu any punding migration 
            if (_context.Database.GetPendingMigrations().Any())
            {
                await _context.Database.MigrateAsync();


            }

            ///2: Data seeding 
            ///
            /// seeding product type from jasson files
            if (!_context.ProductTypes.Any())
            {
                //1: Read All Data from jasson files 
               var TypesData = await  File.ReadAllTextAsync(@"..\Infrastructure\\Presistence\\Data\\Seeding\\types.json");
                
                //2: Transfer All data to c# object
                
               var types =  JsonSerializer.Deserialize<List<ProductType>>(TypesData);

                //3: Add List  to databas 

                if (types is not null && types.Any())
                {
                    await _context.ProductTypes.AddRangeAsync(types);
                    await _context.SaveChangesAsync();
                }

            }

            /// seeding product Brand from jasson files

            if (!_context.ProductPrands.Any())
            {
                //1: Read All Data from jasson files 
                var BrandsData = await File.ReadAllTextAsync(@"..\Infrastructure\\Presistence\\Data\\Seeding\\brands.json");

                //2: Transfer All data to c# object

                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData);

                //3: Add List  to databas 

                if (brands is not null && brands.Any())
                {
                    await _context.ProductPrands.AddRangeAsync(brands);
                    await _context.SaveChangesAsync();
                }

            }



            /// seeding products from jasson files
            /// 

            if (!_context.Products.Any())
            {
                //1: Read All Data from jasson files 
                var productsData = await File.ReadAllTextAsync(@"..\Infrastructure\\Presistence\\Data\\Seeding\\products.json");

                //2: Transfer All data to c# object

                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                //3: Add List  to databas 

                if (products is not null && products.Any())
                {
                    await _context.Products.AddRangeAsync(products);
                    await _context.SaveChangesAsync();
                }

            }

        }
    }
}
