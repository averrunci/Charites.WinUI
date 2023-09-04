// Copyright (C) 2023 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="AnnotatedScrollBarScrollingEventArgs"/>
/// resolved by <see cref="IAnnotatedScrollBarScrollingEventArgsResolver"/>.
/// </summary>
public static class AnnotatedScrollBarScrollingEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IAnnotatedScrollBarScrollingEventArgsResolver"/>
    /// that resolves data of the <see cref="AnnotatedScrollBarScrollingEventArgs"/>.
    /// </summary>
    public static IAnnotatedScrollBarScrollingEventArgsResolver Resolver { get; set; } = new DefaultAnnotatedScrollBarScrollingEventArgsResolver();

    /// <summary>
    /// Gets a value that indicates whether to cancel an annotated scroll bar scrolling.
    /// </summary>
    /// <param name="e">The requested <see cref="AnnotatedScrollBarScrollingEventArgs"/>.</param>
    /// <returns><c>true</c> if an annotated scroll bar scrolling is canceled; otherwise, <c>false</c>.</returns>
    public static bool Cancel(this AnnotatedScrollBarScrollingEventArgs e) => Resolver.Cancel(e);

    /// <summary>
    /// Sets a value that indicates whether to cancel an annotated scroll bar scrolling.
    /// </summary>
    /// <param name="e">The requested <see cref="AnnotatedScrollBarScrollingEventArgs"/>.</param>
    /// <param name="cancel"><c>true</c>if an annotated scroll bar scrolling is canceled; otherwise, <c>false</c>.</param>
    public static void Cancel(this AnnotatedScrollBarScrollingEventArgs e, bool cancel) => Resolver.Cancel(e, cancel);

    /// <summary>
    /// Gets a scroll offset.
    /// </summary>
    /// <param name="e">The requested <see cref="AnnotatedScrollBarScrollingEventArgs"/>.</param>
    /// <returns>A scroll offset.</returns>
    public static double ScrollOffset(this AnnotatedScrollBarScrollingEventArgs e) => Resolver.ScrollOffset(e);

    /// <summary>
    /// Gets a scrolling event kind.
    /// </summary>
    /// <param name="e">The requested <see cref="AnnotatedScrollBarScrollingEventArgs"/>.</param>
    /// <returns>A scrolling event kind.</returns>
    public static AnnotatedScrollBarScrollingEventKind ScrollingEventKind(this AnnotatedScrollBarScrollingEventArgs e) => Resolver.ScrollingEventKind(e);

    private sealed class DefaultAnnotatedScrollBarScrollingEventArgsResolver : IAnnotatedScrollBarScrollingEventArgsResolver
    {
        bool IAnnotatedScrollBarScrollingEventArgsResolver.Cancel(AnnotatedScrollBarScrollingEventArgs e) => e.Cancel;
        void IAnnotatedScrollBarScrollingEventArgsResolver.Cancel(AnnotatedScrollBarScrollingEventArgs e, bool cancel) => e.Cancel = cancel;
        double IAnnotatedScrollBarScrollingEventArgsResolver.ScrollOffset(AnnotatedScrollBarScrollingEventArgs e) => e.ScrollOffset;
        AnnotatedScrollBarScrollingEventKind IAnnotatedScrollBarScrollingEventArgsResolver.ScrollingEventKind(AnnotatedScrollBarScrollingEventArgs e) => e.ScrollingEventKind;
    }
}

/// <summary>
/// Resolves data of the <see cref="AnnotatedScrollBarScrollingEventArgs"/>.
/// </summary>
public interface IAnnotatedScrollBarScrollingEventArgsResolver
{
    /// <summary>
    /// Gets a value that indicates whether to cancel an annotated scroll bar scrolling.
    /// </summary>
    /// <param name="e">The requested <see cref="AnnotatedScrollBarScrollingEventArgs"/>.</param>
    /// <returns><c>true</c> if an annotated scroll bar scrolling is canceled; otherwise, <c>false</c>.</returns>
    bool Cancel(AnnotatedScrollBarScrollingEventArgs e);

    /// <summary>
    /// Sets a value that indicates whether to cancel an annotated scroll bar scrolling.
    /// </summary>
    /// <param name="e">The requested <see cref="AnnotatedScrollBarScrollingEventArgs"/>.</param>
    /// <param name="cancel"><c>true</c>if an annotated scroll bar scrolling is canceled; otherwise, <c>false</c>.</param>
    void Cancel(AnnotatedScrollBarScrollingEventArgs e, bool cancel);

    /// <summary>
    /// Gets a scroll offset.
    /// </summary>
    /// <param name="e">The requested <see cref="AnnotatedScrollBarScrollingEventArgs"/>.</param>
    /// <returns>A scroll offset.</returns>
    double ScrollOffset(AnnotatedScrollBarScrollingEventArgs e);

    /// <summary>
    /// Gets a scrolling event kind.
    /// </summary>
    /// <param name="e">The requested <see cref="AnnotatedScrollBarScrollingEventArgs"/>.</param>
    /// <returns>A scrolling event kind.</returns>
    AnnotatedScrollBarScrollingEventKind ScrollingEventKind(AnnotatedScrollBarScrollingEventArgs e);
}