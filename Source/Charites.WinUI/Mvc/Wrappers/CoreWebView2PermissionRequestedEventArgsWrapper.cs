// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.Foundation;
using Microsoft.Web.WebView2.Core;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="CoreWebView2PermissionRequestedEventArgs"/>
/// resolved by <see cref="ICoreWebView2PermissionRequestedEventArgsResolver"/>.
/// </summary>
public static class CoreWebView2PermissionRequestedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ICoreWebView2PermissionRequestedEventArgsResolver"/>
    /// that resolves data of the <see cref="CoreWebView2PermissionRequestedEventArgs"/>.
    /// </summary>
    public static ICoreWebView2PermissionRequestedEventArgsResolver Resolver { get; set; } = new DefaultCoreWebView2PermissionRequestedEventArgsResolver();

    /// <summary>
    /// Gets a value that indicates whether the request is handled.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2PermissionRequestedEventArgs"/>.</param>
    /// <returns><c>true</c> if the request is handled; otherwise, <c>false</c>.</returns>
    public static bool Handled(this CoreWebView2PermissionRequestedEventArgs e) => Resolver.Handled(e);

    /// <summary>
    /// Sets a value that indicates whether the request is handled.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2PermissionRequestedEventArgs"/>.</param>
    /// <param name="handled"><c>true</c> if the request is handled; otherwise, <c>false</c>.</param>
    public static void Handled(this CoreWebView2PermissionRequestedEventArgs e, bool handled) => Resolver.Handled(e, handled);

    /// <summary>
    /// Gets a value that indicates whether the permission request was initiated through a user gesture
    /// such as clicking an anchor tag with target.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2PermissionRequestedEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> if the permission request was initiated through a user gesture such as clicking an anchor tag
    /// with target; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsUserInitiated(this CoreWebView2PermissionRequestedEventArgs e) => Resolver.IsUserInitiated(e);

    /// <summary>
    /// Gets the kind of the permission that is requested.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2PermissionRequestedEventArgs"/>.</param>
    /// <returns>The kind of the permission that is requested.</returns>
    public static CoreWebView2PermissionKind PermissionKind(this CoreWebView2PermissionRequestedEventArgs e) => Resolver.PermissionKind(e);

    /// <summary>
    /// Gets the status of a permission request. For example, whether the request is ignored.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2PermissionRequestedEventArgs"/>.</param>
    /// <returns>The status of a permission request.</returns>
    public static CoreWebView2PermissionState State(this CoreWebView2PermissionRequestedEventArgs e) => Resolver.State(e);

    /// <summary>
    /// Sets the status of a permission request. For example, whether the request is ignored.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2PermissionRequestedEventArgs"/>.</param>
    /// <param name="state">The status of a permission request.</param>
    public static void State(this CoreWebView2PermissionRequestedEventArgs e, CoreWebView2PermissionState state) => Resolver.State(e, state);

    /// <summary>
    /// Gets the origin of the web content that requests the permission.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2PermissionRequestedEventArgs"/>.</param>
    /// <returns>The origin of the web content that requests the permission.</returns>
    public static string Uri(this CoreWebView2PermissionRequestedEventArgs e) => Resolver.Uri(e);

    /// <summary>
    /// Gets a <see cref="Deferral"/> object.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2PermissionRequestedEventArgs"/>.</param>
    /// <returns>A <see cref="Deferral"/> object.</returns>
    public static Deferral GetDeferralWrapped(this CoreWebView2PermissionRequestedEventArgs e) => Resolver.GetDeferral(e);

    private sealed class DefaultCoreWebView2PermissionRequestedEventArgsResolver : ICoreWebView2PermissionRequestedEventArgsResolver
    {
        bool ICoreWebView2PermissionRequestedEventArgsResolver.Handled(CoreWebView2PermissionRequestedEventArgs e) => e.Handled;
        void ICoreWebView2PermissionRequestedEventArgsResolver.Handled(CoreWebView2PermissionRequestedEventArgs e, bool handled) => e.Handled = handled;
        bool ICoreWebView2PermissionRequestedEventArgsResolver.IsUserInitiated(CoreWebView2PermissionRequestedEventArgs e) => e.IsUserInitiated;
        CoreWebView2PermissionKind ICoreWebView2PermissionRequestedEventArgsResolver.PermissionKind(CoreWebView2PermissionRequestedEventArgs e) => e.PermissionKind;
        CoreWebView2PermissionState ICoreWebView2PermissionRequestedEventArgsResolver.State(CoreWebView2PermissionRequestedEventArgs e) => e.State;
        void ICoreWebView2PermissionRequestedEventArgsResolver.State(CoreWebView2PermissionRequestedEventArgs e, CoreWebView2PermissionState state) => e.State = state;
        string ICoreWebView2PermissionRequestedEventArgsResolver.Uri(CoreWebView2PermissionRequestedEventArgs e) => e.Uri;
        Deferral ICoreWebView2PermissionRequestedEventArgsResolver.GetDeferral(CoreWebView2PermissionRequestedEventArgs e) => e.GetDeferral();
    }
}

