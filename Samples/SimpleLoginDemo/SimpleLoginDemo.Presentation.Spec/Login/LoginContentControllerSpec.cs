// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Carna;
using Charites.Windows.Mvc;
using Charites.Windows.Samples.SimpleLoginDemo.Presentation.Home;
using Microsoft.UI.Xaml.Controls.Primitives;
using NSubstitute;

namespace Charites.Windows.Samples.SimpleLoginDemo.Presentation.Login;

[Specification("LoginContentControllerSpec")]
class LoginContentControllerSpec : FixtureSteppable
{
    LoginContentController Controller { get; } = new();
    LoginContent LoginContent { get; } = new()
    {
        Message = { Value = "Initial Message" }
    };

    ILoginCommand Command { get; } = Substitute.For<ILoginCommand>();
    IContentNavigator Navigator { get; } = Substitute.For<IContentNavigator>();

    public LoginContentControllerSpec()
    {
        WinUIController.SetDataContext(LoginContent, Controller);
    }

    [Example("Logs the user in when the user in authenticated")]
    void Ex01()
    {
        Command.AuthenticateAsync(LoginContent).Returns(LoginAuthenticationResult.Success);

        When("the authenticated user information is set", () =>
        {
            LoginContent.UserId.Value = "user";
            LoginContent.Password.Value = "password";
        });
        When("to click the Login button", async () =>
            await WinUIController.EventHandlersOf(Controller)
                .GetBy("LoginButton")
                .ResolveFromDI<ILoginCommand>(() => Command)
                .ResolveFromDI<IContentNavigator>(() => Navigator)
                .RaiseAsync(nameof(ButtonBase.Click))
        );
        Then("the content should be navigated to the HomeContent", () =>
        {
            Navigator.Received(1).NavigateTo(Arg.Is<HomeContent>(content => content.Id == LoginContent.UserId.Value));
        });
        Then("the message should be an empty", () => LoginContent.Message.Value == string.Empty);
    }

    [Example("Shows login failure message when the user authentication is failed")]
    void Ex02()
    {
        Command.AuthenticateAsync(LoginContent).Returns(LoginAuthenticationResult.Failure);

        When("the unauthenticated user information is set", () =>
        {
            LoginContent.UserId.Value = "user";
            LoginContent.Password.Value = "password";
        });
        When("to click the Login button", async () =>
            await WinUIController.EventHandlersOf(Controller)
                .GetBy("LoginButton")
                .ResolveFromDI<ILoginCommand>(() => Command)
                .ResolveFromDI<IContentNavigator>(() => Navigator)
                .RaiseAsync(nameof(ButtonBase.Click))
        );
        Then("the content should not be navigated to any contents", () =>
        {
            Navigator.DidNotReceive().NavigateTo(Arg.Any<object>());
        });
        Then("the error message should be set", () => LoginContent.Message.Value == Resources.LoginFailure);
    }
}