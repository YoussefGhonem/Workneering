using Mapster;
using System.Text.Json;
using Workneering.User.Domain.Entites;

namespace Workneering.User.Application.Commands.Freelancer.Portfolio.CreatePortfolio
{

    public static class Mapper
    {
        public static void ApplyMapping()
        {


            TypeAdapterConfig<FreelancerPortfolioSkillCreateDto, PortfolioSkill>.NewConfig();
            TypeAdapterConfig<FreelancerPortfolioFileCreateDto, PortfolioFile>.NewConfig();
        }


    }
}
