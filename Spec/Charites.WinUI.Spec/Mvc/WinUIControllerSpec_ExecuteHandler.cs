// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.System;
using Carna;
using Carna.WinUIRunner;
using Charites.Windows.Mvc.Wrappers;
using Microsoft.UI.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;
using NSubstitute;

namespace Charites.Windows.Mvc;

[Context("Executes handlers")]
class WinUIControllerSpec_ExecuteHandler : FixtureSteppable
{
    [Example("Retrieves event handlers and executes them when an element is not attached")]
    void Ex01()
    {
        var loadedEventHandled = false;
        When("the Loaded event is raised using the EventHandlerBase", () =>
            WinUIController.EventHandlersOf(new TestWinUIControllers.TestWinUIController { LoadedAssertionHandler = () => loadedEventHandled = true })
                .GetBy("Element")
                .Raise(nameof(FrameworkElement.Loaded))
        );
        Then("the Loaded event should be handled", () => loadedEventHandled);
    }

    [Example("Retrieves event handlers and executes them asynchronously when an element is not attached")]
    void Ex02()
    {
        var loadedEventHandled = false;
        When("the Loaded event is raised asynchronously using the EventHandlerBase", async () =>
            await WinUIController.EventHandlersOf(new TestWinUIControllers.TestWinUIControllerAsync { LoadedAssertionHandler = () => loadedEventHandled = true })
                .GetBy("Element")
                .RaiseAsync(nameof(FrameworkElement.Loaded))
        );
        Then("the Loaded event should be handled", () => loadedEventHandled);
    }

    [Example("Retrieves event handlers and executes them with the event args resolver scope when an element is not attached")]
    void Ex03()
    {
        var keyDownHandler = Substitute.For<Action<VirtualKey>>();
        When("the KeyDown event is raised using the EventHandlerBase", () =>
            WinUIController.Using(Substitute.For<IKeyRoutedEventArgsResolver>(), typeof(KeyRoutedEventArgsWrapper))
                .Apply(resolver => resolver.Key(Arg.Any<KeyRoutedEventArgs>()).Returns(VirtualKey.Enter))
                .EventHandlersOf(new TestWinUIControllers.TestWinUIController { KeyDownAssertionHandler = keyDownHandler })
                .GetBy("Element")
                .Raise(nameof(UIElement.KeyDown))
        );
        Then("the KeyDown event should be handled", () => keyDownHandler.Received(1).Invoke(VirtualKey.Enter));
    }

    [Example("Retrieves event handlers that have attributed parameters and executes them with the event args resolver scope when an element is not attached")]
    async Task Ex04()
    {
        var keyDownHandler = Substitute.For<Action<VirtualKey>>();
        var attributedArgumentsHandler = Substitute.For<Action<TestWinUIControllers.IDependency1, TestWinUIControllers.IDependency2, TestWinUIControllers.IDependency3, TestElement, TestDataContexts.TestDataContext>>();
        var dependency1 = new TestWinUIControllers.Dependency1();
        var dependency2 = new TestWinUIControllers.Dependency2();
        var dependency3 = new TestWinUIControllers.Dependency3();
        var testElement = await CarnaWinUIRunner.Window.DispatcherQueue.RunAsync(() => new TestElement { Name = "testElement" });
        var dataContext = new TestDataContexts.TestDataContext();
        When("the KeyDown event is raised using the EventHandlerBase", () =>
            WinUIController.Using(Substitute.For<IKeyRoutedEventArgsResolver>(), typeof(KeyRoutedEventArgsWrapper))
                .Apply(resolver => resolver.Key(Arg.Any<KeyRoutedEventArgs>()).Returns(VirtualKey.Enter))
                .EventHandlersOf(new TestWinUIControllers.AttributedParametersController { KeyDownAssertionHandler = keyDownHandler, AttributedArgumentsHandler = attributedArgumentsHandler })
                .GetBy("Element")
                .ResolveFromDI<TestWinUIControllers.IDependency1>(() => dependency1)
                .ResolveFromDI<TestWinUIControllers.IDependency2>(() => dependency2)
                .ResolveFromDI<TestWinUIControllers.IDependency3>(() => dependency3)
                .ResolveFromElement("testElement", testElement)
                .ResolveFromDataContext(dataContext)
                .Raise(nameof(UIElement.KeyDown))
        );
        Then("the KeyDown event should be handled", () => keyDownHandler.Received(1).Invoke(VirtualKey.Enter));
        Then("the attributed arguments should be injected", () => attributedArgumentsHandler.Received(1).Invoke(dependency1, dependency2, dependency3, testElement, dataContext));
    }

