// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Media;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="RenderingEventArgs"/>
/// resolved by <see cref="IRenderingEventArgsResolver"/>.
/// </summary>
public static class RenderingEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IRenderingEventArgsResolver"/>
    /// that resolves data of the <see cref="RenderingEventArgs"/>.
    /// </summary>
    public static IRenderingEventArgsResolver Resolver { get; set; } = new DefaultRenderingEventArgsResolver();

    /// <summary>
    /// Gets the time when the frame rendered, for timing purposes.
    /// </summary>
    /// <param name="e">The requested <see cref="RenderingEventArgs"/>.</param>
    /// <returns>The time when the frame rendered.</returns>
    public static TimeSpan RenderingTime(this RenderingEventArgs e) => Resolver.RenderingTime(e);

    private sealed class DefaultRenderingEventArgsResolver : IRenderingEventArgsResolver
    {
        TimeSpan IRenderingEventArgsResolver.RenderingTime(RenderingEventArgs e) => e.RenderingTime;
    }
}

/// <summary>
/// Resolves data of the <see cref="RenderingEventArgs"/>.
/// </summary>
public interface IRenderingEventArgsResolver
{
    /// <summary>
    /// Gets the time when the frame rendered, for timing purposes.
    /// </summary>
    /// <param name="e">The requested <see cref="RenderingEventArgs"/>.</param>
    /// <returns>The time when the frame rendered.</returns>
    TimeSpan RenderingTime(RenderingEventArgs e);
}