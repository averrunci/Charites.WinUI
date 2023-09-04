// Copyright (C) 2023 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="ScrollingScrollCompletedEventArgs"/>
/// resolved by <see cref="IScrollingScrollCompletedEventArgsResolver"/>.
/// </summary>
public static class ScrollingScrollCompletedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IScrollingScrollCompletedEventArgsResolver"/>
    /// that resolves data of the <see cref="ScrollingScrollCompletedEventArgs"/>.
    /// </summary>
    public static IScrollingScrollCompletedEventArgsResolver Resolver { get; set; } = new DefaultScrollingScrollCompletedEventArgsResolver();

    /// <summary>
    /// Gets the correlation ID associated with the offsets change, previously returned by
    /// <see cref="ScrollView.ScrollTo(double,double)"/>, <see cref="ScrollView.ScrollBy(double,double)"/>, or
    /// <see cref="ScrollView.AddScrollVelocity"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingScrollCompletedEventArgs"/>.</param>
    /// <returns>
    /// The correlation ID associated with the offsets change, previously returned by
    /// <see cref="ScrollView.ScrollTo(double,double)"/>, <see cref="ScrollView.ScrollBy(double,double)"/>, or
    /// <see cref="ScrollView.AddScrollVelocity"/>.
    /// </returns>
    public static int CorrelationId(this ScrollingScrollCompletedEventArgs e) => Resolver.CorrelationId(e);

    private sealed class DefaultScrollingScrollCompletedEventArgsResolver : IScrollingScrollCompletedEventArgsResolver
    {
        int IScrollingScrollCompletedEventArgsResolver.CorrelationId(ScrollingScrollCompletedEventArgs e) => e.CorrelationId;
    }
}

/// <summary>
/// Resolves data of the <see cref="ScrollingScrollCompletedEventArgs"/>.
/// </summary>
public interface IScrollingScrollCompletedEventArgsResolver
{
    /// <summary>
    /// Gets the correlation ID associated with the offsets change, previously returned by
    /// <see cref="ScrollView.ScrollTo(double,double)"/>, <see cref="ScrollView.ScrollBy(double,double)"/>, or
    /// <see cref="ScrollView.AddScrollVelocity"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingScrollCompletedEventArgs"/>.</param>
    /// <returns>
    /// The correlation ID associated with the offsets change, previously returned by
    /// <see cref="ScrollView.ScrollTo(double,double)"/>, <see cref="ScrollView.ScrollBy(double,double)"/>, or
    /// <see cref="ScrollView.AddScrollVelocity"/>.
    /// </returns>
    int CorrelationId(ScrollingScrollCompletedEventArgs e);
}