    [Example("Retrieves event handlers and executes them with the event args resolver scope asynchronously when an element is not attached")]
    void Ex05()
    {
        var keyDownHandler = Substitute.For<Action<VirtualKey>>();
        When("the KeyDown event is raised asynchronously using the EventHandlerBase", async () =>
            await WinUIController.Using(Substitute.For<IKeyRoutedEventArgsResolver>(), typeof(KeyRoutedEventArgsWrapper))
                .Apply(resolver => resolver.Key(Arg.Any<KeyRoutedEventArgs>()).Returns(VirtualKey.Enter))
                .EventHandlersOf(new TestWinUIControllers.TestWinUIControllerAsync { KeyDownAssertionHandler = keyDownHandler })
                .GetBy("Element")
                .RaiseAsync(nameof(UIElement.KeyDown))
        );
        Then("the KeyDown event should be handled", () => keyDownHandler.Received(1).Invoke(VirtualKey.Enter));
    }

    [Example("Retrieves event handlers that have attributed parameters and executes them with the event args resolver scope asynchronously when an element is not attached")]
    async Task Ex06()
    {
        var keyDownHandler = Substitute.For<Action<VirtualKey>>();
        var attributedArgumentsHandler = Substitute.For<Action<TestWinUIControllers.IDependency1, TestWinUIControllers.IDependency2, TestWinUIControllers.IDependency3, TestElement, TestDataContexts.TestDataContext>>();
        var dependency1 = new TestWinUIControllers.Dependency1();
        var dependency2 = new TestWinUIControllers.Dependency2();
        var dependency3 = new TestWinUIControllers.Dependency3();
        var testElement = await CarnaWinUIRunner.Window.DispatcherQueue.RunAsync(() => new TestElement { Name = "TestElement" });
        var dataContext = new TestDataContexts.TestDataContext();
        When("the KeyDown event is raised asynchronously using the EventHandlerBase", async () =>
            await WinUIController.Using(Substitute.For<IKeyRoutedEventArgsResolver>(), typeof(KeyRoutedEventArgsWrapper))
                .Apply(resolver => resolver.Key(Arg.Any<KeyRoutedEventArgs>()).Returns(VirtualKey.Enter))
                .EventHandlersOf(new TestWinUIControllers.AttributedParametersControllerAsync { KeyDownAssertionHandler = keyDownHandler, AttributedArgumentsHandler = attributedArgumentsHandler })
                .GetBy("Element")
                .ResolveFromDI<TestWinUIControllers.IDependency1>(() => dependency1)
                .ResolveFromDI<TestWinUIControllers.IDependency2>(() => dependency2)
                .ResolveFromDI<TestWinUIControllers.IDependency3>(() => dependency3)
                .ResolveFromElement("TestElement", testElement)
                .ResolveFromDataContext(dataContext)
                .RaiseAsync(nameof(UIElement.KeyDown))
        );
        Then("the KeyDown event should be handled", () => keyDownHandler.Received(1).Invoke(VirtualKey.Enter));
        Then("the attributed arguments should be injected", () => attributedArgumentsHandler.Received(1).Invoke(dependency1, dependency2, dependency3, testElement, dataContext));
    }

    [Example("Retrieves event handlers and executes them with the event args resolver scope that has multiple event args resolver when an element is not attached")]
    void Ex07()
    {
        var pointerPressedHandler = Substitute.For<Action<PointerDeviceType>>();
        When("the PointerPressed event is raised using the EventHandlerBase", () =>
            WinUIController.Using(Substitute.For<IPointerRoutedEventArgsResolver>(), typeof(PointerRoutedEventArgsWrapper))
                .Apply(resolver => resolver.Pointer(Arg.Any<PointerRoutedEventArgs>()).Returns((Pointer?)null))
                .Using(Substitute.For<IPointerResolver>(), typeof(PointerWrapper))
                .Apply(resolver => resolver.PointerDeviceType(Arg.Any<Pointer>()).Returns(PointerDeviceType.Mouse))
                .EventHandlersOf(new TestWinUIControllers.TestWinUIController { PointerPressedHandler = pointerPressedHandler })
                .GetBy("Element")
                .Raise(nameof(UIElement.PointerPressed))
        );
        Then("the PointerPressed event should be handled", () => pointerPressedHandler.Received(1).Invoke(PointerDeviceType.Mouse));
    }

