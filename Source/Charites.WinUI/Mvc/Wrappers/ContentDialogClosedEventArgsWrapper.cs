// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="ContentDialogClosedEventArgs"/>
/// resolved by <see cref="IContentDialogClosedEventArgsResolver"/>.
/// </summary>
public static class ContentDialogClosedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IContentDialogClosedEventArgsResolver"/>
    /// that resolves data of the <see cref="ContentDialogClosedEventArgs"/>.
    /// </summary>
    public static IContentDialogClosedEventArgsResolver Resolver { get; set; } = new DefaultContentDialogClosedEventArgsResolver();

    /// <summary>
    /// Gets the <see cref="ContentDialogResult"/> of the button click event.
    /// </summary>
    /// <param name="e">The requested <see cref="ContentDialogClosedEventArgs"/>.</param>
    /// <returns>The result of the button click event.</returns>
    public static ContentDialogResult Result(this ContentDialogClosedEventArgs e) => Resolver.Result(e);

    private sealed class DefaultContentDialogClosedEventArgsResolver : IContentDialogClosedEventArgsResolver
    {
        ContentDialogResult IContentDialogClosedEventArgsResolver.Result(ContentDialogClosedEventArgs e) => e.Result;
    }
}

/// <summary>
/// Resolves data of the <see cref="ContentDialogClosedEventArgs"/>.
/// </summary>
public interface IContentDialogClosedEventArgsResolver
{
    /// <summary>
    /// Gets the <see cref="ContentDialogResult"/> of the button click event.
    /// </summary>
    /// <param name="e">The requested <see cref="ContentDialogClosedEventArgs"/>.</param>
    /// <returns>The result of the button click event.</returns>
    ContentDialogResult Result(ContentDialogClosedEventArgs e);
}