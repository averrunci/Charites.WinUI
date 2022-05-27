// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.ApplicationModel.DataTransfer;
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="TreeViewDragItemsCompletedEventArgs"/>
/// resolved by <see cref="ITreeViewDragItemsCompletedEventArgsResolver"/>.
/// </summary>
public static class TreeViewDragItemsCompletedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ITreeViewDragItemsCompletedEventArgsResolver"/>
    /// that resolves data of the <see cref="TreeViewDragItemsCompletedEventArgs"/>.
    /// </summary>
    public static ITreeViewDragItemsCompletedEventArgsResolver Resolver { get; set; } = new DefaultTreeViewDragItemsCompletedEventArgsResolver();

    /// <summary>
    /// Gets a value that indicates what operation was performed on the dragged data, and whether it was successful.
    /// </summary>
    /// <param name="e">The requested <see cref="TreeViewDragItemsCompletedEventArgs"/>.</param>
    /// <returns>A value of the enumeration that indicates what operation was performed on the dragged data.</returns>
    public static DataPackageOperation DropResult(this TreeViewDragItemsCompletedEventArgs e) => Resolver.DropResult(e);

    /// <summary>
    /// Gets the loosely typed collection of objects that are selected for the item drag action.
    /// </summary>
    /// <param name="e">The requested <see cref="TreeViewDragItemsCompletedEventArgs"/>.</param>
    /// <returns>A loosely typed collection of objects.</returns>
    public static IReadOnlyList<object> Items(this TreeViewDragItemsCompletedEventArgs e) => Resolver.Items(e);

    /// <summary>
    /// Gets the new parent of the <see cref="TreeViewItem"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="TreeViewDragItemsCompletedEventArgs"/>.</param>
    /// <returns>The new parent of the <see cref="TreeViewItem"/>.</returns>
    public static object? NewParentItem(this TreeViewDragItemsCompletedEventArgs e) => Resolver.NewParentItem(e);

    private sealed class DefaultTreeViewDragItemsCompletedEventArgsResolver : ITreeViewDragItemsCompletedEventArgsResolver
    {
        DataPackageOperation ITreeViewDragItemsCompletedEventArgsResolver.DropResult(TreeViewDragItemsCompletedEventArgs e) => e.DropResult;
        IReadOnlyList<object> ITreeViewDragItemsCompletedEventArgsResolver.Items(TreeViewDragItemsCompletedEventArgs e) => e.Items;
        object? ITreeViewDragItemsCompletedEventArgsResolver.NewParentItem(TreeViewDragItemsCompletedEventArgs e) => e.NewParentItem;
    }
}

/// <summary>
/// Resolves data of the <see cref="TreeViewDragItemsCompletedEventArgs"/>.
/// </summary>
public interface ITreeViewDragItemsCompletedEventArgsResolver
{
    /// <summary>
    /// Gets a value that indicates what operation was performed on the dragged data, and whether it was successful.
    /// </summary>
    /// <param name="e">The requested <see cref="TreeViewDragItemsCompletedEventArgs"/>.</param>
    /// <returns>A value of the enumeration that indicates what operation was performed on the dragged data.</returns>
    DataPackageOperation DropResult(TreeViewDragItemsCompletedEventArgs e);

    /// <summary>
    /// Gets the loosely typed collection of objects that are selected for the item drag action.
    /// </summary>
    /// <param name="e">The requested <see cref="TreeViewDragItemsCompletedEventArgs"/>.</param>
    /// <returns>A loosely typed collection of objects.</returns>
    IReadOnlyList<object> Items(TreeViewDragItemsCompletedEventArgs e);

    /// <summary>
    /// Gets the new parent of the <see cref="TreeViewItem"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="TreeViewDragItemsCompletedEventArgs"/>.</param>
    /// <returns>The new parent of the <see cref="TreeViewItem"/>.</returns>
    object? NewParentItem(TreeViewDragItemsCompletedEventArgs e);
}