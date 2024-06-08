using BLL.Interfaces;
using DAL.Context;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC_E_Learning.ViewModels;
using System.Linq;
using System.Linq.Expressions;

namespace BLL.Repository
{

    public class UserRepository : IUserRepository
	{
		private readonly LearningDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public UserRepository(LearningDbContext context, UserManager<AppUser> userManager)
        {
			_context = context;
            _userManager = userManager;
        }

        public async Task<List<Instructor>> GetInstructors()
		{
			var Instructors = await _context.Set<AppUser>().OfType<Instructor>().ToListAsync();
			return Instructors;
		}

        public async Task<Instructor> GetInstructorAsync(string id)
		{
			var Instructor = await _context.Set<AppUser>().OfType<Instructor>().Where(i => i.Id == id).FirstOrDefaultAsync();
			return Instructor;
		}
		public async Task<Instructor> DeleteInstructorAsync(string id)
		{
			var Instructor = await _context.Set<AppUser>().OfType<Instructor>().Where(i => i.Id == id).FirstOrDefaultAsync();
			if (Instructor != null)
				return null;

			_context.Users.Remove(Instructor);
			await _context.SaveChangesAsync();
			return Instructor;
        }


        public async Task<List<AppUser>> GetUsers(Expression<Func<AppUser, bool>> predicate = null, Expression<Func<AppUser, AppUser>> selector = null)
        {
            if(predicate == null && selector == null)
            {
                var appUsers = await _userManager.Users.ToListAsync();
                var userModel = appUsers.Select(u => new AppUser
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    UserName = u.FirstName + u.LastName,
                    Email = u.Email,
                    Discriminator = u.Discriminator
                }).ToList();
                return userModel;
            }
            else
            {
                var appUsers = await _userManager.Users.Where(predicate).Select(selector).ToListAsync();
                var userModel = appUsers.Select(u => new AppUser
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    UserName = u.FirstName + u.LastName,
                    Email = u.Email,
                    Discriminator = u.Discriminator
                }).ToList();
                return userModel;
            }
        }

        public int GetInstructorsCount()
        {
            var user = _context.Set<AppUser>().OfType<Instructor>().Count();
            return user;
        }

        public int GetStudentsCount()
        {
            var user = _context.Set<AppUser>().OfType<Student>().Count();
            return user;
        }

        public int GetUsersCount()
        {
            var users = _context.Users.Count();
            return users;
        }
    }
}
