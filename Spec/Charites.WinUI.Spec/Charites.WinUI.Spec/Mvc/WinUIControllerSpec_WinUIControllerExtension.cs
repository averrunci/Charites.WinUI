// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Carna;
using Microsoft.UI.Xaml;
using NSubstitute;

namespace Charites.Windows.Mvc;

[Context("WinUIControllerExtension")]
class WinUIControllerSpec_WinUIControllerExtension : DispatcherContext, IDisposable
{
    class TestExtension : IWinUIControllerExtension
    {
        public static object TestExtensionContainer { get; } = new();
        public void Attach(object controller, FrameworkElement element) { }
        public void Detach(object controller, FrameworkElement element) { }
        public object Retrieve(object controller) => TestExtensionContainer;
    }

    IWinUIControllerExtension Extension { get; set; } = default!;

    TestDataContexts.TestDataContext DataContext { get; } = new();
    TestElement Element { get; set; } = default!;
    TestWinUIControllers.TestWinUIController Controller { get; set; } = default!;

    public void Dispose()
    {
        WinUIController.RemoveExtension(Extension);
    }

    [Example("Attaches an extension when the element is loaded and detaches it when the element is unloaded")]
    async Task Ex01()
    {
        Extension = Substitute.For<IWinUIControllerExtension>();

        await RunAsync(() =>
        {
            Given("an element that contains a data context", () => Element = new TestElement { DataContext = DataContext });
            When("the WinUIController is enabled for the element", () =>
            {
                WinUIController.SetIsEnabled(Element, true);
                Controller = Element.GetController<TestWinUIControllers.TestWinUIController>();
            });
            When("the extension is added", () => WinUIController.AddExtension(Extension));
        });
        When("the element is set for the content of the window", async () => await SetWindowContentAsync(Element));
        Then("the extension should be attached", () => Extension.Received(1).Attach(Controller, Element));

        When("the content of the window is cleared in order to unload the element", async () => await ClearWindowContentAsync());
        Then("the extension should be detached", () => Extension.Received(1).Detach(Controller, Element));
    }

    [Example("Retrieves a container of an extension")]
    void Ex02()
    {
        Extension = new TestExtension();

        Given("a controller", () => Controller = new TestWinUIControllers.TestWinUIController());
        When("an extension is added", () => WinUIController.AddExtension(Extension));
        Then("the container of the extension should be retrieved", () => WinUIController.Retrieve<TestExtension, object>(Controller) == TestExtension.TestExtensionContainer);
    }
}