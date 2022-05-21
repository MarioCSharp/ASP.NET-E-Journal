namespace E_Journal.Controllers
{
    using E_Journal.Models.Class;
    using E_Journal.Services.Class;
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
        private readonly IClassService classService;
        public ClassController(IUserService userService,
                               ISchoolService schoolService,
                               ITeacherService teacherService,
                               IDirectorService directorService,
                               IClassService classService)
        {
            this.userService = userService;
            this.schoolService = schoolService;
            this.teacherService = teacherService;
            this.directorService = directorService;
            this.classService = classService;
        }
        [Authorize]
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
                Teachers = getAllTeachersWithOutClass
            });
        }
        [Authorize]
        [HttpPost]
        public IActionResult Add(ClassAddFormModel mdl)
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

            var created = classService.Create(mdl, schoolId);

            if (!created)
            {
                return BadRequest();
            }

            return RedirectToAction("Manage", "Director");
        }
    }
}
