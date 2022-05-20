namespace E_Journal.Services.School
{
    using E_Journal.Data;
    using E_Journal.Models.School;
    using System.Linq;
    using E_Journal.Data.Models;
    using System.Collections.Generic;
    using E_Journal.Models.Display_Models;

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

            var directorCr = new Director
            {
                SchoolId = school.Id,
                UserId = school.DirectorId
            };

            context.Directors.Add(directorCr);

            context.SaveChanges();

            return true;
        }

        public List<string> GetAllSchools()
        {
            return context.Schools.Select(x => x.Name).ToList();
        }

        public int GetSchoolIdByDirectorId(string directorId)
        {
            return context.Schools.FirstOrDefault(x => x.DirectorId == directorId).Id;
        }
    }
}
