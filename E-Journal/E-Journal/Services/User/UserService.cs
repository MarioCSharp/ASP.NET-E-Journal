namespace E_Journal.Services.User
{
    using E_Journal.Data;
    using E_Journal.Models.User;
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;

    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor httpContext;
        private readonly ApplicationDbContext context;
        public UserService(IHttpContextAccessor httpContext,
                           ApplicationDbContext context)
        {
            this.httpContext = httpContext;
            this.context = context;
        }

        public List<UserDisplayModel> GetAllUsers()
        {
            return context.Users.Select(x => new UserDisplayModel
            {
                Id = x.Id,
                Name = x.FullName
            }).ToList();
        }

        public string GetUserId()
        {
            return httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public bool IsAdmin()
        {
            return context.UserRoles.Any(x => x.UserId == GetUserId() && x.RoleId == "20a67d16-51b5-4e46-b6d2-11ab9112fff1");
        }
    }
}
