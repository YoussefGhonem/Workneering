﻿using Workneering.Message.Domain.Entities;

namespace Workneering.Message.Application.Queries.GlopalChat.GeRooms
{
    public class RoomsDto
    {
        public Guid? Id { get; set; }
        public Guid? UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserTitle { get; set; }
        public string? UserCountryName { get; set; }
        public string? UserImageUrl { get; set; }
        public string? LastMessage { get; set; }
        public int UnreadCount { get; set; } = 0;
        public DateTimeOffset? LastMessageCreatedDate { get; set; }
    }
}
