using MediatR;
using System.Text.Json.Serialization;

namespace Workneering.Project.Application.Commands.Wishlist.CreateWishlist
{
    public class CreateWishlistCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid? FreelancerId { get; set; }
        [JsonIgnore]
        public Guid? ProjectId { get; set; }

    }
}
