using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
