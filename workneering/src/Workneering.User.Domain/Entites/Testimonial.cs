using Workneering.Base.Domain.Common;

namespace Workneering.User.Domain.Entites
{
    public record Testimonial : BaseEntity
    {
        private string _firstName;
        private string _lastName;
        private string _businessEmail;
        private string _linkedInProfile;
        private string _clientTitle;
        private string? _projectType;
        private string _messageToClient;
        private string _replayClient;

        public Testimonial(string firstName, string lastName, string businessEmail, string linkedInProfile, string clientTitle, string? projectType, string messageToClient)
        {
            _firstName = firstName;
            _lastName = lastName;
            _businessEmail = businessEmail;
            _linkedInProfile = linkedInProfile;
            _clientTitle = clientTitle;
            _projectType = projectType;
            _messageToClient = messageToClient;
        }
        public Testimonial()
        {
        }

        public string FirstName { get => _firstName; private set => _firstName = value; }
        public string LastName { get => _lastName; private set => _lastName = value; }
        public string BusinessEmail { get => _businessEmail; private set => _businessEmail = value; }
        public string LinkedInProfile { get => _linkedInProfile; private set => _linkedInProfile = value; }
        public string ClientTitle { get => _clientTitle; private set => _clientTitle = value; }
        public string? ProjectType { get => _projectType; private set => _projectType = value; }
        public string MessageToClient { get => _messageToClient; private set => _messageToClient = value; }
        public string ReplayClient { get => _replayClient; private set => _replayClient = value; }


        public void UpdateFirstName(string field)
        {
            _firstName = field;
        }
        public void UpdateReplayClient(string field)
        {
            _replayClient = field;
        }
        public void UpdateLastName(string field)
        {
            _lastName = field;
        }
        public void UpdateBusinessEmail(string field)
        {
            _businessEmail = field;
        }
        public void UpdateLinkedInProfile(string field)
        {
            _linkedInProfile = field;
        }
        public void UpdateClientTitle(string field)
        {
            _clientTitle = field;
        }
        public void UpdateProjectType(string? field)
        {
            _projectType = field;
        }
        public void UpdateMessageToClient(string field)
        {
            _messageToClient = field;
        }
    }
}
