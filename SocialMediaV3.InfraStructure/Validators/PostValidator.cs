using FluentValidation;
using SocialMediaV3.Core.DTOs;

namespace SocialMediaV3.InfraStructure.Validators
{
    public class PostValidator:AbstractValidator<PostDto>
    {
        public PostValidator()
        {
            RuleFor(post => post.Description)
                .NotNull()
                .Length(10, 15);

            RuleFor(post => post.Date)
                .NotNull()
                .LessThan(System.DateTime.Now);
        }
    }
}
