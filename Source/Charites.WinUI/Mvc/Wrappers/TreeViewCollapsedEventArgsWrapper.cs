// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="TreeViewCollapsedEventArgs"/>
/// resolved by <see cref="ITreeViewCollapsedEventArgsResolver"/>.
/// </summary>
public static class TreeViewCollapsedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ITreeViewCollapsedEventArgsResolver"/>
    /// that resolves data of the <see cref="TreeViewCollapsedEventArgs"/>.
    /// </summary>
    public static ITreeViewCollapsedEventArgsResolver Resolver { get; set; } = new DefaultTreeViewCollapsedEventArgsResolver();

    /// <summary>
    /// Gets the <see cref="TreeView"/> item that is collapsed.
    /// </summary>
    /// <param name="e">The requested <see cref="TreeViewCollapsedEventArgs"/>.</param>
    /// <returns>The <see cref="TreeView"/> item that is collapsed.</returns>
    public static object Item(this TreeViewCollapsedEventArgs e) => Resolver.Item(e);

    /// <summary>
    /// Gets the <see cref="TreeView"/> node that is collapsed.
    /// </summary>
    /// <param name="e">The requested <see cref="TreeViewCollapsedEventArgs"/>.</param>
    /// <returns>The <see cref="TreeView"/> node that is collapsed.</returns>
    public static TreeViewNode Node(this TreeViewCollapsedEventArgs e) => Resolver.Node(e);

    private sealed class DefaultTreeViewCollapsedEventArgsResolver : ITreeViewCollapsedEventArgsResolver
    {
        object ITreeViewCollapsedEventArgsResolver.Item(TreeViewCollapsedEventArgs e) => e.Item;
        TreeViewNode ITreeViewCollapsedEventArgsResolver.Node(TreeViewCollapsedEventArgs e) => e.Node;
    }
}

/// <summary>
/// Resolves data of the <see cref="TreeViewCollapsedEventArgs"/>.
/// </summary>
public interface ITreeViewCollapsedEventArgsResolver
{
    /// <summary>
    /// Gets the <see cref="TreeView"/> item that is collapsed.
    /// </summary>
    /// <param name="e">The requested <see cref="TreeViewCollapsedEventArgs"/>.</param>
    /// <returns>The <see cref="TreeView"/> item that is collapsed.</returns>
    object Item(TreeViewCollapsedEventArgs e);

    /// <summary>
    /// Gets the <see cref="TreeView"/> node that is collapsed.
    /// </summary>
    /// <param name="e">The requested <see cref="TreeViewCollapsedEventArgs"/>.</param>
    /// <returns>The <see cref="TreeView"/> node that is collapsed.</returns>
    TreeViewNode Node(TreeViewCollapsedEventArgs e);
}