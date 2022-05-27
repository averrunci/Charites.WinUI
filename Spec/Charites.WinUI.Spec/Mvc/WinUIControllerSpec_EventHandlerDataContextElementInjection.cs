// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using System.Collections;
using Carna;

namespace Charites.Windows.Mvc;

[Context("Event handler, data context, and element injection")]
class WinUIControllerSpec_EventHandlerDataContextElementInjection : DispatcherContext
{
    object DataContext { get; set; } = default!;
    TestElement Element { get; set; } = default!;
    TestElement ChildElement { get; set; } = default!;

    static bool EventHandled { get; set; }
    static Action NoArgumentAssertionHandler { get; } = () => EventHandled = true;
    static Action<object> OneArgumentAssertionHandler { get; } = _ => EventHandled = true;
    static Action<object?, object> TwoArgumentsAssertionHandler { get; } = (_, _) => EventHandled = true;

    [Example("Adds event handlers")]
    [Sample(Source = typeof(WinUIControllerSampleDataSource))]
    async Task Ex01(TestWinUIControllers.ITestWinUIController controller)
    {
        await RunAsync(() =>
        {
            Given("a data context", () => DataContext = new object());
            Given("a child element", () => ChildElement = new TestElement { Name = "childElement" });
            Given("an element that has the child element", () => Element = new TestElement { Name = "element", Content = ChildElement, DataContext = DataContext });

            When("the controller is added", () => WinUIController.GetControllers(Element).Add(controller));
            When("the controller is attached to the element", () => WinUIController.GetControllers(Element).AttachTo(Element));

            Then("the data context of the controller should be set", () => controller.DataContext == DataContext);
            Then("the element of the controller should be null", () => controller.Element == null);
            Then("the child element of the controller should be null", () => controller.ChildElement == null);
        });

        EventHandled = false;
        When("the element is set to the content of the window", async () => await SetWindowContentAsync(Element));

        Then("the data context of the controller should be set", () => controller.DataContext == DataContext);
        Then("the element of the controller should be set", () => controller.Element == Element);
        Then("the child element of the controller should be set", () => controller.ChildElement == ChildElement);
        Then("the event should be handled", () => EventHandled);

        await RunAsync(() =>
        {
            EventHandled = false;
            When("the Changed event of the child element is raised", () => ChildElement.RaiseChanged());
            Then("the Changed event should be handled", () => EventHandled);

            EventHandled = false;
            When("the data context of the child element should be set", () => ChildElement.DataContext = new object());
            Then("the DataContextChanged event should be handled", () => EventHandled);
        });
    }

    [Example("Sets elements")]
    [Sample(Source = typeof(WinUIControllerSampleDataSource))]
    async Task Ex02(TestWinUIControllers.ITestWinUIController controller)
    {
        await RunAsync(() =>
        {
            Given("a child element", () => ChildElement = new TestElement { Name = "childElement" });
            Given("an element", () => Element = new TestElement { Name = "element" });
            When("the child element is set to the controller using the WinUIController", () => WinUIController.SetElement(ChildElement, controller, true));
            When("the element is set to the controller using the WinUIController", () => WinUIController.SetElement(Element, controller, true));
            Then("the element should be set to the controller", () => controller.Element == Element);
            Then("the child element should be set to the controller", () => controller.ChildElement == ChildElement);
        });
    }

    [Example("Sets a data context")]
    [Sample(Source = typeof(WinUIControllerSampleDataSource))]
    async Task Ex03(TestWinUIControllers.ITestWinUIController controller)
    {
        await RunAsync(() =>
        {
            Given("a data context", () => DataContext = new object());
            When("the data context is set to the controller using the WinUIController", () => WinUIController.SetDataContext(DataContext, controller));
            Then("the data context should be set to the controller", () => controller.DataContext == DataContext);
        });
    }

    class WinUIControllerSampleDataSource : ISampleDataSource
    {
        IEnumerable ISampleDataSource.GetData()
        {
            yield return new { Description = "When the contents are attributed to fields and the event handler has no argument.", Controller = new TestWinUIControllers.AttributedToField.NoArgumentHandlerController(NoArgumentAssertionHandler) };
            yield return new { Description = "When the contents are attributed to fields and the event handler has one argument.", Controller = new TestWinUIControllers.AttributedToField.OneArgumentHandlerController(OneArgumentAssertionHandler) };
            yield return new { Description = "When the contents are attributed to fields and the event handler has two arguments.", Controller = new TestWinUIControllers.AttributedToField.TwoArgumentsEventHandlerController(TwoArgumentsAssertionHandler) };
            yield return new { Description = "When the contents are attributed to properties and the event handler has no argument.", Controller = new TestWinUIControllers.AttributedToProperty.NoArgumentHandlerController(NoArgumentAssertionHandler) };
            yield return new { Description = "When the contents are attributed to properties and the event handler has one argument.", Controller = new TestWinUIControllers.AttributedToProperty.OneArgumentHandlerController(OneArgumentAssertionHandler) };
            yield return new { Description = "When the contents are attributed to properties and the event handler has two arguments.", Controller = new TestWinUIControllers.AttributedToProperty.TwoArgumentsEventHandlerController(TwoArgumentsAssertionHandler) };
            yield return new { Description = "When the contents are attributed to methods and the event handler has no argument.", Controller = new TestWinUIControllers.AttributedToMethod.NoArgumentHandlerController(NoArgumentAssertionHandler) };
            yield return new { Description = "When the contents are attributed to methods and the event handler has one argument.", Controller = new TestWinUIControllers.AttributedToMethod.OneArgumentHandlerController(OneArgumentAssertionHandler) };
            yield return new { Description = "When the contents are attributed to methods and the event handler has two arguments.", Controller = new TestWinUIControllers.AttributedToMethod.TwoArgumentsEventHandlerController(TwoArgumentsAssertionHandler) };
            yield return new { Description = "When the contents are attributed to methods and the event handler has no argument using a naming convention.", Controller = new TestWinUIControllers.AttributedToMethodUsingNamingConvention.NoArgumentHandlerController(NoArgumentAssertionHandler) };
            yield return new { Description = "When the contents are attributed to methods and the event handler has one argument using a naming convention.", Controller = new TestWinUIControllers.AttributedToMethodUsingNamingConvention.OneArgumentHandlerController(OneArgumentAssertionHandler) };
            yield return new { Description = "When the contents are attributed to methods and the event handler has two arguments using a naming convention.", Controller = new TestWinUIControllers.AttributedToMethodUsingNamingConvention.TwoArgumentsEventHandlerController(TwoArgumentsAssertionHandler) };
            yield return new { Description = "When the contents are attributed to async methods and the event handler has no argument using a naming convention.", Controller = new TestWinUIControllers.AttributedToAsyncMethodUsingNamingConvention.NoArgumentHandlerController(NoArgumentAssertionHandler) };
            yield return new { Description = "When the contents are attributed to async methods and the event handler has one argument using a naming convention.", Controller = new TestWinUIControllers.AttributedToAsyncMethodUsingNamingConvention.OneArgumentHandlerController(OneArgumentAssertionHandler) };
            yield return new { Description = "When the contents are attributed to async methods and the event handler has two arguments using a naming convention.", Controller = new TestWinUIControllers.AttributedToAsyncMethodUsingNamingConvention.TwoArgumentsEventHandlerController(TwoArgumentsAssertionHandler) };
        }
    }
}