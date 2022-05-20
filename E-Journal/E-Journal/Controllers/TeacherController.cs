namespace E_Journal.Controllers
{
    using E_Journal.Models.Teacher;
    using E_Journal.Services.Director;
    using E_Journal.Services.School;
    using E_Journal.Services.Teacher;
    using E_Journal.Services.User;
    using Microsoft.AspNetCore.Mvc;
    public class TeacherController : Controller
    {
        private readonly ITeacherService teacherService;
        private readonly IDirectorService directorService;
        private readonly IUserService userService;
        private readonly ISchoolService schoolService;
        public TeacherController(ITeacherService teacherService,
                                 IDirectorService directorService,
                                 IUserService userService,
                                 ISchoolService schoolService)
        {
            this.teacherService = teacherService;
            this.directorService = directorService;
            this.userService = userService;
            this.schoolService = schoolService;
        }

        public IActionResult Add()
        {
            var id = userService.GetUserId();

            if (!directorService.IsDirector(id))
            {
                return BadRequest();
            }

            var schooldId = schoolService.GetSchoolIdByDirectorId(id);

            if (schooldId == 0 || schooldId == -1)
            {
                return BadRequest();
            }

            return View(new TeacherAddFormModel
            {
                SchoolId = schooldId,
                Users = userService.GetAllUsers()
            });
        }
    }
}
