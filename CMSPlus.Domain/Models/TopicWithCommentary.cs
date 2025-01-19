using CMSPlus.Domain.Entities;

namespace CMSPlus.Domain.Models
{
    public class TopicWithCommentaries
    {
        public TopicModels.TopicDetailsModel TopicDetails { get; set; }
        public IEnumerable<CommentaryEntity> Commentaries{ get; set; }
    }
}