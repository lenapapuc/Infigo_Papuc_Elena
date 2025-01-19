using System.IO.Enumeration;
using CMSPlus.Domain.Entities;
using CMSPlus.Domain.Interfaces;
using CMSPlus.Domain.Models.TopicModels;
using FluentValidation;

namespace CMSPlus.Presentation.Validations;

public class TopicCreateModelValidator:AbstractValidator<TopicCreateModel>
{
    private readonly TopicValidatorHelpers _topicValidatorHelpers;
    public TopicCreateModelValidator(TopicValidatorHelpers topicValidatorHelpers)
    {

        _topicValidatorHelpers = topicValidatorHelpers;
        RuleFor(topic => topic.SystemName).NotEmpty();
        RuleFor(x => x.Body).NotEmpty();
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(topic => topic.SystemName)
            .MustAsync(_topicValidatorHelpers.IsSystemNameUnique).WithMessage("System name must be unique");
        RuleFor(topic => topic.SystemName)
            .Must(_topicValidatorHelpers.IsUrl).WithMessage("The system name is not an URL");
    }
}