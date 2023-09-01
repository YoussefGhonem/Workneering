﻿using Mapster;
using System.Text.Json;
using Workneering.User.Domain.Entites;

namespace Workneering.User.Application.Queries.Freelancer.GetFreelancerPortfolios
{

    public static class Mapper
    {
        public static void ApplyMapping()
        {
            TypeAdapterConfig<PortfolioSkill, FreelancerPortfolioSkillDto>.NewConfig();
            TypeAdapterConfig<PortfolioFile, FreelancerPortfolioFileDto>.NewConfig();
        }


    }
}
