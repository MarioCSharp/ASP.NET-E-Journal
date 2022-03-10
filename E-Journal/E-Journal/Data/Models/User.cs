namespace E_Journal.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser
    {
        [Required]
        [MaxLength(40)]
        public string FullName { get; set; }
    }
}
