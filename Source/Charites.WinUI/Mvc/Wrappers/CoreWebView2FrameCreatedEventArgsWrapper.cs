// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.Web.WebView2.Core;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="CoreWebView2FrameCreatedEventArgs"/>
/// resolved by <see cref="ICoreWebView2FrameCreatedEventArgsResolver"/>.
/// </summary>
public static class CoreWebView2FrameCreatedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ICoreWebView2FrameCreatedEventArgsResolver"/>
    /// that resolves data of the <see cref="CoreWebView2FrameCreatedEventArgs"/>.
    /// </summary>
    public static ICoreWebView2FrameCreatedEventArgsResolver Resolver { get; set; } = new DefaultCoreWebView2FrameCreatedEventArgsResolver();

    /// <summary>
    /// Gets the created frame.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2FrameCreatedEventArgs"/>.</param>
    /// <returns>The created frame.</returns>
    public static CoreWebView2Frame Frame(this CoreWebView2FrameCreatedEventArgs e) => Resolver.Frame(e);

    private sealed class DefaultCoreWebView2FrameCreatedEventArgsResolver : ICoreWebView2FrameCreatedEventArgsResolver
    {
        CoreWebView2Frame ICoreWebView2FrameCreatedEventArgsResolver.Frame(CoreWebView2FrameCreatedEventArgs e) => e.Frame;
    }
}

/// <summary>
/// Resolves data of the <see cref="CoreWebView2FrameCreatedEventArgs"/>.
/// </summary>
public interface ICoreWebView2FrameCreatedEventArgsResolver
{
    /// <summary>
    /// Gets the created frame.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2FrameCreatedEventArgs"/>.</param>
    /// <returns>The created frame.</returns>
    CoreWebView2Frame Frame(CoreWebView2FrameCreatedEventArgs e);
}