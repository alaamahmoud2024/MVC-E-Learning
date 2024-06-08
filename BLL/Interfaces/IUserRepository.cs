using DAL.Models;
using Microsoft.AspNetCore.Identity;
using MVC_E_Learning.ViewModels;
using System.Linq.Expressions;

namespace BLL.Interfaces
{
    public interface IUserRepository
    {
		Task<List<Instructor>> GetInstructors();
		Task<Instructor> GetInstructorAsync(string id);
        Task<Instructor> DeleteInstructorAsync(string id);
        Task<List<AppUser>> GetUsers(Expression<Func<AppUser, bool>> predicate, Expression<Func<AppUser, AppUser>> selector);

        //Task<List<AppUser>> GetUsersWithFilter(List<AppUser> users,Expression<Func<AppUser, bool>> predicate = null);

        int GetInstructorsCount();
        int GetStudentsCount();
        int GetUsersCount();
    }
}
