// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.Foundation;
using Windows.System;
using Charites.Windows.Mvc.Wrappers;
using Microsoft.UI.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;

namespace Charites.Windows.Mvc;

internal class TestWinUIControllers
{
    public interface ITestWinUIController
    {
        object? DataContext { get; }
        FrameworkElement? Element { get; }
        FrameworkElement? ChildElement { get; }
    }

    public class TestWinUIControllerBase
    {
        [DataContext]
        public object? DataContext { get; set; }

        [Element]
        public FrameworkElement? Element { get; set; }

        [EventHandler(ElementName = "Element", Event = nameof(UIElement.Tapped))]
        protected void OnElementTapped()
        {
            TappedAssertionHandler?.Invoke();
        }

        [EventHandler(ElementName = "Element", Event = nameof(FrameworkElement.Loading))]
        protected void OnElementLoading()
        {
            LoadingAssertionHandler?.Invoke();
        }

        [EventHandler(ElementName = "Element", Event = nameof(FrameworkElement.Loaded))]
        protected void OnElementLoaded()
        {
            LoadedAssertionHandler?.Invoke();
        }

        [EventHandler(ElementName = "Element", Event = nameof(TestElement.Changed))]
        protected void OnElementChanged()
        {
            ChangedAssertionHandler?.Invoke();
        }

        [EventHandler(ElementName = "Element", Event = nameof(FrameworkElement.DataContextChanged))]
        protected void OnElementDataContextChanged()
        {
            DataContextChangedAssertionHandler?.Invoke();
        }

        [EventHandler(ElementName = "Element", Event = nameof(UIElement.KeyDown))]
        protected void OnElementKeyDown(KeyRoutedEventArgs e)
        {
            KeyDownAssertionHandler?.Invoke(e.Key());
        }

        [EventHandler(ElementName = "Element", Event = nameof(UIElement.PointerPressed))]
        protected void OnElementPointerPressed(PointerRoutedEventArgs e)
        {
            PointerPressedHandler?.Invoke(e.Pointer().PointerDeviceType());
        }

        public Action? TappedAssertionHandler { get; set; }
        public Action? LoadingAssertionHandler { get; set; }
        public Action? LoadedAssertionHandler { get; set; }
        public Action? ChangedAssertionHandler { get; set; }
        public Action? DataContextChangedAssertionHandler { get; set; }
        public Action<VirtualKey>? KeyDownAssertionHandler { get; set; }
        public Action<PointerDeviceType>? PointerPressedHandler { get; set; }
    }

    [View(Key = "Charites.Windows.Mvc.TestDataContexts+TestDataContext")]
    public class TestWinUIController : TestWinUIControllerBase { }

    [View(Key = "Charites.Windows.Mvc.TestDataContexts+MultiTestDataContext")]
    public class MultiTestWinUIControllerA : TestWinUIControllerBase { }

    [View(Key = "Charites.Windows.Mvc.TestDataContexts+MultiTestDataContext")]
    public class MultiTestWinUIControllerB : TestWinUIControllerBase { }

    [View(Key = "Charites.Windows.Mvc.TestDataContexts+MultiTestDataContext")]
    public class MultiTestWinUIControllerC : TestWinUIControllerBase { }

    public class TestController { [DataContext] public object? DataContext { get; set; } }

    [View(Key = "AttachingTestDataContext")]
    public class TestDataContextController : TestController { }

    [View(Key = "BaseAttachingTestDataContext")]
    public class BaseTestDataContextController : TestController { }

    [View(Key = "Charites.Windows.Mvc.TestDataContexts+AttachingTestDataContextFullName")]
    public class TestDataContextFullNameController : TestController { }

    [View(Key = "Charites.Windows.Mvc.TestDataContexts+BaseAttachingTestDataContextFullName")]
    public class BaseTestDataContextFullNameController : TestController { }

    [View(Key = "GenericAttachingTestDataContext`1")]
    public class GenericTestDataContextController : TestController { }

    [View(Key = "Charites.Windows.Mvc.TestDataContexts+GenericAttachingTestDataContextFullName`1[System.String]")]
    public class GenericTestDataContextFullNameController : TestController { }

    [View(Key = "Charites.Windows.Mvc.TestDataContexts+GenericAttachingTestDataContextFullName`1")]
    public class GenericTestDataContextFullNameWithoutParametersController : TestController { }

