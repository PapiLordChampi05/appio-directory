using System.Runtime.Versioning;
using System.Threading.Tasks;

using appio;
using appio.Browser;
using Avalonia;
using Avalonia.Browser;

internal sealed partial class Program
{
    private static Task Main(string[] args) => BuildAvaloniaApp()
            .WithInterFont()
            .SetupBrowserView()
            .StartBrowserAppAsync("out");

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>();
}