/// <summary>
/// Resolves data of the <see cref="CoreWebView2PermissionRequestedEventArgs"/>.
/// </summary>
public interface ICoreWebView2PermissionRequestedEventArgsResolver
{
    /// <summary>
    /// Gets a value that indicates whether the request is handled.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2PermissionRequestedEventArgs"/>.</param>
    /// <returns><c>true</c> if the request is handled; otherwise, <c>false</c>.</returns>
    bool Handled(CoreWebView2PermissionRequestedEventArgs e);

    /// <summary>
    /// Sets a value that indicates whether the request is handled.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2PermissionRequestedEventArgs"/>.</param>
    /// <param name="handled"><c>true</c> if the request is handled; otherwise, <c>false</c>.</param>
    void Handled(CoreWebView2PermissionRequestedEventArgs e, bool handled);

    /// <summary>
    /// Gets a value that indicates whether the permission request was initiated through a user gesture
    /// such as clicking an anchor tag with target.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2PermissionRequestedEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> if the permission request was initiated through a user gesture such as clicking an anchor tag
    /// with target; otherwise, <c>false</c>.
    /// </returns>
    bool IsUserInitiated(CoreWebView2PermissionRequestedEventArgs e);

    /// <summary>
    /// Gets the kind of the permission that is requested.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2PermissionRequestedEventArgs"/>.</param>
    /// <returns>The kind of the permission that is requested.</returns>
    CoreWebView2PermissionKind PermissionKind(CoreWebView2PermissionRequestedEventArgs e);

    /// <summary>
    /// Gets the status of a permission request. For example, whether the request is ignored.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2PermissionRequestedEventArgs"/>.</param>
    /// <returns>The status of a permission request.</returns>
    CoreWebView2PermissionState State(CoreWebView2PermissionRequestedEventArgs e);

    /// <summary>
    /// Sets the status of a permission request. For example, whether the request is ignored.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2PermissionRequestedEventArgs"/>.</param>
    /// <param name="state">The status of a permission request.</param>
    void State(CoreWebView2PermissionRequestedEventArgs e, CoreWebView2PermissionState state);

    /// <summary>
    /// Gets the origin of the web content that requests the permission.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2PermissionRequestedEventArgs"/>.</param>
    /// <returns>The origin of the web content that requests the permission.</returns>
    string Uri(CoreWebView2PermissionRequestedEventArgs e);

    /// <summary>
    /// Gets a <see cref="Deferral"/> object.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2PermissionRequestedEventArgs"/>.</param>
    /// <returns>A <see cref="Deferral"/> object.</returns>
    Deferral GetDeferral(CoreWebView2PermissionRequestedEventArgs e);
}