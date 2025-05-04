using Avalonia.Controls;
using Avalonia.Input;
using System.Collections.ObjectModel;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Avalonia.Layout;

namespace untitled_role_finder;

public partial class MainWindow : Window
{
    // private readonly Kernel _kernel;
    // private readonly IChatCompletionService _chatService;
    // private readonly ChatHistory _history = new();
    private ObservableCollection<ChatMessage> ChatMessages = new();

    public MainWindow() : base()
    {
        InitializeComponent();
        // Bind the ItemsControl to the messages collection
        ChatMessagesPanel.ItemsSource = ChatMessages;

        // Handle Enter key in the input box
        ConversationInput.KeyDown += ConversationInput_KeyDown;
    }

    private void ConversationInput_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter && !string.IsNullOrWhiteSpace(ConversationInput.Text))
        {
            ChatMessages.Add(new ChatMessage { Message = "User: " + ConversationInput.Text, Alignment = HorizontalAlignment.Right, IsAgent = false  });
            ChatMessages.Add(new ChatMessage { Message = "Agent: " + ConversationInput.Text, Alignment = HorizontalAlignment.Left, IsAgent = true  });
            ConversationInput.Text = string.Empty;
            e.Handled = true;
        }
    }

    // public MainWindow(Kernel kernel, IChatCompletionService chatService) : this()
    // {
    //     _kernel = kernel;
    //     _chatService = chatService;
    //     ChatBox = this.FindControl<TextBox>("ChatBox");
    //     InputBox = this.FindControl<TextBox>("InputBox");
    //     SendButton = this.FindControl<Button>("SendButton");
    //     SendButton.Click += SendButton_Click;
    // }

    // private async void SendButton_Click(object? sender, RoutedEventArgs e)
    // {
    //     var userInput = InputBox.Text;
    //     if (!string.IsNullOrWhiteSpace(userInput))
    //     {
    //         _history.AddUserMessage(userInput);
    //         ChatBox.Text += $"User: {userInput}\n";
    //         InputBox.Text = "";

    //         var result = await _chatService.GetChatMessageContentAsync(_history, kernel: _kernel);
    //         _history.AddMessage(result.Role, result.Content ?? "");
    //         ChatBox.Text += $"Assistant: {result.Content}\n";
    //     }
    // }
}