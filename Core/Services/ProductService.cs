using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Contracts;
using Domain.Models;
using Services.Abstraction;
using Shared;

namespace Services
{
    public class ProductService(IUnitOfWork unitOfWork, IMapper mapper) : IProductService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<IEnumerable<ProductResultDto>> GetAllProductsAsync()
        {
           var Products = await unitOfWork.GetRepository<Product,int>().GetAllAsync();

           var result =  mapper.Map<IEnumerable<ProductResultDto>>(Products);
           
            return result;
        }

        public Task<ProductResultDto> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }


        public Task<BrandResultDto> GetAllBrandsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TypeResultDto> GetAllTypesAsync()
        {
            throw new NotImplementedException();
        }

        
    }
}
