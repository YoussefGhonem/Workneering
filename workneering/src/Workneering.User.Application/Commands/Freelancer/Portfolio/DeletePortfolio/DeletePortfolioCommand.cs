using MediatR;
using System.Text.Json.Serialization;

namespace Workneering.User.Application.Commands.Freelancer.Portfolio.DeletePortfolio
{
    public class DeletePortfolioCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
