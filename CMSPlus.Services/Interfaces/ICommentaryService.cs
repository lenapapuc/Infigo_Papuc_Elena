using CMSPlus.Domain.Entities;

namespace CMSPlus.Services.Interfaces;

public interface ICommentaryService
{
    public Task<CommentaryEntity> GetById(int id);
    public Task<IEnumerable<CommentaryEntity>?> GetByTopicId (int topicId);
    public Task<IEnumerable<CommentaryEntity>> GetAll();
    public Task Create(CommentaryEntity entity);
    public Task Update(CommentaryEntity entity);
    public Task Delete(int id);
}