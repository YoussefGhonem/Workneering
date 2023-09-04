using MediatR;
using System.Text.Json.Serialization;

namespace Workneering.Project.Application.Commands.Wishlist.RemoveWishlist
{
    public class RemoveWishlistCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid? FreelancerId { get; set; }
        [JsonIgnore]
        public Guid? ProjectId { get; set; }

    }
}
