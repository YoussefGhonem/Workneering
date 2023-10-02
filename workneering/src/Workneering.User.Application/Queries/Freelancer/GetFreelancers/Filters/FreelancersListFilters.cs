using System.Collections.Generic;
using Workneering.Base.Application.Common.Pagination.models;
using Workneering.User.Domain.Enums;

namespace Workneering.User.Application.Queries.Freelancer.GetFreelancers.Filters;
public class FreelancersListFilters : BaseFilterDto
{
    public List<Guid>? CategoryIds { get; set; }
    public int? AvailabilityFrom { get; set; }
    public int? AvailabilityTo { get; set; }
    public decimal? HourlyRateFrom { get; set; }
    public decimal? HourlyRateTo { get; set; }
    public List<ExperienceLevelEnum>? ExperienceLevels { get; set; }

}
