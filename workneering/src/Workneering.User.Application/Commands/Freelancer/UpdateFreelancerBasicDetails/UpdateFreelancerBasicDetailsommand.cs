using MediatR;
using Workneering.User.Domain.Enums;

namespace Workneering.User.Application.Commands.Freelancer.UpdateFreelancerBasicDetails
{
    public class UpdateFreelancerBasicDetailsommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public decimal? HourlyRate { get; set; }
        public string? Title { get; set; }
        public string? OverviewDescription { get; set; }
        public VisibilityEnum? Visibility { get; set; }
        public ExperienceLevelEnum? ExperienceLevel { get; set; }
        public string? VideoIntroductionLinkYoutube { get; set; }
        public TypeOfVideoEnum? VideoIntroductionTypeOfVideo { get; set; }
        public HoursPerWeekEnum? AvailabilityHoursPerWeek { get; set; }
        public DateTimeOffset? AvailabilityDateForNewWork { get; set; }
        public bool? AvailabilityContractToHire { get; set; } = false;
    }
}
