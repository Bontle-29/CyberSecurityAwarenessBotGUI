# Cybersecurity Awareness Chatbot 

This project is a Windows Forms application designed to educate users about cybersecurity topics through an interactive chatbot interface.

## Features

- **Graphical User Interface (GUI)**: A user-friendly WinForms interface for seamless interaction.
- **Keyword Recognition**: Identifies and responds to specific cybersecurity topics like `password`, `scam`, `privacy`, `phishing`, `browsing`, and `wifi`.
- **Dynamic Responses**: Utilizes a dictionary of lists to provide varied and informative responses for each topic.
- **Sentiment Detection**: Recognizes user emotions (e.g., worried, confused) and provides empathetic feedback.
- **Conversation Memory**: Remembers user details such as name and favorite topics to personalize the experience.
- **Contextual Flow**: Supports follow-up queries like "tell me more" or "another tip" based on the last discussed topic.
- **Audio Integration**: Plays a greeting sound on application startup.

## Project Structure

- `Assets/`: Contains the `greeting.wav` audio file.
- `Models/`: Includes `UserProfile.cs` for storing user data.
- `Services/`: Contains core logic services:
  - `ChatbotService.cs`: Orchestrates the bot's logic.
  - `ResponseService.cs`: Manages response generation using delegates and random selection.
  - `SentimentService.cs`: Handles sentiment analysis.
  - `MemoryService.cs`: Manages user profile and conversation state.
  - `AudioPlayer.cs`: Handles audio playback.
- `Forms/`: Contains `MainForm.cs`, the primary GUI component.

## How to Run

1. Open the solution in Visual Studio.
2. Ensure the `Assets/greeting.wav` file exists in the output directory.
3. Build and run the project.

## Technical Implementation Highlights

- **Delegates**: Used in `ResponseService` for flexible response handling.
- **Generic Collections**: Extensive use of `Dictionary<string, List<string>>` for organizing data.
- **OOP Principles**: Modular design with clear separation of concerns between GUI, models, and services.
