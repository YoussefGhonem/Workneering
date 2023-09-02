﻿using MediatR;
using Workneering.Shared.Core.Identity.Enums;

namespace Workneering.Identity.Application.Commands.Identity.RegisterUser
{
    public class RegisterUserCommand : IRequest<Guid?>
    {
        public RolesEnum Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid? CountryId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public RegisterUserCommand(string email, string password, RolesEnum role, string firstName, string lastName, Guid? countryId)
        {
            Email = email;
            Password = password;
            Role = role;
            FirstName = firstName;
            LastName = lastName;
            CountryId = countryId;
        }
    }
}