namespace Workneering.Project.Application.Queries.Project.ProjectDetails.GetProjectAttachments
{
    public class ProjectAttachmentsDto
    {
        public string? Url { get; set; }
        public string? Key { get; set; }
        public string? FileName { get; set; }
        public string? Extension { get; set; }
        public string? CreatedDate { get; set; }
        public long? FileSize { get; set; }
    }
}
