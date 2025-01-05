using AutoMapper;
using InveonCourseApp.Core.Dtos;
using InveonCourseApp.Core.Models;
using InveonCourseApp.Core.Repositories;
using InveonCourseApp.Core.Services;
using InveonCourseApp.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseApp.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<CourseWithCategoryDto>> GetProductsWithCategory()
        {
            var filteredProducts = await _productRepository.GetProductsWitCategory();

            var productsDto = _mapper.Map<List<CourseWithCategoryDto>>(filteredProducts);

            return productsDto;
        }
    }
}
