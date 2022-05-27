// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="NavigationViewItemCollapsedEventArgs"/>
/// resolved by <see cref="INavigationViewItemCollapsedEventArgsResolver"/>.
/// </summary>
public static class NavigationViewItemCollapsedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="INavigationViewItemCollapsedEventArgsResolver"/>
    /// that resolves data of the <see cref="NavigationViewItemCollapsedEventArgs"/>.
    /// </summary>
    public static INavigationViewItemCollapsedEventArgsResolver Resolver { get; set; } = new DefaultNavigationViewItemCollapsedEventArgsResolver();

    /// <summary>
    /// Gets the object that has been collapsed after the <see cref="NavigationView.Collapsed"/> event.
    /// </summary>
    /// <param name="e">The requested <see cref="NavigationViewItemCollapsedEventArgs"/>.</param>
    /// <returns>The object that has been collapsed.</returns>
    public static object CollapsedItem(this NavigationViewItemCollapsedEventArgs e) => Resolver.CollapsedItem(e);

    /// <summary>
    /// Gets the container of the object that was collapsed in the <see cref="NavigationView.Collapsed"/> event.
    /// </summary>
    /// <param name="e">The requested <see cref="NavigationViewItemCollapsedEventArgs"/>.</param>
    /// <returns>The container of the collapsed object.</returns>
    public static NavigationViewItemBase CollapsedItemContainer(this NavigationViewItemCollapsedEventArgs e) => Resolver.CollapsedItemContainer(e);

    private sealed class DefaultNavigationViewItemCollapsedEventArgsResolver : INavigationViewItemCollapsedEventArgsResolver
    {
        object INavigationViewItemCollapsedEventArgsResolver.CollapsedItem(NavigationViewItemCollapsedEventArgs e) => e.CollapsedItem;
        NavigationViewItemBase INavigationViewItemCollapsedEventArgsResolver.CollapsedItemContainer(NavigationViewItemCollapsedEventArgs e) => e.CollapsedItemContainer;
    }
}

/// <summary>
/// Resolves data of the <see cref="NavigationViewItemCollapsedEventArgs"/>.
/// </summary>
public interface INavigationViewItemCollapsedEventArgsResolver
{
    /// <summary>
    /// Gets the object that has been collapsed after the <see cref="NavigationView.Collapsed"/> event.
    /// </summary>
    /// <param name="e">The requested <see cref="NavigationViewItemCollapsedEventArgs"/>.</param>
    /// <returns>The object that has been collapsed.</returns>
    object CollapsedItem(NavigationViewItemCollapsedEventArgs e);

    /// <summary>
    /// Gets the container of the object that was collapsed in the <see cref="NavigationView.Collapsed"/> event.
    /// </summary>
    /// <param name="e">The requested <see cref="NavigationViewItemCollapsedEventArgs"/>.</param>
    /// <returns>The container of the collapsed object.</returns>
    NavigationViewItemBase CollapsedItemContainer(NavigationViewItemCollapsedEventArgs e);
}