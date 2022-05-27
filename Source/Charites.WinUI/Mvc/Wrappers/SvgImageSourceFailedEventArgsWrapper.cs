// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Media.Imaging;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="SvgImageSourceFailedEventArgs"/>
/// resolved by <see cref="ISvgImageSourceFailedEventArgsResolver"/>.
/// </summary>
public static class SvgImageSourceFailedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ISvgImageSourceFailedEventArgsResolver"/>
    /// that resolves data of the <see cref="SvgImageSourceFailedEventArgs"/>.
    /// </summary>
    public static ISvgImageSourceFailedEventArgsResolver Resolver { get; set; } = new DefaultSvgImageSourceFailedEventArgsResolver();

    /// <summary>
    /// Gets a value that indicates the reason for the SVG loading failure.
    /// </summary>
    /// <param name="e">The requested <see cref="SvgImageSourceFailedEventArgs"/>.</param>
    /// <returns>A value of the enumeration.</returns>
    public static SvgImageSourceLoadStatus Status(this SvgImageSourceFailedEventArgs e) => Resolver.Status(e);

    private sealed class DefaultSvgImageSourceFailedEventArgsResolver : ISvgImageSourceFailedEventArgsResolver
    {
        SvgImageSourceLoadStatus ISvgImageSourceFailedEventArgsResolver.Status(SvgImageSourceFailedEventArgs e) => e.Status;
    }
}

/// <summary>
/// Resolves data of the <see cref="SvgImageSourceFailedEventArgs"/>.
/// </summary>
public interface ISvgImageSourceFailedEventArgsResolver
{
    /// <summary>
    /// Gets a value that indicates the reason for the SVG loading failure.
    /// </summary>
    /// <param name="e">The requested <see cref="SvgImageSourceFailedEventArgs"/>.</param>
    /// <returns>A value of the enumeration.</returns>
    SvgImageSourceLoadStatus Status(SvgImageSourceFailedEventArgs e);
}