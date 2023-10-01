using Workneering.Base.Domain.Common;
using Workneering.Shared.Core.Models;

namespace Workneering.User.Domain.Entites
{
    public record CertifictionAttachment : BaseEntity
    {
        private FileDto? _fileDetails;
        public CertifictionAttachment(FileDto fileDetails)
        {
            _fileDetails = fileDetails;
        }
        public CertifictionAttachment()
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
