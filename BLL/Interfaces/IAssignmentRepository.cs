using DAL.Models;

namespace BLL.Interfaces
{
    public interface IAssignmentRepository
    {
        Task<List<Assignment>> GetAssignments();
        Task AddAssignment(Assignment Assignment);
        Task<Assignment> GetAssignmentById(int id);
        void DeleteAssignment(int id);

    }
}
