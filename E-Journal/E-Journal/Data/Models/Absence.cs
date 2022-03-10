namespace E_Journal.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Absence
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        [Required]
        public DateTime IssuedOn { get; set; }
    }
}
