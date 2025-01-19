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

    //Method to get the commentaries that belong to a topic by the topic Id
    //The commentaries are extracted in a descending order so that the last commentary posted can be displayed first.
    public async Task<IEnumerable<CommentaryEntity>?> GetByTopicId(int topicId)
    {
        var result = await _dbSet.Where(commentary => commentary.TopicId == topicId).OrderByDescending(commentary => commentary.CreatedOnUtc).ToListAsync();
        return result;
    }
}