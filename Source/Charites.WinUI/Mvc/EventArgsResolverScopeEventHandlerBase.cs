// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml;

namespace Charites.Windows.Mvc;

/// <summary>
/// Represents the base of event handler that are invoked in the event args resolver scope.
/// </summary>
public sealed class EventArgsResolverScopeEventHandlerBase
{
    private readonly IEnumerable<IEventArgsResolver> eventArgsResolvers;
    private readonly EventHandlerBase<FrameworkElement, WinUIEventHandlerItem> eventHandlerBase;

    /// <summary>
    /// Initializes a new instance of the <see cref="EventArgsResolverScopeEventHandlerBase"/> class
    /// with the specified event args resolvers and event handlers.
    /// </summary>
    /// <param name="eventArgsResolvers">The collection of the event args resolver.</param>
    /// <param name="eventHandlerBase">The event handlers that handle an event.</param>
    public EventArgsResolverScopeEventHandlerBase(IEnumerable<IEventArgsResolver> eventArgsResolvers, EventHandlerBase<FrameworkElement, WinUIEventHandlerItem> eventHandlerBase)
    {
        this.eventArgsResolvers = eventArgsResolvers;
        this.eventHandlerBase = eventHandlerBase;
    }

    /// <summary>
    /// Gets an executor that raises an event for the specified name of the element.
    /// </summary>
    /// <param name="elementName">The name of the element that has event handlers.</param>
    /// <returns><see cref="Executor"/> that raises an event.</returns>
    public Executor GetBy(string? elementName) => new(eventArgsResolvers, eventHandlerBase.GetBy(elementName));

    /// <summary>
    /// Provides an event execution.
    /// </summary>
    public sealed class Executor
    {
        private readonly IEnumerable<IEventArgsResolver> eventArgsResolvers;
        private readonly EventHandlerBase<FrameworkElement, WinUIEventHandlerItem>.Executor executor;

        /// <summary>
        /// Initializes a new instance of the <see cref="Executor"/> class
        /// with the specified event args resolvers and executor to raise an event.
        /// </summary>
        /// <param name="eventArgsResolvers">The collection of the event args resolver.</param>
        /// <param name="executor">The executor to raise an event.</param>
        public Executor(IEnumerable<IEventArgsResolver> eventArgsResolvers, EventHandlerBase<FrameworkElement, WinUIEventHandlerItem>.Executor executor)
        {
            this.eventArgsResolvers = eventArgsResolvers;
            this.executor = executor;
        }

        /// <summary>Sets the object where the event handler is attached.</summary>
        /// <param name="sender">The object where the event handler is attached.</param>
        /// <returns>The instance of the <see cref="Executor" /> class.</returns>
        public Executor From(object? sender)
        {
            executor.From(sender);
            return this;
        }

        /// <summary>Sets the event data.</summary>
        /// <param name="args">The event data.</param>
        /// <returns>The instance of the <see cref="Executor" /> class.</returns>
        public Executor With(object? args)
        {
            executor.With(args);
            return this;
        }

        /// <summary>
        /// Resolve a parameter of the specified type using the specified resolver.
        /// </summary>
        /// <typeparam name="TParameter">The type of the parameter to inject to.</typeparam>
        /// <param name="resolver">The function to resolve the parameter of the specified type.</param>
        /// <returns>The instance of the <see cref="Executor" /> class.</returns>
        public Executor Resolve<TParameter>(Func<object?> resolver)
        {
            executor.Resolve<TParameter>(resolver);
            return this;
        }

        /// <summary>Raises the event of the specified name.</summary>
        /// <param name="eventName">The name of the event to raise.</param>
        public void Raise(string eventName)
        {
            using var scope = new EventArgsResolverScope(eventArgsResolvers);

            scope.ApplyResolver();
            executor.Raise(eventName);
        }

        /// <summary>
        /// Raises the event of the specified name asynchronously.
        /// </summary>
        /// <param name="eventName">The name of the event to raise.</param>
        /// <returns>A task that represents the asynchronous raise operation.</returns>
        public async Task RaiseAsync(string eventName)
        {
            using var scope = new EventArgsResolverScope(eventArgsResolvers);

            scope.ApplyResolver();
            await executor.RaiseAsync(eventName);
        }
    }
}