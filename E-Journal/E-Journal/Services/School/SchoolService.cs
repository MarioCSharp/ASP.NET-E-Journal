namespace E_Journal.Services.School
{
    using E_Journal.Data;
    using E_Journal.Models.School;
    using System.Linq;
    using E_Journal.Data.Models;
    public class SchoolService : ISchoolService
    {
        private readonly ApplicationDbContext context;
        public SchoolService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool Create(AddSchoolFormModel model)
        {
            var director = context.Users.FirstOrDefault(x => x.Id == model.DirectorId);
            if (model.CityId < 0 || model.CityId > context.Cities.Count() || model.SchoolName == null || director == null)
            {
                return false;
            }
            var school = new School
            {
                Name = model.SchoolName,
                CityId = model.CityId,
                DirectorId = model.DirectorId
            };
            context.Schools.Add(school);
            context.SaveChanges();
            return true;
        }
    }
}
