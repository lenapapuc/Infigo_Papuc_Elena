namespace CMSPlus.Domain.Models
{
    public class TopicWithCommentaryCreateModel
    {
        public TopicModels.TopicDetailsModel TopicDetails { get; set; }
        public CommentaryModels.CommentaryCreateModel CommentaryCreate { get; set; }
    }
}