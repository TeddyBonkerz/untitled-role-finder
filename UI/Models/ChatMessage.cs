using Avalonia.Layout;

public class ChatMessage
{
    public required string Message { get; set; }
    public HorizontalAlignment Alignment { get; set; }
    public bool IsAgent { get; set; }

}