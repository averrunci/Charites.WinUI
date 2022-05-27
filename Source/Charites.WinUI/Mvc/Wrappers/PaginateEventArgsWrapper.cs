// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.Graphics.Printing;
using Microsoft.UI.Xaml.Printing;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="PaginateEventArgs"/>
/// resolved by <see cref="IPaginateEventArgsResolver"/>.
/// </summary>
public static class PaginateEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IPaginateEventArgsResolver"/>
    /// that resolves data of the <see cref="PaginateEventArgs"/>.
    /// </summary>
    public static IPaginateEventArgsResolver Resolver { get; set; } = new DefaultPaginateEventArgsResolver();

    /// <summary>
    /// Gets the 1-based page number of the current preview page.
    /// </summary>
    /// <param name="e">The requested <see cref="PaginateEventArgs"/>.</param>
    /// <returns>The page number.</returns>
    public static int CurrentPreviewPageNumber(this PaginateEventArgs e) => Resolver.CurrentPreviewPageNumber(e);

    /// <summary>
    /// Gets the PrintTaskOptions for the pages involved in the event occurrence.
    /// </summary>
    /// <param name="e">The requested <see cref="PaginateEventArgs"/>.</param>
    /// <returns>An object that manages the options for print tasks.</returns>
    public static PrintTaskOptions PrintTaskOptions(this PaginateEventArgs e) => Resolver.PrintTaskOptions(e);

    private sealed class DefaultPaginateEventArgsResolver : IPaginateEventArgsResolver
    {
        int IPaginateEventArgsResolver.CurrentPreviewPageNumber(PaginateEventArgs e) => e.CurrentPreviewPageNumber;
        PrintTaskOptions IPaginateEventArgsResolver.PrintTaskOptions(PaginateEventArgs e) => e.PrintTaskOptions;
    }
}

/// <summary>
/// Resolves data of the <see cref="PaginateEventArgs"/>.
/// </summary>
public interface IPaginateEventArgsResolver
{
    /// <summary>
    /// Gets the 1-based page number of the current preview page.
    /// </summary>
    /// <param name="e">The requested <see cref="PaginateEventArgs"/>.</param>
    /// <returns>The page number.</returns>
    int CurrentPreviewPageNumber(PaginateEventArgs e);

    /// <summary>
    /// Gets the PrintTaskOptions for the pages involved in the event occurrence.
    /// </summary>
    /// <param name="e">The requested <see cref="PaginateEventArgs"/>.</param>
    /// <returns>An object that manages the options for print tasks.</returns>
    PrintTaskOptions PrintTaskOptions(PaginateEventArgs e);
}