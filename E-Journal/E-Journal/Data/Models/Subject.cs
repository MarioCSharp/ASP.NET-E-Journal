namespace E_Journal.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [ForeignKey("Class")]
        public int ClassId { get; set; }
        [Required]
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
    }
}
