using Workneering.Base.Domain.Common;
using Workneering.Shared.Core.Models;

namespace Workneering.Project.Domain.Entities;
public record ProjectAttachment : BaseEntity
{
    private FileDto? _imageDetails;
    public ProjectAttachment(FileDto imageDetails)
    {
        _imageDetails = imageDetails;
    }
    public ProjectAttachment()
    {

    }
    public FileDto? ImageDetails { get => _imageDetails; set => _imageDetails = value; }
    public void UpdateImage(FileDto? imageDetails)
    {
        _imageDetails = imageDetails;
    }
}
