// Copyright (C) 2022-2025 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Carna;
using Carna.WinUIRunner;
using Charites.Windows.Mvc;
using Charites.Windows.Samples.SimpleLoginDemo.Presentation.Login;
using Microsoft.UI.Xaml;
using NSubstitute;

namespace Charites.Windows.Samples.SimpleLoginDemo.Presentation;

[Specification("SimpleLoginDemoHostController Spec")]
class SimpleLoginDemoHostControllerSpec : FixtureSteppable
{
    SimpleLoginDemoHostController Controller { get; }
    SimpleLoginDemoHost Host { get; } = new();
    IContentNavigator Navigator { get; } = Substitute.For<IContentNavigator>();

    public SimpleLoginDemoHostControllerSpec()
    {
        Controller = new SimpleLoginDemoHostController(Navigator);
        WinUIController.SetDataContext(Host, Controller);
    }

    [Example("Navigates to an initial content when the SimpleLoginDemoHost is loaded")]
    async Task Ex01()
    {
        await CarnaWinUIRunner.InvokeAsync(() =>
        {
            var windowProvider = Substitute.For<ISimpleLoginDemoWindowProvider>();
            windowProvider.Window.Returns(new Window());

            When("the SimpleLoginDemoHost is loaded", () =>
                WinUIController.EventHandlersOf(Controller)
                    .GetBy(null)
                    .ResolveFromDI<ISimpleLoginDemoWindowProvider>(() => windowProvider)
                    .Raise(nameof(FrameworkElement.Loaded))
            );
            Then("the content should be navigated to the LoginContent", () => { Navigator.Received(1).NavigateTo(Arg.Any<LoginContent>()); });
        });
    }

    [Example("Sets a new content when the current content is navigated")]
    void Ex02()
    {
        var nextContent = new object();
        When("the content is navigated to the next content", () =>
            Navigator.Navigated += Raise.EventWith(Navigator, new ContentNavigatedEventArgs(ContentNavigationMode.New, nextContent, Host.Content.Value!))
        );
        Then("the content to navigate should be set to the content of the SimpleLoginDemoHost", () => Host.Content.Value == nextContent);
    }
}