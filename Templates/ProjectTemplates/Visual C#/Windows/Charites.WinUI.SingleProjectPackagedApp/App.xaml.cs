﻿using Charites.Windows.Mvc;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace $safeprojectname$;

public partial class App
{
    public static Window Window => window ?? throw new InvalidOperationException();
    private static Window? window;

    public App()
    {
        InitializeComponent();

        UnhandledException += OnUnhandledException;
        WinUIController.UnhandledException += OnWinUIControllerUnhandledException;
        WinUIController.ControllerFactory = new $safeprojectname$ControllerFactory();
    }

    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        window = new Window
        {
            Content = new ContentControl
            {
                Content = new ApplicationHost()
            }
        };
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