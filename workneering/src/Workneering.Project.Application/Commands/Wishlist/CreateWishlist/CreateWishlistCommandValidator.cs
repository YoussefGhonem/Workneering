using FluentValidation;
using Workneering.Project.Infrastructure.Persistence;

namespace Workneering.Project.Application.Commands.Wishlist.CreateWishlist
{
    public class CreateWishlistCommandValidator : AbstractValidator<CreateWishlistCommand>
    {
        public CreateWishlistCommandValidator()
        {

        }
    }
}