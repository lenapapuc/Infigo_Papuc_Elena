using CMSPlus.Domain.Entities;
using CMSPlus.Domain.Interfaces;
using CMSPlus.Services.Interfaces;

namespace CMSPlus.Services.Services;

public class CommentaryService : ICommentaryService
{
    private readonly ICommentaryRepository _repository;

    public CommentaryService(ICommentaryRepository repository)
    {
        _repository = repository;
    }

    public async Task<CommentaryEntity> GetById(int id)
    {
        return await _repository.GetById(id);
    }

    public async Task<IEnumerable<CommentaryEntity>?> GetByTopicId(int topicId)
    {
        return await _repository.GetByTopicId(topicId);
    }

    public async Task<IEnumerable<CommentaryEntity>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task Create(CommentaryEntity entity)
    {
        await _repository.Create(entity);
    }

    public async Task Update(CommentaryEntity entity)
    {
        await _repository.Update(entity);
    }

    public async Task Delete(int id)
    {
        await _repository.Delete(id);
    }
}