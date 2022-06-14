// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using System.Reflection;
using Microsoft.UI.Xaml;

namespace Charites.Windows.Mvc;

internal sealed class WinUIEventHandlerExtension : EventHandlerExtension<FrameworkElement, WinUIEventHandlerItem>, IWinUIControllerExtension
{
    private const BindingFlags RoutedEventBindingFlags = BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy;

    private static DependencyProperty EventHandlerBasesProperty { get; } = DependencyProperty.RegisterAttached(
        "ShadowEventHandlerBases", typeof(IDictionary<object, EventHandlerBase<FrameworkElement, WinUIEventHandlerItem>>), typeof(WinUIEventHandlerExtension), new PropertyMetadata(null)
    );

    public WinUIEventHandlerExtension()
    {
        Add<WinUIEventHandlerParameterFromDIResolver>();
        Add<WinUIEventHandlerParameterFromElementResolver>();
        Add<WinUIEventHandlerParameterFromDataContextResolver>();
    }

    protected override IDictionary<object, EventHandlerBase<FrameworkElement, WinUIEventHandlerItem>> EnsureEventHandlerBases(FrameworkElement? element)
    {
        if (element is null) return new Dictionary<object, EventHandlerBase<FrameworkElement, WinUIEventHandlerItem>>();

        if (element.GetValue(EventHandlerBasesProperty) is IDictionary<object, EventHandlerBase<FrameworkElement, WinUIEventHandlerItem>> eventHandlerBases) return eventHandlerBases;

        eventHandlerBases = new Dictionary<object, EventHandlerBase<FrameworkElement, WinUIEventHandlerItem>>();
        element.SetValue(EventHandlerBasesProperty, eventHandlerBases);
        return eventHandlerBases;
    }

    protected override void AddEventHandler(FrameworkElement? element, EventHandlerAttribute eventHandlerAttribute, Func<Type?, Delegate?> handlerCreator, EventHandlerBase<FrameworkElement, WinUIEventHandlerItem> eventHandlers)
    {
        var targetElement = element.FindElement<FrameworkElement>(eventHandlerAttribute.ElementName);
        var routedEvent = RetrieveRoutedEvent(targetElement, eventHandlerAttribute.Event);
        var eventInfo = RetrieveEventInfo(targetElement, eventHandlerAttribute.Event);
        eventHandlers.Add(new WinUIEventHandlerItem(
            eventHandlerAttribute.ElementName, targetElement,
            eventHandlerAttribute.Event, routedEvent, eventInfo,
            handlerCreator(eventInfo?.EventHandlerType), eventHandlerAttribute.HandledEventsToo,
            CreateParameterResolver(element)
        ));
    }

    protected override EventHandlerAction CreateEventHandlerAction(MethodInfo method, object? target, FrameworkElement? element)
        => new WinUIEventHandlerAction(method, target, CreateParameterDependencyResolver(CreateParameterResolver(element)));

    protected override void OnEventHandlerAdded(EventHandlerBase<FrameworkElement, WinUIEventHandlerItem> eventHandlers, FrameworkElement element)
    {
        base.OnEventHandlerAdded(eventHandlers, element);

        eventHandlers.GetBy(element.Name).From(element).With(new RoutedEventArgs()).Raise(nameof(FrameworkElement.Loaded));
    }

    private RoutedEvent? RetrieveRoutedEvent(FrameworkElement? element, string name)
    {
        if (element is null || string.IsNullOrWhiteSpace(name)) return null;

        return element.GetType()
            .GetProperties(RoutedEventBindingFlags)
            .Where(property => property.Name == EnsureRoutedEventName(name))
            .Select(property => property.GetValue(null))
            .FirstOrDefault() as RoutedEvent;
    }

    private string EnsureRoutedEventName(string routedEventName)
        => routedEventName.EndsWith("Event") ? routedEventName : $"{routedEventName}Event";

    private EventInfo? RetrieveEventInfo(FrameworkElement? element, string name)
        => element?.GetType()
            .GetEvents()
            .FirstOrDefault(e => e.Name == name);
}