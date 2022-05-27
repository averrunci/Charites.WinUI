// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.Web.WebView2.Core;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="CoreWebView2NavigationStartingEventArgs"/>
/// resolved by <see cref="ICoreWebView2NavigationStartingEventArgsResolver"/>.
/// </summary>
public static class CoreWebView2NavigationStartingEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ICoreWebView2NavigationStartingEventArgsResolver"/>
    /// that resolves data of the <see cref="CoreWebView2NavigationStartingEventArgs"/>.
    /// </summary>
    public static ICoreWebView2NavigationStartingEventArgsResolver Resolver { get; set; } = new DefaultCoreWebView2NavigationStartingEventArgsResolver();

    /// <summary>
    /// Gets a value that indicates whether to cancel the navigation.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NavigationStartingEventArgs"/>.</param>
    /// <returns><c>true</c> if the navigation is canceled; otherwise, <c>false</c>.</returns>
    public static bool Cancel(this CoreWebView2NavigationStartingEventArgs e) => Resolver.Cancel(e);

    /// <summary>
    /// Sets a value that indicates whether to cancel the navigation.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NavigationStartingEventArgs"/>.</param>
    /// <param name="cancel"><c>true</c> if the navigation is canceled; otherwise, <c>false</c>.</param>
    public static void Cancel(this CoreWebView2NavigationStartingEventArgs e, bool cancel) => Resolver.Cancel(e, cancel);

    /// <summary>
    /// Gets a value that indicates whether the navigation is redirected.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NavigationStartingEventArgs"/>.</param>
    /// <returns><c>true</c> if the navigation is redirected; otherwise, <c>false</c>.</returns>
    public static bool IsRedirected(this CoreWebView2NavigationStartingEventArgs e) => Resolver.IsRedirected(e);

    /// <summary>
    /// Gets a value that indicates whether the new window request was initiated through a user gesture.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NavigationStartingEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> if the new window request was initiated through a user gesture.
    /// </returns>
    public static bool IsUserInitiated(this CoreWebView2NavigationStartingEventArgs e) => Resolver.IsUserInitiated(e);

    /// <summary>
    /// Gets the ID of the navigation.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NavigationStartingEventArgs"/>.</param>
    /// <returns>The ID of the navigation.</returns>
    public static ulong NavigationId(this CoreWebView2NavigationStartingEventArgs e) => Resolver.NavigationId(e);

    /// <summary>
    /// Gets the HTTP request headers for the navigation.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NavigationStartingEventArgs"/>.</param>
    /// <returns>The HTTP request headers for the navigation.</returns>
    public static CoreWebView2HttpRequestHeaders RequestHeaders(this CoreWebView2NavigationStartingEventArgs e) => Resolver.RequestHeaders(e);

    /// <summary>
    /// Gets the uri of the requested navigation.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NavigationStartingEventArgs"/>.</param>
    /// <returns>The uri of the requested navigation.</returns>
    public static string Uri(this CoreWebView2NavigationStartingEventArgs e) => Resolver.Uri(e);

    private sealed class DefaultCoreWebView2NavigationStartingEventArgsResolver : ICoreWebView2NavigationStartingEventArgsResolver
    {
        bool ICoreWebView2NavigationStartingEventArgsResolver.Cancel(CoreWebView2NavigationStartingEventArgs e) => e.Cancel;
        void ICoreWebView2NavigationStartingEventArgsResolver.Cancel(CoreWebView2NavigationStartingEventArgs e, bool cancel) => e.Cancel = cancel;
        bool ICoreWebView2NavigationStartingEventArgsResolver.IsRedirected(CoreWebView2NavigationStartingEventArgs e) => e.IsRedirected;
        bool ICoreWebView2NavigationStartingEventArgsResolver.IsUserInitiated(CoreWebView2NavigationStartingEventArgs e) => e.IsUserInitiated;
        ulong ICoreWebView2NavigationStartingEventArgsResolver.NavigationId(CoreWebView2NavigationStartingEventArgs e) => e.NavigationId;
        CoreWebView2HttpRequestHeaders ICoreWebView2NavigationStartingEventArgsResolver.RequestHeaders(CoreWebView2NavigationStartingEventArgs e) => e.RequestHeaders;
        string ICoreWebView2NavigationStartingEventArgsResolver.Uri(CoreWebView2NavigationStartingEventArgs e) => e.Uri;
    }
}

/// <summary>
/// Resolves data of the <see cref="CoreWebView2NavigationStartingEventArgs"/>.
/// </summary>
public interface ICoreWebView2NavigationStartingEventArgsResolver
{
    /// <summary>
    /// Gets a value that indicates whether to cancel the navigation.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NavigationStartingEventArgs"/>.</param>
    /// <returns><c>true</c> if the navigation is canceled; otherwise, <c>false</c>.</returns>
    bool Cancel(CoreWebView2NavigationStartingEventArgs e);

    /// <summary>
    /// Sets a value that indicates whether to cancel the navigation.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NavigationStartingEventArgs"/>.</param>
    /// <param name="cancel"><c>true</c> if the navigation is canceled; otherwise, <c>false</c>.</param>
    void Cancel(CoreWebView2NavigationStartingEventArgs e, bool cancel);

    /// <summary>
    /// Gets a value that indicates whether the navigation is redirected.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NavigationStartingEventArgs"/>.</param>
    /// <returns><c>true</c> if the navigation is redirected; otherwise, <c>false</c>.</returns>
    bool IsRedirected(CoreWebView2NavigationStartingEventArgs e);

    /// <summary>
    /// Gets a value that indicates whether the new window request was initiated through a user gesture.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NavigationStartingEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> if the new window request was initiated through a user gesture.
    /// </returns>
    bool IsUserInitiated(CoreWebView2NavigationStartingEventArgs e);

    /// <summary>
    /// Gets the ID of the navigation.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NavigationStartingEventArgs"/>.</param>
    /// <returns>The ID of the navigation.</returns>
    ulong NavigationId(CoreWebView2NavigationStartingEventArgs e);

    /// <summary>
    /// Gets the HTTP request headers for the navigation.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NavigationStartingEventArgs"/>.</param>
    /// <returns>The HTTP request headers for the navigation.</returns>
    CoreWebView2HttpRequestHeaders RequestHeaders(CoreWebView2NavigationStartingEventArgs e);

    /// <summary>
    /// Gets the uri of the requested navigation.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NavigationStartingEventArgs"/>.</param>
    /// <returns>The uri of the requested navigation.</returns>
    string Uri(CoreWebView2NavigationStartingEventArgs e);
}