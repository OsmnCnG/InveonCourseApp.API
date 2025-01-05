using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseApp.Core.Dtos
{
    public class CourseWithCategoryDto : CourseDto
    {
        public CategoryDto Category { get; set; }

    }
}
