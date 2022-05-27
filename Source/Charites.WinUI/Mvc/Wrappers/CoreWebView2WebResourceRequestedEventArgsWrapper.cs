// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.Foundation;
using Microsoft.Web.WebView2.Core;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="CoreWebView2WebResourceRequestedEventArgs"/>
/// resolved by <see cref="ICoreWebView2WebResourceRequestedEventArgsResolver"/>.
/// </summary>
public static class CoreWebView2WebResourceRequestedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ICoreWebView2WebResourceRequestedEventArgsResolver"/>
    /// that resolves data of the <see cref="CoreWebView2WebResourceRequestedEventArgs"/>.
    /// </summary>
    public static ICoreWebView2WebResourceRequestedEventArgsResolver Resolver { get; set; } = new DefaultCoreWebView2WebResourceRequestedEventArgsResolver();

    /// <summary>
    /// Gets the web resource request.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2WebResourceRequestedEventArgs"/>.</param>
    /// <returns>The web resource request.</returns>
    public static CoreWebView2WebResourceRequest Request(this CoreWebView2WebResourceRequestedEventArgs e) => Resolver.Request(e);

    /// <summary>
    /// Gets the web resource request context.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2WebResourceRequestedEventArgs"/>.</param>
    /// <returns>The web resource request context.</returns>
    public static CoreWebView2WebResourceContext ResourceContext(this CoreWebView2WebResourceRequestedEventArgs e) => Resolver.ResourceContext(e);

    /// <summary>
    /// Gets the <see cref="CoreWebView2WebResourceResponse"/> object.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2WebResourceRequestedEventArgs"/>.</param>
    /// <returns>The <see cref="CoreWebView2WebResourceResponse"/> object.</returns>
    public static CoreWebView2WebResourceResponse Response(this CoreWebView2WebResourceRequestedEventArgs e) => Resolver.Response(e);

    /// <summary>
    /// Sets the <see cref="CoreWebView2WebResourceResponse"/> object.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2WebResourceRequestedEventArgs"/>.</param>
    /// <param name="response">The <see cref="CoreWebView2WebResourceResponse"/> object.</param>
    public static void Response(this CoreWebView2WebResourceRequestedEventArgs e, CoreWebView2WebResourceResponse response) => Resolver.Response(e, response);

    /// <summary>
    /// Gets a <see cref="Deferral"/> object.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2WebResourceRequestedEventArgs"/>.</param>
    /// <returns>A <see cref="Deferral"/> object.</returns>
    public static Deferral GetDeferralWrapped(this CoreWebView2WebResourceRequestedEventArgs e) => Resolver.GetDeferral(e);

    private sealed class DefaultCoreWebView2WebResourceRequestedEventArgsResolver : ICoreWebView2WebResourceRequestedEventArgsResolver
    {
        CoreWebView2WebResourceRequest ICoreWebView2WebResourceRequestedEventArgsResolver.Request(CoreWebView2WebResourceRequestedEventArgs e) => e.Request;
        CoreWebView2WebResourceContext ICoreWebView2WebResourceRequestedEventArgsResolver.ResourceContext(CoreWebView2WebResourceRequestedEventArgs e) => e.ResourceContext;
        CoreWebView2WebResourceResponse ICoreWebView2WebResourceRequestedEventArgsResolver.Response(CoreWebView2WebResourceRequestedEventArgs e) => e.Response;
        void ICoreWebView2WebResourceRequestedEventArgsResolver.Response(CoreWebView2WebResourceRequestedEventArgs e, CoreWebView2WebResourceResponse response) => e.Response = response;
        Deferral ICoreWebView2WebResourceRequestedEventArgsResolver.GetDeferral(CoreWebView2WebResourceRequestedEventArgs e) => e.GetDeferral();
    }
}

/// <summary>
/// Resolves data of the <see cref="CoreWebView2WebResourceRequestedEventArgs"/>.
/// </summary>
public interface ICoreWebView2WebResourceRequestedEventArgsResolver
{
    /// <summary>
    /// Gets the web resource request.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2WebResourceRequestedEventArgs"/>.</param>
    /// <returns>The web resource request.</returns>
    CoreWebView2WebResourceRequest Request(CoreWebView2WebResourceRequestedEventArgs e);

    /// <summary>
    /// Gets the web resource request context.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2WebResourceRequestedEventArgs"/>.</param>
    /// <returns>The web resource request context.</returns>
    CoreWebView2WebResourceContext ResourceContext(CoreWebView2WebResourceRequestedEventArgs e);

    /// <summary>
    /// Gets the <see cref="CoreWebView2WebResourceResponse"/> object.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2WebResourceRequestedEventArgs"/>.</param>
    /// <returns>The <see cref="CoreWebView2WebResourceResponse"/> object.</returns>
    CoreWebView2WebResourceResponse Response(CoreWebView2WebResourceRequestedEventArgs e);

    /// <summary>
    /// Sets the <see cref="CoreWebView2WebResourceResponse"/> object.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2WebResourceRequestedEventArgs"/>.</param>
    /// <param name="response">The <see cref="CoreWebView2WebResourceResponse"/> object.</param>
    void Response(CoreWebView2WebResourceRequestedEventArgs e, CoreWebView2WebResourceResponse response);

    /// <summary>
    /// Gets a <see cref="Deferral"/> object.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2WebResourceRequestedEventArgs"/>.</param>
    /// <returns>A <see cref="Deferral"/> object.</returns>
    Deferral GetDeferral(CoreWebView2WebResourceRequestedEventArgs e);
}