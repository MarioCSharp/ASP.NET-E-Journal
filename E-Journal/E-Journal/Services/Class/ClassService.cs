namespace E_Journal.Services.Class
{
    using E_Journal.Models.Class;
    using E_Journal.Data.Models;
    using E_Journal.Data;
    using System.Linq;

    public class ClassService : IClassService
    {
        private readonly ApplicationDbContext context;
        public ClassService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool Create(ClassAddFormModel mdl, int schoolId)
        {
            if (string.IsNullOrEmpty(mdl.TeacherId) || string.IsNullOrEmpty(mdl.ClassName))
            {
                return false;
            }

            var @class = new Class
            {
                ClassTeacherId = mdl.TeacherId,
                ClassName = mdl.ClassName,
                SchoolId = schoolId
            };

            var teacher = context.Teacher.FirstOrDefault(x => x.UserId == mdl.TeacherId);
            teacher.HaveClass = true;

            context.Classes.Add(@class);
            context.SaveChanges();

            return true;
        }
    }
}
