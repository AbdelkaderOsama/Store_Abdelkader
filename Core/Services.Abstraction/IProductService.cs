﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Services.Abstraction
{
    public interface IProductService
    {
     Task<IEnumerable<ProductResultDto>> GetAllProductsAsync();

      Task<ProductResultDto?> GetProductByIdAsync(int id);
     
      Task <IEnumerable<BrandResultDto>> GetAllBrandsAsync();
     
      Task< IEnumerable< TypeResultDto>> GetAllTypesAsync();



    }
}
