// Import packages
using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Avalonia;
using Avalonia.ReactiveUI;


namespace untitled_role_finder;

public class Program
{
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()

            .LogToTrace();

    // public static async Task Main(string[] args)
    // {
    //     // Load configuration from appsettings.json and environment variables
    //     var configuration = new ConfigurationBuilder()
    //         .SetBasePath(Directory.GetCurrentDirectory())
    //         .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    //         .AddEnvironmentVariables()
    //         .AddUserSecrets<Program>()
    //         .Build();

    //     // Populate values from your OpenAI deployment
    //     var modelId = configuration["OpenAI:ModelId"];
    //     var endpoint = configuration["OpenAI:Endpoint"];
    //     var apiKey = configuration["OpenAI:ApiKey"];

    //     // Create a kernel with Azure OpenAI chat completion
    //     var builder = Kernel.CreateBuilder().AddOpenAIChatCompletion(modelId, apiKey, null, null, null);

    //     // Add enterprise components
    //     // builder.Services.AddLogging(services => 
    //     // services.AddConsole().SetMinimumLevel(LogLevel.Warning));

    //     // Build the kernel
    //     Kernel kernel = builder.Build();
    //     var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

    //     // Add plugins
    //     var puppeteerPlugin = await PuppeteerPlugin.CreateAsync();
    //     kernel.Plugins.AddFromObject(puppeteerPlugin, "PuppeteerPlugin");
    //     // kernel.Plugins.AddFromType<JobsPlugin>("Jobs");

    //     // Enable planning
    //     OpenAIPromptExecutionSettings openAIPromptExecutionSettings = new() 
    //     {
    //         FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
    //     };

    //     var appBuilder = AppBuilder.Configure<App>()
    //         .UsePlatformDetect()
    //         .UseReactiveUI();

    //     appBuilder.StartWithClassicDesktopLifetime(args);
    // }
}

// // Create a history store the conversation
// var history = new ChatHistory();

// string? userInput;
// while(true) {
//     Console.Write("User > ");
//     userInput = Console.ReadLine();
//     if (string.IsNullOrEmpty(userInput))
//         break;

//     history.AddUserMessage(userInput);

//     //var result = await kernel.InvokePromptAsync(userInput);

//     // Get the response from the AI
//     var result = await chatCompletionService.GetChatMessageContentAsync(
//         history,
//         executionSettings: openAIPromptExecutionSettings,
//         kernel: kernel);

//     // Add the message from the agent to the chat history
//     history.AddMessage(result.Role, result.Content ?? string.Empty);

//     // Print the results
//     Console.WriteLine("Assistant > " + result);
//     Console.WriteLine("==================================================");

// }