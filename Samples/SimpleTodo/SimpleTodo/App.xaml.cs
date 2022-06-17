// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Charites.Windows.Mvc;
using Charites.Windows.Samples.SimpleTodo.Presentation;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Samples.SimpleTodo;

public partial class App
{
    private readonly SimpleTodoWindowProvider windowProvider = new();

    public App()
    {
        InitializeComponent();

        UnhandledException += OnUnhandledException;
        WinUIController.UnhandledException += OnWinUIControllerUnhandledException;
        WinUIController.ControllerFactory = new SimpleTodoControllerFactory(windowProvider);
    }

    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        var window = new Window
        {
            Content = new ContentControl
            {
                Content = new SimpleTodoHost()
            }
        };
        if (AppWindowTitleBar.IsCustomizationSupported()) window.ExtendsContentIntoTitleBar = true;
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