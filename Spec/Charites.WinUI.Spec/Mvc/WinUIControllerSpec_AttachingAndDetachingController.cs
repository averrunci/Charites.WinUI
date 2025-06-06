// Copyright (C) 2022-2025 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Carna;

namespace Charites.Windows.Mvc;

[Context(
    "Attaching and detaching a controller",
    typeof(WinUIControllerSpec_AttachingAndDetachingController_IsEnabled),
    typeof(WinUIControllerSpec_AttachingAndDetachingController_IsEnabledBeforeDataContextIsSet)
)]
class WinUIControllerSpec_AttachingAndDetachingController : DispatcherContext
{
    TestElement Element { get; set; } = default!;

    TestWinUIControllers.TestWinUIController Controller { get; set; } = default!;
    bool DataContextChangedEventHandled { get; set; }
    bool LoadingEventHandled { get; set; }
    bool LoadedEventHandled { get; set; }
    bool ChangedEventHandled { get; set; }

    TestWinUIControllers.TestWinUIControllerBase[] Controllers { get; set; } = default!;
    bool[] DataContextChangedEventsHandled { get; set; } = default!;
    bool[] LoadingEventsHandled { get; set; } = default!;
    bool[] LoadedEventsHandled { get; set; } = default!;
    bool[] ChangedEventsHandled { get; set; } = default!;

    [Example("Attaches a controller when the Key property of the WinUIController is set")]
    async Task Ex01()
    {
        await RunAsync(() =>
        {
            Given("an element that contains the data context", () => Element = new TestElement { DataContext = new TestDataContexts.KeyAttachingTestDataContext() });
            When("the key of the element is set using the WinUIController", () => WinUIController.SetKey(Element, "TestElement"));
            Then("the WinUIController should be enabled for the element", () => WinUIController.GetIsEnabled(Element));
            Then("the controller should be attached to the element", () =>
                WinUIController.GetControllers(Element).Select(controller => controller.GetType()).SequenceEqual(new[] { typeof(TestWinUIControllers.KeyTestDataContextController) }) &&
                WinUIController.GetControllers(Element).OfType<TestWinUIControllers.TestController>().All(controller => controller.DataContext == Element.DataContext)
            );
        });
    }

    [Example("Sets the changed data context when the WinUIController is enabled and the data context of an element is changed")]
    async Task Ex02()
    {
        await RunAsync(() =>
        {
            Given("an element that contains the data context", () => Element = new TestElement { DataContext = new TestDataContexts.AttachingTestDataContext() });
            When("the WinUIController is enabled for the element", () => WinUIController.SetIsEnabled(Element, true));
            Then("the data context of the controller should be set", () => Element.GetController<TestWinUIControllers.TestController>().DataContext == Element.DataContext);
            When("another data context is set for the element", () => Element.DataContext = new object());
            Then("the data context of the controller should be changed", () => Element.GetController<TestWinUIControllers.TestController>().DataContext == Element.DataContext);
        });
    }

    [Example("Removes event handlers and sets null to elements and a data context when the Unloaded event of the root element is raised")]
    async Task Ex03()
    {
        await RunAsync(() =>
        {
            Given("an element that contains the data context", () => Element = new TestElement { Name = "Element", DataContext = new TestDataContexts.TestDataContext() });
            When("the WinUIController is enabled for the element", () =>
            {
                WinUIController.SetIsEnabled(Element, true);
                Controller = Element.GetController<TestWinUIControllers.TestWinUIController>();
                Controller.DataContextChangedAssertionHandler = () => DataContextChangedEventHandled = true;
                Controller.LoadingAssertionHandler = () => LoadingEventHandled = true;
                Controller.LoadedAssertionHandler = () => LoadedEventHandled = true;
                Controller.ChangedAssertionHandler = () => ChangedEventHandled = true;
            });
            Then("the data context of the controller should be set", () => Controller.DataContext == Element.DataContext);
        });

        When("the element is set for the content of the window", async () => await SetWindowContentAsync(Element));

        await RunAsync(() =>
        {
            Then("the element of the controller should be set", () => Controller.Element == Element);

            Then("the DataContextChanged event should be handled", () => DataContextChangedEventHandled);
            Then("the Loading event should be handled", () => LoadingEventHandled);
            Then("the Loaded event should be handled", () => LoadedEventHandled);

            When("the Changed event of the element is raised", () => Element.RaiseChanged());
            Then("the Changed event should be handled", () => ChangedEventHandled);
        });

        When("the content of the window is cleared in order to unload the element", async () => await ClearWindowContentAsync());

        await RunAsync(() =>
        {
            Then("the controller associated with the element should be detached from the WinUIController", () => !WinUIController.GetControllers(Element).Any());

            ChangedEventHandled = false;
            When("the Changed event of the element is raised", () => Element.RaiseChanged());
            Then("the Changed event should not be handled", () => !ChangedEventHandled);
        });
    }

