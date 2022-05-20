namespace E_Journal.Services.Director
{
    using E_Journal.Data;
    using System.Linq;

    public class DirectorService : IDirectorService
    {
        private readonly ApplicationDbContext context;
        public DirectorService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool IsDirector(string Id)
        {
            var directors = context.Directors.ToHashSet();

            return directors.Any(d => d.UserId == Id);
        }
    }
}
