namespace E_Journal.Models.School
{
    using E_Journal.Models.Display_Models;
    using E_Journal.Models.User;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class AddSchoolFormModel
    {
        [Required]
        public string SchoolName { get; set; }
        [Required]
        public int CityId { get; set; }
        [Required]
        public string DirectorId { get; set; }

        public List<UserDisplayModel> Users { get; set; }
        public List<CityDisplayModel> Cities { get; set; }
    }
}
