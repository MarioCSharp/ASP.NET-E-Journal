namespace E_Journal.Services.Teacher
{
    using E_Journal.Models.Teacher;
    using System.Collections.Generic;
    public interface ITeacherService
    {
        List<TeacherDisplayModel> GetAllTeachersWithoutClass(int schoolId);
    }
}
