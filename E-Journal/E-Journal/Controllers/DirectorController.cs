namespace E_Journal.Controllers
{
    using E_Journal.Services.Director;
    using E_Journal.Services.User;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    public class DirectorController : Controller
    {
        private readonly IUserService userService;
        private readonly IDirectorService directorService;

        public DirectorController(IUserService userService,
                                  IDirectorService directorService)
        {
            this.userService = userService;
            this.directorService = directorService;
        }
        [Authorize]
        public IActionResult Manage()
        {
            var id = userService.GetUserId();

            if (!directorService.IsDirector(id))
            {
                return BadRequest();
            }

            return View();
        }
    }
}
