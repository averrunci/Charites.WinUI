// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Printing;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="GetPreviewPageEventArgs"/>
/// resolved by <see cref="IGetPreviewPageEventArgsResolver"/>.
/// </summary>
public static class GetPreviewPageEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IGetPreviewPageEventArgsResolver"/>
    /// that resolves data of the <see cref="GetPreviewPageEventArgs"/>.
    /// </summary>
    public static IGetPreviewPageEventArgsResolver Resolver { get; set; } = new DefaultGetPreviewPageEventArgsResolver();

    /// <summary>
    /// Gets the page number of the potentially repaginated page involved in the preview.
    /// </summary>
    /// <param name="e">The requested <see cref="GetPreviewPageEventArgs"/>.</param>
    /// <returns>The page number of the potentially repaginated page.</returns>
    public static int PageNumber(this GetPreviewPageEventArgs e) => Resolver.PageNumber(e);

    private sealed class DefaultGetPreviewPageEventArgsResolver : IGetPreviewPageEventArgsResolver
    {
        int IGetPreviewPageEventArgsResolver.PageNumber(GetPreviewPageEventArgs e) => e.PageNumber;
    }
}

/// <summary>
/// Resolves data of the <see cref="GetPreviewPageEventArgs"/>.
/// </summary>
public interface IGetPreviewPageEventArgsResolver
{
    /// <summary>
    /// Gets the page number of the potentially repaginated page involved in the preview.
    /// </summary>
    /// <param name="e">The requested <see cref="GetPreviewPageEventArgs"/>.</param>
    /// <returns>The page number of the potentially repaginated page.</returns>
    int PageNumber(GetPreviewPageEventArgs e);
}