    [View(Key = "IAttachingTestDataContext")]
    public class InterfaceImplementedTestDataContextController : TestController { }

    [View(Key = "Charites.Windows.Mvc.TestDataContexts+IAttachingTestDataContextFullName")]
    public class InterfaceImplementedTestDataContextFullNameController : TestController { }

    [View(Key = "TestElement")]
    public class KeyTestDataContextController : TestController { }

    public class TestWinUIControllerAsync
    {
        [DataContext]
        public object? DataContext { get; set; }

        [Element]
        public FrameworkElement? Element { get; set; }

        [EventHandler(ElementName = "Element", Event = nameof(UIElement.Tapped))]
        private async Task OnElementTappedAsync()
        {
            await Task.Run(() => TappedAssertionHandler?.Invoke());
        }

        [EventHandler(ElementName = "Element", Event = nameof(FrameworkElement.Loading))]
        private async Task OnElementLoadingAsync()
        {
            await Task.Run(() => LoadingAssertionHandler?.Invoke());
        }

        [EventHandler(ElementName = "Element", Event = nameof(FrameworkElement.Loaded))]
        private async Task OnElementLoadedAsync()
        {
            await Task.Run(() => LoadedAssertionHandler?.Invoke());
        }

        [EventHandler(ElementName = "Element", Event = nameof(TestElement.Changed))]
        private async Task OnElementChangedAsync()
        {
            await Task.Run(() => ChangedAssertionHandler?.Invoke());
        }

        [EventHandler(ElementName = "Element", Event = nameof(FrameworkElement.DataContextChanged))]
        private async Task OnElementDataContextChangedAsync()
        {
            await Task.Run(() => DataContextChangedAssertionHandler?.Invoke());
        }

        [EventHandler(ElementName = "Element", Event = nameof(UIElement.KeyDown))]
        private async Task OnElementKeyDownAsync(KeyRoutedEventArgs e)
        {
            await Task.Run(() => KeyDownAssertionHandler?.Invoke(e.Key()));
        }

        [EventHandler(ElementName = "Element", Event = nameof(UIElement.PointerPressed))]
        protected async Task OnElementPointerPressedAsync(PointerRoutedEventArgs e)
        {
            await Task.Run(() => PointerPressedHandler?.Invoke(e.Pointer().PointerDeviceType()));
        }

        public Action? TappedAssertionHandler { get; set; }
        public Action? LoadingAssertionHandler { get; set; }
        public Action? LoadedAssertionHandler { get; set; }
        public Action? ChangedAssertionHandler { get; set; }
        public Action? DataContextChangedAssertionHandler { get; set; }
        public Action<VirtualKey>? KeyDownAssertionHandler { get; set; }
        public Action<PointerDeviceType>? PointerPressedHandler { get; set; }
    }

    public class ExceptionTestWinUIController
    {
        [EventHandler(Event = nameof(TestElement.Changed))]
        private void OnChanged()
        {
            throw new Exception();
        }
    }

    public class AttributedParametersController
    {
        [DataContext]
        public object? DataContext { get; set; }

        [Element]
        public FrameworkElement? Element { get; set; }

        [EventHandler(ElementName = "Element", Event = nameof(UIElement.KeyDown))]
        protected void OnElementKeyDown(KeyRoutedEventArgs e, [FromDI] IDependency1 dependency1, [FromDI] IDependency2 dependency2, [FromDI] IDependency3 dependency3, [FromElement] TestElement testElement, [FromDataContext] TestDataContexts.TestDataContext dataContext)
        {
            KeyDownAssertionHandler?.Invoke(e.Key());
            AttributedArgumentsHandler?.Invoke(dependency1, dependency2, dependency3, testElement, dataContext);
        }

        [EventHandler(ElementName = "Element", Event = nameof(UIElement.PointerPressed))]
        protected void OnElementPointerPressed(PointerRoutedEventArgs e, [FromDI] IDependency1 dependency1, [FromDI] IDependency2 dependency2, [FromDI] IDependency3 dependency3, [FromElement] TestElement testElement, [FromDataContext] TestDataContexts.TestDataContext dataContext)
        {
            PointerPressedHandler?.Invoke(e.Pointer().PointerDeviceType());
            AttributedArgumentsHandler?.Invoke(dependency1, dependency2, dependency3, testElement, dataContext);
        }

