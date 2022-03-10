namespace E_Journal.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Director
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("School")]
        public int SchoolId { get; set; }
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
    }
}
