// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.Graphics.Printing;
using Microsoft.UI.Xaml.Printing;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="AddPagesEventArgs"/>
/// resolved by <see cref="IAddPagesEventArgsResolver"/>.
/// </summary>
public static class AddPagesEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IAddPagesEventArgsResolver"/>
    /// that resolves data of the <see cref="AddPagesEventArgs"/>.
    /// </summary>
    public static IAddPagesEventArgsResolver Resolver { get; set; } = new DefaultAddPagesEventArgsResolver();

    /// <summary>
    /// Gets the PrintTaskOptions for the pages added.
    /// </summary>
    /// <param name="e">The requested <see cref="AddPagesEventArgs"/>.</param>
    /// <returns>An object that manages the options for print tasks.</returns>
    public static PrintTaskOptions PrintTaskOptions(this AddPagesEventArgs e) => Resolver.PrintTaskOptions(e);

    private sealed class DefaultAddPagesEventArgsResolver : IAddPagesEventArgsResolver
    {
        PrintTaskOptions IAddPagesEventArgsResolver.PrintTaskOptions(AddPagesEventArgs e) => e.PrintTaskOptions;
    }
}

/// <summary>
/// Resolves data of the <see cref="AddPagesEventArgs"/>.
/// </summary>
public interface IAddPagesEventArgsResolver
{
    /// <summary>
    /// Gets the PrintTaskOptions for the pages added.
    /// </summary>
    /// <param name="e">The requested <see cref="AddPagesEventArgs"/>.</param>
    /// <returns>An object that manages the options for print tasks.</returns>
    PrintTaskOptions PrintTaskOptions(AddPagesEventArgs e);
}