        public Action<VirtualKey>? KeyDownAssertionHandler { get; set; }
        public Action<PointerDeviceType>? PointerPressedHandler { get; set; }
        public Action<IDependency1, IDependency2, IDependency3, TestElement, TestDataContexts.TestDataContext>? AttributedArgumentsHandler { get; set; }
    }

    public class AttributedParametersControllerAsync
    {
        [DataContext]
        public object? DataContext { get; set; }

        [Element]
        public FrameworkElement? Element { get; set; }

        [EventHandler(ElementName = "Element", Event = nameof(UIElement.KeyDown))]
        private async Task OnElementKeyDownAsync(KeyRoutedEventArgs e, [FromDI] IDependency1 dependency1, [FromDI] IDependency2 dependency2, [FromDI] IDependency3 dependency3, [FromElement(Name = "TestElement")] TestElement testElement, [FromDataContext] TestDataContexts.TestDataContext dataContext)
        {
            await Task.Run(() =>
            {
                KeyDownAssertionHandler?.Invoke(e.Key());
                AttributedArgumentsHandler?.Invoke(dependency1, dependency2, dependency3, testElement, dataContext);
            });
        }


        [EventHandler(ElementName = "Element", Event = nameof(UIElement.PointerPressed))]
        protected async Task OnElementPointerPressedAsync(PointerRoutedEventArgs e, [FromDI] IDependency1 dependency1, [FromDI] IDependency2 dependency2, [FromDI] IDependency3 dependency3, [FromElement(Name = "TestElement")] TestElement testElement, [FromDataContext] TestDataContexts.TestDataContext dataContext)
        {
            await Task.Run(() =>
            {
                PointerPressedHandler?.Invoke(e.Pointer().PointerDeviceType());
                AttributedArgumentsHandler?.Invoke(dependency1, dependency2, dependency3, testElement, dataContext);
            });
        }

        public Action<VirtualKey>? KeyDownAssertionHandler { get; set; }
        public Action<PointerDeviceType>? PointerPressedHandler { get; set; }
        public Action<IDependency1, IDependency2, IDependency3, TestElement, TestDataContexts.TestDataContext>? AttributedArgumentsHandler { get; set; }
    }

    public interface IDependency1 { }
    public interface IDependency2 { }
    public interface IDependency3 { }
    public class Dependency1 : IDependency1 { }
    public class Dependency2 : IDependency2 { }
    public class Dependency3 : IDependency3 { }

    public class AttributedToField
    {
        public class NoArgumentHandlerController : ITestWinUIController
        {
            [DataContext]
            private object? dataContext;

            [Element]
            private FrameworkElement? element;

            [Element]
            private FrameworkElement? childElement;

            [EventHandler(ElementName = "childElement", Event = nameof(FrameworkElement.Loaded))]
            private Action loadedHandler;

            [EventHandler(ElementName = "childElement", Event = nameof(TestElement.Changed))]
            private Action changedHandler;

            [EventHandler(ElementName = "childElement", Event = nameof(FrameworkElement.DataContextChanged))]
            private Action dataContextChangedHandler;

            public NoArgumentHandlerController(Action assertionHandler)
            {
                loadedHandler = assertionHandler;
                changedHandler = assertionHandler;
                dataContextChangedHandler = assertionHandler;
            }

            public object? DataContext => dataContext;
            public FrameworkElement? Element => element;
            public FrameworkElement? ChildElement => childElement;
        }

        public class OneArgumentHandlerController : ITestWinUIController
        {
            [DataContext]
            private object? dataContext;

            [Element]
            private FrameworkElement? element;

            [Element]
            private FrameworkElement? childElement;

            [EventHandler(ElementName = "childElement", Event = nameof(FrameworkElement.Loaded))]
            private Action<RoutedEventArgs> loadedHandler;

            [EventHandler(ElementName = "childElement", Event = nameof(TestElement.Changed))]
            private Action<RoutedEventArgs> changedHandler;

            [EventHandler(ElementName = "childElement", Event = nameof(FrameworkElement.DataContextChanged))]
            private Action<DataContextChangedEventArgs> dataContextChangedHandler;

            public OneArgumentHandlerController(Action<object> assertionHandler)
            {
                loadedHandler = assertionHandler;
                changedHandler = assertionHandler;
                dataContextChangedHandler = assertionHandler;
            }

            public object? DataContext => dataContext;
            public FrameworkElement? Element => element;
            public FrameworkElement? ChildElement => childElement;
        }

