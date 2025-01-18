using CMSPlus.Domain.Entities;
using CMSPlus.Domain.Interfaces;
using CMSPlus.Domain.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CMSPlus.Domain.Repositories;

public class CommentaryRepository : Repository<CommentaryEntity>, ICommentaryRepository
{
    public CommentaryRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<CommentaryEntity>?> GetByTopicId(int topicId)
    {
        var result = await _dbSet.Where(commentary => commentary.TopicId == topicId).ToListAsync();
        return result;
    }
}