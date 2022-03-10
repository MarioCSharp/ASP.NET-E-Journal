namespace E_Journal.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("School")]
        public int SchoolId { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int Grade { get; set; }
        [Required]
        [ForeignKey("Class")]
        public int ClassId { get; set; }
        [Required]
        public decimal Success { get; set; }
    }
}
