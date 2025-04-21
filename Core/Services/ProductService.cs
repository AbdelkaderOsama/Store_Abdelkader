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

        public async Task<ProductResultDto?> GetProductByIdAsync(int id)
        {
            var prouct =  await unitOfWork.GetRepository<Product, int>().GetAsync(id);
            if (prouct != null) return null;
            var result = mapper.Map<ProductResultDto>(prouct);
            return result;
        }


        

        Task<IEnumerable<BrandResultDto>> IProductService.GetAllBrandsAsync()
        {
         var brands = unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();
           var result =  mapper.Map<IEnumerable<BrandResultDto>>(brands);

            return (Task<IEnumerable<BrandResultDto>>)result;
       

        }

       Task<IEnumerable<TypeResultDto>> IProductService.GetAllTypesAsync()
       {
            var types = unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            var result = mapper.Map<IEnumerable<BrandResultDto>>(types);

            return (Task<IEnumerable<TypeResultDto>>)result;
       }
    }
}
