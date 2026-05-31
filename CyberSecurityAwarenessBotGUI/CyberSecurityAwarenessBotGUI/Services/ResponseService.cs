using System;
using System.Collections.Generic;

namespace CyberSecurityAwarenessBotGUI.Services
{
    public delegate string ResponseDelegate(string input);

    public class ResponseService
    {
        private readonly Dictionary<string, List<string>> _responses;
        private readonly Random _random;

        public ResponseService()
        {
            _responses = new Dictionary<string, List<string>>
            {
                {"password", new List<string>
                    {
                        "Use strong, unique passwords for each account. Avoid using personal details in your passwords.",
                        "Consider using a password manager to keep track of complex passwords securely.",
                        "Enable two-factor authentication wherever possible for an extra layer of security."
                    }
                },
                {"scam", new List<string>
                    {
                        "Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organizations.",
                        "Always verify the sender of an email before clicking on any links or downloading attachments.",
                        "If an offer seems too good to be true, it probably is. Be skeptical of unsolicited messages."
                    }
                },
                {"privacy", new List<string>
                    {
                        "Review the privacy settings on your social media accounts and other online services regularly.",
                        "Be mindful of the information you share online, even with friends and family.",
                        "Use a VPN to protect your online privacy, especially when using public Wi-Fi."
                    }
                },
                {"phishing", new List<string>
                    {
                        "Do not click suspicious links in emails.",
                        "Check the sender\'s email address carefully.",
                        "Avoid sharing passwords or OTPs through email."
                    }
                },
                {"browsing", new List<string>
                    {
                        "Always check if a website uses HTTPS before entering sensitive information.",
                        "Be wary of pop-up ads and unexpected redirects while browsing.",
                        "Keep your web browser and its extensions updated to the latest versions for security."
                    }
                },
                {"wifi", new List<string>
                    {
                        "Avoid connecting to unsecured public Wi-Fi networks for sensitive activities like online banking.",
                        "Use a strong, unique password for your home Wi-Fi network.",
                        "Consider using a VPN when connected to any public Wi-Fi network."
                    }
                }
            };
            _random = new Random();
        }

        public string GetRandomResponse(string topic)
        {
            if (_responses.ContainsKey(topic.ToLower()))
            {
                List<string> topicResponses = _responses[topic.ToLower()];
                int index = _random.Next(topicResponses.Count);
                return topicResponses[index];
            }
            return "I\'m not sure how to respond to that topic right now.";
        }

        // Example of using a delegate for response generation
        public string GenerateResponseWithDelegate(string input, ResponseDelegate del)
        {
            return del(input);
        }
    }
}