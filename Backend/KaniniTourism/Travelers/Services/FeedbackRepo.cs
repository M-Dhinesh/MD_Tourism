using Travelers.Models;
using Travelers.Interfaces;
using Travelers.Models;

namespace Travelers.Services
{
    public class FeedbackRepo: IRepo<TravelerFeedback,int>
    {
        private readonly Context _context;
        public FeedbackRepo(Context context)
        {

            _context = context;

        }
        public async Task<TravelerFeedback?> Add(TravelerFeedback item)
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

        public Task<TravelerFeedback?> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TravelerFeedback?> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TravelerFeedback?> Get(string email)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TravelerFeedback>?> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TravelerFeedback?> Update(TravelerFeedback item)
        {
            throw new NotImplementedException();
        }
    }
}
