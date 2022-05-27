// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="ItemsRepeaterElementPreparedEventArgs"/>
/// resolved by <see cref="IItemsRepeaterElementPreparedEventArgsResolver"/>.
/// </summary>
public static class ItemsRepeaterElementPreparedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IItemsRepeaterElementPreparedEventArgsResolver"/>
    /// that resolves data of the <see cref="ItemsRepeaterElementPreparedEventArgs"/>.
    /// </summary>
    public static IItemsRepeaterElementPreparedEventArgsResolver Resolver { get; set; } = new DefaultItemsRepeaterElementPreparedEventArgsResolver();

    /// <summary>
    /// Gets the prepared element.
    /// </summary>
    /// <param name="e">The requested <see cref="ItemsRepeaterElementPreparedEventArgs"/>.</param>
    /// <returns>The prepared element.</returns>
    public static UIElement Element(this ItemsRepeaterElementPreparedEventArgs e) => Resolver.Element(e);

    /// <summary>
    /// Gets the index of the item the element was prepared for.
    /// </summary>
    /// <param name="e">The requested <see cref="ItemsRepeaterElementPreparedEventArgs"/>.</param>
    /// <returns>The index of the item the element was prepared for.</returns>
    public static int Index(this ItemsRepeaterElementPreparedEventArgs e) => Resolver.Index(e);

    private sealed class DefaultItemsRepeaterElementPreparedEventArgsResolver : IItemsRepeaterElementPreparedEventArgsResolver
    {
        UIElement IItemsRepeaterElementPreparedEventArgsResolver.Element(ItemsRepeaterElementPreparedEventArgs e) => e.Element;
        int IItemsRepeaterElementPreparedEventArgsResolver.Index(ItemsRepeaterElementPreparedEventArgs e) => e.Index;
    }
}

/// <summary>
/// Resolves data of the <see cref="ItemsRepeaterElementPreparedEventArgs"/>.
/// </summary>
public interface IItemsRepeaterElementPreparedEventArgsResolver
{
    /// <summary>
    /// Gets the prepared element.
    /// </summary>
    /// <param name="e">The requested <see cref="ItemsRepeaterElementPreparedEventArgs"/>.</param>
    /// <returns>The prepared element.</returns>
    UIElement Element(ItemsRepeaterElementPreparedEventArgs e);

    /// <summary>
    /// Gets the index of the item the element was prepared for.
    /// </summary>
    /// <param name="e">The requested <see cref="ItemsRepeaterElementPreparedEventArgs"/>.</param>
    /// <returns>The index of the item the element was prepared for.</returns>
    int Index(ItemsRepeaterElementPreparedEventArgs e);
}