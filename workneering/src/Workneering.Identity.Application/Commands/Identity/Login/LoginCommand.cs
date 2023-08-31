﻿using MediatR;

namespace Workneering.Identity.Application.Commands.Identity.Login
{
    public class LoginCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}