using System.IO.Enumeration;
using CMSPlus.Domain.Entities;
using CMSPlus.Domain.Interfaces;
using CMSPlus.Domain.Models.CommentaryModels;
using FluentValidation;

namespace CMSPlus.Presentation.Validations;

public class CommentaryCreateModelValidator : AbstractValidator<CommentaryCreateModel>
{
 
    public CommentaryCreateModelValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Body).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
    }
}