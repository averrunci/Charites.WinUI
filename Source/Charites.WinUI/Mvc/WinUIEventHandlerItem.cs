﻿// Copyright (C) 2022-2025 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using System.Reflection;
using Microsoft.UI.Xaml;

namespace Charites.Windows.Mvc;

/// <summary>
/// Represents an item of an event handler.
/// </summary>
public sealed class WinUIEventHandlerItem : EventHandlerItem<FrameworkElement>
{
    private readonly RoutedEvent? routedEvent;
    private readonly EventInfo? eventInfo;
    
    private bool isEventHandlerAdded;

    /// <summary>
    /// Initializes a new instance of the <see cref="WinUIEventHandlerItem"/> class
    /// with the specified element name, element, event name, routed event, event information,
    /// event handler, and a value that indicates whether to register the handler such that
    /// it is invoked even when the event is marked handled in its event data.
    /// </summary>
    /// <param name="elementName">The name of the element that raises the event.</param>
    /// <param name="element">The element that raises the event.</param>
    /// <param name="eventName">The name of the event.</param>
    /// <param name="routedEvent">The routed event that is raised.</param>
    /// <param name="eventInfo">The information of the event that is raised</param>
    /// <param name="handler">The handler of the event.</param>
    /// <param name="handledEventsToo">
    /// <c>true</c> to register the handler such that it is invoked even when the
    /// event is marked handled in its event data; <c>false</c> to register the
    /// handler with the default condition that it will not be invoked if the event
    /// is already marked handled.
    /// </param>
    /// <param name="parameterResolver">The resolver to resolve parameters.</param>
    public WinUIEventHandlerItem(string elementName, FrameworkElement? element, string eventName, RoutedEvent? routedEvent, EventInfo? eventInfo, Delegate? handler, bool handledEventsToo, IEnumerable<IEventHandlerParameterResolver> parameterResolver) : base(elementName, element, eventName, handler, handledEventsToo, parameterResolver)
    {
        this.routedEvent = routedEvent;
        this.eventInfo = eventInfo;
    }

    /// <summary>
    /// Adds the specified event handler to the specified element.
    /// </summary>
    /// <param name="element">The element to which the specified event handler is added.</param>
    /// <param name="handler">The event handler to add.</param>
    /// <param name="handledEventsToo">
    /// <c>true</c> to register the handler such that it is invoked even when the
    /// event is marked handled in its event data; <c>false</c> to register the
    /// handler with the default condition that it will not be invoked if the event
    /// is already marked handled.
    /// </param>
    protected override void AddEventHandler(FrameworkElement element, Delegate handler, bool handledEventsToo)
    {
        if (isEventHandlerAdded) return;

        if (routedEvent is not null)
        {
            element.AddHandler(routedEvent, handler, handledEventsToo);
        }
        else
        {
            eventInfo?.AddMethod?.Invoke(element, [handler]);
        }

        isEventHandlerAdded = true;
    }

    /// <summary>
    /// Removes the specified event handler from the specified element.
    /// </summary>
    /// <param name="element">The element from which the specified event handler is removed.</param>
    /// <param name="handler">The event handler to remove.</param>
    protected override void RemoveEventHandler(FrameworkElement element, Delegate handler)
    {
        if (!isEventHandlerAdded) return;

        if (routedEvent is not null)
        {
            element.RemoveHandler(routedEvent, handler);
        }
        else
        {
            eventInfo?.RemoveMethod?.Invoke(element, [handler]);
        }

        isEventHandlerAdded = false;
    }
}