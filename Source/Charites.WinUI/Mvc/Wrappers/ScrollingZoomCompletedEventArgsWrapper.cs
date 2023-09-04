// Copyright (C) 2023 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using System.Numerics;
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="ScrollingZoomCompletedEventArgs"/>
/// resolved by <see cref="IScrollingZoomCompletedEventArgsResolver"/>.
/// </summary>
public static class ScrollingZoomCompletedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IScrollingZoomCompletedEventArgsResolver"/>
    /// that resolves data of the <see cref="ScrollingZoomCompletedEventArgs"/>.
    /// </summary>
    public static IScrollingZoomCompletedEventArgsResolver Resolver { get; set; } = new DefaultScrollingZoomCompletedEventArgsResolver();

    /// <summary>
    /// Gets the correlation ID associated with the zoom factor change, previously returned by
    /// <see cref="ScrollView.ZoomTo(float,Vector2?)"/>, <see cref="ScrollView.ZoomBy(float,Vector2?)"/>, or
    /// <see cref="ScrollView.AddZoomVelocity"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingZoomCompletedEventArgs"/>.</param>
    /// <returns>
    /// The correlation ID associated with the zoom factor change, previously returned by
    /// <see cref="ScrollView.ZoomTo(float,Vector2?)"/>, <see cref="ScrollView.ZoomBy(float,Vector2?)"/>, or
    /// <see cref="ScrollView.AddZoomVelocity"/>.
    /// </returns>
    public static int CorrelationId(this ScrollingZoomCompletedEventArgs e) => Resolver.CorrelationId(e);

    private sealed class DefaultScrollingZoomCompletedEventArgsResolver : IScrollingZoomCompletedEventArgsResolver
    {
        int IScrollingZoomCompletedEventArgsResolver.CorrelationId(ScrollingZoomCompletedEventArgs e) => e.CorrelationId;
    }
}

/// <summary>
/// Resolves data of the <see cref="ScrollingZoomCompletedEventArgs"/>.
/// </summary>
public interface IScrollingZoomCompletedEventArgsResolver
{
    /// <summary>
    /// Gets the correlation ID associated with the zoom factor change, previously returned by
    /// <see cref="ScrollView.ZoomTo(float,Vector2?)"/>, <see cref="ScrollView.ZoomBy(float,Vector2?)"/>, or
    /// <see cref="ScrollView.AddZoomVelocity"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingZoomCompletedEventArgs"/>.</param>
    /// <returns>
    /// The correlation ID associated with the zoom factor change, previously returned by
    /// <see cref="ScrollView.ZoomTo(float,Vector2?)"/>, <see cref="ScrollView.ZoomBy(float,Vector2?)"/>, or
    /// <see cref="ScrollView.AddZoomVelocity"/>.
    /// </returns>
    int CorrelationId(ScrollingZoomCompletedEventArgs e);
}