// Copyright (C) 2023 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="ItemsViewItemInvokedEventArgs"/>
/// resolved by <see cref="IItemsViewItemInvokedEventArgsResolver"/>.
/// </summary>
public static class ItemsViewItemInvokedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IItemsViewItemInvokedEventArgsResolver"/>
    /// that resolves data of the <see cref="ItemsViewItemInvokedEventArgs"/>.
    /// </summary>
    public static IItemsViewItemInvokedEventArgsResolver Resolver { get; set; } = new DefaultItemsViewItemInvokedEventArgsResolver();

    /// <summary>
    /// Gets the invoked item.
    /// </summary>
    /// <param name="e">The requested <see cref="ItemsViewItemInvokedEventArgs"/>.</param>
    /// <returns>The invoked item</returns>
    public static object? InvokedItem(this ItemsViewItemInvokedEventArgs e) => Resolver.InvokedItem(e);

    private sealed class DefaultItemsViewItemInvokedEventArgsResolver : IItemsViewItemInvokedEventArgsResolver
    {
        object? IItemsViewItemInvokedEventArgsResolver.InvokedItem(ItemsViewItemInvokedEventArgs e) => e.InvokedItem;
    }
}

/// <summary>
/// Resolves data of the <see cref="ItemsViewItemInvokedEventArgs"/>.
/// </summary>
public interface IItemsViewItemInvokedEventArgsResolver
{
    /// <summary>
    /// Gets the invoked item.
    /// </summary>
    /// <param name="e">The requested <see cref="ItemsViewItemInvokedEventArgs"/>.</param>
    /// <returns>The invoked item</returns>
    object? InvokedItem(ItemsViewItemInvokedEventArgs e);
}