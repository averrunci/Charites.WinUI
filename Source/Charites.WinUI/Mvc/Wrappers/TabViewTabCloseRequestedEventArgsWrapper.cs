// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="TabViewTabCloseRequestedEventArgs"/>
/// resolved by <see cref="ITabViewTabCloseRequestedEventArgsResolver"/>.
/// </summary>
public static class TabViewTabCloseRequestedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ITabViewTabCloseRequestedEventArgsResolver"/>
    /// that resolves data of the <see cref="TabViewTabCloseRequestedEventArgs"/>.
    /// </summary>
    public static ITabViewTabCloseRequestedEventArgsResolver Resolver { get; set; } = new DefaultTabViewTabCloseRequestedEventArgsResolver();

    /// <summary>
    /// Gets a value that represents the data context for the tab in which a close is being requested.
    /// </summary>
    /// <param name="e">The requested <see cref="TabViewTabCloseRequestedEventArgs"/>.</param>
    /// <returns>A value that represents the data context for the tab in which a close is being requested.</returns>
    public static object Item(this TabViewTabCloseRequestedEventArgs e) => Resolver.Item(e);

    /// <summary>
    /// Gets the tab in which a close is being requested.
    /// </summary>
    /// <param name="e">The requested <see cref="TabViewTabCloseRequestedEventArgs"/>.</param>
    /// <returns>The tab in which a close is being requested.</returns>
    public static TabViewItem Tab(this TabViewTabCloseRequestedEventArgs e) => Resolver.Tab(e);

    private sealed class DefaultTabViewTabCloseRequestedEventArgsResolver : ITabViewTabCloseRequestedEventArgsResolver
    {
        object ITabViewTabCloseRequestedEventArgsResolver.Item(TabViewTabCloseRequestedEventArgs e) => e.Item;
        TabViewItem ITabViewTabCloseRequestedEventArgsResolver.Tab(TabViewTabCloseRequestedEventArgs e) => e.Tab;
    }
}

/// <summary>
/// Resolves data of the <see cref="TabViewTabCloseRequestedEventArgs"/>.
/// </summary>
public interface ITabViewTabCloseRequestedEventArgsResolver
{
    /// <summary>
    /// Gets a value that represents the data context for the tab in which a close is being requested.
    /// </summary>
    /// <param name="e">The requested <see cref="TabViewTabCloseRequestedEventArgs"/>.</param>
    /// <returns>A value that represents the data context for the tab in which a close is being requested.</returns>
    object Item(TabViewTabCloseRequestedEventArgs e);

    /// <summary>
    /// Gets the tab in which a close is being requested.
    /// </summary>
    /// <param name="e">The requested <see cref="TabViewTabCloseRequestedEventArgs"/>.</param>
    /// <returns>The tab in which a close is being requested.</returns>
    TabViewItem Tab(TabViewTabCloseRequestedEventArgs e);
}