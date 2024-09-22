using FeedbackAPI.Interfaces;
using FeedbackAPI.Models;

namespace FeedbackAPI.Services
{
    public class FeedbackService : IFeedback
    {
        private readonly IRepo<feedback, int> _repo;
        public FeedbackService(IRepo<feedback,int> repo)
        {
            _repo = repo;
        }
        public async Task<feedback?> AddReview(feedback item)
        {
            try
            {
                var FB=await _repo.Add(item);
                if (FB != null)
                {
                    return FB;
                }
                return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<feedback?> DeleteReview(int id)
        {
            try
            {
                var fb = await _repo.Delete(id);
                if (fb != null) {
                    return fb; }
                return null;
            }
            catch(Exception)
            {
                throw new Exception();
            }
        }

        public async Task<ICollection<feedback>?> GetAllReviews()
        {
            try
            {
                var reviews = await _repo.GetAll();
                if (reviews != null)
                {
                    return reviews;
                }
                return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<feedback?> GetReview(int id)
        {
            try
            {
                var review = await _repo.Get(id);
                if (review != null)
                {
                    return review;
                }
                return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
