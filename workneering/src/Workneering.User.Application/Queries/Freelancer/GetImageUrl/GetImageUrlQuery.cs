using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workneering.User.Application.Queries.Client.GetClientCategorization;

namespace Workneering.User.Application.Queries.Freelancer.GetImageUrl
{
    public class GetImageUrlQuery : IRequest<GetImageUrlDto>
    {
        public Guid ClientId { get; set; }
    }
}
