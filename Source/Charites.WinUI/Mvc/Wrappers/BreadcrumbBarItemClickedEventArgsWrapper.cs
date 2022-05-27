// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="BreadcrumbBarItemClickedEventArgs"/>
/// resolved by <see cref="IBreadcrumbBarItemClickedEventArgsResolver"/>.
/// </summary>
public static class BreadcrumbBarItemClickedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IBreadcrumbBarItemClickedEventArgsResolver"/>
    /// that resolves data of the <see cref="BreadcrumbBarItemClickedEventArgs"/>.
    /// </summary>
    public static IBreadcrumbBarItemClickedEventArgsResolver Resolver { get; set; } = new DefaultBreadcrumbBarItemClickedEventArgsResolver();

    /// <summary>
    /// Gets the index of the item that was clicked
    /// </summary>
    /// <param name="e">The requested <see cref="BreadcrumbBarItemClickedEventArgs"/>.</param>
    /// <returns>The index of the item that was clicked.</returns>
    public static int Index(this BreadcrumbBarItemClickedEventArgs e) => Resolver.Index(e);

    /// <summary>
    /// Gets the <see cref="BreadcrumbBarItem.Content"/> property value of the <see cref="BreadcrumbBarItem"/> that is clicked.
    /// </summary>
    /// <param name="e">The requested <see cref="BreadcrumbBarItemClickedEventArgs"/>.</param>
    /// <returns>The <see cref="BreadcrumbBarItem.Content"/> property value of the <see cref="BreadcrumbBarItem"/> that is clicked.</returns>
    public static object? Item(this BreadcrumbBarItemClickedEventArgs e) => Resolver.Item(e);

    private sealed class DefaultBreadcrumbBarItemClickedEventArgsResolver : IBreadcrumbBarItemClickedEventArgsResolver
    {
        int IBreadcrumbBarItemClickedEventArgsResolver.Index(BreadcrumbBarItemClickedEventArgs e) => e.Index;
        object? IBreadcrumbBarItemClickedEventArgsResolver.Item(BreadcrumbBarItemClickedEventArgs e) => e.Item;
    }
}

/// <summary>
/// Resolves data of the <see cref="BreadcrumbBarItemClickedEventArgs"/>.
/// </summary>
public interface IBreadcrumbBarItemClickedEventArgsResolver
{
    /// <summary>
    /// Gets the index of the item that was clicked
    /// </summary>
    /// <param name="e">The requested <see cref="BreadcrumbBarItemClickedEventArgs"/>.</param>
    /// <returns>The index of the item that was clicked.</returns>
    int Index(BreadcrumbBarItemClickedEventArgs e);

    /// <summary>
    /// Gets the <see cref="BreadcrumbBarItem.Content"/> property value of the <see cref="BreadcrumbBarItem"/> that is clicked.
    /// </summary>
    /// <param name="e">The requested <see cref="BreadcrumbBarItemClickedEventArgs"/>.</param>
    /// <returns>The <see cref="BreadcrumbBarItem.Content"/> property value of the <see cref="BreadcrumbBarItem"/> that is clicked.</returns>
    object? Item(BreadcrumbBarItemClickedEventArgs e);
}