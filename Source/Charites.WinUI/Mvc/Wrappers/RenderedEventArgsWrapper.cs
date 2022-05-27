// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Media;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="RenderedEventArgs"/>
/// resolved by <see cref="IRenderedEventArgsResolver"/>.
/// </summary>
public static class RenderedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IRenderedEventArgsResolver"/>
    /// that resolves data of the <see cref="RenderedEventArgs"/>.
    /// </summary>
    public static IRenderedEventArgsResolver Resolver { get; set; } = new DefaultRenderedEventArgsResolver();

    /// <summary>
    /// Gets the duration of the time it took to render the most recent frame.
    /// </summary>
    /// <param name="e">The requested <see cref="RenderedEventArgs"/>.</param>
    /// <returns>The duration of the time it took to render the most recent frame.</returns>
    public static TimeSpan FrameDuration(this RenderedEventArgs e) => Resolver.FrameDuration(e);

    private sealed class DefaultRenderedEventArgsResolver : IRenderedEventArgsResolver
    {
        TimeSpan IRenderedEventArgsResolver.FrameDuration(RenderedEventArgs e) => e.FrameDuration;
    }
}

/// <summary>
/// Resolves data of the <see cref="RenderedEventArgs"/>.
/// </summary>
public interface IRenderedEventArgsResolver
{
    /// <summary>
    /// Gets the duration of the time it took to render the most recent frame.
    /// </summary>
    /// <param name="e">The requested <see cref="RenderedEventArgs"/>.</param>
    /// <returns>The duration of the time it took to render the most recent frame.</returns>
    TimeSpan FrameDuration(RenderedEventArgs e);
}