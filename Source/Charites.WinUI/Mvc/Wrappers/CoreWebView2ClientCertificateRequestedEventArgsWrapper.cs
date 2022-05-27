// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.Foundation;
using Microsoft.Web.WebView2.Core;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="CoreWebView2ClientCertificateRequestedEventArgs"/>
/// resolved by <see cref="ICoreWebView2ClientCertificateRequestedEventArgsResolver"/>.
/// </summary>
public static class CoreWebView2ClientCertificateRequestedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ICoreWebView2ClientCertificateRequestedEventArgsResolver"/>
    /// that resolves data of the <see cref="CoreWebView2ClientCertificateRequestedEventArgs"/>.
    /// </summary>
    public static ICoreWebView2ClientCertificateRequestedEventArgsResolver Resolver { get; set; } = new DefaultCoreWebView2ClientCertificateRequestedEventArgsResolver();

    /// <summary>
    /// Gets the list contains distinguished names of certificate authorities allowed by the server.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ClientCertificateRequestedEventArgs"/>.</param>
    /// <returns>The list contains distinguished names of certificate authorities allowed by the server.</returns>
    public static IReadOnlyList<string> AllowedCertificateAuthorities(this CoreWebView2ClientCertificateRequestedEventArgs e) => Resolver.AllowedCertificateAuthorities(e);

    /// <summary>
    /// Gets a value that indicates whether to cancel the certificate selection.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ClientCertificateRequestedEventArgs"/>.</param>
    /// <returns><c>true</c> if the certificate selection is canceled; otherwise, <c>false</c>.</returns>
    public static bool Cancel(this CoreWebView2ClientCertificateRequestedEventArgs e) => Resolver.Cancel(e);

    /// <summary>
    /// Sets a value that indicates whether to cancel the certificate selection.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ClientCertificateRequestedEventArgs"/>.</param>
    /// <param name="cancel"><c>true</c> if the certificate selection is canceled; otherwise, <c>false</c>.</param>
    public static void Cancel(this CoreWebView2ClientCertificateRequestedEventArgs e, bool cancel) => Resolver.Cancel(e, cancel);

    /// <summary>
    /// Gets a value that indicates whether the event has been handled by host.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ClientCertificateRequestedEventArgs"/>.</param>
    /// <returns><c>true</c> if the event is handled by host; otherwise, <c>false</c>.</returns>
    public static bool Handled(this CoreWebView2ClientCertificateRequestedEventArgs e) => Resolver.Handled(e);

    /// <summary>
    /// Sets a value that indicates whether the event has been handled by host.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ClientCertificateRequestedEventArgs"/>.</param>
    /// <param name="handle"><c>true</c> if the event is handled by host; otherwise, <c>false</c>.</param>
    public static void Handled(this CoreWebView2ClientCertificateRequestedEventArgs e, bool handle) => Resolver.Handled(e, handle);

    /// <summary>
    /// Gets the host name of the server that requested client certificate authentication.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ClientCertificateRequestedEventArgs"/>.</param>
    /// <returns>The host name of the server that requested client certificate authentication.</returns>
    public static string Host(this CoreWebView2ClientCertificateRequestedEventArgs e) => Resolver.Host(e);

    /// <summary>
    /// Gets a value the indicates whether the server that issued this request is an http proxy.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ClientCertificateRequestedEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> if the server that issued this request is an http proxy.
    /// <c>false</c> if the server is the origin server.
    /// </returns>
    public static bool IsProxy(this CoreWebView2ClientCertificateRequestedEventArgs e) => Resolver.IsProxy(e);

    /// <summary>
    /// Gets the list of <see cref="CoreWebView2ClientCertificate"/> when client certificate authentication is requested.
    /// The list contains mutually trusted CA certificate.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ClientCertificateRequestedEventArgs"/>.</param>
    /// <returns>The list of <see cref="CoreWebView2ClientCertificate"/> when client certificate authentication is requested.</returns>
    public static IReadOnlyList<CoreWebView2ClientCertificate> MutuallyTrustedCertificates(this CoreWebView2ClientCertificateRequestedEventArgs e) => Resolver.MutuallyTrustedCertificates(e);

    /// <summary>
    /// Gets the port of the server that requested client certificate authentication.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ClientCertificateRequestedEventArgs"/>.</param>
    /// <returns>The port of the server that requested client certificate authentication.</returns>
    public static int Port(this CoreWebView2ClientCertificateRequestedEventArgs e) => Resolver.Port(e);

    /// <summary>
    /// Gets the selected certificate to respond to the server.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ClientCertificateRequestedEventArgs"/>.</param>
    /// <returns>The selected certificate to respond to the server.</returns>
    public static CoreWebView2ClientCertificate SelectedCertificate(this CoreWebView2ClientCertificateRequestedEventArgs e) => Resolver.SelectedCertificate(e);

    /// <summary>
    /// Sets the selected certificate to respond to the server.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ClientCertificateRequestedEventArgs"/>.</param>
    /// <param name="selectedCertificate">The selected certificate to respond to the server.</param>
    public static void SelectedCertificate(this CoreWebView2ClientCertificateRequestedEventArgs e, CoreWebView2ClientCertificate selectedCertificate) => Resolver.SelectedCertificate(e, selectedCertificate);

    /// <summary>
    /// Gets a <see cref="Deferral"/> object.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ClientCertificateRequestedEventArgs"/>.</param>
    /// <returns>A <see cref="Deferral"/> object.</returns>
    public static Deferral GetDeferralWrapped(this CoreWebView2ClientCertificateRequestedEventArgs e) => Resolver.GetDeferral(e);

    private sealed class DefaultCoreWebView2ClientCertificateRequestedEventArgsResolver : ICoreWebView2ClientCertificateRequestedEventArgsResolver
    {
        IReadOnlyList<string> ICoreWebView2ClientCertificateRequestedEventArgsResolver.AllowedCertificateAuthorities(CoreWebView2ClientCertificateRequestedEventArgs e) => e.AllowedCertificateAuthorities;
        bool ICoreWebView2ClientCertificateRequestedEventArgsResolver.Cancel(CoreWebView2ClientCertificateRequestedEventArgs e) => e.Cancel;
        void ICoreWebView2ClientCertificateRequestedEventArgsResolver.Cancel(CoreWebView2ClientCertificateRequestedEventArgs e, bool cancel) => e.Cancel = cancel;
        bool ICoreWebView2ClientCertificateRequestedEventArgsResolver.Handled(CoreWebView2ClientCertificateRequestedEventArgs e) => e.Handled;
        void ICoreWebView2ClientCertificateRequestedEventArgsResolver.Handled(CoreWebView2ClientCertificateRequestedEventArgs e, bool handle) => e.Handled = handle;
        string ICoreWebView2ClientCertificateRequestedEventArgsResolver.Host(CoreWebView2ClientCertificateRequestedEventArgs e) => e.Host;
        bool ICoreWebView2ClientCertificateRequestedEventArgsResolver.IsProxy(CoreWebView2ClientCertificateRequestedEventArgs e) => e.IsProxy;
        IReadOnlyList<CoreWebView2ClientCertificate> ICoreWebView2ClientCertificateRequestedEventArgsResolver.MutuallyTrustedCertificates(CoreWebView2ClientCertificateRequestedEventArgs e) => e.MutuallyTrustedCertificates;
        int ICoreWebView2ClientCertificateRequestedEventArgsResolver.Port(CoreWebView2ClientCertificateRequestedEventArgs e) => e.Port;
        CoreWebView2ClientCertificate ICoreWebView2ClientCertificateRequestedEventArgsResolver.SelectedCertificate(CoreWebView2ClientCertificateRequestedEventArgs e) => e.SelectedCertificate;
        void ICoreWebView2ClientCertificateRequestedEventArgsResolver.SelectedCertificate(CoreWebView2ClientCertificateRequestedEventArgs e, CoreWebView2ClientCertificate selectedCertificate) => e.SelectedCertificate = selectedCertificate;
        Deferral ICoreWebView2ClientCertificateRequestedEventArgsResolver.GetDeferral(CoreWebView2ClientCertificateRequestedEventArgs e) => e.GetDeferral();
    }
}

