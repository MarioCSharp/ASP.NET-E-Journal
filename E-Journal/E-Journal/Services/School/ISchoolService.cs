namespace E_Journal.Services.School
{
    using E_Journal.Models.School;
    using System.Collections.Generic;

    public interface ISchoolService
    {
        bool Create(AddSchoolFormModel model);
        List<string> GetAllSchools();
        int GetSchoolIdByDirectorId(string directorId);
    }
}
