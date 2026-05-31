
namespace CyberSecurityAwarenessBotGUI.Models
{
    public class UserProfile
    {
        public string UserName { get; set; }
        public string FavoriteCybersecurityTopic { get; set; }
        public string LastTopicDiscussed { get; set; }

        public UserProfile()
        {
            UserName = "";
            FavoriteCybersecurityTopic = "";
            LastTopicDiscussed = "";
        }
    }
}