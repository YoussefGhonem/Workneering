using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workneering.User.Application.Queries.Client.GetClientCategorization;
using Workneering.User.Infrastructure.Persistence;
using Workneering.User.Application.Services.DbQueryService;
using Workneering.Shared.Core.Extention;
using Workneering.Packages.Storage.AWS3.Services;

namespace Workneering.User.Application.Queries.Company.GetImageUrl
{
    public class GetImageUrlQueryHandler : IRequestHandler<GetImageUrlQuery, GetImageUrlDto>
    {
        private readonly IDbQueryService _dbQueryService;
        private readonly IStorageService _storageService;

        public GetImageUrlQueryHandler(IDbQueryService dbQueryService, IStorageService storageService)
        {
            _dbQueryService = dbQueryService;
            _storageService = storageService;
        }
        public async Task<GetImageUrlDto> Handle(GetImageUrlQuery request, CancellationToken cancellationToken)
        {
            var ImageUrl = await _dbQueryService.GetImageKey(request.ClientId, cancellationToken);
            if (ImageUrl != null)
            {
                var ImageUrlResult =  ImageUrl.SetDownloadFileUrlByKey(_storageService);
                var GetImageUrlDto = new GetImageUrlDto() { ImageUrl = ImageUrlResult };
                return GetImageUrlDto;
            }
            return new GetImageUrlDto() { ImageUrl = null };
        }
    }
}
