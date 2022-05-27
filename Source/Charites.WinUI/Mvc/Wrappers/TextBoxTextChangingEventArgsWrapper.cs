// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="TextBoxTextChangingEventArgs"/>
/// resolved by <see cref="ITextBoxTextChangingEventArgsResolver"/>.
/// </summary>
public static class TextBoxTextChangingEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ITextBoxTextChangingEventArgsResolver"/>
    /// that resolves data of the <see cref="TextBoxTextChangingEventArgs"/>.
    /// </summary>
    public static ITextBoxTextChangingEventArgsResolver Resolver { get; set; } = new DefaultTextBoxTextChangingEventArgsResolver();

    /// <summary>
    /// Gets a value that indicates whether the event occurred due to a change in the text content.
    /// </summary>
    /// <param name="e">The requested <see cref="TextBoxTextChangingEventArgs"/>.</param>
    /// <returns><c>true</c> if a change to the text content caused the event; otherwise, <c>false</c>.</returns>
    public static bool IsContentChanging(this TextBoxTextChangingEventArgs e) => Resolver.IsContentChanging(e);

    private sealed class DefaultTextBoxTextChangingEventArgsResolver : ITextBoxTextChangingEventArgsResolver
    {
        bool ITextBoxTextChangingEventArgsResolver.IsContentChanging(TextBoxTextChangingEventArgs e) => e.IsContentChanging;
    }
}

/// <summary>
/// Resolves data of the <see cref="TextBoxTextChangingEventArgs"/>.
/// </summary>
public interface ITextBoxTextChangingEventArgsResolver
{
    /// <summary>
    /// Gets a value that indicates whether the event occurred due to a change in the text content.
    /// </summary>
    /// <param name="e">The requested <see cref="TextBoxTextChangingEventArgs"/>.</param>
    /// <returns><c>true</c> if a change to the text content caused the event; otherwise, <c>false</c>.</returns>
    bool IsContentChanging(TextBoxTextChangingEventArgs e);
}