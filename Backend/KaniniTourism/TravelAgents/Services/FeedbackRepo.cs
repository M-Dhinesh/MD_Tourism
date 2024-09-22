using TravelAgents.Interfaces;
using TravelAgents.Models;

namespace TravelAgents.Services
{
    public class FeedbackRepo: IRepo<TravelAgentFeedback,int>
    {
        private readonly Context _context;
        public FeedbackRepo(Context context)
        {

            _context = context;

        }
        public async Task<TravelAgentFeedback?> Add(TravelAgentFeedback item)
        {
            try
            {
                _context.Feedbacks.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public Task<TravelAgentFeedback?> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TravelAgentFeedback?> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TravelAgentFeedback?> Get(string email)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TravelAgentFeedback>?> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TravelAgentFeedback?> Update(TravelAgentFeedback item)
        {
            throw new NotImplementedException();
        }
    }
}
