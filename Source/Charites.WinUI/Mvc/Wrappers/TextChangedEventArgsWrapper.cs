// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="TextChangedEventArgs"/>
/// resolved by <see cref="ITextChangedEventArgsResolver"/>.
/// </summary>
public static class TextChangedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ITextChangedEventArgsResolver"/>
    /// that resolves data of the <see cref="TextChangedEventArgs"/>.
    /// </summary>
    public static ITextChangedEventArgsResolver Resolver { get; set; } = new DefaultTextChangedEventArgsResolver();

    /// <summary>
    /// Gets a reference to the object that raised the event.
    /// This is often a template part of a control rather than an element that was declared in your app UI.
    /// </summary>
    /// <param name="e">The requested <see cref="TextChangedEventArgs"/>.</param>
    /// <returns>The object that raised the event.</returns>
    public static object? OriginalSource(this TextChangedEventArgs e) => Resolver.OriginalSource(e);

    private sealed class DefaultTextChangedEventArgsResolver : ITextChangedEventArgsResolver
    {
        object? ITextChangedEventArgsResolver.OriginalSource(TextChangedEventArgs e) => e.OriginalSource;
    }
}

/// <summary>
/// Resolves data of the <see cref="TextChangedEventArgs"/>.
/// </summary>
public interface ITextChangedEventArgsResolver
{
    /// <summary>
    /// Gets a reference to the object that raised the event.
    /// This is often a template part of a control rather than an element that was declared in your app UI.
    /// </summary>
    /// <param name="e">The requested <see cref="TextChangedEventArgs"/>.</param>
    /// <returns>The object that raised the event.</returns>
    object? OriginalSource(TextChangedEventArgs e);
}