namespace E_Journal.Controllers
{
    using E_Journal.Data;
    using E_Journal.Models.Display_Models;
    using E_Journal.Models.School;
    using E_Journal.Models.User;
    using E_Journal.Services.School;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class SchoolController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly ISchoolService schoolService;
        public SchoolController(ApplicationDbContext context,
                                ISchoolService schoolService)
        {
            this.context = context;
            this.schoolService = schoolService;
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Add()
        {
            var users = context.Users
                .Select(x => new UserDisplayModel
                {
                    Id = x.Id,
                    Name = x.FullName
                })
                .ToList();
            var cities = context.Cities
                .Select(x => new CityDisplayModel
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .ToList();
            return View(new AddSchoolFormModel
            {
                Users = users,
                Cities = cities
            });
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult Add(AddSchoolFormModel mdl)
        {
            if (!ModelState.IsValid)
            {
                return View(mdl);
            }
            var created = schoolService.Create(mdl);
            if (!created)
            {
                return BadRequest();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
