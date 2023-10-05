namespace Workneering.Message.Application.Queries.GetUserInfoForChat;
public class UserInfoForChatDto
{
    public Guid? Id { get; set; }
    public string? UserName { get; set; }
    public string? UserTitle { get; set; }
    public string? UserCountryName { get; set; }
    public string? UserPhotoUrl { get; set; }
    public string? UserRole { get; set; }
}
