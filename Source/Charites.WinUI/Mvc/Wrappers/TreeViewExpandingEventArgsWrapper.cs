﻿// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="TreeViewExpandingEventArgs"/>
/// resolved by <see cref="ITreeViewExpandingEventArgsResolver"/>.
/// </summary>
public static class TreeViewExpandingEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ITreeViewExpandingEventArgsResolver"/>
    /// that resolves data of the <see cref="TreeViewExpandingEventArgs"/>.
    /// </summary>
    public static ITreeViewExpandingEventArgsResolver Resolver { get; set; } = new DefaultTreeViewExpandingEventArgsResolver();

    /// <summary>
    /// Gets the data item for the tree view node that is expanding.
    /// </summary>
    /// <param name="e">The requested <see cref="TreeViewExpandingEventArgs"/>.</param>
    /// <returns>The data item for the tree view node that is expanding.</returns>
    public static object Item(this TreeViewExpandingEventArgs e) => Resolver.Item(e);

    /// <summary>
    /// Gets the tree view node that is expanding.
    /// </summary>
    /// <param name="e">The requested <see cref="TreeViewExpandingEventArgs"/>.</param>
    /// <returns>The tree view node that is expanding.</returns>
    public static TreeViewNode Node(this TreeViewExpandingEventArgs e) => Resolver.Node(e);

    private sealed class DefaultTreeViewExpandingEventArgsResolver : ITreeViewExpandingEventArgsResolver
    {
        object ITreeViewExpandingEventArgsResolver.Item(TreeViewExpandingEventArgs e) => e.Item;
        TreeViewNode ITreeViewExpandingEventArgsResolver.Node(TreeViewExpandingEventArgs e) => e.Node;
    }
}

/// <summary>
/// Resolves data of the <see cref="TreeViewExpandingEventArgs"/>.
/// </summary>
public interface ITreeViewExpandingEventArgsResolver
{
    /// <summary>
    /// Gets the data item for the tree view node that is expanding.
    /// </summary>
    /// <param name="e">The requested <see cref="TreeViewExpandingEventArgs"/>.</param>
    /// <returns>The data item for the tree view node that is expanding.</returns>
    object Item(TreeViewExpandingEventArgs e);

    /// <summary>
    /// Gets the tree view node that is expanding.
    /// </summary>
    /// <param name="e">The requested <see cref="TreeViewExpandingEventArgs"/>.</param>
    /// <returns>The tree view node that is expanding.</returns>
    TreeViewNode Node(TreeViewExpandingEventArgs e);
}