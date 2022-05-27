// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.Web.WebView2.Core;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="CoreWebView2BrowserProcessExitedEventArgs"/>
/// resolved by <see cref="ICoreWebView2BrowserProcessExitedEventArgsResolver"/>.
/// </summary>
public static class CoreWebView2BrowserProcessExitedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ICoreWebView2BrowserProcessExitedEventArgsResolver"/>
    /// that resolves data of the <see cref="CoreWebView2BrowserProcessExitedEventArgs"/>.
    /// </summary>
    public static ICoreWebView2BrowserProcessExitedEventArgsResolver Resolver { get; set; } = new DefaultCoreWebView2BrowserProcessExitedEventArgsResolver();

    /// <summary>
    /// Gets the kind of browser process exit that has occurred.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2BrowserProcessExitedEventArgs"/>.</param>
    /// <returns>The kind of browser process exit that has occurred.</returns>
    public static CoreWebView2BrowserProcessExitKind BrowserProcessExitKind(this CoreWebView2BrowserProcessExitedEventArgs e) => Resolver.BrowserProcessExitKind(e);

    /// <summary>
    /// Gets the process ID of the browser process that has exited.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2BrowserProcessExitedEventArgs"/>.</param>
    /// <returns>The process ID of the browser process that has exited.</returns>
    public static uint BrowserProcessId(this CoreWebView2BrowserProcessExitedEventArgs e) => Resolver.BrowserProcessId(e);

    private sealed class DefaultCoreWebView2BrowserProcessExitedEventArgsResolver : ICoreWebView2BrowserProcessExitedEventArgsResolver
    {
        CoreWebView2BrowserProcessExitKind ICoreWebView2BrowserProcessExitedEventArgsResolver.BrowserProcessExitKind(CoreWebView2BrowserProcessExitedEventArgs e) => e.BrowserProcessExitKind;
        uint ICoreWebView2BrowserProcessExitedEventArgsResolver.BrowserProcessId(CoreWebView2BrowserProcessExitedEventArgs e) => e.BrowserProcessId;
    }
}

/// <summary>
/// Resolves data of the <see cref="CoreWebView2BrowserProcessExitedEventArgs"/>.
/// </summary>
public interface ICoreWebView2BrowserProcessExitedEventArgsResolver
{
    /// <summary>
    /// Gets the kind of browser process exit that has occurred.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2BrowserProcessExitedEventArgs"/>.</param>
    /// <returns>The kind of browser process exit that has occurred.</returns>
    CoreWebView2BrowserProcessExitKind BrowserProcessExitKind(CoreWebView2BrowserProcessExitedEventArgs e);

    /// <summary>
    /// Gets the process ID of the browser process that has exited.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2BrowserProcessExitedEventArgs"/>.</param>
    /// <returns>The process ID of the browser process that has exited.</returns>
    uint BrowserProcessId(CoreWebView2BrowserProcessExitedEventArgs e);
}