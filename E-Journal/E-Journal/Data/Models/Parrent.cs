namespace E_Journal.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Parrent
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Student")]
        public string KidId { get; set; }
    }
}
