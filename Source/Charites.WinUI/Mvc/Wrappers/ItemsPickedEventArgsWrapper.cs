// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="ItemsPickedEventArgs"/>
/// resolved by <see cref="IItemsPickedEventArgsResolver"/>.
/// </summary>
public static class ItemsPickedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IItemsPickedEventArgsResolver"/>
    /// that resolves data of the <see cref="ItemsPickedEventArgs"/>.
    /// </summary>
    public static IItemsPickedEventArgsResolver Resolver { get; set; } = new DefaultItemsPickedEventArgsResolver();

    /// <summary>
    /// Gets the collection of items that were selected by the user.
    /// </summary>
    /// <param name="e">The requested <see cref="ItemsPickedEventArgs"/>.</param>
    /// <returns>The collection of items that were selected by the user.</returns>
    public static IList<object> AddedItems(this ItemsPickedEventArgs e) => Resolver.AddedItems(e);

    /// <summary>
    /// Gets the collection of items that were unselected.
    /// </summary>
    /// <param name="e">The requested <see cref="ItemsPickedEventArgs"/>.</param>
    /// <returns>The collection of items that were unselected.</returns>
    public static IList<object> RemovedItems(this ItemsPickedEventArgs e) => Resolver.RemovedItems(e);

    private sealed class DefaultItemsPickedEventArgsResolver : IItemsPickedEventArgsResolver
    {
        IList<object> IItemsPickedEventArgsResolver.AddedItems(ItemsPickedEventArgs e) => e.AddedItems;
        IList<object> IItemsPickedEventArgsResolver.RemovedItems(ItemsPickedEventArgs e) => e.RemovedItems;
    }
}

/// <summary>
/// Resolves data of the <see cref="ItemsPickedEventArgs"/>.
/// </summary>
public interface IItemsPickedEventArgsResolver
{
    /// <summary>
    /// Gets the collection of items that were selected by the user.
    /// </summary>
    /// <param name="e">The requested <see cref="ItemsPickedEventArgs"/>.</param>
    /// <returns>The collection of items that were selected by the user.</returns>
    IList<object> AddedItems(ItemsPickedEventArgs e);

    /// <summary>
    /// Gets the collection of items that were unselected.
    /// </summary>
    /// <param name="e">The requested <see cref="ItemsPickedEventArgs"/>.</param>
    /// <returns>The collection of items that were unselected.</returns>
    IList<object> RemovedItems(ItemsPickedEventArgs e);
}