        public class TwoArgumentsEventHandlerController : ITestWinUIController
        {
            [DataContext]
            private object? dataContext;

            [Element]
            private FrameworkElement? element;

            [Element]
            private FrameworkElement? childElement;

            [EventHandler(ElementName = "childElement", Event = nameof(FrameworkElement.Loaded))]
            private RoutedEventHandler loadedHandler;

            [EventHandler(ElementName = "childElement", Event = nameof(TestElement.Changed))]
            private RoutedEventHandler changedHandler;

            [EventHandler(ElementName = "childElement", Event = nameof(FrameworkElement.DataContextChanged))]
            private TypedEventHandler<FrameworkElement?, DataContextChangedEventArgs> dataContextChangedHandler;

            public TwoArgumentsEventHandlerController(Action<object?, object> assertionHandler)
            {
                loadedHandler = (s, e) => assertionHandler(s, e);
                changedHandler = (s, e) => assertionHandler(s, e);
                dataContextChangedHandler = (s, e) => assertionHandler(s, e);
            }

            public object? DataContext => dataContext;
            public FrameworkElement? Element => element;
            public FrameworkElement? ChildElement => childElement;
        }
    }

    public class AttributedToProperty
    {
        public class NoArgumentHandlerController : ITestWinUIController
        {
            [DataContext]
            public object? DataContext { get; private set; }

            [Element(Name = "element")]
            public FrameworkElement? Element { get; private set; }

            [Element(Name = "childElement")]
            public FrameworkElement? ChildElement { get; private set; }

            [EventHandler(ElementName = "childElement", Event = nameof(FrameworkElement.Loaded))]
            private Action LoadedHandler { get; set; }

            [EventHandler(ElementName = "childElement", Event = nameof(TestElement.Changed))]
            private Action ChangedHandler { get; set; }

            [EventHandler(ElementName = "childElement", Event = nameof(FrameworkElement.DataContextChanged))]
            private Action DataContextChangedHandler { get; set; }

            public NoArgumentHandlerController(Action assertionHandler)
            {
                LoadedHandler = assertionHandler;
                ChangedHandler = assertionHandler;
                DataContextChangedHandler = assertionHandler;
            }
        }

        public class OneArgumentHandlerController : ITestWinUIController
        {
            [DataContext]
            public object? DataContext { get; private set; }

            [Element(Name = "element")]
            public FrameworkElement? Element { get; private set; }

            [Element(Name = "childElement")]
            public FrameworkElement? ChildElement { get; private set; }

            [EventHandler(ElementName = "childElement", Event = nameof(FrameworkElement.Loaded))]
            private Action<RoutedEventArgs> LoadedHandler { get; set; }

            [EventHandler(ElementName = "childElement", Event = nameof(TestElement.Changed))]
            private Action<RoutedEventArgs> ChangedHandler { get; set; }

            [EventHandler(ElementName = "childElement", Event = nameof(FrameworkElement.DataContextChanged))]
            private Action<DataContextChangedEventArgs> DataContextChangedHandler { get; set; }

            public OneArgumentHandlerController(Action<object> assertionHandler)
            {
                LoadedHandler = assertionHandler;
                ChangedHandler = assertionHandler;
                DataContextChangedHandler = assertionHandler;
            }
        }

        public class TwoArgumentsEventHandlerController : ITestWinUIController
        {
            [DataContext]
            public object? DataContext { get; private set; }

            [Element(Name = "element")]
            public FrameworkElement? Element { get; private set; }

            [Element(Name = "childElement")]
            public FrameworkElement? ChildElement { get; private set; }

            [EventHandler(ElementName = "childElement", Event = nameof(FrameworkElement.Loaded))]
            private RoutedEventHandler LoadedHandler { get; set; }

            [EventHandler(ElementName = "childElement", Event = nameof(TestElement.Changed))]
            private RoutedEventHandler ChangedHandler { get; set; }

            [EventHandler(ElementName = "childElement", Event = nameof(FrameworkElement.DataContextChanged))]
            private TypedEventHandler<FrameworkElement?, DataContextChangedEventArgs> DataContextChangedHandler { get; set; }

            public TwoArgumentsEventHandlerController(Action<object?, object> assertionHandler)
            {
                LoadedHandler = (s, e) => assertionHandler(s, e);
                ChangedHandler = (s, e) => assertionHandler(s, e);
                DataContextChangedHandler = (s, e) => assertionHandler(s, e);
            }
        }
    }

