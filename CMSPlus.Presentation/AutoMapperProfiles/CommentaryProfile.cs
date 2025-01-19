using AutoMapper;
using CMSPlus.Domain.Entities;
using CMSPlus.Domain.Models.TopicModels;

using CMSPlus.Domain.Models.CommentaryModels;

namespace CMSPlus.Presentation.AutoMapperProfiles;

public class CommentaryProfile : Profile
{
    public CommentaryProfile()
    {
        CreateMap<CommentaryEntity, CommentaryModel>();
        CreateMap<CommentaryModel, CommentaryEntity>();
        CreateMap<CommentaryEntity, CommentaryCreateModel>();
        CreateMap<CommentaryCreateModel, CommentaryEntity>();
   
    }
}