using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseApp.Core.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Instructor { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public int Lesson { get; set; }
        public int Trainee { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int? InstructorUserId { get; set; }
        public AppUser InstructorUser { get; set; }
        public ICollection<UserCourse> UserCourses { get; set; }

    }
}
