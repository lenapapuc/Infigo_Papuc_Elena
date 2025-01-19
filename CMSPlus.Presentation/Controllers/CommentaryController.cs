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
    private readonly ITopicService _topicService;
    private readonly IMapper _mapper;


    public CommentaryController(ICommentaryService commentaryService, IMapper mapper, ITopicService topicService)
    {
        _commentaryService = commentaryService;
        _topicService = topicService;
        _mapper = mapper;
      
    }

    public async Task<IActionResult> TopicWithCommentaries(int topicId)
    {
        var topicEntity = await _topicService.GetById(topicId);
        var topicDetails = _mapper.Map<TopicEntity, TopicDetailsModel>(topicEntity);

        var commentaries = await _commentaryService.GetByTopicId(topicId);
        var topicWithCommentaries = new TopicWithCommentaries
        {
            TopicDetails = topicDetails,
            Commentaries = commentaries
        };
        return View(topicWithCommentaries);
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
        return RedirectToAction("TopicWithCommentaries", new { topicId = commentary.TopicId });
    }


}