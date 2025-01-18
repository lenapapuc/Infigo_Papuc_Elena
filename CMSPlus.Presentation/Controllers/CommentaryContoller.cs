using AutoMapper;
using CMSPlus.Domain.Entities;
using CMSPlus.Services.Interfaces;
using CMSPlus.Domain.Models.TopicModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace CMSPlus.Presentation.Controllers;

public class CommentaryController : Controller
{
    private readonly ICommentaryService _commentaryService;
    private readonly IMapper _mapper;
    private readonly IValidator<TopicEditModel> _editModelValidator;
    private readonly IValidator<TopicCreateModel> _createModelValidator;

    public CommentaryController(ICommentaryService commentaryService, IMapper mapper)
    {
        _commentaryService = commentaryService;
        _mapper = mapper;
     
    }


}