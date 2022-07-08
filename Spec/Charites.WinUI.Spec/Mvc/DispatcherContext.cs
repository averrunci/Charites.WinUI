// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Carna;
using Carna.WinUIRunner;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;

namespace Charites.Windows.Mvc;

internal class DispatcherContext : FixtureSteppable
{
    protected async Task<Window> EnsureWindowAsync() => window ?? await CarnaWinUIRunner.Window.DispatcherQueue.RunAsync(() => window = new Window());
    private Window? window;

    protected Task RunAsync(DispatcherQueueHandler action) => CarnaWinUIRunner.Window.DispatcherQueue.RunAsync(action);

    protected async Task SetWindowContentAsync(FrameworkElement element)
    {
        var currentWindow = await EnsureWindowAsync();
        var taskCompletionSource = new TaskCompletionSource();

        void OnElementLoaded(object? sender, RoutedEventArgs e)
        {
            element.Loaded -= OnElementLoaded;
            taskCompletionSource.SetResult();
        }

        await RunAsync(() =>
        {
            element.Loaded += OnElementLoaded;
            currentWindow.Content = element;
        });
        await taskCompletionSource.Task;
    }

    protected async Task ClearWindowContentAsync()
    {
        var currentWindow = await EnsureWindowAsync();
        var taskCompletionSource = new TaskCompletionSource();

        void OnElementUnloaded(object? sender, RoutedEventArgs e) => taskCompletionSource.SetResult();

        await RunAsync(() =>
        {
            if (currentWindow.Content is FrameworkElement element) element.Unloaded += OnElementUnloaded;
            currentWindow.Content = null;
        });
        await taskCompletionSource.Task;
    }
}