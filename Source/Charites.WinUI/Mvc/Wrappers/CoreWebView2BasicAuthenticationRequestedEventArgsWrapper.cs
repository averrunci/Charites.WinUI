// Copyright (C) 2022-2024 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.Web.WebView2.Core;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="CoreWebView2BasicAuthenticationRequestedEventArgs"/>
/// resolved by <see cref="ICoreWebView2BasicAuthenticationRequestedEventArgsResolver"/>.
/// </summary>
public static class CoreWebView2BasicAuthenticationRequestedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ICoreWebView2BasicAuthenticationRequestedEventArgsResolver"/>
    /// that resolves data of the <see cref="CoreWebView2BasicAuthenticationRequestedEventArgs"/>.
    /// </summary>
    public static ICoreWebView2BasicAuthenticationRequestedEventArgsResolver Resolver { get; set; } = new DefaultCoreWebView2BasicAuthenticationRequestedEventArgsResolver();

    /// <summary>
    /// Gets a value that indicates whether to cancel the authentication request.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2BasicAuthenticationRequestedEventArgs"/>.</param>
    /// <returns><c>true</c> if the authentication request is canceled; otherwise, <c>false</c>.</returns>
    public static bool Cancel(this CoreWebView2BasicAuthenticationRequestedEventArgs e) => Resolver.Cancel(e);

    /// <summary>
    /// Sets a value that indicates whether to cancel the authentication request.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2BasicAuthenticationRequestedEventArgs"/>.</param>
    /// <param name="cancel"><c>true</c> if the authentication request is canceled; otherwise, <c>false</c>.</param>
    public static void Cancel(this CoreWebView2BasicAuthenticationRequestedEventArgs e, bool cancel) => Resolver.Cancel(e, cancel);

    /// <summary>
    /// Gets the authentication challenge string.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2BasicAuthenticationRequestedEventArgs"/>.</param>
    /// <returns>The authentication challenge string.</returns>
    public static string Challenge(this CoreWebView2BasicAuthenticationRequestedEventArgs e) => Resolver.Challenge(e);

    /// <summary>
    /// Gets the response to the authentication request with credentials.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2BasicAuthenticationRequestedEventArgs"/>.</param>
    /// <returns>The response to the authentication request with credentials.</returns>
    public static CoreWebView2BasicAuthenticationResponse Response(this CoreWebView2BasicAuthenticationRequestedEventArgs e) => Resolver.Response(e);

    /// <summary>
    /// Gets the URI that led to the authentication challenge.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2BasicAuthenticationRequestedEventArgs"/>.</param>
    /// <returns>The URI that led to the authentication challenge.</returns>
    public static string Uri(this CoreWebView2BasicAuthenticationRequestedEventArgs e) => Resolver.Uri(e);

    /// <summary>
    /// Gets a <see cref="CoreWebView2Deferral"/> object.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2BasicAuthenticationRequestedEventArgs"/>.</param>
    /// <returns>A <see cref="CoreWebView2Deferral"/> object.</returns>
    public static CoreWebView2Deferral GetDeferralWrapped(this CoreWebView2BasicAuthenticationRequestedEventArgs e) => Resolver.GetDeferral(e);

    private sealed class DefaultCoreWebView2BasicAuthenticationRequestedEventArgsResolver : ICoreWebView2BasicAuthenticationRequestedEventArgsResolver
    {
        bool ICoreWebView2BasicAuthenticationRequestedEventArgsResolver.Cancel(CoreWebView2BasicAuthenticationRequestedEventArgs e) => e.Cancel;
        void ICoreWebView2BasicAuthenticationRequestedEventArgsResolver.Cancel(CoreWebView2BasicAuthenticationRequestedEventArgs e, bool cancel) => e.Cancel = cancel;
        string ICoreWebView2BasicAuthenticationRequestedEventArgsResolver.Challenge(CoreWebView2BasicAuthenticationRequestedEventArgs e) => e.Challenge;
        CoreWebView2BasicAuthenticationResponse ICoreWebView2BasicAuthenticationRequestedEventArgsResolver.Response(CoreWebView2BasicAuthenticationRequestedEventArgs e) => e.Response;
        string ICoreWebView2BasicAuthenticationRequestedEventArgsResolver.Uri(CoreWebView2BasicAuthenticationRequestedEventArgs e) => e.Uri;
        CoreWebView2Deferral ICoreWebView2BasicAuthenticationRequestedEventArgsResolver.GetDeferral(CoreWebView2BasicAuthenticationRequestedEventArgs e) => e.GetDeferral();
    }
}

/// <summary>
/// Resolves data of the <see cref="CoreWebView2BasicAuthenticationRequestedEventArgs"/>.
/// </summary>
public interface ICoreWebView2BasicAuthenticationRequestedEventArgsResolver
{
    /// <summary>
    /// Gets a value that indicates whether to cancel the authentication request.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2BasicAuthenticationRequestedEventArgs"/>.</param>
    /// <returns><c>true</c> if the authentication request is canceled; otherwise, <c>false</c>.</returns>
    bool Cancel(CoreWebView2BasicAuthenticationRequestedEventArgs e);

    /// <summary>
    /// Sets a value that indicates whether to cancel the authentication request.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2BasicAuthenticationRequestedEventArgs"/>.</param>
    /// <param name="cancel"><c>true</c> if the authentication request is canceled; otherwise, <c>false</c>.</param>
    void Cancel(CoreWebView2BasicAuthenticationRequestedEventArgs e, bool cancel);

    /// <summary>
    /// Gets the authentication challenge string.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2BasicAuthenticationRequestedEventArgs"/>.</param>
    /// <returns>The authentication challenge string.</returns>
    string Challenge(CoreWebView2BasicAuthenticationRequestedEventArgs e);

    /// <summary>
    /// Gets the response to the authentication request with credentials.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2BasicAuthenticationRequestedEventArgs"/>.</param>
    /// <returns>The response to the authentication request with credentials.</returns>
    CoreWebView2BasicAuthenticationResponse Response(CoreWebView2BasicAuthenticationRequestedEventArgs e);

    /// <summary>
    /// Gets the URI that led to the authentication challenge.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2BasicAuthenticationRequestedEventArgs"/>.</param>
    /// <returns>The URI that led to the authentication challenge.</returns>
    string Uri(CoreWebView2BasicAuthenticationRequestedEventArgs e);

    /// <summary>
    /// Gets a <see cref="CoreWebView2Deferral"/> object.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2BasicAuthenticationRequestedEventArgs"/>.</param>
    /// <returns>A <see cref="CoreWebView2Deferral"/> object.</returns>
    CoreWebView2Deferral GetDeferral(CoreWebView2BasicAuthenticationRequestedEventArgs e);
}