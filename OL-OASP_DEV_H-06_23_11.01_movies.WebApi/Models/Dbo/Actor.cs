﻿using OL_OASP_DEV_H_06_23_11._01_movies.Shared.Models.Base;

namespace OL_OASP_DEV_H_06_23_11._01_movies.WebApi.Models.Dbo
{
    public class Actor: ActorBase
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
    }
}
