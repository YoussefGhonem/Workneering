using Mapster;
using System.Text.Json;
using Workneering.User.Domain.Entites;

namespace Workneering.User.Application.Commands.Freelancer.Portfolio.UpdatePortfolio
{

    public static class Mapper
    {
        public static void ApplyMapping()
        {
            TypeAdapterConfig<PortfolioSkill, FreelancerPortfolioSkillUpdateDto>.NewConfig();
            TypeAdapterConfig<PortfolioFile, FreelancerPortfolioFileUpdateDto>.NewConfig();

            TypeAdapterConfig<FreelancerPortfolioSkillUpdateDto, PortfolioSkill>.NewConfig();
            TypeAdapterConfig<FreelancerPortfolioFileUpdateDto, PortfolioFile>.NewConfig();
        }


    }
}
