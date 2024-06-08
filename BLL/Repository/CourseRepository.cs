using BLL.Interfaces;
using BLL.ViewModels;
using DAL.Context;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using MVC_E_Learning.ViewModels;

namespace BLL.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly LearningDbContext _context;

        public CourseRepository(LearningDbContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> GetCourses()
        {
            var courses = await _context.Courses.Include(t=>t.Topic).ToListAsync();
            return courses;

        }

        public async Task AddCourse(Course course)
        {
            await _context.Courses.AddAsync(course);
            _context.SaveChanges();
        }

        public async Task<Course> GetCourseById(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
                return null;
            return course;
        }

        public void EditCourse(Course model)
        {
             _context.Courses.Update(model);
            _context.SaveChanges();

        }

        public void DeleteCourse(int id)
        {
            var course = _context.Courses.Find(id);
            if(course != null) 
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
        }

        public async Task AssignCourseToInstructor(InstructorCourseVM model)
        {
            var course = await GetCourseById(model.CourseId);
            var instructor = await _context.Instructors.FindAsync(model.InstructorId);

            if(course != null && instructor != null)
            {
                var instructorCourse = new InstructorCourse
                {
                    CourseId = model.CourseId,
                    InstructorId = model.InstructorId

                };
                await _context.InstructorCourse.AddAsync(instructorCourse);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<InstructorCourseVM>> GetAssignedCoursesAndInstructor()
        {
            var data = from ins in _context.InstructorCourse
                       join i in _context.Instructors on ins.InstructorId equals i.Id
                       join c in _context.Courses on ins.CourseId equals c.Id
                       select new InstructorCourseVM
                       {
                           CourseId = c.Id,
                           CourseName = c.Name,
                           InstructorId = i.Id,
                           InstructorName = i.UserName
                       };
            return await data.ToListAsync();
        }

        public void DeleteAssignedCourse(int id)
        {
            var Assignedcourse = _context.InstructorCourse.Find(id);
            if (Assignedcourse != null)
            {
                _context.InstructorCourse.Remove(Assignedcourse);
                _context.SaveChanges();
            }
        }

        public int GetCoursesCount()
        {
            var courses = _context.Courses.Count();
            return courses;
        }
    }
}
