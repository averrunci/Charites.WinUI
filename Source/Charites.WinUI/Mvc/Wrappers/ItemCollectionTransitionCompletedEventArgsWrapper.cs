// Copyright (C) 2023 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="ItemCollectionTransitionCompletedEventArgs"/>
/// resolved by <see cref="IItemCollectionTransitionCompletedEventArgsResolver"/>.
/// </summary>
public static class ItemCollectionTransitionCompletedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IItemCollectionTransitionCompletedEventArgsResolver"/>
    /// that resolves data of the <see cref="ItemCollectionTransitionCompletedEventArgs"/>.
    /// </summary>
    public static IItemCollectionTransitionCompletedEventArgsResolver Resolver { get; set; } = new DefaultItemCollectionTransitionCompletedEventArgsResolver();

    /// <summary>
    /// Gets an element.
    /// </summary>
    /// <param name="e">The requested <see cref="ItemCollectionTransitionCompletedEventArgs"/>.</param>
    /// <returns>An element.</returns>
    public static UIElement? Element(this ItemCollectionTransitionCompletedEventArgs e) => Resolver.Element(e);

    /// <summary>
    /// Gets a transition.
    /// </summary>
    /// <param name="e">The requested <see cref="ItemCollectionTransitionCompletedEventArgs"/>.</param>
    /// <returns>A transition.</returns>
    public static ItemCollectionTransition? Transition(this ItemCollectionTransitionCompletedEventArgs e) => Resolver.Transition(e);

    private sealed class DefaultItemCollectionTransitionCompletedEventArgsResolver : IItemCollectionTransitionCompletedEventArgsResolver
    {
        UIElement? IItemCollectionTransitionCompletedEventArgsResolver.Element(ItemCollectionTransitionCompletedEventArgs e) => e.Element;
        ItemCollectionTransition? IItemCollectionTransitionCompletedEventArgsResolver.Transition(ItemCollectionTransitionCompletedEventArgs e) => e.Transition;
    }
}

/// <summary>
/// Resolves data of the <see cref="ItemCollectionTransitionCompletedEventArgs"/>.
/// </summary>
public interface IItemCollectionTransitionCompletedEventArgsResolver
{
    /// <summary>
    /// Gets an element.
    /// </summary>
    /// <param name="e">The requested <see cref="ItemCollectionTransitionCompletedEventArgs"/>.</param>
    /// <returns>An element.</returns>
    UIElement? Element(ItemCollectionTransitionCompletedEventArgs e);

    /// <summary>
    /// Gets a transition.
    /// </summary>
    /// <param name="e">The requested <see cref="ItemCollectionTransitionCompletedEventArgs"/>.</param>
    /// <returns>A transition.</returns>
    ItemCollectionTransition? Transition(ItemCollectionTransitionCompletedEventArgs e);
}