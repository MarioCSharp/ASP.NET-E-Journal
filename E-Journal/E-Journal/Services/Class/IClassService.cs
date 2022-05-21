namespace E_Journal.Services.Class
{
    using E_Journal.Models.Class;
    public interface IClassService
    {
        bool Create(ClassAddFormModel mdl, int schoolId);
    }
}
