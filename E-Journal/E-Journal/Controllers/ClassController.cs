namespace E_Journal.Controllers
{
    using E_Journal.Models.Class;
    using E_Journal.Services.Director;
    using E_Journal.Services.School;
    using E_Journal.Services.Teacher;
    using E_Journal.Services.User;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    public class ClassController : Controller
    {
        private readonly IUserService userService;
        private readonly ISchoolService schoolService;
        private readonly ITeacherService teacherService;
        private readonly IDirectorService directorService;
        public ClassController(IUserService userService,
                               ISchoolService schoolService,
                               ITeacherService teacherService,
                               IDirectorService directorService)
        {
            this.userService = userService;
            this.schoolService = schoolService;
            this.teacherService = teacherService;
            this.directorService = directorService;
        }
        public IActionResult Add()
        {
            var userId = userService.GetUserId();

            if (!directorService.IsDirector(userId))
            {
                return BadRequest();
            }

            var schoolId = schoolService.GetSchoolIdByDirectorId(userId);

            if (schoolId == 0 || schoolId == -1)
            {
                return BadRequest();
            }

            var getAllTeachersWithOutClass = teacherService.GetAllTeachersWithoutClass(schoolId);

            return View(new ClassAddFormModel
            {
                SchoolId = schoolId,
                Teachers = getAllTeachersWithOutClass
            });
        }
    }
}
