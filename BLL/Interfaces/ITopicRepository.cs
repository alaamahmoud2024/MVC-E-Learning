using DAL.Models;

namespace BLL.Interfaces
{
    public interface ITopicRepository
    {
        Task<List<Topic>> GetTopics();
        Task AddTopic(Topic topic);
        Task<Topic> GetTopicById(int id);
        void EditTopic(Topic model);
        void DeleteTopic(int id);

        //int GetTotal();
        int GetTopicsCount();
       
    }
}
