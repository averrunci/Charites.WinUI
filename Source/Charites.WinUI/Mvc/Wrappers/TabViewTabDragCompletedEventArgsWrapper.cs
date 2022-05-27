// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.ApplicationModel.DataTransfer;
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="TabViewTabDragCompletedEventArgs"/>
/// resolved by <see cref="ITabViewTabDragCompletedEventArgsResolver"/>.
/// </summary>
public static class TabViewTabDragCompletedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ITabViewTabDragCompletedEventArgsResolver"/>
    /// that resolves data of the <see cref="TabViewTabDragCompletedEventArgs"/>.
    /// </summary>
    public static ITabViewTabDragCompletedEventArgsResolver Resolver { get; set; } = new DefaultTabViewTabDragCompletedEventArgsResolver();

    /// <summary>
    /// Gets a value that indicates what operation was performed on the dragged data,
    /// and whether it was successful.
    /// </summary>
    /// <param name="e">The requested <see cref="TabViewTabDragCompletedEventArgs"/>.</param>
    /// <returns>
    /// A value that indicates what operation was performed on the dragged data,
    /// and whether it was successful.
    /// </returns>
    public static DataPackageOperation DropResult(this TabViewTabDragCompletedEventArgs e) => Resolver.DropResult(e);

    /// <summary>
    /// Gets the item that was selected for the drag action.
    /// </summary>
    /// <param name="e">The requested <see cref="TabViewTabDragCompletedEventArgs"/>.</param>
    /// <returns>The item that was selected for the drag action.</returns>
    public static object Item(this TabViewTabDragCompletedEventArgs e) => Resolver.Item(e);

    /// <summary>
    /// Gets the <see cref="TabViewItem"/> that was selected for the drag action.
    /// </summary>
    /// <param name="e">The requested <see cref="TabViewTabDragCompletedEventArgs"/>.</param>
    /// <returns>The <see cref="TabViewItem"/> that was selected for the drag action.</returns>
    public static TabViewItem Tab(this TabViewTabDragCompletedEventArgs e) => Resolver.Tab(e);

    private sealed class DefaultTabViewTabDragCompletedEventArgsResolver : ITabViewTabDragCompletedEventArgsResolver
    {
        DataPackageOperation ITabViewTabDragCompletedEventArgsResolver.DropResult(TabViewTabDragCompletedEventArgs e) => e.DropResult;
        object ITabViewTabDragCompletedEventArgsResolver.Item(TabViewTabDragCompletedEventArgs e) => e.Item;
        TabViewItem ITabViewTabDragCompletedEventArgsResolver.Tab(TabViewTabDragCompletedEventArgs e) => e.Tab;
    }
}

/// <summary>
/// Resolves data of the <see cref="TabViewTabDragCompletedEventArgs"/>.
/// </summary>
public interface ITabViewTabDragCompletedEventArgsResolver
{
    /// <summary>
    /// Gets a value that indicates what operation was performed on the dragged data,
    /// and whether it was successful.
    /// </summary>
    /// <param name="e">The requested <see cref="TabViewTabDragCompletedEventArgs"/>.</param>
    /// <returns>
    /// A value that indicates what operation was performed on the dragged data,
    /// and whether it was successful.
    /// </returns>
    DataPackageOperation DropResult(TabViewTabDragCompletedEventArgs e);

    /// <summary>
    /// Gets the item that was selected for the drag action.
    /// </summary>
    /// <param name="e">The requested <see cref="TabViewTabDragCompletedEventArgs"/>.</param>
    /// <returns>The item that was selected for the drag action.</returns>
    object Item(TabViewTabDragCompletedEventArgs e);

    /// <summary>
    /// Gets the <see cref="TabViewItem"/> that was selected for the drag action.
    /// </summary>
    /// <param name="e">The requested <see cref="TabViewTabDragCompletedEventArgs"/>.</param>
    /// <returns>The <see cref="TabViewItem"/> that was selected for the drag action.</returns>
    TabViewItem Tab(TabViewTabDragCompletedEventArgs e);
}