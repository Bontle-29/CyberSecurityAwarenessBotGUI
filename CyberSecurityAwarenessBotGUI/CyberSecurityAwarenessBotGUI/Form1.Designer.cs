using System;
using System.Drawing;
using System.Windows.Forms;
using CyberSecurityAwarenessBotGUI.Services;

namespace CyberSecurityAwarenessBotGUI.Forms
{
    public partial class MainForm : Form
    {
        private ChatbotService _chatbotService;
        private AudioPlayer _audioPlayer;
        private const string GreetingAudioPath = "../../Assets/greeting.wav";

        public MainForm()
        {
            InitializeComponent();
            _chatbotService = new ChatbotService();
            _audioPlayer = new AudioPlayer(GreetingAudioPath);
            this.Load += new EventHandler(MainForm_Load);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _audioPlayer.PlayGreeting();
            DisplayBotMessage("Hello! I am your Cybersecurity Awareness Bot. How can I help you today?");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string userInput = txtUserInput.Text.Trim();
            if (!string.IsNullOrEmpty(userInput))
            {
                DisplayUserMessage(userInput);
                txtUserInput.Clear();
                string botResponse = _chatbotService.GetBotResponse(userInput);
                DisplayBotMessage(botResponse);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbChatDisplay.Clear();
        }

        private void DisplayUserMessage(string message)
        {
            rtbChatDisplay.AppendText($"You: {message}\n", Color.Blue);
        }

        private void DisplayBotMessage(string message)
        {
            rtbChatDisplay.AppendText($"Bot: {message}\n", Color.Green);
        }

        // Placeholder for designer-generated code
        private void InitializeComponent()
        {
            this.rtbChatDisplay = new System.Windows.Forms.RichTextBox();
            this.txtUserInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblHelp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtbChatDisplay
            // 
            this.rtbChatDisplay.Location = new System.Drawing.Point(12, 50);
            this.rtbChatDisplay.Name = "rtbChatDisplay";
            this.rtbChatDisplay.ReadOnly = true;
            this.rtbChatDisplay.Size = new System.Drawing.Size(776, 300);
            this.rtbChatDisplay.TabIndex = 0;
            this.rtbChatDisplay.Text = "";
            // 
            // txtUserInput
            // 
            this.txtUserInput.Location = new System.Drawing.Point(12, 356);
            this.txtUserInput.Name = "txtUserInput";
            this.txtUserInput.Size = new System.Drawing.Size(695, 20);
            this.txtUserInput.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(713, 354);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(713, 383);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(359, 25);
            // 
            // lblAsciiArt
            // 
            this.lblAsciiArt = new System.Windows.Forms.Label();
            this.lblAsciiArt.AutoSize = true;
            this.lblAsciiArt.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsciiArt.Location = new System.Drawing.Point(12, 40);
            this.lblAsciiArt.Name = "lblAsciiArt";
            this.lblAsciiArt.Size = new System.Drawing.Size(301, 78);
            this.lblAsciiArt.TabIndex = 6;
            this.lblAsciiArt.Text = "    .--------.\r\n    / .------. \\\r\n   / /        \\ \\\r\n   | |        | |\r\n  _| |________| |_\r\n.' |_|        |_| '.\r\n'._____ ____ _____.'\r\n|     .'____'.     |\r\n'.__.'.'    '.'.__.'\r\n'.__.'      '.__.'\r\n  |                |\r\n  |  [SECURITY]    |\r\n  |      BOT       |\r\n  |________________|\r\n      |        |\r\n      |        |\r\n      |________|\r\n      /_      _\\\r\n     /_        _\\ ";
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Cybersecurity Awareness Chatbot";
            this.Controls.Add(this.lblAsciiArt);
            // 
            // lblHelp
            // 
            this.lblHelp.AutoSize = true;
            this.lblHelp.Location = new System.Drawing.Point(14, 388);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(276, 13);
            this.lblHelp.TabIndex = 5;
            this.lblHelp.Text = "Type \'tell me more\' or \'another tip\' for follow-up info.";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtUserInput);
            this.Controls.Add(this.rtbChatDisplay);
            this.Name = "MainForm";
            this.Text = "Cybersecurity Awareness Bot";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.RichTextBox rtbChatDisplay;
        private System.Windows.Forms.TextBox txtUserInput;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.Label lblAsciiArt;
    }

    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
            box.ScrollToCaret();
        }
    }
}