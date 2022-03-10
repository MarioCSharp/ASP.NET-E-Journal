namespace E_Journal.Data
{
    using E_Journal.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Parrent> Parrents { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
    }
}
