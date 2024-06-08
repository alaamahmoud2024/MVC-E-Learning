using BLL.Interfaces;
using DAL.Context;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using MVC_E_Learning.ViewModels;

namespace BLL.Repository
{
    public class TopicRepository : ITopicRepository
    {
        private readonly LearningDbContext _context;

        public TopicRepository(LearningDbContext context)
        {
            _context = context;
        }
        public async Task<List<Topic>> GetTopics()
        {
            var topics = await _context.Topics.ToListAsync();
            return topics;
        }

        public async Task AddTopic(Topic topic)
        {
            await _context.Topics.AddAsync(topic);
            _context.SaveChanges();
        }

        public async Task<Topic> GetTopicById(int id)
        {
            var topic = await _context.Topics.FindAsync(id);
            if (topic == null)
                return null;
            return topic;
        }
        public void EditTopic(Topic model)
        {
            _context.Topics.Update(model);
            _context.SaveChanges();
        }

        public void DeleteTopic(int id)
        {
            var topic = _context.Topics.Find(id);
            if (topic != null)
            {
                _context.Topics.Remove(topic);
                _context.SaveChanges();
            }
        }

        //public int GetTotal()
        //{
        //    var topcics = _context.Topics.Count();
        //    return topcics;
        //}

        public int GetTopicsCount()
        {
            var topics = _context.Topics.Count();
            return topics;
        }
    }
}
