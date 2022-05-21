using E_Journal.Models.User;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Journal.Models.Teacher
{
    public class TeacherAddFormModel
    {
        [Required]
        public string UserId { get; set; }
        public List<UserDisplayModel> Users { get; set; }
        [Required]
        public string Subject { get; set; }
    }
}
