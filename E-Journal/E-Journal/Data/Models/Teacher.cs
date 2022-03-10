namespace E_Journal.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("School")]
        public int SchoolId { get; set; }
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        [Required]
        public string Subject { get; set; }
    }
}
