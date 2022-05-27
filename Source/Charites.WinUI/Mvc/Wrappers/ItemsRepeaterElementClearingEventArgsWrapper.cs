// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="ItemsRepeaterElementClearingEventArgs"/>
/// resolved by <see cref="IItemsRepeaterElementClearingEventArgsResolver"/>.
/// </summary>
public static class ItemsRepeaterElementClearingEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IItemsRepeaterElementClearingEventArgsResolver"/>
    /// that resolves data of the <see cref="ItemsRepeaterElementClearingEventArgs"/>.
    /// </summary>
    public static IItemsRepeaterElementClearingEventArgsResolver Resolver { get; set; } = new DefaultItemsRepeaterElementClearingEventArgsResolver();

    /// <summary>
    /// Gets the element that is being cleared for re-use.
    /// </summary>
    /// <param name="e">The requested <see cref="ItemsRepeaterElementClearingEventArgs"/>.</param>
    /// <returns>The element that is being cleared.</returns>
    public static UIElement Element(this ItemsRepeaterElementClearingEventArgs e) => Resolver.Element(e);

    private sealed class DefaultItemsRepeaterElementClearingEventArgsResolver : IItemsRepeaterElementClearingEventArgsResolver
    {
        UIElement IItemsRepeaterElementClearingEventArgsResolver.Element(ItemsRepeaterElementClearingEventArgs e) => e.Element;
    }
}

/// <summary>
/// Resolves data of the <see cref="ItemsRepeaterElementClearingEventArgs"/>.
/// </summary>
public interface IItemsRepeaterElementClearingEventArgsResolver
{
    /// <summary>
    /// Gets the element that is being cleared for re-use.
    /// </summary>
    /// <param name="e">The requested <see cref="ItemsRepeaterElementClearingEventArgs"/>.</param>
    /// <returns>The element that is being cleared.</returns>
    UIElement Element(ItemsRepeaterElementClearingEventArgs e);
}