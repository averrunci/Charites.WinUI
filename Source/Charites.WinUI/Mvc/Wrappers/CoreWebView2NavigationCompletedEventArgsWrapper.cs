// Copyright (C) 2022-2023 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.Web.WebView2.Core;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="CoreWebView2NavigationCompletedEventArgs"/>
/// resolved by <see cref="ICoreWebView2NavigationCompletedEventArgsResolver"/>.
/// </summary>
public static class CoreWebView2NavigationCompletedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ICoreWebView2NavigationCompletedEventArgsResolver"/>
    /// that resolves data of the <see cref="CoreWebView2NavigationCompletedEventArgs"/>.
    /// </summary>
    public static ICoreWebView2NavigationCompletedEventArgsResolver Resolver { get; set; } = new DefaultCoreWebView2NavigationCompletedEventArgsResolver();

    /// <summary>
    /// Gets the HTTP status code of the navigation.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NavigationCompletedEventArgs"/>.</param>
    /// <returns>
    /// The HTTP status code of the navigation if it involved an HTTP request.
    /// </returns>
    public static int HttpStatusCode(this CoreWebView2NavigationCompletedEventArgs e) => Resolver.HttpStatusCode(e);

    /// <summary>
    /// Gets a value that indicates whether the navigation is successful.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NavigationCompletedEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> if the navigation is successful.
    /// <c>false</c> for a navigation that ended up in an error page (failures due to no network,
    /// DNS lookup failure, HTTP server responds with 4xx).
    /// </returns>
    public static bool IsSuccess(this CoreWebView2NavigationCompletedEventArgs e) => Resolver.IsSuccess(e);

    /// <summary>
    /// Gets the ID of the navigation.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NavigationCompletedEventArgs"/>.</param>
    /// <returns>The ID of the navigation.</returns>
    public static ulong NavigationId(this CoreWebView2NavigationCompletedEventArgs e) => Resolver.NavigationId(e);

    /// <summary>
    /// Gets the error code if the navigation failed.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NavigationCompletedEventArgs"/>.</param>
    /// <returns>The error code if the navigation failed.</returns>
    public static CoreWebView2WebErrorStatus WebErrorStatus(this CoreWebView2NavigationCompletedEventArgs e) => Resolver.WebErrorStatus(e);

    private sealed class DefaultCoreWebView2NavigationCompletedEventArgsResolver : ICoreWebView2NavigationCompletedEventArgsResolver
    {
        int ICoreWebView2NavigationCompletedEventArgsResolver.HttpStatusCode(CoreWebView2NavigationCompletedEventArgs e) => e.HttpStatusCode;
        bool ICoreWebView2NavigationCompletedEventArgsResolver.IsSuccess(CoreWebView2NavigationCompletedEventArgs e) => e.IsSuccess;
        ulong ICoreWebView2NavigationCompletedEventArgsResolver.NavigationId(CoreWebView2NavigationCompletedEventArgs e) => e.NavigationId;
        CoreWebView2WebErrorStatus ICoreWebView2NavigationCompletedEventArgsResolver.WebErrorStatus(CoreWebView2NavigationCompletedEventArgs e) => e.WebErrorStatus;
    }
}

/// <summary>
/// Resolves data of the <see cref="CoreWebView2NavigationCompletedEventArgs"/>.
/// </summary>
public interface ICoreWebView2NavigationCompletedEventArgsResolver
{
    /// <summary>
    /// Gets the HTTP status code of the navigation.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NavigationCompletedEventArgs"/>.</param>
    /// <returns>
    /// The HTTP status code of the navigation if it involved an HTTP request.
    /// </returns>
    int HttpStatusCode(CoreWebView2NavigationCompletedEventArgs e);

    /// <summary>
    /// Gets a value that indicates whether the navigation is successful.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NavigationCompletedEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> if the navigation is successful.
    /// <c>false</c> for a navigation that ended up in an error page (failures due to no network,
    /// DNS lookup failure, HTTP server responds with 4xx).
    /// </returns>
    bool IsSuccess(CoreWebView2NavigationCompletedEventArgs e);

    /// <summary>
    /// Gets the ID of the navigation.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NavigationCompletedEventArgs"/>.</param>
    /// <returns>The ID of the navigation.</returns>
    ulong NavigationId(CoreWebView2NavigationCompletedEventArgs e);

    /// <summary>
    /// Gets the error code if the navigation failed.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NavigationCompletedEventArgs"/>.</param>
    /// <returns>The error code if the navigation failed.</returns>
    CoreWebView2WebErrorStatus WebErrorStatus(CoreWebView2NavigationCompletedEventArgs e);
}