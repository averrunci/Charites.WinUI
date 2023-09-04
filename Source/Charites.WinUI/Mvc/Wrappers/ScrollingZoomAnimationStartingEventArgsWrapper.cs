// Copyright (C) 2023 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using System.Numerics;
using Microsoft.UI.Composition;
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="ScrollingZoomAnimationStartingEventArgs"/>
/// resolved by <see cref="IScrollingZoomAnimationStartingEventArgsResolver"/>.
/// </summary>
public static class ScrollingZoomAnimationStartingEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IScrollingZoomAnimationStartingEventArgsResolver"/>
    /// that resolves data of the <see cref="ScrollingZoomAnimationStartingEventArgs"/>.
    /// </summary>
    public static IScrollingZoomAnimationStartingEventArgsResolver Resolver { get; set; } = new DefaultScrollingZoomAnimationStartingEventArgsResolver();

    /// <summary>
    /// Gets the animation to run during the animated zoom factor change.
    /// The animation targets the content's scale.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingZoomAnimationStartingEventArgs"/>.</param>
    /// <returns>The animation to run during the animated zoom factor change.</returns>
    public static CompositionAnimation Animation(this ScrollingZoomAnimationStartingEventArgs e) => Resolver.Animation(e);

    /// <summary>
    /// Sets the animation to run during the animated zoom factor change.
    /// The animation targets the content's scale.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingZoomAnimationStartingEventArgs"/>.</param>
    /// <param name="animation">The animation to run during the animated zoom factor change.</param>
    public static void Animation(this ScrollingZoomAnimationStartingEventArgs e, CompositionAnimation animation) => Resolver.Animation(e, animation);

    /// <summary>
    /// Gets the center point for the zoom factor change.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingZoomAnimationStartingEventArgs"/>.</param>
    /// <returns>The center point for the zoom factor change.</returns>
    public static Vector2 CenterPoint(this ScrollingZoomAnimationStartingEventArgs e) => Resolver.CenterPoint(e);

    /// <summary>
    /// Gets the correlation ID associated with the animated zoom factor change,
    /// previously returned by <see cref="ScrollView.ZoomTo(float,Vector2?)"/> or <see cref="ScrollView.ZoomBy(float,Vector2?)"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingZoomAnimationStartingEventArgs"/>.</param>
    /// <returns>
    /// The correlation ID associated with the animated zoom factor change,
    /// previously returned by <see cref="ScrollView.ZoomTo(float,Vector2?)"/> or <see cref="ScrollView.ZoomBy(float,Vector2?)"/>.
    /// </returns>
    public static int CorrelationId(this ScrollingZoomAnimationStartingEventArgs e) => Resolver.CorrelationId(e);

    /// <summary>
    /// Gets the content scale at the end of the animation.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingZoomAnimationStartingEventArgs"/>.</param>
    /// <returns>The content scale at the end of the animation.</returns>
    public static float EndZoomFactor(this ScrollingZoomAnimationStartingEventArgs e) => Resolver.EndZoomFactor(e);

    /// <summary>
    /// Gets the content scale at the start of the animation.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingZoomAnimationStartingEventArgs"/>.</param>
    /// <returns>The content scale at the start of the animation.</returns>
    public static float StartZoomFactor(this ScrollingZoomAnimationStartingEventArgs e) => Resolver.StartZoomFactor(e);

    private sealed class DefaultScrollingZoomAnimationStartingEventArgsResolver : IScrollingZoomAnimationStartingEventArgsResolver
    {
        CompositionAnimation IScrollingZoomAnimationStartingEventArgsResolver.Animation(ScrollingZoomAnimationStartingEventArgs e) => e.Animation;
        void IScrollingZoomAnimationStartingEventArgsResolver.Animation(ScrollingZoomAnimationStartingEventArgs e, CompositionAnimation animation) => e.Animation = animation;
        Vector2 IScrollingZoomAnimationStartingEventArgsResolver.CenterPoint(ScrollingZoomAnimationStartingEventArgs e) => e.CenterPoint;
        int IScrollingZoomAnimationStartingEventArgsResolver.CorrelationId(ScrollingZoomAnimationStartingEventArgs e) => e.CorrelationId;
        float IScrollingZoomAnimationStartingEventArgsResolver.EndZoomFactor(ScrollingZoomAnimationStartingEventArgs e) => e.EndZoomFactor;
        float IScrollingZoomAnimationStartingEventArgsResolver.StartZoomFactor(ScrollingZoomAnimationStartingEventArgs e) => e.StartZoomFactor;
    }
}

/// <summary>
/// Resolves data of the <see cref="ScrollingZoomAnimationStartingEventArgs"/>.
/// </summary>
public interface IScrollingZoomAnimationStartingEventArgsResolver
{
    /// <summary>
    /// Gets the animation to run during the animated zoom factor change.
    /// The animation targets the content's scale.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingZoomAnimationStartingEventArgs"/>.</param>
    /// <returns>The animation to run during the animated zoom factor change.</returns>
    CompositionAnimation Animation(ScrollingZoomAnimationStartingEventArgs e);

    /// <summary>
    /// Sets the animation to run during the animated zoom factor change.
    /// The animation targets the content's scale.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingZoomAnimationStartingEventArgs"/>.</param>
    /// <param name="animation">The animation to run during the animated zoom factor change.</param>
    void Animation(ScrollingZoomAnimationStartingEventArgs e, CompositionAnimation animation);

    /// <summary>
    /// Gets the center point for the zoom factor change.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingZoomAnimationStartingEventArgs"/>.</param>
    /// <returns>The center point for the zoom factor change.</returns>
    Vector2 CenterPoint(ScrollingZoomAnimationStartingEventArgs e);

    /// <summary>
    /// Gets the correlation ID associated with the animated zoom factor change,
    /// previously returned by <see cref="ScrollView.ZoomTo(float,Vector2?)"/> or <see cref="ScrollView.ZoomBy(float,Vector2?)"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingZoomAnimationStartingEventArgs"/>.</param>
    /// <returns>
    /// The correlation ID associated with the animated zoom factor change,
    /// previously returned by <see cref="ScrollView.ZoomTo(float,Vector2?)"/> or <see cref="ScrollView.ZoomBy(float,Vector2?)"/>.
    /// </returns>
    int CorrelationId(ScrollingZoomAnimationStartingEventArgs e);

    /// <summary>
    /// Gets the content scale at the end of the animation.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingZoomAnimationStartingEventArgs"/>.</param>
    /// <returns>The content scale at the end of the animation.</returns>
    float EndZoomFactor(ScrollingZoomAnimationStartingEventArgs e);

    /// <summary>
    /// Gets the content scale at the start of the animation.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingZoomAnimationStartingEventArgs"/>.</param>
    /// <returns>The content scale at the start of the animation.</returns>
    float StartZoomFactor(ScrollingZoomAnimationStartingEventArgs e);
}