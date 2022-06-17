// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Carna;
using Charites.Windows.Mvc;
using Charites.Windows.Samples.SimpleLoginDemo.Presentation.Login;
using Microsoft.UI.Xaml.Controls.Primitives;
using NSubstitute;

namespace Charites.Windows.Samples.SimpleLoginDemo.Presentation.Home;

[Specification("HomeContentController Spec")]
class HomeContentControllerSpec : FixtureSteppable
{
    HomeContentController Controller { get; } = new();
    IContentNavigator Navigator { get; } = Substitute.For<IContentNavigator>();

    [Example("Logs the user out")]
    void Ex01()
    {
        When("to click the Logout button", () =>
            WinUIController.EventHandlersOf(Controller)
                .GetBy("LogoutButton")
                .ResolveFromDI<IContentNavigator>(() => Navigator)
                .Raise(nameof(ButtonBase.Click))
        );
        Then("the content should be navigated to the LoginContent", () =>
        {
            Navigator.Received(1).NavigateTo(Arg.Any<LoginContent>());
        });
    }
}