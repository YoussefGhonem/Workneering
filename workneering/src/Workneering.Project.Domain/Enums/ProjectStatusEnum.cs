namespace Workneering.Project.Domain.Enums
{
    public enum ProjectStatusEnum
    {
        Draft = 1,
        Posted = 2,
        Pending = 3, // when project type is by wirkneering team
        Ongoing = 4,
        Rejected = 5, // can be rejected by workneering system
        Closed = 6

    }
}
