// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="ItemsRepeaterElementIndexChangedEventArgs"/>
/// resolved by <see cref="IItemsRepeaterElementIndexChangedEventArgsResolver"/>.
/// </summary>
public static class ItemsRepeaterElementIndexChangedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IItemsRepeaterElementIndexChangedEventArgsResolver"/>
    /// that resolves data of the <see cref="ItemsRepeaterElementIndexChangedEventArgs"/>.
    /// </summary>
    public static IItemsRepeaterElementIndexChangedEventArgsResolver Resolver { get; set; } = new DefaultItemsRepeaterElementIndexChangedEventArgsResolver();

    /// <summary>
    /// Get the element for which the index changed.
    /// </summary>
    /// <param name="e">The requested <see cref="ItemsRepeaterElementIndexChangedEventArgs"/>.</param>
    /// <returns>The element for which the index changed.</returns>
    public static UIElement Element(this ItemsRepeaterElementIndexChangedEventArgs e) => Resolver.Element(e);

    /// <summary>
    /// Gets the index of the element after the change.
    /// </summary>
    /// <param name="e">The requested <see cref="ItemsRepeaterElementIndexChangedEventArgs"/>.</param>
    /// <returns>The index of the element after the change.</returns>
    public static int NewIndex(this ItemsRepeaterElementIndexChangedEventArgs e) => Resolver.NewIndex(e);

    /// <summary>
    /// Gets the index of the element before the change.
    /// </summary>
    /// <param name="e">The requested <see cref="ItemsRepeaterElementIndexChangedEventArgs"/>.</param>
    /// <returns>The index of the element before the change.</returns>
    public static int OldIndex(this ItemsRepeaterElementIndexChangedEventArgs e) => Resolver.OldIndex(e);

    private sealed class DefaultItemsRepeaterElementIndexChangedEventArgsResolver : IItemsRepeaterElementIndexChangedEventArgsResolver
    {
        UIElement IItemsRepeaterElementIndexChangedEventArgsResolver.Element(ItemsRepeaterElementIndexChangedEventArgs e) => e.Element;
        int IItemsRepeaterElementIndexChangedEventArgsResolver.NewIndex(ItemsRepeaterElementIndexChangedEventArgs e) => e.NewIndex;
        int IItemsRepeaterElementIndexChangedEventArgsResolver.OldIndex(ItemsRepeaterElementIndexChangedEventArgs e) => e.OldIndex;
    }
}

/// <summary>
/// Resolves data of the <see cref="ItemsRepeaterElementIndexChangedEventArgs"/>.
/// </summary>
public interface IItemsRepeaterElementIndexChangedEventArgsResolver
{
    /// <summary>
    /// Get the element for which the index changed.
    /// </summary>
    /// <param name="e">The requested <see cref="ItemsRepeaterElementIndexChangedEventArgs"/>.</param>
    /// <returns>The element for which the index changed.</returns>
    UIElement Element(ItemsRepeaterElementIndexChangedEventArgs e);

    /// <summary>
    /// Gets the index of the element after the change.
    /// </summary>
    /// <param name="e">The requested <see cref="ItemsRepeaterElementIndexChangedEventArgs"/>.</param>
    /// <returns>The index of the element after the change.</returns>
    int NewIndex(ItemsRepeaterElementIndexChangedEventArgs e);

    /// <summary>
    /// Gets the index of the element before the change.
    /// </summary>
    /// <param name="e">The requested <see cref="ItemsRepeaterElementIndexChangedEventArgs"/>.</param>
    /// <returns>The index of the element before the change.</returns>
    int OldIndex(ItemsRepeaterElementIndexChangedEventArgs e);
}