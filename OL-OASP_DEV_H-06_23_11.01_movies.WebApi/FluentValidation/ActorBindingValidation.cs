using FluentValidation;
using OL_OASP_DEV_H_06_23_11._01_movies.Shared.Models;
using OL_OASP_DEV_H_06_23_11._01_movies.Shared.Models.Binding;
using OL_OASP_DEV_H_06_23_11._01_movies.WebApi.Services.Interfaces;

namespace OL_OASP_DEV_H_06_23_11._01_movies.WebApi.FluentValidation
{
    public class ActorBindingValidation : AbstractValidator<ActorBinding>
    {
        public ActorBindingValidation(IMoviesService moviesService)
        {
            RuleFor(y => y.MovieId).MustAsync(async (id, cancellation) => await moviesService.MovieExists(id)).WithMessage(ErrorCodes.NotFound);
            RuleFor(y=>y.FirstName).NotEmpty().WithMessage(ErrorCodes.MissingValue);
            RuleFor(y => y.LastName).NotEmpty().WithMessage(ErrorCodes.MissingValue);

        }
    }
}