    public class AttributedToMethod
    {
        public class NoArgumentHandlerController : ITestWinUIController
        {
            [DataContext]
            public void SetDataContext(object? dataContext) => DataContext = dataContext;
            public object? DataContext { get; private set; }

            [Element(Name = "element")]
            public void SetElement(FrameworkElement? element) => Element = element;
            public FrameworkElement? Element { get; private set; }

            [Element(Name = "childElement")]
            public void SetChildElement(FrameworkElement? childElement) => ChildElement = childElement;
            public FrameworkElement? ChildElement { get; private set; }

            [EventHandler(ElementName = "childElement", Event = nameof(FrameworkElement.Loaded))]
            public void OnChildElementLoaded()
            {
                loadedHandler();
            }
            private readonly Action loadedHandler;

            [EventHandler(ElementName = "childElement", Event = nameof(TestElement.Changed))]
            public void OnChildElementChanged()
            {
                changedHandler();
            }
            private readonly Action changedHandler;

            [EventHandler(ElementName = "childElement", Event = nameof(FrameworkElement.DataContextChanged))]
            public void OnChildElementDataContextChanged()
            {
                dataContextChangedHandler();
            }
            private readonly Action dataContextChangedHandler;

            public NoArgumentHandlerController(Action assertionHandler)
            {
                loadedHandler = assertionHandler;
                changedHandler = assertionHandler;
                dataContextChangedHandler = assertionHandler;
            }
        }

        public class OneArgumentHandlerController : ITestWinUIController
        {
            [DataContext]
            public void SetDataContext(object? dataContext) => DataContext = dataContext;
            public object? DataContext { get; private set; }

            [Element(Name = "element")]
            public void SetElement(FrameworkElement? element) => Element = element;
            public FrameworkElement? Element { get; private set; }

            [Element(Name = "childElement")]
            public void SetChildElement(FrameworkElement? childElement) => ChildElement = childElement;
            public FrameworkElement? ChildElement { get; private set; }

            [EventHandler(ElementName = "childElement", Event = nameof(FrameworkElement.Loaded))]
            public void OnChildElementLoaded(RoutedEventArgs e)
            {
                loadedHandler(e);
            }
            private readonly Action<RoutedEventArgs> loadedHandler;

            [EventHandler(ElementName = "childElement", Event = nameof(TestElement.Changed))]
            public void OnChildElementChanged(RoutedEventArgs e)
            {
                changedHandler(e);
            }
            private readonly Action<RoutedEventArgs> changedHandler;

            [EventHandler(ElementName = "childElement", Event = nameof(FrameworkElement.DataContextChanged))]
            public void OnChildElementDataContextChanged(DataContextChangedEventArgs e)
            {
                dataContextChangedHandler(e);
            }
            private readonly Action<DataContextChangedEventArgs> dataContextChangedHandler;

            public OneArgumentHandlerController(Action<object> assertionHandler)
            {
                loadedHandler = assertionHandler;
                changedHandler = assertionHandler;
                dataContextChangedHandler = assertionHandler;
            }
        }

        public class TwoArgumentsEventHandlerController : ITestWinUIController
        {
            [DataContext]
            public void SetDataContext(object? dataContext) => DataContext = dataContext;
            public object? DataContext { get; private set; }

            [Element(Name = "element")]
            public void SetElement(FrameworkElement? element) => Element = element;
            public FrameworkElement? Element { get; private set; }

            [Element(Name = "childElement")]
            public void SetChildElement(FrameworkElement? childElement) => ChildElement = childElement;
            public FrameworkElement? ChildElement { get; private set; }

            [EventHandler(ElementName = "childElement", Event = nameof(FrameworkElement.Loaded))]
            public void OnChildElementLoaded(object sender, RoutedEventArgs e)
            {
                loadedHandler(sender, e);
            }
            private readonly RoutedEventHandler loadedHandler;

            [EventHandler(ElementName = "childElement", Event = nameof(TestElement.Changed))]
            public void OnChildElementChanged(object sender, RoutedEventArgs e)
            {
                changedHandler(sender, e);
            }
            private readonly RoutedEventHandler changedHandler;

