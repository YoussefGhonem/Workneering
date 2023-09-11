using MediatR;

namespace Workneering.User.Application.Commands.Client.ClientBasicDetails.UpdateClientWhatDoIdo
{
    public class UpdateClientWhatDoIdoCommand : IRequest<Unit>
    {
        public string WhatDoIdo { get; set; }

    }
}
