using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace untitled_role_finder;

public partial class App : Application
{
    public Kernel? KernelInstance { get; set; }
    public IChatCompletionService? ChatServiceInstance { get; set; }
    
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

        public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // You need to set KernelInstance and ChatServiceInstance before this is called!
            desktop.MainWindow = new MainWindow(KernelInstance!, ChatServiceInstance!);
        }

        base.OnFrameworkInitializationCompleted();
    }
}