/// <summary>
/// Resolves data of the <see cref="CoreWebView2ClientCertificateRequestedEventArgs"/>.
/// </summary>
public interface ICoreWebView2ClientCertificateRequestedEventArgsResolver
{
    /// <summary>
    /// Gets the list contains distinguished names of certificate authorities allowed by the server.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ClientCertificateRequestedEventArgs"/>.</param>
    /// <returns>The list contains distinguished names of certificate authorities allowed by the server.</returns>
    IReadOnlyList<string> AllowedCertificateAuthorities(CoreWebView2ClientCertificateRequestedEventArgs e);

    /// <summary>
    /// Gets a value that indicates whether to cancel the certificate selection.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ClientCertificateRequestedEventArgs"/>.</param>
    /// <returns><c>true</c> if the certificate selection is canceled; otherwise, <c>false</c>.</returns>
    bool Cancel(CoreWebView2ClientCertificateRequestedEventArgs e);

    /// <summary>
    /// Sets a value that indicates whether to cancel the certificate selection.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ClientCertificateRequestedEventArgs"/>.</param>
    /// <param name="cancel"><c>true</c> if the certificate selection is canceled; otherwise, <c>false</c>.</param>
    void Cancel(CoreWebView2ClientCertificateRequestedEventArgs e, bool cancel);

