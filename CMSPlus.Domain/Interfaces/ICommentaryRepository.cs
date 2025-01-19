using CMSPlus.Domain.Entities;

namespace CMSPlus.Domain.Interfaces;

public interface ICommentaryRepository : IRepository<CommentaryEntity>
{
    //Method that retrieves commentaries by topic
    public Task<IEnumerable<CommentaryEntity>?> GetByTopicId(int topicId);
}