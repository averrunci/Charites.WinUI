// Copyright (C) 2023 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using System.Numerics;
using Microsoft.UI.Composition;
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="ScrollingScrollAnimationStartingEventArgs"/>
/// resolved by <see cref="IScrollingScrollAnimationStartingEventArgsResolver"/>.
/// </summary>
public static class ScrollingScrollAnimationStartingEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IScrollingScrollAnimationStartingEventArgsResolver"/>
    /// that resolves data of the <see cref="ScrollingScrollAnimationStartingEventArgs"/>.
    /// </summary>
    public static IScrollingScrollAnimationStartingEventArgsResolver Resolver { get; set; } = new DefaultScrollingScrollAnimationStartingEventArgsResolver();

    /// <summary>
    /// Gets the animation to run during the animated scroll offset change.
    /// The animation targets the content's position.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingScrollAnimationStartingEventArgs"/>.</param>
    /// <returns>The animation to run during the animated scroll offset change.</returns>
    public static CompositionAnimation Animation(this ScrollingScrollAnimationStartingEventArgs e) => Resolver.Animation(e);

    /// <summary>
    /// Sets the animation to run during the animated scroll offset change.
    /// The animation targets the content's position.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingScrollAnimationStartingEventArgs"/>.</param>
    /// <param name="animation">The animation to run during the animated scroll offset change.</param>
    public static void Animation(this ScrollingScrollAnimationStartingEventArgs e, CompositionAnimation animation) => Resolver.Animation(e, animation);

    /// <summary>
    /// Gets the correlation ID associated with the animated scroll offset change,
    /// previously returned by <see cref="ScrollView.ScrollTo(double,double)"/> or <see cref="ScrollView.ScrollBy(double,double)"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingScrollAnimationStartingEventArgs"/>.</param>
    /// <returns>
    /// The correlation ID associated with the animated scroll offset change,
    /// previously returned by <see cref="ScrollView.ScrollTo(double,double)"/> or <see cref="ScrollView.ScrollBy(double,double)"/>.
    /// </returns>
    public static int CorrelationId(this ScrollingScrollAnimationStartingEventArgs e) => Resolver.CorrelationId(e);

    /// <summary>
    /// Gets the position of the content at the end of the animation.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingScrollAnimationStartingEventArgs"/>.</param>
    /// <returns>The position of the content at the end of the animation.</returns>
    public static Vector2 EndPosition(this ScrollingScrollAnimationStartingEventArgs e) => Resolver.EndPosition(e);

    /// <summary>
    /// Gets the position of the content at the start of the animation.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingScrollAnimationStartingEventArgs"/>.</param>
    /// <returns>The position of the content at the start of the animation.</returns>
    public static Vector2 StartPosition(this ScrollingScrollAnimationStartingEventArgs e) => Resolver.StartPosition(e);

    private sealed class DefaultScrollingScrollAnimationStartingEventArgsResolver : IScrollingScrollAnimationStartingEventArgsResolver
    {
        CompositionAnimation IScrollingScrollAnimationStartingEventArgsResolver.Animation(ScrollingScrollAnimationStartingEventArgs e) => e.Animation;
        void IScrollingScrollAnimationStartingEventArgsResolver.Animation(ScrollingScrollAnimationStartingEventArgs e, CompositionAnimation animation) => e.Animation = animation;
        int IScrollingScrollAnimationStartingEventArgsResolver.CorrelationId(ScrollingScrollAnimationStartingEventArgs e) => e.CorrelationId;
        Vector2 IScrollingScrollAnimationStartingEventArgsResolver.EndPosition(ScrollingScrollAnimationStartingEventArgs e) => e.EndPosition;
        Vector2 IScrollingScrollAnimationStartingEventArgsResolver.StartPosition(ScrollingScrollAnimationStartingEventArgs e) => e.StartPosition;
    }
}

/// <summary>
/// Resolves data of the <see cref="ScrollingScrollAnimationStartingEventArgs"/>.
/// </summary>
public interface IScrollingScrollAnimationStartingEventArgsResolver
{
    /// <summary>
    /// Gets the animation to run during the animated scroll offset change.
    /// The animation targets the content's position.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingScrollAnimationStartingEventArgs"/>.</param>
    /// <returns>The animation to run during the animated scroll offset change.</returns>
    CompositionAnimation Animation(ScrollingScrollAnimationStartingEventArgs e);

    /// <summary>
    /// Sets the animation to run during the animated scroll offset change.
    /// The animation targets the content's position.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingScrollAnimationStartingEventArgs"/>.</param>
    /// <param name="animation">The animation to run during the animated scroll offset change.</param>
    void Animation(ScrollingScrollAnimationStartingEventArgs e, CompositionAnimation animation);

    /// <summary>
    /// Gets the correlation ID associated with the animated scroll offset change,
    /// previously returned by <see cref="ScrollView.ScrollTo(double,double)"/> or <see cref="ScrollView.ScrollBy(double,double)"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingScrollAnimationStartingEventArgs"/>.</param>
    /// <returns>
    /// The correlation ID associated with the animated scroll offset change,
    /// previously returned by <see cref="ScrollView.ScrollTo(double,double)"/> or <see cref="ScrollView.ScrollBy(double,double)"/>.
    /// </returns>
    int CorrelationId(ScrollingScrollAnimationStartingEventArgs e);

    /// <summary>
    /// Gets the position of the content at the end of the animation.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingScrollAnimationStartingEventArgs"/>.</param>
    /// <returns>The position of the content at the end of the animation.</returns>
    Vector2 EndPosition(ScrollingScrollAnimationStartingEventArgs e);

    /// <summary>
    /// Gets the position of the content at the start of the animation.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingScrollAnimationStartingEventArgs"/>.</param>
    /// <returns>The position of the content at the start of the animation.</returns>
    Vector2 StartPosition(ScrollingScrollAnimationStartingEventArgs e);
}