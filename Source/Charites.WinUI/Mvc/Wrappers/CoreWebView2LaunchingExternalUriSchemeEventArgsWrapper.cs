// Copyright (C) 2023 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.Foundation;
using Microsoft.Web.WebView2.Core;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="CoreWebView2LaunchingExternalUriSchemeEventArgs"/>
/// resolved by <see cref="ICoreWebView2LaunchingExternalUriSchemeEventArgsResolver"/>.
/// </summary>
public static class CoreWebView2LaunchingExternalUriSchemeEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ICoreWebView2LaunchingExternalUriSchemeEventArgsResolver"/>
    /// that resolves data of the <see cref="CoreWebView2LaunchingExternalUriSchemeEventArgs"/>.
    /// </summary>
    public static ICoreWebView2LaunchingExternalUriSchemeEventArgsResolver Resolver { get; set; } = new DefaultCoreWebView2LaunchingExternalUriSchemeEventArgsResolver();

    /// <summary>
    /// Gets a value that indicates whether to cancel the navigation.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2LaunchingExternalUriSchemeEventArgs"/>.</param>
    /// <returns><c>true</c> if the navigation is canceled; otherwise, <c>false</c>.</returns>
    public static bool Cancel(this CoreWebView2LaunchingExternalUriSchemeEventArgs e) => Resolver.Cancel(e);

    /// <summary>
    /// Sets a value that indicates whether to cancel the navigation.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2LaunchingExternalUriSchemeEventArgs"/>.</param>
    /// <param name="cancel"><c>true</c> if the navigation is canceled; otherwise, <c>false</c>.</param>
    public static void Cancel(this CoreWebView2LaunchingExternalUriSchemeEventArgs e, bool cancel) => Resolver.Cancel(e, cancel);

    /// <summary>
    /// Gets the origin initiating the external URI scheme launch.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2LaunchingExternalUriSchemeEventArgs"/>.</param>
    /// <returns>The origin initiating the external URI scheme launch.</returns>
    public static string InitiatingOrigin(this CoreWebView2LaunchingExternalUriSchemeEventArgs e) => Resolver.InitiatingOrigin(e);

    /// <summary>
    /// Gets a value that indicates whether to initiate the launching external URI scheme request through a user gesture.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2LaunchingExternalUriSchemeEventArgs"/>.</param>
    /// <returns><c>true</c> if the launching external URI scheme request is initiated through a user gesture; otherwise, <c>false</c>.</returns>
    public static bool IsUserInitiated(this CoreWebView2LaunchingExternalUriSchemeEventArgs e) => Resolver.IsUserInitiated(e);

    /// <summary>
    /// Gets the URI with the external URI scheme to be launched.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2LaunchingExternalUriSchemeEventArgs"/>.</param>
    /// <returns>The URI with the external URI scheme to be launched.</returns>
    public static string Uri(this CoreWebView2LaunchingExternalUriSchemeEventArgs e) => Resolver.Uri(e);

    /// <summary>
    /// Gets a <see cref="Deferral"/> object and put the event into a deferred state.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2LaunchingExternalUriSchemeEventArgs"/>.</param>
    /// <returns>A <see cref="Deferral"/> object.</returns>
    public static Deferral GetDeferralWrapped(this CoreWebView2LaunchingExternalUriSchemeEventArgs e) => Resolver.GetDeferralWrapped(e);

    private sealed class DefaultCoreWebView2LaunchingExternalUriSchemeEventArgsResolver : ICoreWebView2LaunchingExternalUriSchemeEventArgsResolver
    {
        bool ICoreWebView2LaunchingExternalUriSchemeEventArgsResolver.Cancel(CoreWebView2LaunchingExternalUriSchemeEventArgs e) => e.Cancel;
        void ICoreWebView2LaunchingExternalUriSchemeEventArgsResolver.Cancel(CoreWebView2LaunchingExternalUriSchemeEventArgs e, bool cancel) => e.Cancel = cancel;
        string ICoreWebView2LaunchingExternalUriSchemeEventArgsResolver.InitiatingOrigin(CoreWebView2LaunchingExternalUriSchemeEventArgs e) => e.InitiatingOrigin;
        bool ICoreWebView2LaunchingExternalUriSchemeEventArgsResolver.IsUserInitiated(CoreWebView2LaunchingExternalUriSchemeEventArgs e) => e.IsUserInitiated;
        string ICoreWebView2LaunchingExternalUriSchemeEventArgsResolver.Uri(CoreWebView2LaunchingExternalUriSchemeEventArgs e) => e.Uri;
        Deferral ICoreWebView2LaunchingExternalUriSchemeEventArgsResolver.GetDeferralWrapped(CoreWebView2LaunchingExternalUriSchemeEventArgs e) => e.GetDeferral();
    }
}

/// <summary>
/// Resolves data of the <see cref="CoreWebView2LaunchingExternalUriSchemeEventArgs"/>.
/// </summary>
public interface ICoreWebView2LaunchingExternalUriSchemeEventArgsResolver
{
    /// <summary>
    /// Gets a value that indicates whether to cancel the navigation.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2LaunchingExternalUriSchemeEventArgs"/>.</param>
    /// <returns><c>true</c> if the navigation is canceled; otherwise, <c>false</c>.</returns>
    bool Cancel(CoreWebView2LaunchingExternalUriSchemeEventArgs e);

    /// <summary>
    /// Sets a value that indicates whether to cancel the navigation.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2LaunchingExternalUriSchemeEventArgs"/>.</param>
    /// <param name="cancel"><c>true</c> if the navigation is canceled; otherwise, <c>false</c>.</param>
    void Cancel(CoreWebView2LaunchingExternalUriSchemeEventArgs e, bool cancel);

    /// <summary>
    /// Gets the origin initiating the external URI scheme launch.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2LaunchingExternalUriSchemeEventArgs"/>.</param>
    /// <returns>The origin initiating the external URI scheme launch.</returns>
    string InitiatingOrigin(CoreWebView2LaunchingExternalUriSchemeEventArgs e);

    /// <summary>
    /// Gets a value that indicates whether to initiate the launching external URI scheme request through a user gesture.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2LaunchingExternalUriSchemeEventArgs"/>.</param>
    /// <returns><c>true</c> if the launching external URI scheme request is initiated through a user gesture; otherwise, <c>false</c>.</returns>
    bool IsUserInitiated(CoreWebView2LaunchingExternalUriSchemeEventArgs e);

    /// <summary>
    /// Gets the URI with the external URI scheme to be launched.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2LaunchingExternalUriSchemeEventArgs"/>.</param>
    /// <returns>The URI with the external URI scheme to be launched.</returns>
    string Uri(CoreWebView2LaunchingExternalUriSchemeEventArgs e);

    /// <summary>
    /// Gets a <see cref="Deferral"/> object and put the event into a deferred state.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2LaunchingExternalUriSchemeEventArgs"/>.</param>
    /// <returns>A <see cref="Deferral"/> object.</returns>
    Deferral GetDeferralWrapped(CoreWebView2LaunchingExternalUriSchemeEventArgs e);
}