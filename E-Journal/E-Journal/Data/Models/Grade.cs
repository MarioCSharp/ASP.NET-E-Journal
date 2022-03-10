namespace E_Journal.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Grade
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string About { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        [Required]
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
    }
}
