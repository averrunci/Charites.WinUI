// Copyright (C) 2023 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="AnnotatedScrollBarDetailLabelRequestedEventArgs"/>
/// resolved by <see cref="IAnnotatedScrollBarDetailLabelRequestedEventArgsResolver"/>.
/// </summary>
public static class AnnotatedScrollBarDetailLabelRequestedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IAnnotatedScrollBarDetailLabelRequestedEventArgsResolver"/>
    /// that resolves data of the <see cref="AnnotatedScrollBarDetailLabelRequestedEventArgs"/>.
    /// </summary>
    public static IAnnotatedScrollBarDetailLabelRequestedEventArgsResolver Resolver { get; set; } = new DefaultAnnotatedScrollBarDetailLabelRequestedEventArgsResolver();

    /// <summary>
    /// Gets a content.
    /// </summary>
    /// <param name="e">The requested <see cref="AnnotatedScrollBarDetailLabelRequestedEventArgs"/>.</param>
    /// <returns>A content.</returns>
    public static object? Content(this AnnotatedScrollBarDetailLabelRequestedEventArgs e) => Resolver.Content(e);

    /// <summary>
    /// Sets a content.
    /// </summary>
    /// <param name="e">The requested <see cref="AnnotatedScrollBarDetailLabelRequestedEventArgs"/>.</param>
    /// <param name="content">A content.</param>
    public static void Content(this AnnotatedScrollBarDetailLabelRequestedEventArgs e, object? content) => Resolver.Content(e, content);

    /// <summary>
    /// Gets a scroll offset.
    /// </summary>
    /// <param name="e">The requested <see cref="AnnotatedScrollBarDetailLabelRequestedEventArgs"/>.</param>
    /// <returns>A scroll offset.</returns>
    public static double ScrollOffset(this AnnotatedScrollBarDetailLabelRequestedEventArgs e) => Resolver.ScrollOffset(e);

    private sealed class DefaultAnnotatedScrollBarDetailLabelRequestedEventArgsResolver : IAnnotatedScrollBarDetailLabelRequestedEventArgsResolver
    {
        object? IAnnotatedScrollBarDetailLabelRequestedEventArgsResolver.Content(AnnotatedScrollBarDetailLabelRequestedEventArgs e) => e.Content;
        void IAnnotatedScrollBarDetailLabelRequestedEventArgsResolver.Content(AnnotatedScrollBarDetailLabelRequestedEventArgs e, object? content) => e.Content = content;
        double IAnnotatedScrollBarDetailLabelRequestedEventArgsResolver.ScrollOffset(AnnotatedScrollBarDetailLabelRequestedEventArgs e) => e.ScrollOffset;
    }
}

/// <summary>
/// Resolves data of the <see cref="AnnotatedScrollBarDetailLabelRequestedEventArgs"/>.
/// </summary>
public interface IAnnotatedScrollBarDetailLabelRequestedEventArgsResolver
{
    /// <summary>
    /// Gets a content.
    /// </summary>
    /// <param name="e">The requested <see cref="AnnotatedScrollBarDetailLabelRequestedEventArgs"/>.</param>
    /// <returns>A content.</returns>
    object? Content(AnnotatedScrollBarDetailLabelRequestedEventArgs e);

    /// <summary>
    /// Sets a content.
    /// </summary>
    /// <param name="e">The requested <see cref="AnnotatedScrollBarDetailLabelRequestedEventArgs"/>.</param>
    /// <param name="content">A content.</param>
    void Content(AnnotatedScrollBarDetailLabelRequestedEventArgs e, object? content);

    /// <summary>
    /// Gets a scroll offset.
    /// </summary>
    /// <param name="e">The requested <see cref="AnnotatedScrollBarDetailLabelRequestedEventArgs"/>.</param>
    /// <returns>A scroll offset.</returns>
    double ScrollOffset(AnnotatedScrollBarDetailLabelRequestedEventArgs e);
}