using MediatR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Workneering.Shared.Core.Identity.Enums;

namespace Workneering.Identity.Application.Commands.Identity.RegisterWiththirdPart
{
    public class RegisterWiththirdPartCommand : IRequest<string>
    {
        public string provider { get; set; }
        public string userId { get; set; }
        public string accessToken { get; set; }
        public RolesEnum Role { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        //public string name { get; set; }
    }
}