using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseApp.Core.Models
{
    public class AppUser : IdentityUser<int>
    {
        public DateTime LastLoginDate { get; set; }
        [NotMapped] public List<string> Authority { get; set; }
        public ICollection<UserCourse> UserCourses { get; set; }


    }
}
