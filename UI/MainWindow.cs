using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Threading.Tasks;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace untitled_role_finder;

public partial class MainWindow : Window
{
    private readonly Kernel _kernel;
    private readonly IChatCompletionService _chatService;
    private readonly ChatHistory _history = new();

    public MainWindow(Kernel kernel, IChatCompletionService chatService)
    {
        InitializeComponent();
        _kernel = kernel;
        _chatService = chatService;
        SendButton.Click += SendButton_Click;
    }

    private async void SendButton_Click(object? sender, RoutedEventArgs e)
    {
        var userInput = InputBox.Text;
        if (!string.IsNullOrWhiteSpace(userInput))
        {
            _history.AddUserMessage(userInput);
            ChatBox.Text += $"User: {userInput}\n";
            InputBox.Text = "";

            var result = await _chatService.GetChatMessageContentAsync(_history, kernel: _kernel);
            _history.AddMessage(result.Role, result.Content ?? "");
            ChatBox.Text += $"Assistant: {result.Content}\n";
        }
    }
}