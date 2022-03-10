namespace E_Journal.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Class
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ClassName { get; set; }
        [Required]
        [ForeignKey("User")]
        public string ClassTeacherId { get; set; }
        [Required]
        [ForeignKey("School")]
        public int SchoolId { get; set; }
    }
}
