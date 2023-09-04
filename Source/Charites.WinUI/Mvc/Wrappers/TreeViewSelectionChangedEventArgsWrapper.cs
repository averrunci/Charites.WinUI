// Copyright (C) 2023 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="TreeViewSelectionChangedEventArgs"/>
/// resolved by <see cref="ITreeViewSelectionChangedEventArgsResolver"/>.
/// </summary>
public static class TreeViewSelectionChangedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ITreeViewSelectionChangedEventArgsResolver"/>
    /// that resolves data of the <see cref="TreeViewSelectionChangedEventArgs"/>.
    /// </summary>
    public static ITreeViewSelectionChangedEventArgsResolver Resolver { get; set; } = new DefaultTreeViewSelectionChangedEventArgsResolver();

    /// <summary>
    /// Gets a list that contains the items that were selected.
    /// </summary>
    /// <param name="e">The requested <see cref="TreeViewSelectionChangedEventArgs"/>.</param>
    /// <returns>A list that contains the items that were selected.</returns>
    public static IList<object> AddedItems(this TreeViewSelectionChangedEventArgs e) => Resolver.AddedItems(e);

    /// <summary>
    /// Gets a list that contains the items that were unselected.
    /// </summary>
    /// <param name="e">The requested <see cref="TreeViewSelectionChangedEventArgs"/>.</param>
    /// <returns>A list that contains the items that were unselected.</returns>
    public static IList<object> RemovedItems(this TreeViewSelectionChangedEventArgs e) => Resolver.RemovedItems(e);

    private sealed class DefaultTreeViewSelectionChangedEventArgsResolver : ITreeViewSelectionChangedEventArgsResolver
    {
        IList<object> ITreeViewSelectionChangedEventArgsResolver.AddedItems(TreeViewSelectionChangedEventArgs e) => e.AddedItems;
        IList<object> ITreeViewSelectionChangedEventArgsResolver.RemovedItems(TreeViewSelectionChangedEventArgs e) => e.RemovedItems;
    }
}

/// <summary>
/// Resolves data of the <see cref="TreeViewSelectionChangedEventArgs"/>.
/// </summary>
public interface ITreeViewSelectionChangedEventArgsResolver
{
    /// <summary>
    /// Gets a list that contains the items that were selected.
    /// </summary>
    /// <param name="e">The requested <see cref="TreeViewSelectionChangedEventArgs"/>.</param>
    /// <returns>A list that contains the items that were selected.</returns>
    IList<object> AddedItems(TreeViewSelectionChangedEventArgs e);

    /// <summary>
    /// Gets a list that contains the items that were unselected.
    /// </summary>
    /// <param name="e">The requested <see cref="TreeViewSelectionChangedEventArgs"/>.</param>
    /// <returns>A list that contains the items that were unselected.</returns>
    IList<object> RemovedItems(TreeViewSelectionChangedEventArgs e);
}