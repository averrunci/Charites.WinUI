// Copyright (C) 2023 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.Foundation;
using Microsoft.Web.WebView2.Core;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="CoreWebView2ServerCertificateErrorDetectedEventArgs"/>
/// resolved by <see cref="ICoreWebView2ServerCertificateErrorDetectedEventArgsResolver"/>.
/// </summary>
public static class CoreWebView2ServerCertificateErrorDetectedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ICoreWebView2ServerCertificateErrorDetectedEventArgsResolver"/>
    /// that resolves data of the <see cref="CoreWebView2ServerCertificateErrorDetectedEventArgs"/>.
    /// </summary>
    public static ICoreWebView2ServerCertificateErrorDetectedEventArgsResolver Resolver { get; set; } = new DefaultCoreWebView2ServerCertificateErrorDetectedEventArgsResolver();

    /// <summary>
    /// Gets the action of the server error detection.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ServerCertificateErrorDetectedEventArgs"/>.</param>
    /// <returns>The action of the server error detection.</returns>
    public static CoreWebView2ServerCertificateErrorAction Action(this CoreWebView2ServerCertificateErrorDetectedEventArgs e) => Resolver.Action(e);

    /// <summary>
    /// Sets the action of the server error detection.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ServerCertificateErrorDetectedEventArgs"/>.</param>
    /// <param name="action">The action of the server error detection.</param>
    public static void Action(this CoreWebView2ServerCertificateErrorDetectedEventArgs e, CoreWebView2ServerCertificateErrorAction action) => Resolver.Action(e, action);

    /// <summary>
    /// Gets the TLS error code for the invalid certificate.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ServerCertificateErrorDetectedEventArgs"/>.</param>
    /// <returns>The TLS error code for the invalid certificate.</returns>
    public static CoreWebView2WebErrorStatus ErrorStatus(this CoreWebView2ServerCertificateErrorDetectedEventArgs e) => Resolver.ErrorStatus(e);

    /// <summary>
    /// Gets the URI associated with the request for the invalid certificate.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ServerCertificateErrorDetectedEventArgs"/>.</param>
    /// <returns>The URI associated with the request for the invalid certificate.</returns>
    public static string RequestUri(this CoreWebView2ServerCertificateErrorDetectedEventArgs e) => Resolver.RequestUri(e);

    /// <summary>
    /// Get the <see cref="CoreWebView2Certificate"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ServerCertificateErrorDetectedEventArgs"/>.</param>
    /// <returns>The <see cref="CoreWebView2Certificate"/>.</returns>
    public static CoreWebView2Certificate ServerCertificate(this CoreWebView2ServerCertificateErrorDetectedEventArgs e) => Resolver.ServerCertificate(e);

    /// <summary>
    /// Gets a <see cref="Deferral"/> object.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ServerCertificateErrorDetectedEventArgs"/>.</param>
    /// <returns>A <see cref="Deferral"/> object.</returns>
    public static Deferral GetDeferralWrapped(this CoreWebView2PermissionRequestedEventArgs e) => Resolver.GetDeferral(e);

    private sealed class DefaultCoreWebView2ServerCertificateErrorDetectedEventArgsResolver : ICoreWebView2ServerCertificateErrorDetectedEventArgsResolver
    {
        CoreWebView2ServerCertificateErrorAction ICoreWebView2ServerCertificateErrorDetectedEventArgsResolver.Action(CoreWebView2ServerCertificateErrorDetectedEventArgs e) => e.Action;
        void ICoreWebView2ServerCertificateErrorDetectedEventArgsResolver.Action(CoreWebView2ServerCertificateErrorDetectedEventArgs e, CoreWebView2ServerCertificateErrorAction action) => e.Action = action;
        CoreWebView2WebErrorStatus ICoreWebView2ServerCertificateErrorDetectedEventArgsResolver.ErrorStatus(CoreWebView2ServerCertificateErrorDetectedEventArgs e) => e.ErrorStatus;
        string ICoreWebView2ServerCertificateErrorDetectedEventArgsResolver.RequestUri(CoreWebView2ServerCertificateErrorDetectedEventArgs e) => e.RequestUri;
        CoreWebView2Certificate ICoreWebView2ServerCertificateErrorDetectedEventArgsResolver.ServerCertificate(CoreWebView2ServerCertificateErrorDetectedEventArgs e) => e.ServerCertificate;
        Deferral ICoreWebView2ServerCertificateErrorDetectedEventArgsResolver.GetDeferral(CoreWebView2PermissionRequestedEventArgs e) => e.GetDeferral();
    }
}

/// <summary>
/// Resolves data of the <see cref="CoreWebView2ServerCertificateErrorDetectedEventArgs"/>.
/// </summary>
public interface ICoreWebView2ServerCertificateErrorDetectedEventArgsResolver
{
    /// <summary>
    /// Gets the action of the server error detection.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ServerCertificateErrorDetectedEventArgs"/>.</param>
    /// <returns>The action of the server error detection.</returns>
    CoreWebView2ServerCertificateErrorAction Action(CoreWebView2ServerCertificateErrorDetectedEventArgs e);

    /// <summary>
    /// Sets the action of the server error detection.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ServerCertificateErrorDetectedEventArgs"/>.</param>
    /// <param name="action">The action of the server error detection.</param>
    void Action(CoreWebView2ServerCertificateErrorDetectedEventArgs e, CoreWebView2ServerCertificateErrorAction action);

    /// <summary>
    /// Gets the TLS error code for the invalid certificate.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ServerCertificateErrorDetectedEventArgs"/>.</param>
    /// <returns>The TLS error code for the invalid certificate.</returns>
    CoreWebView2WebErrorStatus ErrorStatus(CoreWebView2ServerCertificateErrorDetectedEventArgs e);

    /// <summary>
    /// Gets the URI associated with the request for the invalid certificate.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ServerCertificateErrorDetectedEventArgs"/>.</param>
    /// <returns>The URI associated with the request for the invalid certificate.</returns>
    string RequestUri(CoreWebView2ServerCertificateErrorDetectedEventArgs e);

    /// <summary>
    /// Get the <see cref="CoreWebView2Certificate"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ServerCertificateErrorDetectedEventArgs"/>.</param>
    /// <returns>The <see cref="CoreWebView2Certificate"/>.</returns>
    CoreWebView2Certificate ServerCertificate(CoreWebView2ServerCertificateErrorDetectedEventArgs e);

    /// <summary>
    /// Gets a <see cref="Deferral"/> object.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ServerCertificateErrorDetectedEventArgs"/>.</param>
    /// <returns>A <see cref="Deferral"/> object.</returns>
    Deferral GetDeferral(CoreWebView2PermissionRequestedEventArgs e);
}