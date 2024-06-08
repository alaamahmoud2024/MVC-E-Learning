using BLL.Interfaces;
using DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace BLL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Lazy<IAssignmentRepository> assignments;
        private readonly Lazy<ICourseRepository> courses;

        private readonly Lazy<ITopicRepository> topics;
        private readonly Lazy<IUserRepository> users;
        private readonly LearningDbContext _context;
        private readonly Lazy<IContactRepository> contacts;

        //public UnitOfWork(LearningDbContext context)
        //{
        //    _context = context;
        //    assignments = new Lazy<IAssignmentRepository>(new AssignmentRepository(context));
        //    courses = new Lazy<ICourseRepository>(new CourseRepository(context));
        //    users = new Lazy<IUserRepository>(new UserRepository(context));

        //    topics = new Lazy<ITopicRepository>(new TopicRepository(context));
        //    contacts = new Lazy<IContactRepository>(new ContactRepository(context));
        //}

        //public IAssignmentRepository Assignments => assignments.Value;
        //public ICourseRepository Courses => courses.Value;

        //public ITopicRepository Topics => topics.Value;
        //public IContactRepository Contacts => contacts.Value;
        //public IUserRepository User => users.Value;


        //public async Task<int> CompleteAsync()
        //   => await _context.SaveChangesAsync();

        //public async ValueTask DisposeAsync()
        //   => await _context.DisposeAsync();
    }
}
