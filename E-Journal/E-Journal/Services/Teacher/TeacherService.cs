namespace E_Journal.Services.Teacher
{
    using E_Journal.Models.Teacher;
    using System.Collections.Generic;
    using System;
    using System.Linq;
    using E_Journal.Data;
    using E_Journal.Data.Models;

    public class TeacherService : ITeacherService
    {
        private readonly ApplicationDbContext context;

        public TeacherService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool Create(TeacherAddFormModel mdl, int schoolId)
        {
            if (schoolId == 0 || schoolId == -1 || string.IsNullOrEmpty(mdl.Subject))
            {
                return false;
            }

            var teacher = new Teacher
            {
                SchoolId = schoolId,
                UserId = mdl.UserId,
                Subject = mdl.Subject,
                HaveClass = false
            };

            context.Teacher.Add(teacher);
            context.SaveChanges();

            return true;
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
