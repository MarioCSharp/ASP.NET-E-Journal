namespace E_Journal.Services.Teacher
{
    using E_Journal.Models.Teacher;
    using System.Collections.Generic;
    using System;
    using System.Linq;
    using E_Journal.Data;

    public class TeacherService : ITeacherService
    {
        private readonly ApplicationDbContext context;

        public TeacherService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<TeacherDisplayModel> GetAllTeachersWithoutClass(int schoolId)
        {
            return context.Teacher
                .Where(x => x.SchoolId == schoolId && !x.HaveClass)
                .Select(x => new TeacherDisplayModel
                {
                    TeacherId = x.UserId,
                    Name = context.Users.FirstOrDefault(y => y.Id == x.UserId).FullName
                })
                .ToList();
        }
    }
}
