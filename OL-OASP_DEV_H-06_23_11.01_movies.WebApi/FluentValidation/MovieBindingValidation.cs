using FluentValidation;
using OL_OASP_DEV_H_06_23_11._01_movies.Shared.Models;
using OL_OASP_DEV_H_06_23_11._01_movies.Shared.Models.Binding;

namespace OL_OASP_DEV_H_06_23_11._01_movies.WebApi.FluentValidation
{
    public class MovieBindingValidation : AbstractValidator<MovieBinding>
    {
        public MovieBindingValidation()
        {
            RuleFor(y=>y.Title).NotEmpty().WithMessage(ErrorCodes.MissingValue);
            RuleFor(y => y.Genre).NotEmpty().WithMessage(ErrorCodes.MissingValue);

            RuleFor(y => y.ReleaseYear).NotEmpty().WithMessage(ErrorCodes.MissingValue);

            RuleFor(y => y.ReleaseYear).GreaterThan(1900).WithMessage(ErrorCodes.OutOfRange);
        }
    }
}
