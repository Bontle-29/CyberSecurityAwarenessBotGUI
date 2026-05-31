using System.Collections.Generic;
using System.Linq;

namespace CyberSecurityAwarenessBotGUI.Services
{
    public class SentimentService
    {
        private readonly Dictionary<string, string> _sentimentKeywords;

        public SentimentService()
        {
            _sentimentKeywords = new Dictionary<string, string>
            {
                {"worried", "worried"},
                {"scared", "worried"},
                {"confused", "confused"},
                {"curious", "curious"},
                {"frustrated", "worried"}
            };
        }

        public string DetectSentiment(string input)
        {
            foreach (var keyword in _sentimentKeywords.Keys)
            {
                if (input.ToLower().Contains(keyword))
                {
                    return _sentimentKeywords[keyword];
                }
            }
            return "neutral";
        }

        public string GetEmpatheticResponse(string sentiment)
        {
            switch (sentiment)
            {
                case "worried":
                    return "It\'s completely understandable to feel that way. Let me share some tips to help you stay safe.";
                case "confused":
                    return "It\'s okay to be confused about this. Let\'s break it down.";
                case "curious":
                    return "That\'s a great question! I can tell you more about that.";
                default:
                    return "";
            }
        }
    }
}