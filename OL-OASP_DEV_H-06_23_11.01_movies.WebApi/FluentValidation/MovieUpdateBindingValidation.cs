using FluentValidation;
using OL_OASP_DEV_H_06_23_11._01_movies.Shared.Models;
using OL_OASP_DEV_H_06_23_11._01_movies.Shared.Models.Binding;
using OL_OASP_DEV_H_06_23_11._01_movies.WebApi.Services.Interfaces;

namespace OL_OASP_DEV_H_06_23_11._01_movies.WebApi.FluentValidation
{
    public class MovieUpdateBindingValidation : AbstractValidator<MovieUpdateBinding>
    {
        public MovieUpdateBindingValidation(IMoviesService moviesService)
        {
            RuleFor(y => y.Id).MustAsync(async (id, cancellation) => await moviesService.MovieExists(id)).WithMessage(ErrorCodes.NotFound);
            RuleFor(y=>y.Title).NotEmpty().WithMessage(ErrorCodes.MissingValue);
            RuleFor(y => y.Genre).NotEmpty().WithMessage(ErrorCodes.MissingValue);
            RuleFor(y => y.ReleaseYear).GreaterThan(1900).WithMessage(ErrorCodes.OutOfRange);
        }
    }
}
