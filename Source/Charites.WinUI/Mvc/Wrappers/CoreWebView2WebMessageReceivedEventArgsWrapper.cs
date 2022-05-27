// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.Web.WebView2.Core;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="CoreWebView2WebMessageReceivedEventArgs"/>
/// resolved by <see cref="ICoreWebView2WebMessageReceivedEventArgsResolver"/>.
/// </summary>
public static class CoreWebView2WebMessageReceivedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ICoreWebView2WebMessageReceivedEventArgsResolver"/>
    /// that resolves data of the <see cref="CoreWebView2WebMessageReceivedEventArgs"/>.
    /// </summary>
    public static ICoreWebView2WebMessageReceivedEventArgsResolver Resolver { get; set; } = new DefaultCoreWebView2WebMessageReceivedEventArgsResolver();

    /// <summary>
    /// Gets the URI of the document that sent this web message.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2WebMessageReceivedEventArgs"/>.</param>
    /// <returns>The URI of the document that sent this web message.</returns>
    public static string Source(this CoreWebView2WebMessageReceivedEventArgs e) => Resolver.Source(e);

    /// <summary>
    /// Gets the message posted from the WebView content to the host converted to a JSON string.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2WebMessageReceivedEventArgs"/>.</param>
    /// <returns>The message posted from the WebView content to the host converted to a JSON string.</returns>
    public static string WebMessageAsJson(this CoreWebView2WebMessageReceivedEventArgs e) => Resolver.WebMessageAsJson(e);

    /// <summary>
    /// Gets the message posted from the WebView content to the host as a string.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2WebMessageReceivedEventArgs"/>.</param>
    /// <returns>The message posted from the WebView content to the host as a string.</returns>
    public static string TryGetWebMessageAsStringWrapped(this CoreWebView2WebMessageReceivedEventArgs e) => Resolver.TryGetWebMessageAsString(e);

    private sealed class DefaultCoreWebView2WebMessageReceivedEventArgsResolver : ICoreWebView2WebMessageReceivedEventArgsResolver
    {
        string ICoreWebView2WebMessageReceivedEventArgsResolver.Source(CoreWebView2WebMessageReceivedEventArgs e) => e.Source;
        string ICoreWebView2WebMessageReceivedEventArgsResolver.WebMessageAsJson(CoreWebView2WebMessageReceivedEventArgs e) => e.WebMessageAsJson;
        string ICoreWebView2WebMessageReceivedEventArgsResolver.TryGetWebMessageAsString(CoreWebView2WebMessageReceivedEventArgs e) => e.TryGetWebMessageAsString();
    }
}

/// <summary>
/// Resolves data of the <see cref="CoreWebView2WebMessageReceivedEventArgs"/>.
/// </summary>
public interface ICoreWebView2WebMessageReceivedEventArgsResolver
{
    /// <summary>
    /// Gets the URI of the document that sent this web message.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2WebMessageReceivedEventArgs"/>.</param>
    /// <returns>The URI of the document that sent this web message.</returns>
    string Source(CoreWebView2WebMessageReceivedEventArgs e);

    /// <summary>
    /// Gets the message posted from the WebView content to the host converted to a JSON string.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2WebMessageReceivedEventArgs"/>.</param>
    /// <returns>The message posted from the WebView content to the host converted to a JSON string.</returns>
    string WebMessageAsJson(CoreWebView2WebMessageReceivedEventArgs e);

    /// <summary>
    /// Gets the message posted from the WebView content to the host as a string.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2WebMessageReceivedEventArgs"/>.</param>
    /// <returns>The message posted from the WebView content to the host as a string.</returns>
    string TryGetWebMessageAsString(CoreWebView2WebMessageReceivedEventArgs e);
}