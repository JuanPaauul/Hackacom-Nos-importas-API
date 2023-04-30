using appPrevencionRiesgos.Model.Security;

namespace appPrevencionRiesgos.Data.Entities
{
    public interface IUserConfidenceEntity
    {
        public string? EmailFrom { get; set; }
        public IDictionary<string, string>? Data { get; set; }
    }
    public class UserConfidenceSenderEntity : IUserConfidenceEntity
    {
        private Task<UserInformationModel> userFrom;
        private string? emailTo;

        public string? EmailFrom { get; set; }
        public IDictionary<string, string>? Data { get; set; }
        public UserConfidenceSenderEntity(UserInformationEntity? userInformation,string? emailFrom)
        {
            EmailFrom = emailFrom;
            Data = new Dictionary<string, string>()
            {
                {"firstName", userInformation.FirstName},
                {"lastName", userInformation.LastName},
                {"email", userInformation.Email},
                {"confidenceUserImageUrl", userInformation.ImageUrl},
                {"status", "sent"},
            };
        }

        public UserConfidenceSenderEntity(Task<UserInformationModel> userFrom, string? emailTo)
        {
            this.userFrom = userFrom;
            this.emailTo = emailTo;
        }
    }
    public class UserConfidenceReceiverEntity : IUserConfidenceEntity
    {
        private Task<UserInformationModel> userTo;

        public string? EmailFrom { get; set; }
        public IDictionary<string, string>? Data { get; set; }
        public UserConfidenceReceiverEntity(UserInformationEntity? userInformation, string? emailFrom)
        {
            EmailFrom = emailFrom;
            Data = new Dictionary<string, string>()
            {
                {"firstName", userInformation.FirstName},
                {"lastName", userInformation.LastName},
                {"email", userInformation.Email},
                {"confidenceUserImageUrl", userInformation.ImageUrl},
                {"status", "pending"},
            };
        }

        public UserConfidenceReceiverEntity(Task<UserInformationModel> userTo, string emailFrom)
        {
            this.userTo = userTo;
            EmailFrom = emailFrom;
        }
    }
}
