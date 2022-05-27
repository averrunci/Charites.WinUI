// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.Foundation;
using Microsoft.UI.Xaml;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="EffectiveViewportChangedEventArgs"/>
/// resolved by <see cref="IEffectiveViewportChangedEventArgsResolver"/>.
/// </summary>
public static class EffectiveViewportChangedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IEffectiveViewportChangedEventArgsResolver"/>
    /// that resolves data of the <see cref="EffectiveViewportChangedEventArgs"/>.
    /// </summary>
    public static IEffectiveViewportChangedEventArgsResolver Resolver { get; set; } = new DefaultEffectiveViewportChangedEventArgsResolver();

    /// <summary>
    /// Gets the sum of translation in the X-axis that is required to bring the <see cref="FrameworkElement"/> into view of each viewport containing the element.
    /// </summary>
    /// <param name="e">The requested <see cref="EffectiveViewportChangedEventArgs"/>.</param>
    /// <returns>The translation in the X-axis that is required to bring the <see cref="FrameworkElement"/> into view of each viewport containing the element</returns>
    public static double BringIntoViewDistanceX(this EffectiveViewportChangedEventArgs e) => Resolver.BringIntoViewDistanceX(e);

    /// <summary>
    /// Gets the sum of translation in the Y-axis that is required to bring the <see cref="FrameworkElement"/> into view of each viewport containing the element.
    /// </summary>
    /// <param name="e">The requested <see cref="EffectiveViewportChangedEventArgs"/>.</param>
    /// <returns>The translation in the Y-axis that is required to bring the <see cref="FrameworkElement"/> into view of each viewport containing the element.</returns>
    public static double BringIntoViewDistanceY(this EffectiveViewportChangedEventArgs e) => Resolver.BringIntoViewDistanceY(e);

    /// <summary>
    /// Gets the <see cref="Rect"/> representing the effective viewport.
    /// </summary>
    /// <param name="e">The requested <see cref="EffectiveViewportChangedEventArgs"/>.</param>
    /// <returns>The <see cref="Rect"/> representing the effective viewport.</returns>
    public static Rect EffectiveViewport(this EffectiveViewportChangedEventArgs e) => Resolver.EffectiveViewport(e);

    /// <summary>
    /// Gets the <see cref="Rect"/> representing the maximum effective viewport with the current viewport sizes.
    /// </summary>
    /// <param name="e">The requested <see cref="EffectiveViewportChangedEventArgs"/>.</param>
    /// <returns>The <see cref="Rect"/> representing the maximum effective viewport with the current viewport sizes.</returns>
    public static Rect MaxViewport(this EffectiveViewportChangedEventArgs e) => Resolver.MaxViewport(e);

    private sealed class DefaultEffectiveViewportChangedEventArgsResolver : IEffectiveViewportChangedEventArgsResolver
    {
        double IEffectiveViewportChangedEventArgsResolver.BringIntoViewDistanceX(EffectiveViewportChangedEventArgs e) => e.BringIntoViewDistanceX;
        double IEffectiveViewportChangedEventArgsResolver.BringIntoViewDistanceY(EffectiveViewportChangedEventArgs e) => e.BringIntoViewDistanceY;
        Rect IEffectiveViewportChangedEventArgsResolver.EffectiveViewport(EffectiveViewportChangedEventArgs e) => e.EffectiveViewport;
        Rect IEffectiveViewportChangedEventArgsResolver.MaxViewport(EffectiveViewportChangedEventArgs e) => e.MaxViewport;
    }
}

/// <summary>
/// Resolves data of the <see cref="EffectiveViewportChangedEventArgs"/>.
/// </summary>
public interface IEffectiveViewportChangedEventArgsResolver
{
    /// <summary>
    /// Gets the sum of translation in the X-axis that is required to bring the <see cref="FrameworkElement"/> into view of each viewport containing the element.
    /// </summary>
    /// <param name="e">The requested <see cref="EffectiveViewportChangedEventArgs"/>.</param>
    /// <returns>The translation in the X-axis that is required to bring the <see cref="FrameworkElement"/> into view of each viewport containing the element</returns>
    double BringIntoViewDistanceX(EffectiveViewportChangedEventArgs e);

    /// <summary>
    /// Gets the sum of translation in the Y-axis that is required to bring the <see cref="FrameworkElement"/> into view of each viewport containing the element.
    /// </summary>
    /// <param name="e">The requested <see cref="EffectiveViewportChangedEventArgs"/>.</param>
    /// <returns>The translation in the Y-axis that is required to bring the <see cref="FrameworkElement"/> into view of each viewport containing the element.</returns>
    double BringIntoViewDistanceY(EffectiveViewportChangedEventArgs e);

    /// <summary>
    /// Gets the <see cref="Rect"/> representing the effective viewport.
    /// </summary>
    /// <param name="e">The requested <see cref="EffectiveViewportChangedEventArgs"/>.</param>
    /// <returns>The <see cref="Rect"/> representing the effective viewport.</returns>
    Rect EffectiveViewport(EffectiveViewportChangedEventArgs e);

    /// <summary>
    /// Gets the <see cref="Rect"/> representing the maximum effective viewport with the current viewport sizes.
    /// </summary>
    /// <param name="e">The requested <see cref="EffectiveViewportChangedEventArgs"/>.</param>
    /// <returns>The <see cref="Rect"/> representing the maximum effective viewport with the current viewport sizes.</returns>
    Rect MaxViewport(EffectiveViewportChangedEventArgs e);
}