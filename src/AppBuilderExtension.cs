using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;

using appio.Browser.Views;
using appio.Browser.ViewModels;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;

namespace appio.Browser;

public static class AppBuilderExtension
{
    public static AppBuilder SetupBrowserView(this AppBuilder appBuilder)
    {
        appBuilder.AfterSetup(_ =>
        {
            if (Application.Current.ApplicationLifetime is ISingleViewApplicationLifetime browserLifetime)
            {
                MainView mv = new() { DataContext = new MainViewModel() };

                browserLifetime.MainView = mv;
            }
        });

        return appBuilder;
    }
}
