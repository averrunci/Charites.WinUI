// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls.Primitives;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="ItemsChangedEventArgs"/>
/// resolved by <see cref="IItemsChangedEventArgsResolver"/>.
/// </summary>
public static class ItemsChangedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IItemsChangedEventArgsResolver"/>
    /// that resolves data of the <see cref="ItemsChangedEventArgs"/>.
    /// </summary>
    public static IItemsChangedEventArgsResolver Resolver { get; set; } = new DefaultItemsChangedEventArgsResolver();

    /// <summary>
    /// Gets the action that occurred on the items collection.
    /// </summary>
    /// <param name="e">The requested <see cref="ItemsChangedEventArgs"/>.</param>
    /// <returns>Returns the action that occurred.</returns>
    public static int Action(this ItemsChangedEventArgs e) => Resolver.Action(e);

    /// <summary>
    /// Gets the number of items that were involved in the change.
    /// </summary>
    /// <param name="e">The requested <see cref="ItemsChangedEventArgs"/>.</param>
    /// <returns>Integer that represents the number of items involved in the change.</returns>
    public static int ItemCount(this ItemsChangedEventArgs e) => Resolver.ItemCount(e);

    /// <summary>
    /// Gets the number of UI elements involved in the change.
    /// </summary>
    /// <param name="e">The requested <see cref="ItemsChangedEventArgs"/>.</param>
    /// <returns>Integer that represents the number of UI elements involved in the change.</returns>
    public static int ItemUICount(this ItemsChangedEventArgs e) => Resolver.ItemUICount(e);

    /// <summary>
    /// Gets the position in the collection before the change occurred.
    /// </summary>
    /// <param name="e">The requested <see cref="ItemsChangedEventArgs"/>.</param>
    /// <returns>Returns a <see cref="GeneratorPosition"/>.</returns>
    public static GeneratorPosition OldPosition(this ItemsChangedEventArgs e) => Resolver.OldPosition(e);

    /// <summary>
    /// Gets the position in the collection where the change occurred.
    /// </summary>
    /// <param name="e">The requested <see cref="ItemsChangedEventArgs"/>.</param>
    /// <returns>Returns a <see cref="GeneratorPosition"/>.</returns>
    public static GeneratorPosition Position(this ItemsChangedEventArgs e) => Resolver.Position(e);

    private sealed class DefaultItemsChangedEventArgsResolver : IItemsChangedEventArgsResolver
    {
        int IItemsChangedEventArgsResolver.Action(ItemsChangedEventArgs e) => e.Action;
        int IItemsChangedEventArgsResolver.ItemCount(ItemsChangedEventArgs e) => e.ItemCount;
        int IItemsChangedEventArgsResolver.ItemUICount(ItemsChangedEventArgs e) => e.ItemUICount;
        GeneratorPosition IItemsChangedEventArgsResolver.OldPosition(ItemsChangedEventArgs e) => e.OldPosition;
        GeneratorPosition IItemsChangedEventArgsResolver.Position(ItemsChangedEventArgs e) => e.Position;
    }
}

/// <summary>
/// Resolves data of the <see cref="ItemsChangedEventArgs"/>.
/// </summary>
public interface IItemsChangedEventArgsResolver
{
    /// <summary>
    /// Gets the action that occurred on the items collection.
    /// </summary>
    /// <param name="e">The requested <see cref="ItemsChangedEventArgs"/>.</param>
    /// <returns>Returns the action that occurred.</returns>
    int Action(ItemsChangedEventArgs e);

    /// <summary>
    /// Gets the number of items that were involved in the change.
    /// </summary>
    /// <param name="e">The requested <see cref="ItemsChangedEventArgs"/>.</param>
    /// <returns>Integer that represents the number of items involved in the change.</returns>
    int ItemCount(ItemsChangedEventArgs e);

    /// <summary>
    /// Gets the number of UI elements involved in the change.
    /// </summary>
    /// <param name="e">The requested <see cref="ItemsChangedEventArgs"/>.</param>
    /// <returns>Integer that represents the number of UI elements involved in the change.</returns>
    int ItemUICount(ItemsChangedEventArgs e);

    /// <summary>
    /// Gets the position in the collection before the change occurred.
    /// </summary>
    /// <param name="e">The requested <see cref="ItemsChangedEventArgs"/>.</param>
    /// <returns>Returns a <see cref="GeneratorPosition"/>.</returns>
    GeneratorPosition OldPosition(ItemsChangedEventArgs e);

    /// <summary>
    /// Gets the position in the collection where the change occurred.
    /// </summary>
    /// <param name="e">The requested <see cref="ItemsChangedEventArgs"/>.</param>
    /// <returns>Returns a <see cref="GeneratorPosition"/>.</returns>
    GeneratorPosition Position(ItemsChangedEventArgs e);
}