// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="MediaFailedRoutedEventArgs"/>
/// resolved by <see cref="IMediaFailedRoutedEventArgsResolver"/>.
/// </summary>
public static class MediaFailedRoutedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IMediaFailedRoutedEventArgsResolver"/>
    /// that resolves data of the <see cref="MediaFailedRoutedEventArgs"/>.
    /// </summary>
    public static IMediaFailedRoutedEventArgsResolver Resolver { get; set; } = new DefaultMediaFailedRoutedEventArgsResolver();

    /// <summary>
    /// Gets the message component of the exception, as a string.
    /// </summary>
    /// <param name="e">The requested <see cref="MediaFailedRoutedEventArgs"/>.</param>
    /// <returns>The message component of the exception.</returns>
    public static string ErrorMessage(this MediaFailedRoutedEventArgs e) => Resolver.ErrorMessage(e);

    /// <summary>
    /// Gets the trace information for a media failed event.
    /// </summary>
    /// <param name="e">The requested <see cref="MediaFailedRoutedEventArgs"/>.</param>
    /// <returns>The error trace for the failed media event.</returns>
    public static string ErrorTrace(this MediaFailedRoutedEventArgs e) => Resolver.ErrorTrace(e);

    /// <summary>
    /// Gets a reference to the object that raised the event.
    /// This is often a template part of a control rather than an element that was declared in your app UI.
    /// </summary>
    /// <param name="e">The requested <see cref="MediaFailedRoutedEventArgs"/>.</param>
    /// <returns>The object that raised the event.</returns>
    public static object? OriginalSource(this MediaFailedRoutedEventArgs e) => Resolver.OriginalSource(e);

    private sealed class DefaultMediaFailedRoutedEventArgsResolver : IMediaFailedRoutedEventArgsResolver
    {
        string IMediaFailedRoutedEventArgsResolver.ErrorMessage(MediaFailedRoutedEventArgs e) => e.ErrorMessage;
        string IMediaFailedRoutedEventArgsResolver.ErrorTrace(MediaFailedRoutedEventArgs e) => e.ErrorTrace;
        object? IMediaFailedRoutedEventArgsResolver.OriginalSource(MediaFailedRoutedEventArgs e) => e.OriginalSource;
    }
}

/// <summary>
/// Resolves data of the <see cref="MediaFailedRoutedEventArgs"/>.
/// </summary>
public interface IMediaFailedRoutedEventArgsResolver
{
    /// <summary>
    /// Gets the message component of the exception, as a string.
    /// </summary>
    /// <param name="e">The requested <see cref="MediaFailedRoutedEventArgs"/>.</param>
    /// <returns>The message component of the exception.</returns>
    string ErrorMessage(MediaFailedRoutedEventArgs e);

    /// <summary>
    /// Gets the trace information for a media failed event.
    /// </summary>
    /// <param name="e">The requested <see cref="MediaFailedRoutedEventArgs"/>.</param>
    /// <returns>The error trace for the failed media event.</returns>
    string ErrorTrace(MediaFailedRoutedEventArgs e);

    /// <summary>
    /// Gets a reference to the object that raised the event.
    /// This is often a template part of a control rather than an element that was declared in your app UI.
    /// </summary>
    /// <param name="e">The requested <see cref="MediaFailedRoutedEventArgs"/>.</param>
    /// <returns>The object that raised the event.</returns>
    object? OriginalSource(MediaFailedRoutedEventArgs e);
}