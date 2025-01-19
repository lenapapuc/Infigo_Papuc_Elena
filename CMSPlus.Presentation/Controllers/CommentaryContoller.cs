using AutoMapper;
using CMSPlus.Domain.Entities;
using CMSPlus.Services.Interfaces;
using CMSPlus.Domain.Models.CommentaryModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using CMSPlus.Services.Services;
using Microsoft.AspNetCore.Routing;
using CMSPlus.Domain.Models.TopicModels;
using CMSPlus.Domain.Models;

namespace CMSPlus.Presentation.Controllers;

public class CommentaryController : Controller
{
    private readonly ICommentaryService _commentaryService;
    private readonly IMapper _mapper;


    public CommentaryController(ICommentaryService commentaryService, IMapper mapper)
    {
        _commentaryService = commentaryService;
        _mapper = mapper;

    }

    public async Task<IActionResult> Index(int topicId)
    {
        var commentaries = await _commentaryService.GetByTopicId(topicId);
        var commentaryToDisplay = _mapper.Map<IEnumerable<CommentaryEntity>, IEnumerable<CommentaryModel>>(commentaries);
        return View(commentaryToDisplay);
    }

    [HttpGet]
    public IActionResult Create(int topicId)
    {
        var model = new CommentaryCreateModel
        {
            TopicId = topicId // Initialize the model with the TopicId
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CommentaryCreateModel commentary)
    {
        //var validationResult = await _createModelValidator.ValidateAsync(topic);
        /*if (!validationResult.IsValid)
        {
            validationResult.AddToModelState(this.ModelState);
            return View(topic);
        }*/
        var commentaryEntity = _mapper.Map<CommentaryCreateModel, CommentaryEntity>(commentary);
        await _commentaryService.Create(commentaryEntity);
        return RedirectToAction("Index", new { topicId = commentary.TopicId });
    }


}