// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="SwipeItemInvokedEventArgs"/>
/// resolved by <see cref="ISwipeItemInvokedEventArgsResolver"/>.
/// </summary>
public static class SwipeItemInvokedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ISwipeItemInvokedEventArgsResolver"/>
    /// that resolves data of the <see cref="SwipeItemInvokedEventArgs"/>.
    /// </summary>
    public static ISwipeItemInvokedEventArgsResolver Resolver { get; set; } = new DefaultSwipeItemInvokedEventArgsResolver();

    /// <summary>
    /// Gets the <see cref="SwipeControl"/> that owns the invoked item.
    /// </summary>
    /// <param name="e">The requested <see cref="SwipeItemInvokedEventArgs"/>.</param>
    /// <returns>The <see cref="SwipeControl"/> that owns the invoked item.</returns>
    public static SwipeControl SwipeControl(this SwipeItemInvokedEventArgs e) => Resolver.SwipeControl(e);

    private sealed class DefaultSwipeItemInvokedEventArgsResolver : ISwipeItemInvokedEventArgsResolver
    {
        SwipeControl ISwipeItemInvokedEventArgsResolver.SwipeControl(SwipeItemInvokedEventArgs e) => e.SwipeControl;
    }
}

/// <summary>
/// Resolves data of the <see cref="SwipeItemInvokedEventArgs"/>.
/// </summary>
public interface ISwipeItemInvokedEventArgsResolver
{
    /// <summary>
    /// Gets the <see cref="SwipeControl"/> that owns the invoked item.
    /// </summary>
    /// <param name="e">The requested <see cref="SwipeItemInvokedEventArgs"/>.</param>
    /// <returns>The <see cref="SwipeControl"/> that owns the invoked item.</returns>
    SwipeControl SwipeControl(SwipeItemInvokedEventArgs e);
}