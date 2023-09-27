using MediatR;
using Microsoft.AspNetCore.Http;

namespace Workneering.User.Application.Commands.Company.CompanyBasicDetails.UpdateCompanyImage
{
    public class UpdateCompanyImageCommand : IRequest<Unit>
    {
        public IFormFile Image { get; set; }

    }
}
