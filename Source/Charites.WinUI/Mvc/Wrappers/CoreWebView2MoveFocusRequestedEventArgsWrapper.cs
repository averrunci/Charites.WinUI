// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.Web.WebView2.Core;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="CoreWebView2MoveFocusRequestedEventArgs"/>
/// resolved by <see cref="ICoreWebView2MoveFocusRequestedEventArgsResolver"/>.
/// </summary>
public static class CoreWebView2MoveFocusRequestedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ICoreWebView2MoveFocusRequestedEventArgsResolver"/>
    /// that resolves data of the <see cref="CoreWebView2MoveFocusRequestedEventArgs"/>.
    /// </summary>
    public static ICoreWebView2MoveFocusRequestedEventArgsResolver Resolver { get; set; } = new DefaultCoreWebView2MoveFocusRequestedEventArgsResolver();

    /// <summary>
    /// Gets a value that indicates whether the event has been handled by the app.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2MoveFocusRequestedEventArgs"/>.</param>
    /// <returns><c>true</c> if the event is handled by the app; otherwise, <c>false</c>.</returns>
    public static bool Handled(this CoreWebView2MoveFocusRequestedEventArgs e) => Resolver.Handled(e);

    /// <summary>
    /// Sets a value that indicates whether the event has been handled by the app.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2MoveFocusRequestedEventArgs"/>.</param>
    /// <param name="handled"><c>true</c> if the event is handled by the app; otherwise, <c>false</c>.</param>
    public static void Handled(this CoreWebView2MoveFocusRequestedEventArgs e, bool handled) => Resolver.Handled(e, handled);

    /// <summary>
    /// Gets the reason for WebView to raise the <see cref="CoreWebView2Controller.MoveFocusRequested"/> event.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2MoveFocusRequestedEventArgs"/>.</param>
    /// <returns>The reason for WebView to raise the <see cref="CoreWebView2Controller.MoveFocusRequested"/> event.</returns>
    public static CoreWebView2MoveFocusReason Reason(this CoreWebView2MoveFocusRequestedEventArgs e) => Resolver.Reason(e);

    private sealed class DefaultCoreWebView2MoveFocusRequestedEventArgsResolver : ICoreWebView2MoveFocusRequestedEventArgsResolver
    {
        bool ICoreWebView2MoveFocusRequestedEventArgsResolver.Handled(CoreWebView2MoveFocusRequestedEventArgs e) => e.Handled;
        void ICoreWebView2MoveFocusRequestedEventArgsResolver.Handled(CoreWebView2MoveFocusRequestedEventArgs e, bool handled) => e.Handled = handled;
        CoreWebView2MoveFocusReason ICoreWebView2MoveFocusRequestedEventArgsResolver.Reason(CoreWebView2MoveFocusRequestedEventArgs e) => e.Reason;
    }
}

/// <summary>
/// Resolves data of the <see cref="CoreWebView2MoveFocusRequestedEventArgs"/>.
/// </summary>
public interface ICoreWebView2MoveFocusRequestedEventArgsResolver
{
    /// <summary>
    /// Gets a value that indicates whether the event has been handled by the app.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2MoveFocusRequestedEventArgs"/>.</param>
    /// <returns><c>true</c> if the event is handled by the app; otherwise, <c>false</c>.</returns>
    bool Handled(CoreWebView2MoveFocusRequestedEventArgs e);

    /// <summary>
    /// Sets a value that indicates whether the event has been handled by the app.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2MoveFocusRequestedEventArgs"/>.</param>
    /// <param name="handled"><c>true</c> if the event is handled by the app; otherwise, <c>false</c>.</param>
    void Handled(CoreWebView2MoveFocusRequestedEventArgs e, bool handled);

    /// <summary>
    /// Gets the reason for WebView to raise the <see cref="CoreWebView2Controller.MoveFocusRequested"/> event.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2MoveFocusRequestedEventArgs"/>.</param>
    /// <returns>The reason for WebView to raise the <see cref="CoreWebView2Controller.MoveFocusRequested"/> event.</returns>
    CoreWebView2MoveFocusReason Reason(CoreWebView2MoveFocusRequestedEventArgs e);
}