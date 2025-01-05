using InveonCourseApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseApp.Core.Dtos
{
    public class CourseDto : BaseDto
    {
        public string Name { get; set; }
        public string Instructor { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int Lesson { get; set; }
        public int Trainee { get; set; }
        public int InstructorUserId { get; set; }

    }
}
