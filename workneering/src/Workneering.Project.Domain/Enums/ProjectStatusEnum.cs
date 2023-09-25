namespace Workneering.Project.Domain.Enums
{
    public enum ProjectStatusEnum
    {
        Draft = 1,
        Posted = 2,
        Pending = 3, // when project type is by wirkneering team
        Active = 4, // when client accept offer from freelancer or when workneering team aacept project
        Rejected = 5, // can be rejected by workneering system
        Closed = 6
    }
}
