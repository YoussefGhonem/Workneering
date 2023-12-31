﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Workneering.Identity.Domain.Builders;
using Workneering.Identity.Infrastructure.Persistence;
using Workneering.User.Application.Commands.CreateUser;

namespace Workneering.Identity.Application.Commands.Identity.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid?>
    {
        private readonly UserManager<Workneering.Identity.Domain.Entities.User> _userManager;
        private readonly IdentityDatabaseContext _identityDbContext;
        private readonly IMediator _mediator;

        public RegisterUserCommandHandler(IMediator mediator, UserManager<Domain.Entities.User> userManager, IdentityDatabaseContext identityDatabase)
        {
            _userManager = userManager;
            _identityDbContext = identityDatabase;
            _mediator = mediator;
        }

        public async Task<Guid?> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var rolesFromDb = await _identityDbContext.Roles.ToListAsync(cancellationToken);


            var userBuilder = new CreateUserFactory(request.Name, request.Email)
                .WithRoles(rolesFromDb, request.Role);

            var user = userBuilder.Build();
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded) throw new Exception(result.Errors.ToString());
            await _identityDbContext.SaveChangesAsync(user.Id, cancellationToken);
            var command = new CreateUserCommand(user.Id, request.Role, request.Name);
            await _mediator.Send(command, cancellationToken);

            return user.Id;
        }
    }
}