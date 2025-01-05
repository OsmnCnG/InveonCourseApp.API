using InveonCourseApp.Core.Dtos;
using InveonCourseApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseApp.Core.Services
{
    public interface IProductService : IService<Product>
    {
        Task<List<CourseWithCategoryDto>> GetProductsWithCategory();

    }
}
