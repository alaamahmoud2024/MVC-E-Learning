using BLL.Interfaces;
using DAL.Context;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace BLL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly LearningDbContext _context;
        private readonly UserManager<AppUser>? userManager;
        private LearningDbContext context;

        public GenericRepository(LearningDbContext context, UserManager<AppUser>? userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        public GenericRepository(LearningDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        => await _context.Set<T>().ToListAsync();

         
        public async Task<T?> GetAsync(int id)
        => await _context.Set<T>().FindAsync(id);

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public int GetTotal()
       => _context.Set<T>().Count();


    }
}
