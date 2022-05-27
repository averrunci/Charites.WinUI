// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.ApplicationModel.DataTransfer;
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="TabViewTabDragStartingEventArgs"/>
/// resolved by <see cref="ITabViewTabDragStartingEventArgsResolver"/>.
/// </summary>
public static class TabViewTabDragStartingEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ITabViewTabDragStartingEventArgsResolver"/>
    /// that resolves data of the <see cref="TabViewTabDragStartingEventArgs"/>.
    /// </summary>
    public static ITabViewTabDragStartingEventArgsResolver Resolver { get; set; } = new DefaultTabViewTabDragStartingEventArgsResolver();

    /// <summary>
    /// Gets a value that indicates whether the drag action should be canceled.
    /// </summary>
    /// <param name="e">The requested <see cref="TabViewTabDragStartingEventArgs"/>.</param>
    /// <returns><c>true</c> if the drag action is canceled; otherwise, <c>false</c>.</returns>
    public static bool Cancel(this TabViewTabDragStartingEventArgs e) => Resolver.Cancel(e);

    /// <summary>
    /// Sets a value that indicates whether the drag action should be canceled.
    /// </summary>
    /// <param name="e">The requested <see cref="TabViewTabDragStartingEventArgs"/>.</param>
    /// <param name="cancel"><c>true</c> if the drag action is canceled; otherwise, <c>false</c>.</param>
    public static void Cancel(this TabViewTabDragStartingEventArgs e, bool cancel) => Resolver.Cancel(e, cancel);

    /// <summary>
    /// Gets the data payload associated with a drag action.
    /// </summary>
    /// <param name="e">The requested <see cref="TabViewTabDragStartingEventArgs"/>.</param>
    /// <returns>The data payload associated with a drag action.</returns>
    public static DataPackage Data(this TabViewTabDragStartingEventArgs e) => Resolver.Data(e);

    /// <summary>
    /// Gets the item that was selected for the drag action.
    /// </summary>
    /// <param name="e">The requested <see cref="TabViewTabDragStartingEventArgs"/>.</param>
    /// <returns>The item that was selected for the drag action.</returns>
    public static object Item(this TabViewTabDragStartingEventArgs e) => Resolver.Item(e);

    /// <summary>
    /// Gets the <see cref="TabViewItem"/> that was selected for the drag action.
    /// </summary>
    /// <param name="e">The requested <see cref="TabViewTabDragStartingEventArgs"/>.</param>
    /// <returns>The <see cref="TabViewItem"/> that was selected for the drag action.</returns>
    public static TabViewItem Tab(this TabViewTabDragStartingEventArgs e) => Resolver.Tab(e);

    private sealed class DefaultTabViewTabDragStartingEventArgsResolver : ITabViewTabDragStartingEventArgsResolver
    {
        bool ITabViewTabDragStartingEventArgsResolver.Cancel(TabViewTabDragStartingEventArgs e) => e.Cancel;
        void ITabViewTabDragStartingEventArgsResolver.Cancel(TabViewTabDragStartingEventArgs e, bool cancel) => e.Cancel = cancel;
        DataPackage ITabViewTabDragStartingEventArgsResolver.Data(TabViewTabDragStartingEventArgs e) => e.Data;
        object ITabViewTabDragStartingEventArgsResolver.Item(TabViewTabDragStartingEventArgs e) => e.Item;
        TabViewItem ITabViewTabDragStartingEventArgsResolver.Tab(TabViewTabDragStartingEventArgs e) => e.Tab;
    }
}

/// <summary>
/// Resolves data of the <see cref="TabViewTabDragStartingEventArgs"/>.
/// </summary>
public interface ITabViewTabDragStartingEventArgsResolver
{
    /// <summary>
    /// Gets a value that indicates whether the drag action should be canceled.
    /// </summary>
    /// <param name="e">The requested <see cref="TabViewTabDragStartingEventArgs"/>.</param>
    /// <returns><c>true</c> if the drag action is canceled; otherwise, <c>false</c>.</returns>
    bool Cancel(TabViewTabDragStartingEventArgs e);

    /// <summary>
    /// Sets a value that indicates whether the drag action should be canceled.
    /// </summary>
    /// <param name="e">The requested <see cref="TabViewTabDragStartingEventArgs"/>.</param>
    /// <param name="cancel"><c>true</c> if the drag action is canceled; otherwise, <c>false</c>.</param>
    void Cancel(TabViewTabDragStartingEventArgs e, bool cancel);

    /// <summary>
    /// Gets the data payload associated with a drag action.
    /// </summary>
    /// <param name="e">The requested <see cref="TabViewTabDragStartingEventArgs"/>.</param>
    /// <returns>The data payload associated with a drag action.</returns>
    DataPackage Data(TabViewTabDragStartingEventArgs e);

    /// <summary>
    /// Gets the item that was selected for the drag action.
    /// </summary>
    /// <param name="e">The requested <see cref="TabViewTabDragStartingEventArgs"/>.</param>
    /// <returns>The item that was selected for the drag action.</returns>
    object Item(TabViewTabDragStartingEventArgs e);

    /// <summary>
    /// Gets the <see cref="TabViewItem"/> that was selected for the drag action.
    /// </summary>
    /// <param name="e">The requested <see cref="TabViewTabDragStartingEventArgs"/>.</param>
    /// <returns>The <see cref="TabViewItem"/> that was selected for the drag action.</returns>
    TabViewItem Tab(TabViewTabDragStartingEventArgs e);
}