// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="NavigationViewSelectionChangedEventArgs"/>
/// resolved by <see cref="INavigationViewSelectionChangedEventArgsResolver"/>.
/// </summary>
public static class NavigationViewSelectionChangedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="INavigationViewSelectionChangedEventArgsResolver"/>
    /// that resolves data of the <see cref="NavigationViewSelectionChangedEventArgs"/>.
    /// </summary>
    public static INavigationViewSelectionChangedEventArgsResolver Resolver { get; set; } = new DefaultNavigationViewSelectionChangedEventArgsResolver();

    /// <summary>
    /// Gets a value that indicates whether the <see cref="NavigationView.SelectedItem"/> is the menu item for Settings.
    /// </summary>
    /// <param name="e">The requested <see cref="NavigationViewSelectionChangedEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> if the <see cref="NavigationView.SelectedItem"/> is the menu item for Settings; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsSettingsSelected(this NavigationViewSelectionChangedEventArgs e) => Resolver.IsSettingsSelected(e);

    /// <summary>
    /// Gets the navigation transition recommended for the direction of the navigation.
    /// </summary>
    /// <param name="e">The requested <see cref="NavigationViewSelectionChangedEventArgs"/>.</param>
    /// <returns>The navigation transition recommended for the direction of the navigation.</returns>
    public static NavigationTransitionInfo RecommendedNavigationTransitionInfo(this NavigationViewSelectionChangedEventArgs e) => Resolver.RecommendedNavigationTransitionInfo(e);

    /// <summary>
    /// Gets the newly selected menu item.
    /// </summary>
    /// <param name="e">The requested <see cref="NavigationViewSelectionChangedEventArgs"/>.</param>
    /// <returns>The newly selected menu item.</returns>
    public static object? SelectedItem(this NavigationViewSelectionChangedEventArgs e) => Resolver.SelectedItem(e);

    /// <summary>
    /// Gets the container for the selected item.
    /// </summary>
    /// <param name="e">The requested <see cref="NavigationViewSelectionChangedEventArgs"/>.</param>
    /// <returns>The container for the selected item.</returns>
    public static NavigationViewItemBase? SelectedItemContainer(this NavigationViewSelectionChangedEventArgs e) => Resolver.SelectedItemContainer(e);

    private sealed class DefaultNavigationViewSelectionChangedEventArgsResolver : INavigationViewSelectionChangedEventArgsResolver
    {
        bool INavigationViewSelectionChangedEventArgsResolver.IsSettingsSelected(NavigationViewSelectionChangedEventArgs e) => e.IsSettingsSelected;
        NavigationTransitionInfo INavigationViewSelectionChangedEventArgsResolver.RecommendedNavigationTransitionInfo(NavigationViewSelectionChangedEventArgs e) => e.RecommendedNavigationTransitionInfo;
        object? INavigationViewSelectionChangedEventArgsResolver.SelectedItem(NavigationViewSelectionChangedEventArgs e) => e.SelectedItem;
        NavigationViewItemBase? INavigationViewSelectionChangedEventArgsResolver.SelectedItemContainer(NavigationViewSelectionChangedEventArgs e) => e.SelectedItemContainer;
    }
}

/// <summary>
/// Resolves data of the <see cref="NavigationViewSelectionChangedEventArgs"/>.
/// </summary>
public interface INavigationViewSelectionChangedEventArgsResolver
{
    /// <summary>
    /// Gets a value that indicates whether the <see cref="NavigationView.SelectedItem"/> is the menu item for Settings.
    /// </summary>
    /// <param name="e">The requested <see cref="NavigationViewSelectionChangedEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> if the <see cref="NavigationView.SelectedItem"/> is the menu item for Settings; otherwise, <c>false</c>.
    /// </returns>
    bool IsSettingsSelected(NavigationViewSelectionChangedEventArgs e);

    /// <summary>
    /// Gets the navigation transition recommended for the direction of the navigation.
    /// </summary>
    /// <param name="e">The requested <see cref="NavigationViewSelectionChangedEventArgs"/>.</param>
    /// <returns>The navigation transition recommended for the direction of the navigation.</returns>
    NavigationTransitionInfo RecommendedNavigationTransitionInfo(NavigationViewSelectionChangedEventArgs e);

    /// <summary>
    /// Gets the newly selected menu item.
    /// </summary>
    /// <param name="e">The requested <see cref="NavigationViewSelectionChangedEventArgs"/>.</param>
    /// <returns>The newly selected menu item.</returns>
    object? SelectedItem(NavigationViewSelectionChangedEventArgs e);

    /// <summary>
    /// Gets the container for the selected item.
    /// </summary>
    /// <param name="e">The requested <see cref="NavigationViewSelectionChangedEventArgs"/>.</param>
    /// <returns>The container for the selected item.</returns>
    NavigationViewItemBase? SelectedItemContainer(NavigationViewSelectionChangedEventArgs e);
}