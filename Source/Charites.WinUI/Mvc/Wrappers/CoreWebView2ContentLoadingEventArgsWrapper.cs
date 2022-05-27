// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.Web.WebView2.Core;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="CoreWebView2ContentLoadingEventArgs"/>
/// resolved by <see cref="ICoreWebView2ContentLoadingEventArgsResolver"/>.
/// </summary>
public static class CoreWebView2ContentLoadingEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ICoreWebView2ContentLoadingEventArgsResolver"/>
    /// that resolves data of the <see cref="CoreWebView2ContentLoadingEventArgs"/>.
    /// </summary>
    public static ICoreWebView2ContentLoadingEventArgsResolver Resolver { get; set; } = new DefaultCoreWebView2ContentLoadingEventArgsResolver();

    /// <summary>
    /// Gets a value that indicates whether the loaded content is an error page.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ContentLoadingEventArgs"/>.</param>
    /// <returns><c>true</c> if the loaded content is an error page; otherwise, <c>false</c>.</returns>
    public static bool IsErrorPage(this CoreWebView2ContentLoadingEventArgs e) => Resolver.IsErrorPage(e);

    /// <summary>
    /// Gets the ID of the navigation.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ContentLoadingEventArgs"/>.</param>
    /// <returns>The ID of the navigation.</returns>
    public static ulong NavigationId(this CoreWebView2ContentLoadingEventArgs e) => Resolver.NavigationId(e);

    private sealed class DefaultCoreWebView2ContentLoadingEventArgsResolver : ICoreWebView2ContentLoadingEventArgsResolver
    {
        bool ICoreWebView2ContentLoadingEventArgsResolver.IsErrorPage(CoreWebView2ContentLoadingEventArgs e) => e.IsErrorPage;
        ulong ICoreWebView2ContentLoadingEventArgsResolver.NavigationId(CoreWebView2ContentLoadingEventArgs e) => e.NavigationId;
    }
}

/// <summary>
/// Resolves data of the <see cref="CoreWebView2ContentLoadingEventArgs"/>.
/// </summary>
public interface ICoreWebView2ContentLoadingEventArgsResolver
{
    /// <summary>
    /// Gets a value that indicates whether the loaded content is an error page.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ContentLoadingEventArgs"/>.</param>
    /// <returns><c>true</c> if the loaded content is an error page; otherwise, <c>false</c>.</returns>
    bool IsErrorPage(CoreWebView2ContentLoadingEventArgs e);

    /// <summary>
    /// Gets the ID of the navigation.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ContentLoadingEventArgs"/>.</param>
    /// <returns>The ID of the navigation.</returns>
    ulong NavigationId(CoreWebView2ContentLoadingEventArgs e);
}