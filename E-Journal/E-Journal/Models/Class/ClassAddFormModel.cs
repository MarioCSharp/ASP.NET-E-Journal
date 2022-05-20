namespace E_Journal.Models.Class
{
    using E_Journal.Models.Teacher;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ClassAddFormModel
    {
        [Required]
        public string ClassName { get; set; }
        [Required]
        public int SchoolId { get; set; }
        [Required]
        public int TeacherId { get; set; }
        public List<TeacherDisplayModel> Teachers { get; set; }

    }
}
