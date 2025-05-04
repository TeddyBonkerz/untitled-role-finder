using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using Avalonia.Layout;
using Avalonia.Threading;

namespace untitled_role_finder.ViewModels;

public class ChatMessage
{
    public required string Message { get; set; }
    public HorizontalAlignment Alignment { get; set; }
    public bool IsAgent { get; set; }

}

public class MainWindowViewModel : ReactiveObject
{
    private string _userInput = string.Empty;
    public string UserInput
    {
        get => _userInput;
        set => this.RaiseAndSetIfChanged(ref _userInput, value);
    }

    public ObservableCollection<ChatMessage> Messages { get; } = new();

    public ReactiveCommand<Unit, Unit> SendMessageCommand { get; }

    public MainWindowViewModel()
    {
        SendMessageCommand = ReactiveCommand.CreateFromTask(() => SendMessage());
    }

    private async Task SendMessage()
    {
        if (!string.IsNullOrWhiteSpace(UserInput))
        {
            if (!Dispatcher.UIThread.CheckAccess())
            {
                Console.WriteLine("WARNING: UI access from non-UI thread!");
            }

            // Add user message on UI thread
            await Dispatcher.UIThread.InvokeAsync(() =>
            {
                Messages.Add(new ChatMessage
                {
                    Message = UserInput,
                    Alignment = HorizontalAlignment.Right,
                    IsAgent = false
                });

                // Clear input on UI thread to avoid CanExecute issues
                UserInput = string.Empty;
            });

            // Simulate background AI response
            var aiResponse = await Task.Run(() =>
            {
                Thread.Sleep(500); // simulate delay
                return "This is an AI response.";
            });

            // Add AI message on UI thread
            await Dispatcher.UIThread.InvokeAsync(() =>
            {
                Messages.Add(new ChatMessage
                {
                    Message = aiResponse,
                    Alignment = HorizontalAlignment.Left,
                    IsAgent = true
                });
            });
        }
    }

}