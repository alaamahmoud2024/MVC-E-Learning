using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Emit;

namespace DAL.Context
{
    public class LearningDbContext : IdentityDbContext<AppUser>
    {
        public LearningDbContext(DbContextOptions<LearningDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
            builder.Entity<AppUser>().ToTable("users");

            #region Seeding Roles

            var RolesNames = new List<string>() { "Student", "Admin", "Instructor" };

            foreach (var roleName in RolesNames)
            {

                var role = new IdentityRole
                {
                    Name = roleName,
                    NormalizedName = roleName.ToUpper(),
                };
                builder.Entity<IdentityRole>().HasData(role);
            }
            #endregion
        }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<InstructorCourse> InstructorCourse { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        //public DbSet<Contact> Contacts { get; set; }    





    }
}
