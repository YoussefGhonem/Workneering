using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workneering.Packages.Storage.AWS3.Models;
using Workneering.User.Domain.Entites;

namespace Workneering.User.Application.Services.Common.Mapping
{
   public class PortfolioMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<StoredFile, PortfolioFile>()
                  .Map(dest => dest.FileDetails.Key, src => src.Key)
                  .Map(dest => dest.FileDetails.Extension, src => src.Extension)
                  .Map(dest => dest.FileDetails.FileName, src => src.FileName)
                  .Map(dest => dest.FileDetails.FileSize, src => src.FileSize);
        }

    }
}
