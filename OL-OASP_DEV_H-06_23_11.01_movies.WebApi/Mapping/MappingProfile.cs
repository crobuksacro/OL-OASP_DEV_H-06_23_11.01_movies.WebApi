using AutoMapper;
using OL_OASP_DEV_H_06_23_11._01_movies.Shared.Models.Binding;
using OL_OASP_DEV_H_06_23_11._01_movies.Shared.Models.ViewModels;
using OL_OASP_DEV_H_06_23_11._01_movies.WebApi.Models.Dbo;

namespace OL_OASP_DEV_H_06_23_11._01_movies.WebApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Actor, ActorViewModel>();
            CreateMap<ActorBinding, Actor>();

            CreateMap<Movie, MovieViewModel>();
            CreateMap<MovieBinding, Movie>();
            CreateMap<MovieUpdateBinding, Movie>();
        }
    }
}
