// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="TabViewTabDroppedOutsideEventArgs"/>
/// resolved by <see cref="ITabViewTabDroppedOutsideEventArgsResolver"/>.
/// </summary>
public static class TabViewTabDroppedOutsideEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ITabViewTabDroppedOutsideEventArgsResolver"/>
    /// that resolves data of the <see cref="TabViewTabDroppedOutsideEventArgs"/>.
    /// </summary>
    public static ITabViewTabDroppedOutsideEventArgsResolver Resolver { get; set; } = new DefaultTabViewTabDroppedOutsideEventArgsResolver();

    /// <summary>
    /// Gets the item that was dropped outside of the <see cref="TabView"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="TabViewTabDroppedOutsideEventArgs"/>.</param>
    /// <returns>The item that was dropped outside of the <see cref="TabView"/>.</returns>
    public static object Item(this TabViewTabDroppedOutsideEventArgs e) => Resolver.Item(e);

    /// <summary>
    /// Gets the <see cref="TabViewItem"/> that was dropped outside of the <see cref="TabView"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="TabViewTabDroppedOutsideEventArgs"/>.</param>
    /// <returns>The <see cref="TabViewItem"/> that was dropped outside of the <see cref="TabView"/>.</returns>
    public static TabViewItem Tab(this TabViewTabDroppedOutsideEventArgs e) => Resolver.Tab(e);

    private sealed class DefaultTabViewTabDroppedOutsideEventArgsResolver : ITabViewTabDroppedOutsideEventArgsResolver
    {
        object ITabViewTabDroppedOutsideEventArgsResolver.Item(TabViewTabDroppedOutsideEventArgs e) => e.Item;
        TabViewItem ITabViewTabDroppedOutsideEventArgsResolver.Tab(TabViewTabDroppedOutsideEventArgs e) => e.Tab;
    }
}

/// <summary>
/// Resolves data of the <see cref="TabViewTabDroppedOutsideEventArgs"/>.
/// </summary>
public interface ITabViewTabDroppedOutsideEventArgsResolver
{
    /// <summary>
    /// Gets the item that was dropped outside of the <see cref="TabView"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="TabViewTabDroppedOutsideEventArgs"/>.</param>
    /// <returns>The item that was dropped outside of the <see cref="TabView"/>.</returns>
    object Item(TabViewTabDroppedOutsideEventArgs e);

    /// <summary>
    /// Gets the <see cref="TabViewItem"/> that was dropped outside of the <see cref="TabView"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="TabViewTabDroppedOutsideEventArgs"/>.</param>
    /// <returns>The <see cref="TabViewItem"/> that was dropped outside of the <see cref="TabView"/>.</returns>
    TabViewItem Tab(TabViewTabDroppedOutsideEventArgs e);
}