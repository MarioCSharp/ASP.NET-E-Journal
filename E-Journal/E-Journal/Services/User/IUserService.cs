namespace E_Journal.Services.User
{
    using E_Journal.Models.User;
    using System.Collections.Generic;

    public interface IUserService
    {
        string GetUserId();
        bool IsAdmin();
        List<UserDisplayModel> GetAllUsers();
    }
}
