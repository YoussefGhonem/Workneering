using FluentValidation;
using Workneering.Project.Infrastructure.Persistence;

namespace Workneering.Project.Application.Commands.Wishlist.RemoveWishlist
{
    public class RemoveWishlistCommandValidator : AbstractValidator<RemoveWishlistCommand>
    {
        public RemoveWishlistCommandValidator()
        {

        }
    }
}