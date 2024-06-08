using BLL.Interfaces;
using DAL.Context;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using MVC_E_Learning.ViewModels;

namespace BLL.Repository
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly LearningDbContext _context;

        public AssignmentRepository(LearningDbContext context)
        {
            _context = context;
        }

        public async Task<List<Assignment>> GetAssignments()
        {
            var assignments = await _context.Assignments.Include(t => t.Course).ToListAsync();
            return assignments;
        }
        public async Task<Assignment> GetAssignmentById(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment == null)
                return null;
            return assignment;
        }

        public async Task AddAssignment(Assignment assignment)
        {
            await _context.Assignments.AddAsync(assignment);
            _context.SaveChanges();
        }

        public void DeleteAssignment(int id)
        {
            var assignment = _context.Assignments.Find(id);
            if (assignment != null)
            {
                _context.Assignments.Remove(assignment);
                _context.SaveChanges();
            }
        }
    }
}
