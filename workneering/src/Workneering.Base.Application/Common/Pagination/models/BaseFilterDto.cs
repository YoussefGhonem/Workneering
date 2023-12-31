namespace Workneering.Base.Application.Common.Pagination.models;

public abstract class BaseFilterDto
{
    public bool ApplySort { get; set; } = false;
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public SortOptionsEnum? SortOrder { get; set; } = SortOptionsEnum.Ascending;
    public string? SortField { get; set; }

    public string GetSortOrder()
    {
        return SortOrder is SortOptionsEnum.Ascending ? "ASC" : "DESC";
    }
}

public enum SortOptionsEnum
{
    Ascending = 1,
    Descending = 2
}