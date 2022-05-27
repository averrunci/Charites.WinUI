// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Documents;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="HyperlinkClickEventArgs"/>
/// resolved by <see cref="IHyperlinkClickEventArgsResolver"/>.
/// </summary>
public static class HyperlinkClickEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IHyperlinkClickEventArgsResolver"/>
    /// that resolves data of the <see cref="HyperlinkClickEventArgs"/>.
    /// </summary>
    public static IHyperlinkClickEventArgsResolver Resolver { get; set; } = new DefaultHyperlinkClickEventArgsResolver();

    /// <summary>
    /// Gets a reference to the object that raised the event.
    /// This is often a template part of a control rather than an element that was declared in your app UI.
    /// </summary>
    /// <param name="e">The requested <see cref="HyperlinkClickEventArgs"/>.</param>
    /// <returns>The object that raised the event.</returns>
    public static object? OriginalSource(this HyperlinkClickEventArgs e) => Resolver.OriginalSource(e);

    private sealed class DefaultHyperlinkClickEventArgsResolver : IHyperlinkClickEventArgsResolver
    {
        object? IHyperlinkClickEventArgsResolver.OriginalSource(HyperlinkClickEventArgs e) => e.OriginalSource;
    }
}

/// <summary>
/// Resolves data of the <see cref="HyperlinkClickEventArgs"/>.
/// </summary>
public interface IHyperlinkClickEventArgsResolver
{
    /// <summary>
    /// Gets a reference to the object that raised the event.
    /// This is often a template part of a control rather than an element that was declared in your app UI.
    /// </summary>
    /// <param name="e">The requested <see cref="HyperlinkClickEventArgs"/>.</param>
    /// <returns>The object that raised the event.</returns>
    object? OriginalSource(HyperlinkClickEventArgs e);
}