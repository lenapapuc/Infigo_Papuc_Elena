using CMSPlus.Domain.Entities;

namespace CMSPlus.Domain.Models
{
    //Model that combines topic with it's commentaries so that it's possible to desplay both in the details page
    public class TopicWithCommentaries
    {
        public TopicModels.TopicDetailsModel TopicDetails { get; set; }
        public IEnumerable<CommentaryEntity> Commentaries{ get; set; }
    }
}