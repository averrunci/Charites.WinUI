// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Charites.Windows.Mvc;
using Charites.Windows.Samples.SimpleLoginDemo.Presentation.Login;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Samples.SimpleLoginDemo.Presentation;

[View(Key = nameof(SimpleLoginDemoHost))]
public class SimpleLoginDemoHostController : ControllerBase<SimpleLoginDemoHost>, IDisposable
{
    private readonly IContentNavigator navigator;

    public SimpleLoginDemoHostController(IContentNavigator navigator)
    {
        this.navigator = navigator;

        SubscribeToContentNavigatorEvent();
    }

    public void Dispose()
    {
        UnsubscribeFromContentNavigatorEvent();
    }

    private void SubscribeToContentNavigatorEvent()
    {
        navigator.Navigated += OnContentNavigated;
    }

    private void UnsubscribeFromContentNavigatorEvent()
    {
        navigator.Navigated -= OnContentNavigated;
    }

    private void Navigate(SimpleLoginDemoHost host, object content)
    {
        host.Content.Value = content;
    }

    private void NavigateToLoginContent()
    {
        navigator.NavigateTo(new LoginContent());
    }

    private void OnContentNavigated(object? sender, ContentNavigatedEventArgs e) => DataContext.IfPresent(e.Content, Navigate);

    [EventHandler(Event = nameof(FrameworkElement.Loading))]
    private void SimpleLoginDemoHost_Loading([FromElement(Name = "HeaderGrid")] Grid headerGrid, [FromDI] ISimpleLoginDemoWindowProvider windowProvider)
        => windowProvider.Window.SetTitleBar(headerGrid);
    [EventHandler(Event = nameof(FrameworkElement.Loaded))]
    private void SimpleLoginDemoHost_Loaded() => NavigateToLoginContent();
}