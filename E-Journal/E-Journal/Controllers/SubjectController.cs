namespace E_Journal.Controllers
{
    using E_Journal.Services.Director;
    using E_Journal.Services.User;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    public class SubjectController : Controller
    {
        private readonly IUserService userService;
        private readonly IDirectorService directorService;
        public SubjectController(IUserService userService,
                                IDirectorService directorService)
        {
            this.userService = userService;
            this.directorService = directorService;
        }

        [Authorize]
        public IActionResult Add()
        {
            if (!directorService.IsDirector(userService.GetUserId()))
            {
                return BadRequest();
            }
            return View();
        }
    }
}
