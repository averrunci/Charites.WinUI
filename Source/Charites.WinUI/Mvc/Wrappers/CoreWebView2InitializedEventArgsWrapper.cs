// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="CoreWebView2InitializedEventArgs"/>
/// resolved by <see cref="ICoreWebView2InitializedEventArgsResolver"/>.
/// </summary>
public static class CoreWebView2InitializedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ICoreWebView2InitializedEventArgsResolver"/>
    /// that resolves data of the <see cref="CoreWebView2InitializedEventArgs"/>.
    /// </summary>
    public static ICoreWebView2InitializedEventArgsResolver Resolver { get; set; } = new DefaultCoreWebView2InitializedEventArgsResolver();

    /// <summary>
    /// Gets the exception raised when a <see cref="WebView2"/> is created.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2InitializedEventArgs"/>.</param>
    /// <returns>The exception, or <c>null</c> if no exception occurred.</returns>
    public static Exception? Exception(this CoreWebView2InitializedEventArgs e) => Resolver.Exception(e);

    private sealed class DefaultCoreWebView2InitializedEventArgsResolver : ICoreWebView2InitializedEventArgsResolver
    {
        Exception? ICoreWebView2InitializedEventArgsResolver.Exception(CoreWebView2InitializedEventArgs e) => e.Exception;
    }
}

/// <summary>
/// Resolves data of the <see cref="CoreWebView2InitializedEventArgs"/>.
/// </summary>
public interface ICoreWebView2InitializedEventArgsResolver
{
    /// <summary>
    /// Gets the exception raised when a <see cref="WebView2"/> is created.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2InitializedEventArgs"/>.</param>
    /// <returns>The exception, or <c>null</c> if no exception occurred.</returns>
    Exception? Exception(CoreWebView2InitializedEventArgs e);
}