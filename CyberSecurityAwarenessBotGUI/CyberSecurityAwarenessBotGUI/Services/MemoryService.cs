using CyberSecurityAwarenessBotGUI.Models;

namespace CyberSecurityAwarenessBotGUI.Services
{
    public class MemoryService
    {
        private UserProfile _userProfile;

        public MemoryService()
        {
            _userProfile = new UserProfile();
        }

        public UserProfile GetUserProfile()
        {
            return _userProfile;
        }

        public void SetUserName(string name)
        {
            _userProfile.UserName = name;
        }

        public void SetFavoriteCybersecurityTopic(string topic)
        {
            _userProfile.FavoriteCybersecurityTopic = topic;
        }

        public void SetLastTopicDiscussed(string topic)
        {
            _userProfile.LastTopicDiscussed = topic;
        }

        public string GetLastTopicDiscussed()
        {
            return _userProfile.LastTopicDiscussed;
        }
    }
}
