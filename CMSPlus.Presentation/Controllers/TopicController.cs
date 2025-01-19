using AutoMapper;
using CMSPlus.Domain.Entities;
using CMSPlus.Services.Interfaces;
using CMSPlus.Domain.Models.TopicModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using CMSPlus.Domain.Models;
using CMSPlus.Services.Services;

namespace CMSPlus.Presentation.Controllers;

public class TopicController : Controller
{
    private readonly ITopicService _topicService;
    private readonly IMapper _mapper;
    private readonly IValidator<TopicEditModel> _editModelValidator;
    private readonly IValidator<TopicCreateModel> _createModelValidator;
    private readonly ICommentaryService _commentaryService;

    public TopicController(ITopicService topicService,IMapper mapper, IValidator<TopicEditModel> editModelValidator, IValidator<TopicCreateModel> createModelValidator, ICommentaryService commentaryService)
    {
        _topicService = topicService;
        _mapper = mapper;
        _editModelValidator = editModelValidator;
        _createModelValidator = createModelValidator;
        _commentaryService = commentaryService;
    }
    
    public async Task<IActionResult> Index()
    {
        var topics =  await _topicService.GetAll();
        var topicToDisplay = _mapper.Map<IEnumerable<TopicEntity>, IEnumerable<TopicModel>>(topics);
        return View(topicToDisplay);
    }
    
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var topicToEdit = await _topicService.GetById(id);
        if (topicToEdit == null)
        {
            throw new ArgumentException($"Item with Id: {id} wasn't found!");
        }
        var topicDto = _mapper.Map<TopicEntity, TopicEditModel>(topicToEdit);
        return View(topicDto);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(TopicEditModel updatedEntity)
    {
        var validationResult = await _editModelValidator.ValidateAsync(updatedEntity);
        if (!validationResult.IsValid)
        {
            validationResult.AddToModelState(this.ModelState);
            return View(updatedEntity);
        }

        var topicEntity = await _topicService.GetById(updatedEntity.Id);
        topicEntity = _mapper.Map(updatedEntity, topicEntity);
        await _topicService.Update(topicEntity);
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var topicToDelete = await _topicService.GetById(id);
        if (topicToDelete == null)
        {
            throw new ArgumentException($"Item with Id: {id} wasn't found!");
        }
        var topicDto = _mapper.Map<TopicEntity, TopicModel>(topicToDelete);
        return View(topicDto);
    }    
    
    [HttpPost]
    [ActionName("Delete")]
    public async Task<IActionResult> DeleteById(int id)
    {
        await _topicService.Delete(id);
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(TopicCreateModel topic)
    {
        var validationResult = await _createModelValidator.ValidateAsync(topic);
        if (!validationResult.IsValid)
        {
            validationResult.AddToModelState(this.ModelState);
            return View(topic);
        }
        var topicEntity = _mapper.Map<TopicCreateModel, TopicEntity>(topic);
        await _topicService.Create(topicEntity);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Details(string systemName)
    {
        var topic = await _topicService.GetBySystemName(systemName);
        if (topic == null)
        {
            throw new ArgumentException($"Item with system name: {systemName} wasn't found!");
        }
        var topicDto = _mapper.Map<TopicEntity, TopicDetailsModel>(topic);
        return View(topicDto);
    }

    public async Task<IActionResult> TopicWithCommentaries(string systemName)
    {
        var topic = await _topicService.GetBySystemName(systemName);
        if (topic == null)
        {
            throw new ArgumentException($"Item with system name: {systemName} wasn't found!");
        }
        var topicDetails = _mapper.Map<TopicEntity, TopicDetailsModel>(topic);
        var commentaries = await _commentaryService.GetByTopicId(topic.Id);
        var topicWithCommentaries = new TopicWithCommentaries
        {
            TopicDetails = topicDetails,
            Commentaries = commentaries
        };
        return View(topicWithCommentaries);
    }
}