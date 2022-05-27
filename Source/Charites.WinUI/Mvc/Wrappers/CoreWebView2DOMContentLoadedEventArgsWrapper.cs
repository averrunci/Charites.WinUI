// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.Web.WebView2.Core;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="CoreWebView2DOMContentLoadedEventArgs"/>
/// resolved by <see cref="ICoreWebView2DOMContentLoadedEventArgsResolver"/>.
/// </summary>
public static class CoreWebView2DOMContentLoadedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ICoreWebView2DOMContentLoadedEventArgsResolver"/>
    /// that resolves data of the <see cref="CoreWebView2DOMContentLoadedEventArgs"/>.
    /// </summary>
    public static ICoreWebView2DOMContentLoadedEventArgsResolver Resolver { get; set; } = new DefaultCoreWebView2DOMContentLoadedEventArgsResolver();

    /// <summary>
    /// Gets the ID of the navigation.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2DOMContentLoadedEventArgs"/>.</param>
    /// <returns>The ID of the navigation.</returns>
    public static ulong NavigationId(this CoreWebView2DOMContentLoadedEventArgs e) => Resolver.NavigationId(e);

    private sealed class DefaultCoreWebView2DOMContentLoadedEventArgsResolver : ICoreWebView2DOMContentLoadedEventArgsResolver
    {
        ulong ICoreWebView2DOMContentLoadedEventArgsResolver.NavigationId(CoreWebView2DOMContentLoadedEventArgs e) => e.NavigationId;
    }
}

/// <summary>
/// Resolves data of the <see cref="CoreWebView2DOMContentLoadedEventArgs"/>.
/// </summary>
public interface ICoreWebView2DOMContentLoadedEventArgsResolver
{
    /// <summary>
    /// Gets the ID of the navigation.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2DOMContentLoadedEventArgs"/>.</param>
    /// <returns>The ID of the navigation.</returns>
    ulong NavigationId(CoreWebView2DOMContentLoadedEventArgs e);
}