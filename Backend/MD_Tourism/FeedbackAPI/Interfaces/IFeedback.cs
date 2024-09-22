using FeedbackAPI.Models;

namespace FeedbackAPI.Interfaces
{
    public interface IFeedback
    {
        public Task<feedback?> AddReview(feedback item);
        public Task<feedback?> DeleteReview(int id);
        public Task<feedback?> GetReview(int id);
        public Task<ICollection<feedback>?> GetAllReviews();

    }
}
