using BLL.Interfaces;
using DAL.Context;
using DAL.Models;

namespace BLL.Repository
{
    public class ContactRepository : IContactRepository
    {
        public ContactRepository(LearningDbContext context)
        {
        }
    }
}
