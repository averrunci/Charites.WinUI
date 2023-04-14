// Copyright (C) 2022-2023 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Charites.Windows.Mvc;
using Charites.Windows.Samples.SimpleLoginDemo.Presentation;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;

namespace Charites.Windows.Samples.SimpleLoginDemo;

public partial class App
{
    private readonly SimpleLoginDemoWindowProvider windowProvider = new();

    public App()
    {
        InitializeComponent();

        UnhandledException += OnUnhandledException;
        WinUIController.UnhandledException += OnWinUIControllerUnhandledException;
        WinUIController.ControllerFactory = new SimpleLoginDemoControllerFactory(windowProvider);
    }

    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        var window = new Window
        {
            ExtendsContentIntoTitleBar = true,
            Content = new ContentControl
            {
                Content = new SimpleLoginDemoHost()
            },
            SystemBackdrop = new MicaBackdrop()
        };
        windowProvider.Register(window);
        window.Activate();
    }

    private void OnUnhandledException(object? sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        HandleUnhandledException(e.Exception);
        e.Handled = true;
    }

    private void OnWinUIControllerUnhandledException(object? sender, Charites.Windows.Mvc.UnhandledExceptionEventArgs e)
    {
        HandleUnhandledException(e.Exception);
        e.Handled = true;
    }

    private void HandleUnhandledException(Exception exc)
    {
    }
}