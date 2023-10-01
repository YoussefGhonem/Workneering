using Workneering.Base.Domain.Common;
using Workneering.Shared.Core.Models;

namespace Workneering.User.Domain.Entites
{
    public record CertifictionFile : BaseEntity
    {
        private FileDto? _fileDetails;
        public CertifictionFile(FileDto fileDetails)
        {
            _fileDetails = fileDetails;
        }
        public CertifictionFile()
        {

        }
        public FileDto? FileDetails { get => _fileDetails; set => _fileDetails = value; }
        public void UpdateFile(FileDto? fileDetails)
        {
            _fileDetails = fileDetails;
        }

        public void UpdateFiles(List<FileDto>? fileDetails)
        {
            foreach (var item in fileDetails)
            {
                UpdateFile(item);
            }
        }

    }
}
