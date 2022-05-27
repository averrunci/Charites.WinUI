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
public class SimpleLoginDemoHostController : IDisposable
{
    private readonly IContentNavigator navigator;

    private void SetDataContext(SimpleLoginDemoHost? host) => this.host = host;
    private SimpleLoginDemoHost? host;

    [Element]
    private void SetHeaderGrid(Grid? headerGrid) => this.headerGrid = headerGrid;
    private Grid? headerGrid;

    public SimpleLoginDemoHostController(IContentNavigator navigator)
    {
        this.navigator = navigator;

        SubscribeContentNavigatorEvent();
    }

    public void Dispose()
    {
        UnsubscribeContentNavigatorEvent();
    }

    private void SubscribeContentNavigatorEvent()
    {
        navigator.Navigated += OnContentNavigated;
    }

    private void UnsubscribeContentNavigatorEvent()
    {
        navigator.Navigated -= OnContentNavigated;
    }

    private void OnContentNavigated(object? sender, ContentNavigatedEventArgs e)
    {
        if (host is null) return;

        host.Content.Value = e.Content;
    }

    [EventHandler(Event = nameof(FrameworkElement.Loaded))]
    private void SimpleLoginDemoHost_Loaded([FromDI] ISimpleLoginDemoWindowProvider windowProvider)
    {
        windowProvider.Window.SetTitleBar(headerGrid);

        navigator.NavigateTo(new LoginContent());
    }
}