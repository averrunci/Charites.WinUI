// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="NavigationViewItemExpandingEventArgs"/>
/// resolved by <see cref="INavigationViewItemExpandingEventArgsResolver"/>.
/// </summary>
public static class NavigationViewItemExpandingEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="INavigationViewItemExpandingEventArgsResolver"/>
    /// that resolves data of the <see cref="NavigationViewItemExpandingEventArgs"/>.
    /// </summary>
    public static INavigationViewItemExpandingEventArgsResolver Resolver { get; set; } = new DefaultNavigationViewItemExpandingEventArgsResolver();

    /// <summary>
    /// Gets the object that is expanding after the <see cref="NavigationView.Expanding"/> event.
    /// </summary>
    /// <param name="e">The requested <see cref="NavigationViewItemExpandingEventArgs"/>.</param>
    /// <returns>The expanding object.</returns>
    public static object ExpandingItem(this NavigationViewItemExpandingEventArgs e) => Resolver.ExpandingItem(e);

    /// <summary>
    /// Gets the container of the expanding item after the <see cref="NavigationView.Expanding"/> event.
    /// </summary>
    /// <param name="e">The requested <see cref="NavigationViewItemExpandingEventArgs"/>.</param>
    /// <returns>The container of the expanding item.</returns>
    public static NavigationViewItemBase ExpandingItemContainer(this NavigationViewItemExpandingEventArgs e) => Resolver.ExpandingItemContainer(e);

    private sealed class DefaultNavigationViewItemExpandingEventArgsResolver : INavigationViewItemExpandingEventArgsResolver
    {
        object INavigationViewItemExpandingEventArgsResolver.ExpandingItem(NavigationViewItemExpandingEventArgs e) => e.ExpandingItem;
        NavigationViewItemBase INavigationViewItemExpandingEventArgsResolver.ExpandingItemContainer(NavigationViewItemExpandingEventArgs e) => e.ExpandingItemContainer;
    }
}

/// <summary>
/// Resolves data of the <see cref="NavigationViewItemExpandingEventArgs"/>.
/// </summary>
public interface INavigationViewItemExpandingEventArgsResolver
{
    /// <summary>
    /// Gets the object that is expanding after the <see cref="NavigationView.Expanding"/> event.
    /// </summary>
    /// <param name="e">The requested <see cref="NavigationViewItemExpandingEventArgs"/>.</param>
    /// <returns>The expanding object.</returns>
    object ExpandingItem(NavigationViewItemExpandingEventArgs e);

    /// <summary>
    /// Gets the container of the expanding item after the <see cref="NavigationView.Expanding"/> event.
    /// </summary>
    /// <param name="e">The requested <see cref="NavigationViewItemExpandingEventArgs"/>.</param>
    /// <returns>The container of the expanding item.</returns>
    NavigationViewItemBase ExpandingItemContainer(NavigationViewItemExpandingEventArgs e);
}