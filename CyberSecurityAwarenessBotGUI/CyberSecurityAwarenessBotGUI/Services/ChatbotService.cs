using System;
using System.Collections.Generic;
using CyberSecurityAwarenessBotGUI.Models;

namespace CyberSecurityAwarenessBotGUI.Services
{
    public class ChatbotService
    {
        private readonly ResponseService _responseService;
        private readonly SentimentService _sentimentService;
        private readonly MemoryService _memoryService;
        private readonly Dictionary<string, string> _keywordMapping;

        public ChatbotService()
        {
            _responseService = new ResponseService();
            _sentimentService = new SentimentService();
            _memoryService = new MemoryService();

            _keywordMapping = new Dictionary<string, string>
            {
                {"password", "password"},
                {"scam", "scam"},
                {"privacy", "privacy"},
                {"phishing", "phishing"},
                {"browsing", "browsing"},
                {"wifi", "wifi"}
            };
        }

        public string GetBotResponse(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
            {
                return "Please type something so I can help you.";
            }

            string lowerInput = userInput.ToLower();

            // 1. Sentiment Detection
            string sentiment = _sentimentService.DetectSentiment(lowerInput);
            if (sentiment != "neutral")
            {
                string empatheticResponse = _sentimentService.GetEmpatheticResponse(sentiment);
                if (!string.IsNullOrEmpty(empatheticResponse))
                {
                    // After empathetic response, try to provide a relevant tip based on last topic or keywords
                    string followUpTip = GetResponseBasedOnKeywords(lowerInput);
                    if (string.IsNullOrEmpty(followUpTip) && !string.IsNullOrEmpty(_memoryService.GetLastTopicDiscussed()))
                    {
                        followUpTip = _responseService.GetRandomResponse(_memoryService.GetLastTopicDiscussed());
                    }
                    return empatheticResponse + (string.IsNullOrEmpty(followUpTip) ? "" : " " + followUpTip);
                }
            }

            // 2. Keyword Recognition and Response
            string recognizedTopic = GetRecognizedTopic(lowerInput);
            if (!string.IsNullOrEmpty(recognizedTopic))
            {
                _memoryService.SetLastTopicDiscussed(recognizedTopic);
                return _responseService.GetRandomResponse(recognizedTopic);
            }

            // 3. Conversation Flow (Follow-up questions)
            if (lowerInput.Contains("tell me more") || lowerInput.Contains("explain more") || lowerInput.Contains("another tip"))
            {
                string lastTopic = _memoryService.GetLastTopicDiscussed();
                if (!string.IsNullOrEmpty(lastTopic))
                {
                    return _responseService.GetRandomResponse(lastTopic);
                }
            }

            // 4. Memory Recall (simple example)
            if (lowerInput.Contains("my name is"))
            {
                string name = ExtractName(userInput);
                if (!string.IsNullOrEmpty(name))
                {
                    _memoryService.SetUserName(name);
                    return $"Nice to meet you, {name}! How can I help you with cybersecurity today?";
                }
            }

            if (lowerInput.Contains("i am interested in") || lowerInput.Contains("my favorite topic is"))
            {
                string topic = ExtractFavoriteTopic(userInput);
                if (!string.IsNullOrEmpty(topic))
                {
                    _memoryService.SetFavoriteCybersecurityTopic(topic);
                    return $"That\'s great! I\'ll remember you\'re interested in {topic}.";
                }
            }

            // Default response for unknown inputs
            return "I\'m not sure I understand. Can you try rephrasing?";
        }

        private string GetRecognizedTopic(string input)
        {
            foreach (var keyword in _keywordMapping.Keys)
            {
                if (input.Contains(keyword))
                {
                    return _keywordMapping[keyword];
                }
            }
            return null;
        }

        private string GetResponseBasedOnKeywords(string input)
        {
            foreach (var keyword in _keywordMapping.Keys)
            {
                if (input.Contains(keyword))
                {
                    return _responseService.GetRandomResponse(keyword);
                }
            }
            return null;
        }

        private string ExtractName(string input)
        {
            // Simple extraction, can be improved with regex
            int index = input.ToLower().IndexOf("my name is");
            if (index != -1)
            {
                return input.Substring(index + "my name is".Length).Trim();
            }
            return null;
        }

        private string ExtractFavoriteTopic(string input)
        {
            int index = input.ToLower().IndexOf("i am interested in");
            if (index != -1)
            {
                return input.Substring(index + "i am interested in".Length).Trim();
            }
            index = input.ToLower().IndexOf("my favorite topic is");
            if (index != -1)
            {
                return input.Substring(index + "my favorite topic is".Length).Trim();
            }
            return null;
        }
    }
}