    [Example("Removes event handlers and sets null to elements and a data context when the WinUIController is disabled")]
    async Task Ex04()
    {
        await RunAsync(() =>
        {
            Given("an element that contains the data context", () => Element = new TestElement { Name = "Element", DataContext = new TestDataContexts.TestDataContext() });
            When("the WinUIController is enabled for the element", () =>
            {
                WinUIController.SetIsEnabled(Element, true);
                Controller = Element.GetController<TestWinUIControllers.TestWinUIController>();
                Controller.DataContextChangedAssertionHandler = () => DataContextChangedEventHandled = true;
                Controller.LoadingAssertionHandler = () => LoadingEventHandled = true;
                Controller.LoadedAssertionHandler = () => LoadedEventHandled = true;
                Controller.ChangedAssertionHandler = () => ChangedEventHandled = true;
            });
            Then("the data context of the controller should be set", () => Controller.DataContext == Element.DataContext);
        });

        When("the element is set for the content of the window", async () => await SetWindowContentAsync(Element));

        await RunAsync(() =>
        {
            Then("the element of the controller should be set", () => Controller.Element == Element);

            Then("the DataContextChanged event should be handled", () => DataContextChangedEventHandled);
            Then("the Loading event should be handled", () => LoadingEventHandled);
            Then("the Loaded event should be handled", () => LoadedEventHandled);

            When("the WinUIController is disabled for the element", () => WinUIController.SetIsEnabled(Element, false));
            Then("the controller should be detached", () => !WinUIController.GetControllers(Element).Any());
            Then("the data context of the controller should be null", () => Controller.DataContext == null);
            Then("the element of the controller should be null", () => Controller.Element == null);

            When("the Changed event of the element is raised", () => Element.RaiseChanged());
            Then("the Changed event should not be handled", () => !ChangedEventHandled);
        });

        When("the content of the window is cleared in order to unload the element", async () => await ClearWindowContentAsync());

        When("the element is set for the content of the window", async () => await SetWindowContentAsync(Element));

        await RunAsync(() =>
        {
            Then("the controller should not be attached", () => !WinUIController.GetControllers(Element).Any());
        });
    }

    [Example("Attaches multi controllers")]
    async Task Ex05()
    {
        await RunAsync(() =>
        {
            Given("an element that contains the data context", () => Element = new TestElement { Name = "Element", DataContext = new TestDataContexts.MultiTestDataContext() });
            When("the WinUIController is enabled for the element", () =>
            {
                WinUIController.SetIsEnabled(Element, true);
                Controllers =
                [
                    Element.GetController<TestWinUIControllers.MultiTestWinUIControllerA>(),
                    Element.GetController<TestWinUIControllers.MultiTestWinUIControllerB>(),
                    Element.GetController<TestWinUIControllers.MultiTestWinUIControllerC>()
                ];
                DataContextChangedEventsHandled = [false, false, false];
                LoadingEventsHandled = [false, false, false];
                LoadedEventsHandled = [false, false, false];
                ChangedEventsHandled = [false, false, false];
                for (var index = 0; index < Controllers.Length; ++index)
                {
                    var eventHandledIndex = index;
                    Controllers[index].DataContextChangedAssertionHandler = () => DataContextChangedEventsHandled[eventHandledIndex] = true;
                    Controllers[index].LoadingAssertionHandler = () => LoadingEventsHandled[eventHandledIndex] = true;
                    Controllers[index].LoadedAssertionHandler = () => LoadedEventsHandled[eventHandledIndex] = true;
                    Controllers[index].ChangedAssertionHandler = () => ChangedEventsHandled[eventHandledIndex] = true;
                }
            });
            Then("the data context of the controller should be set", () => Controllers.All(controller => controller.DataContext == Element.DataContext));
        });

        When("the element is set for the content of the window", async () => await SetWindowContentAsync(Element));

        await RunAsync(() =>
        {
            Then("the element of the controller should be set", () => Controllers.All(controller => controller.Element == Element));

            Then("the DataContextChanged event should be handled", () => DataContextChangedEventsHandled.All(h => h));
            Then("the Loading event should be handled", () => LoadingEventsHandled.All(h => h));
            Then("the Loaded event should be handled", () => LoadedEventsHandled.All(h => h));

            When("the Changed event of the element is raised", () => Element.RaiseChanged());
            Then("the Changed event should be handled", () => ChangedEventsHandled.All(h => h));
        });

        When("the content of the window is cleared in order to unload the element", async () => await ClearWindowContentAsync());

        await RunAsync(() =>
        {
            Then("the data context of the controller should be null", () => Controllers.All(controller => controller.DataContext == null));
            Then("the element of the controller should be null", () => Controllers.All(controller => controller.Element == null));

            for (var index = 0; index < ChangedEventsHandled.Length; index++)
            {
                ChangedEventsHandled[index] = false;
            }
            When("the Changed event of the element is raised", () => Element.RaiseChanged());
            Then("the Changed event should not be handled", () => ChangedEventsHandled.All(h => !h));
        });
    }
}