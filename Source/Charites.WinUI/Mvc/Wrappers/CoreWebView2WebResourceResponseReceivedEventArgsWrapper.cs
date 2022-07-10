// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.Web.WebView2.Core;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="CoreWebView2WebResourceResponseReceivedEventArgs"/>
/// resolved by <see cref="ICoreWebView2WebResourceResponseReceivedEventArgsResolver"/>.
/// </summary>
public static class CoreWebView2WebResourceResponseReceivedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ICoreWebView2WebResourceResponseReceivedEventArgsResolver"/>
    /// that resolves data of the <see cref="CoreWebView2WebResourceResponseReceivedEventArgs"/>.
    /// </summary>
    public static ICoreWebView2WebResourceResponseReceivedEventArgsResolver Resolver { get; set; } = new DefaultCoreWebView2WebResourceResponseReceivedEventArgsResolver();

    /// <summary>
    /// Gets the request object for the web resource, as committed.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2WebResourceResponseReceivedEventArgs"/>.</param>
    /// <returns>The request object for the web resource, as committed.</returns>
    public static CoreWebView2WebResourceRequest Request(this CoreWebView2WebResourceResponseReceivedEventArgs e) => Resolver.Request(e);

    /// <summary>
    /// Gets the view of the response object received for the web resource.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2WebResourceResponseReceivedEventArgs"/>.</param>
    /// <returns>The view of the response object received for the web resource.</returns>
    public static CoreWebView2WebResourceResponseView Response(this CoreWebView2WebResourceResponseReceivedEventArgs e) => Resolver.Response(e);

    private sealed class DefaultCoreWebView2WebResourceResponseReceivedEventArgsResolver : ICoreWebView2WebResourceResponseReceivedEventArgsResolver
    {
        CoreWebView2WebResourceRequest ICoreWebView2WebResourceResponseReceivedEventArgsResolver.Request(CoreWebView2WebResourceResponseReceivedEventArgs e) => e.Request;
        CoreWebView2WebResourceResponseView ICoreWebView2WebResourceResponseReceivedEventArgsResolver.Response(CoreWebView2WebResourceResponseReceivedEventArgs e) => e.Response;
    }
}

/// <summary>
/// Resolves data of the <see cref="CoreWebView2WebResourceResponseReceivedEventArgs"/>.
/// </summary>
public interface ICoreWebView2WebResourceResponseReceivedEventArgsResolver
{
    /// <summary>
    /// Gets the request object for the web resource, as committed.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2WebResourceResponseReceivedEventArgs"/>.</param>
    /// <returns>The request object for the web resource, as committed.</returns>
    CoreWebView2WebResourceRequest Request(CoreWebView2WebResourceResponseReceivedEventArgs e);

    /// <summary>
    /// Gets the view of the response object received for the web resource.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2WebResourceResponseReceivedEventArgs"/>.</param>
    /// <returns>The view of the response object received for the web resource.</returns>
    CoreWebView2WebResourceResponseView Response(CoreWebView2WebResourceResponseReceivedEventArgs e);
}