namespace E_Journal.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class City
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
