using AutoMapper;
using CMSPlus.Domain.Entities;
using CMSPlus.Services.Interfaces;
using CMSPlus.Domain.Models.CommentaryModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using CMSPlus.Services.Services;

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


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CommentaryCreateModel commentary)
    {
        //var validationResult = await _createModelValidator.ValidateAsync(topic);
        /*if (!validationResult.IsValid)
        {
            validationResult.AddToModelState(this.ModelState);
            return View(topic);
        }*/
        var commentaryEntity = _mapper.Map<CommentaryCreateModel, CommentaryEntity>(commentary);
        await _commentaryService.Create(commentaryEntity);
        return Ok(commentaryEntity);
    }


}