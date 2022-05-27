// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.Web.WebView2.Core;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="CoreWebView2SourceChangedEventArgs"/>
/// resolved by <see cref="ICoreWebView2SourceChangedEventArgsResolver"/>.
/// </summary>
public static class CoreWebView2SourceChangedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ICoreWebView2SourceChangedEventArgsResolver"/>
    /// that resolves data of the <see cref="CoreWebView2SourceChangedEventArgs"/>.
    /// </summary>
    public static ICoreWebView2SourceChangedEventArgsResolver Resolver { get; set; } = new DefaultCoreWebView2SourceChangedEventArgsResolver();

    /// <summary>
    /// Gets a value that indicates whether the page being navigated to is a new document.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2SourceChangedEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> if the page being navigated to is a new document; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsNewDocument(this CoreWebView2SourceChangedEventArgs e) => Resolver.IsNewDocument(e);

    private sealed class DefaultCoreWebView2SourceChangedEventArgsResolver : ICoreWebView2SourceChangedEventArgsResolver
    {
        bool ICoreWebView2SourceChangedEventArgsResolver.IsNewDocument(CoreWebView2SourceChangedEventArgs e) => e.IsNewDocument;
    }
}

/// <summary>
/// Resolves data of the <see cref="CoreWebView2SourceChangedEventArgs"/>.
/// </summary>
public interface ICoreWebView2SourceChangedEventArgsResolver
{
    /// <summary>
    /// Gets a value that indicates whether the page being navigated to is a new document.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2SourceChangedEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> if the page being navigated to is a new document; otherwise, <c>false</c>.
    /// </returns>
    bool IsNewDocument(CoreWebView2SourceChangedEventArgs e);
}