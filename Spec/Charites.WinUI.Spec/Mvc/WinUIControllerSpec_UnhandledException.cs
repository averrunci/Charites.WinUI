// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using System.Reflection;
using Carna;

namespace Charites.Windows.Mvc;

[Context("Unhandled exception")]
class WinUIControllerSpec_UnhandledException : DispatcherContext, IDisposable
{
    TestWinUIControllers.ExceptionTestWinUIController Controller { get; set; } = default!;
    TestElement Element { get; set; } = default!;

    Exception? UnhandledException { get; set; }
    bool HandledException { get; set; }

    public WinUIControllerSpec_UnhandledException()
    {
        WinUIController.UnhandledException += OnUwpControllerUnhandledException;
    }

    public void Dispose()
    {
        WinUIController.UnhandledException -= OnUwpControllerUnhandledException;
    }

    private void OnUwpControllerUnhandledException(object? sender, UnhandledExceptionEventArgs e)
    {
        UnhandledException = e.Exception;
        e.Handled = HandledException;
    }

    [Example("Handles an unhandled exception as it is handled")]
    async Task Ex01()
    {
        HandledException = true;

        await RunAsync(() =>
        {
            Given("a controller that has an event handler that throws an exception", () => Controller = new TestWinUIControllers.ExceptionTestWinUIController());
            Given("an element", () => Element = new TestElement());

            When("the controller is added", () => WinUIController.GetControllers(Element).Add(Controller));
            When("the controller is attached to the element", () => WinUIController.GetControllers(Element).AttachTo(Element));
        });

        When("the element is set to the content of the window", async () => await SetWindowContentAsync(Element));

        await RunAsync(() =>
        {
            When("the Changed event of the element is raised", () => Element.RaiseChanged());
            Then("the unhandled exception should be handled", () => UnhandledException != null);
        });
    }

    [Example("Handles an unhandled exception as it is not handled")]
    async Task Ex02()
    {
        HandledException = false;

        await RunAsync(() =>
        {
            Given("a controller that has an event handler that throws an exception", () => Controller = new TestWinUIControllers.ExceptionTestWinUIController());
            Given("an element", () => Element = new TestElement());

            When("the controller is added", () => WinUIController.GetControllers(Element).Add(Controller));
            When("the controller is attached to the element", () => WinUIController.GetControllers(Element).AttachTo(Element));
        });

        When("the element is set to the content of the window", async () => await SetWindowContentAsync(Element));

        await RunAsync(() =>
        {
            When("the Changed event of the element is raised", () => Element.RaiseChanged());
            Then<TargetInvocationException>("the exception should be thrown");
            Then("the unhandled exception should be handled", () => UnhandledException != null);
        });
    }
}