            [EventHandler(ElementName = "childElement", Event = nameof(FrameworkElement.DataContextChanged))]
            public void OnChildElementDataContextChanged(FrameworkElement? sender, DataContextChangedEventArgs e)
            {
                dataContextChangedHandler(sender, e);
            }
            private readonly TypedEventHandler<FrameworkElement?, DataContextChangedEventArgs> dataContextChangedHandler;

            public TwoArgumentsEventHandlerController(Action<object?, object> assertionHandler)
            {
                loadedHandler = (s, e) => assertionHandler(s, e);
                changedHandler = (s, e) => assertionHandler(s, e);
                dataContextChangedHandler = (s, e) => assertionHandler(s, e);
            }
        }
    }

    public class AttributedToMethodUsingNamingConvention
    {
        public class NoArgumentHandlerController : ITestWinUIController
        {
            public void SetDataContext(object? dataContext) => DataContext = dataContext;
            public object? DataContext { get; private set; }

            [Element(Name = "element")]
            public void SetElement(FrameworkElement? element) => Element = element;
            public FrameworkElement? Element { get; private set; }

            [Element(Name = "childElement")]
            public void SetChildElement(FrameworkElement? childElement) => ChildElement = childElement;
            public FrameworkElement? ChildElement { get; private set; }

            public void childElement_Loaded()
            {
                loadedHandler();
            }
            private readonly Action loadedHandler;

            public void childElement_Changed()
            {
                changedHandler();
            }
            private readonly Action changedHandler;

            public void childElement_DataContextChanged()
            {
                dataContextChangedHandler();
            }
            private readonly Action dataContextChangedHandler;

            public NoArgumentHandlerController(Action assertionHandler)
            {
                loadedHandler = assertionHandler;
                changedHandler = assertionHandler;
                dataContextChangedHandler = assertionHandler;
            }
        }

        public class OneArgumentHandlerController : ITestWinUIController
        {
            public void SetDataContext(object? dataContext) => DataContext = dataContext;
            public object? DataContext { get; private set; }

            [Element(Name = "element")]
            public void SetElement(FrameworkElement? element) => Element = element;
            public FrameworkElement? Element { get; private set; }

            [Element(Name = "childElement")]
            public void SetChildElement(FrameworkElement? childElement) => ChildElement = childElement;
            public FrameworkElement? ChildElement { get; private set; }

            public void childElement_Loaded(RoutedEventArgs e)
            {
                loadedHandler(e);
            }
            private readonly Action<RoutedEventArgs> loadedHandler;

            public void childElement_Changed(RoutedEventArgs e)
            {
                changedHandler(e);
            }
            private readonly Action<RoutedEventArgs> changedHandler;

            public void childElement_DataContextChanged(DataContextChangedEventArgs e)
            {
                dataContextChangedHandler(e);
            }
            private readonly Action<DataContextChangedEventArgs> dataContextChangedHandler;

            public OneArgumentHandlerController(Action<object> assertionHandler)
            {
                loadedHandler = assertionHandler;
                changedHandler = assertionHandler;
                dataContextChangedHandler = assertionHandler;
            }
        }

        public class TwoArgumentsEventHandlerController : ITestWinUIController
        {
            public void SetDataContext(object? dataContext) => DataContext = dataContext;
            public object? DataContext { get; private set; }

            [Element(Name = "element")]
            public void SetElement(FrameworkElement? element) => Element = element;
            public FrameworkElement? Element { get; private set; }

            [Element(Name = "childElement")]
            public void SetChildElement(FrameworkElement? childElement) => ChildElement = childElement;
            public FrameworkElement? ChildElement { get; private set; }

            public void childElement_Loaded(object? sender, RoutedEventArgs e)
            {
                loadedHandler(sender, e);
            }
            private readonly RoutedEventHandler loadedHandler;

            public void childElement_Changed(object? sender, RoutedEventArgs e)
            {
                changedHandler(sender, e);
            }
            private readonly RoutedEventHandler changedHandler;

            public void childElement_DataContextChanged(FrameworkElement? sender, DataContextChangedEventArgs e)
            {
                dataContextChangedHandler(sender, e);
            }
            private readonly TypedEventHandler<FrameworkElement?, DataContextChangedEventArgs> dataContextChangedHandler;

            public TwoArgumentsEventHandlerController(Action<object?, object> assertionHandler)
            {
                loadedHandler = (s, e) => assertionHandler(s, e);
                changedHandler = (s, e) => assertionHandler(s, e);
                dataContextChangedHandler = (s, e) => assertionHandler(s, e);
            }
        }
    }