    [Example("Retrieves event handlers that have attributed parameters and executes them with the event args resolver scope that has multiple event args resolver when an element is not attached")]
    async Task Ex08()
    {
        var pointerPressedHandler = Substitute.For<Action<PointerDeviceType>>();
        var attributedArgumentsHandler = Substitute.For<Action<TestWinUIControllers.IDependency1, TestWinUIControllers.IDependency2, TestWinUIControllers.IDependency3, TestElement, TestDataContexts.TestDataContext>>();
        var dependency1 = new TestWinUIControllers.Dependency1();
        var dependency2 = new TestWinUIControllers.Dependency2();
        var dependency3 = new TestWinUIControllers.Dependency3();
        var testElement = await CarnaWinUIRunner.Window.DispatcherQueue.RunAsync(() => new TestElement { Name = "testElement" });
        var dataContext = new TestDataContexts.TestDataContext();
        When("the PointerPressed event is raised using the EventHandlerBase", () =>
            WinUIController.Using(Substitute.For<IPointerRoutedEventArgsResolver>(), typeof(PointerRoutedEventArgsWrapper))
                .Apply(resolver => resolver.Pointer(Arg.Any<PointerRoutedEventArgs>()).Returns((Pointer?)null))
                .Using(Substitute.For<IPointerResolver>(), typeof(PointerWrapper))
                .Apply(resolver => resolver.PointerDeviceType(Arg.Any<Pointer>()).Returns(PointerDeviceType.Mouse))
                .EventHandlersOf(new TestWinUIControllers.AttributedParametersController { PointerPressedHandler = pointerPressedHandler, AttributedArgumentsHandler = attributedArgumentsHandler })
                .GetBy("Element")
                .ResolveFromDI<TestWinUIControllers.IDependency1>(() => dependency1)
                .ResolveFromDI<TestWinUIControllers.IDependency2>(() => dependency2)
                .ResolveFromDI<TestWinUIControllers.IDependency3>(() => dependency3)
                .ResolveFromElement("testElement", testElement)
                .ResolveFromDataContext(dataContext)
                .Raise(nameof(UIElement.PointerPressed))
        );
        Then("the PointerPressed event should be handled", () => pointerPressedHandler.Received(1).Invoke(PointerDeviceType.Mouse));
        Then("the attributed arguments should be injected", () => attributedArgumentsHandler.Received(1).Invoke(dependency1, dependency2, dependency3, testElement, dataContext));
    }

    [Example("Retrieves event handlers and executes them with the event args resolver scope that has multiple event args resolver asynchronously when an element is not attached")]
    void Ex09()
    {
        var pointerPressedHandler = Substitute.For<Action<PointerDeviceType>>();
        When("the PointerPressed event is raised asynchronously using the EventHandlerBase", async () =>
            await WinUIController.Using(Substitute.For<IPointerRoutedEventArgsResolver>(), typeof(PointerRoutedEventArgsWrapper))
                .Apply(resolver => resolver.Pointer(Arg.Any<PointerRoutedEventArgs>()).Returns((Pointer?)null))
                .Using(Substitute.For<IPointerResolver>(), typeof(PointerWrapper))
                .Apply(resolver => resolver.PointerDeviceType(Arg.Any<Pointer>()).Returns(PointerDeviceType.Mouse))
                .EventHandlersOf(new TestWinUIControllers.TestWinUIControllerAsync { PointerPressedHandler = pointerPressedHandler })
                .GetBy("Element")
                .RaiseAsync(nameof(UIElement.PointerPressed))
        );
        Then("the PointerPressed event should be handled", () => pointerPressedHandler.Received(1).Invoke(PointerDeviceType.Mouse));
    }

    [Example("Retrieves event handlers that have attributed parameters and executes them with the event args resolver scope that has multiple event args resolver asynchronously when an element is not attached")]
    async Task Ex10()
    {
        var pointerPressedHandler = Substitute.For<Action<PointerDeviceType>>();
        var attributedArgumentsHandler = Substitute.For<Action<TestWinUIControllers.IDependency1, TestWinUIControllers.IDependency2, TestWinUIControllers.IDependency3, TestElement, TestDataContexts.TestDataContext>>();
        var dependency1 = new TestWinUIControllers.Dependency1();
        var dependency2 = new TestWinUIControllers.Dependency2();
        var dependency3 = new TestWinUIControllers.Dependency3();
        var testElement = await CarnaWinUIRunner.Window.DispatcherQueue.RunAsync(() => new TestElement { Name = "TestElement" });
        var dataContext = new TestDataContexts.TestDataContext();
        When("the PointerPressed event is raised asynchronously using the EventHandlerBase", async () =>
            await WinUIController.Using(Substitute.For<IPointerRoutedEventArgsResolver>(), typeof(PointerRoutedEventArgsWrapper))
                .Apply(resolver => resolver.Pointer(Arg.Any<PointerRoutedEventArgs>()).Returns((Pointer?)null))
                .Using(Substitute.For<IPointerResolver>(), typeof(PointerWrapper))
                .Apply(resolver => resolver.PointerDeviceType(Arg.Any<Pointer>()).Returns(PointerDeviceType.Mouse))
                .EventHandlersOf(new TestWinUIControllers.AttributedParametersControllerAsync { PointerPressedHandler = pointerPressedHandler, AttributedArgumentsHandler = attributedArgumentsHandler })
                .GetBy("Element")
                .ResolveFromDI<TestWinUIControllers.IDependency1>(() => dependency1)
                .ResolveFromDI<TestWinUIControllers.IDependency2>(() => dependency2)
                .ResolveFromDI<TestWinUIControllers.IDependency3>(() => dependency3)
                .ResolveFromElement("TestElement", testElement)
                .ResolveFromDataContext(dataContext)
                .RaiseAsync(nameof(UIElement.PointerPressed))
        );
        Then("the PointerPressed event should be handled", () => pointerPressedHandler.Received(1).Invoke(PointerDeviceType.Mouse));
        Then("the attributed arguments should be injected", () => attributedArgumentsHandler.Received(1).Invoke(dependency1, dependency2, dependency3, testElement, dataContext));
    }
}