    /// <summary>
    /// Gets a value that indicates whether the event has been handled by host.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ClientCertificateRequestedEventArgs"/>.</param>
    /// <returns><c>true</c> if the event is handled by host; otherwise, <c>false</c>.</returns>
    bool Handled(CoreWebView2ClientCertificateRequestedEventArgs e);

    /// <summary>
    /// Sets a value that indicates whether the event has been handled by host.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ClientCertificateRequestedEventArgs"/>.</param>
    /// <param name="handle"><c>true</c> if the event is handled by host; otherwise, <c>false</c>.</param>
    void Handled(CoreWebView2ClientCertificateRequestedEventArgs e, bool handle);

    /// <summary>
    /// Gets the host name of the server that requested client certificate authentication.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ClientCertificateRequestedEventArgs"/>.</param>
    /// <returns>The host name of the server that requested client certificate authentication.</returns>
    string Host(CoreWebView2ClientCertificateRequestedEventArgs e);

    /// <summary>
    /// Gets a value the indicates whether the server that issued this request is an http proxy.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ClientCertificateRequestedEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> if the server that issued this request is an http proxy.
    /// <c>false</c> if the server is the origin server.
    /// </returns>
    bool IsProxy(CoreWebView2ClientCertificateRequestedEventArgs e);

    /// <summary>
    /// Gets the list of <see cref="CoreWebView2ClientCertificate"/> when client certificate authentication is requested.
    /// The list contains mutually trusted CA certificate.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ClientCertificateRequestedEventArgs"/>.</param>
    /// <returns>The list of <see cref="CoreWebView2ClientCertificate"/> when client certificate authentication is requested.</returns>
    IReadOnlyList<CoreWebView2ClientCertificate> MutuallyTrustedCertificates(CoreWebView2ClientCertificateRequestedEventArgs e);

    /// <summary>
    /// Gets the port of the server that requested client certificate authentication.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ClientCertificateRequestedEventArgs"/>.</param>
    /// <returns>The port of the server that requested client certificate authentication.</returns>
    int Port(CoreWebView2ClientCertificateRequestedEventArgs e);

    /// <summary>
    /// Gets the selected certificate to respond to the server.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ClientCertificateRequestedEventArgs"/>.</param>
    /// <returns>The selected certificate to respond to the server.</returns>
    CoreWebView2ClientCertificate SelectedCertificate(CoreWebView2ClientCertificateRequestedEventArgs e);

    /// <summary>
    /// Sets the selected certificate to respond to the server.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ClientCertificateRequestedEventArgs"/>.</param>
    /// <param name="selectedCertificate">The selected certificate to respond to the server.</param>
    void SelectedCertificate(CoreWebView2ClientCertificateRequestedEventArgs e, CoreWebView2ClientCertificate selectedCertificate);

    /// <summary>
    /// Gets a <see cref="Deferral"/> object.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ClientCertificateRequestedEventArgs"/>.</param>
    /// <returns>A <see cref="Deferral"/> object.</returns>
    Deferral GetDeferral(CoreWebView2ClientCertificateRequestedEventArgs e);
}