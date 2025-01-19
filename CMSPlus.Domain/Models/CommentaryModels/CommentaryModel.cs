namespace CMSPlus.Domain.Models.CommentaryModels;

public class CommentaryModel : BaseCommentaryModel
{
    public CommentaryModel()
    {
        UpdatedOnUtc = CreatedOnUtc = DateTime.UtcNow;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Body { get; set; }
    public int TopicId { get; set; }
    public DateTime? CreatedOnUtc { get; set; }
    public DateTime? UpdatedOnUtc { get; set; }
}