    public class AttributedToAsyncMethodUsingNamingConvention
    {
        public class NoArgumentHandlerController : ITestWinUIController
        {
            public void SetDataContext(object? dataContext) => DataContext = dataContext;
            public object? DataContext { get; private set; }

            [Element(Name = "element")]
            public void SetElement(FrameworkElement? element) => Element = element;
            public FrameworkElement? Element { get; private set; }

            [Element(Name = "childElement")]
            public void SetChildElement(FrameworkElement? childElement) => ChildElement = childElement;
            public FrameworkElement? ChildElement { get; private set; }

            public Task childElement_LoadedAsync()
            {
                loadedHandler();
                return Task.CompletedTask;
            }
            private readonly Action loadedHandler;

            public Task childElement_ChangedAsync()
            {
                changedHandler();
                return Task.CompletedTask;
            }
            private readonly Action changedHandler;

            public Task childElement_DataContextChangedAsync()
            {
                dataContextChangedHandler();
                return Task.CompletedTask;
            }
            private readonly Action dataContextChangedHandler;

            public NoArgumentHandlerController(Action assertionHandler)
            {
                loadedHandler = assertionHandler;
                changedHandler = assertionHandler;
                dataContextChangedHandler = assertionHandler;
            }
        }

        public class OneArgumentHandlerController : ITestWinUIController
        {
            public void SetDataContext(object? dataContext) => DataContext = dataContext;
            public object? DataContext { get; private set; }

            [Element(Name = "element")]
            public void SetElement(FrameworkElement? element) => Element = element;
            public FrameworkElement? Element { get; private set; }

            [Element(Name = "childElement")]
            public void SetChildElement(FrameworkElement? childElement) => ChildElement = childElement;
            public FrameworkElement? ChildElement { get; private set; }

            public Task childElement_LoadedAsync(RoutedEventArgs e)
            {
                loadedHandler(e);
                return Task.CompletedTask;
            }
            private readonly Action<RoutedEventArgs> loadedHandler;

            public Task childElement_ChangedAsync(RoutedEventArgs e)
            {
                changedHandler(e);
                return Task.CompletedTask;
            }
            private readonly Action<RoutedEventArgs> changedHandler;

            public Task childElement_DataContextChangedAsync(DataContextChangedEventArgs e)
            {
                dataContextChangedHandler(e);
                return Task.CompletedTask;
            }
            private readonly Action<DataContextChangedEventArgs> dataContextChangedHandler;

            public OneArgumentHandlerController(Action<object> assertionHandler)
            {
                loadedHandler = assertionHandler;
                changedHandler = assertionHandler;
                dataContextChangedHandler = assertionHandler;
            }
        }

        public class TwoArgumentsEventHandlerController : ITestWinUIController
        {
            public void SetDataContext(object? dataContext) => DataContext = dataContext;
            public object? DataContext { get; private set; }

            [Element(Name = "element")]
            public void SetElement(FrameworkElement? element) => Element = element;
            public FrameworkElement? Element { get; private set; }

            [Element(Name = "childElement")]
            public void SetChildElement(FrameworkElement? childElement) => ChildElement = childElement;
            public FrameworkElement? ChildElement { get; private set; }

            public Task childElement_LoadedAsync(object? sender, RoutedEventArgs e)
            {
                loadedHandler(sender, e);
                return Task.CompletedTask;
            }
            private readonly RoutedEventHandler loadedHandler;

            public Task childElement_ChangedAsync(object? sender, RoutedEventArgs e)
            {
                changedHandler(sender, e);
                return Task.CompletedTask;
            }
            private readonly RoutedEventHandler changedHandler;

            public Task childElement_DataContextChangedAsync(FrameworkElement? sender, DataContextChangedEventArgs e)
            {
                dataContextChangedHandler(sender, e);
                return Task.CompletedTask;
            }
            private readonly TypedEventHandler<FrameworkElement?, DataContextChangedEventArgs> dataContextChangedHandler;

            public TwoArgumentsEventHandlerController(Action<object?, object> assertionHandler)
            {
                loadedHandler = (s, e) => assertionHandler(s, e);
                changedHandler = (s, e) => assertionHandler(s, e);
                dataContextChangedHandler = (s, e) => assertionHandler(s, e);
            }
        }
    }
}