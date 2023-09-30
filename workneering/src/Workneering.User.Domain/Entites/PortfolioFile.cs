using Workneering.Base.Domain.Common;
using Workneering.Shared.Core.Models;

namespace Workneering.User.Domain.Entites
{
    public record PortfolioFile : BaseEntity
    {
        private FileDto? _fileDetails;
        public PortfolioFile(FileDto fileDetails)
        {
            _fileDetails = fileDetails;
        }
        public PortfolioFile()
        {

        }
        public FileDto? FileDetails { get => _fileDetails; set => _fileDetails = value; }



    }
}
