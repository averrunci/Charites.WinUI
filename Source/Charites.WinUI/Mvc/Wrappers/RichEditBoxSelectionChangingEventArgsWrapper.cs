// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="RichEditBoxSelectionChangingEventArgs"/>
/// resolved by <see cref="IRichEditBoxSelectionChangingEventArgsResolver"/>.
/// </summary>
public static class RichEditBoxSelectionChangingEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IRichEditBoxSelectionChangingEventArgsResolver"/>
    /// that resolves data of the <see cref="RichEditBoxSelectionChangingEventArgs"/>.
    /// </summary>
    public static IRichEditBoxSelectionChangingEventArgsResolver Resolver { get; set; } = new DefaultRichEditBoxSelectionChangingEventArgsResolver();

    /// <summary>
    /// Gets a value that indicates whether the selection operation should be canceled.
    /// </summary>
    /// <param name="e">The requested <see cref="RichEditBoxSelectionChangingEventArgs"/>.</param>
    /// <returns><c>true</c> to cancel the selection operation; otherwise, <c>false</c>.</returns>
    public static bool Cancel(this RichEditBoxSelectionChangingEventArgs e) => Resolver.Cancel(e);

    /// <summary>
    /// Sets a value that indicates whether the selection operation should be canceled.
    /// </summary>
    /// <param name="e">The requested <see cref="RichEditBoxSelectionChangingEventArgs"/>.</param>
    /// <param name="cancel"><c>true</c> to cancel the selection operation; otherwise, <c>false</c>.</param>
    public static void Cancel(this RichEditBoxSelectionChangingEventArgs e, bool cancel) => Resolver.Cancel(e, cancel);

    /// <summary>
    /// Gets the length of the text selection.
    /// </summary>
    /// <param name="e">The requested <see cref="RichEditBoxSelectionChangingEventArgs"/>.</param>
    /// <returns>The length of the text selection.</returns>
    public static int SelectionLength(this RichEditBoxSelectionChangingEventArgs e) => Resolver.SelectionLength(e);

    /// <summary>
    /// Gets the starting index of the text selection.
    /// </summary>
    /// <param name="e">The requested <see cref="RichEditBoxSelectionChangingEventArgs"/>.</param>
    /// <returns>The starting index of the text selection.</returns>
    public static int SelectionStart(this RichEditBoxSelectionChangingEventArgs e) => Resolver.SelectionStart(e);

    private sealed class DefaultRichEditBoxSelectionChangingEventArgsResolver : IRichEditBoxSelectionChangingEventArgsResolver
    {
        bool IRichEditBoxSelectionChangingEventArgsResolver.Cancel(RichEditBoxSelectionChangingEventArgs e) => e.Cancel;
        void IRichEditBoxSelectionChangingEventArgsResolver.Cancel(RichEditBoxSelectionChangingEventArgs e, bool cancel) => e.Cancel = cancel;
        int IRichEditBoxSelectionChangingEventArgsResolver.SelectionLength(RichEditBoxSelectionChangingEventArgs e) => e.SelectionLength;
        int IRichEditBoxSelectionChangingEventArgsResolver.SelectionStart(RichEditBoxSelectionChangingEventArgs e) => e.SelectionStart;
    }
}

/// <summary>
/// Resolves data of the <see cref="RichEditBoxSelectionChangingEventArgs"/>.
/// </summary>
public interface IRichEditBoxSelectionChangingEventArgsResolver
{
    /// <summary>
    /// Gets a value that indicates whether the selection operation should be canceled.
    /// </summary>
    /// <param name="e">The requested <see cref="RichEditBoxSelectionChangingEventArgs"/>.</param>
    /// <returns><c>true</c> to cancel the selection operation; otherwise, <c>false</c>.</returns>
    bool Cancel(RichEditBoxSelectionChangingEventArgs e);

    /// <summary>
    /// Sets a value that indicates whether the selection operation should be canceled.
    /// </summary>
    /// <param name="e">The requested <see cref="RichEditBoxSelectionChangingEventArgs"/>.</param>
    /// <param name="cancel"><c>true</c> to cancel the selection operation; otherwise, <c>false</c>.</param>
    void Cancel(RichEditBoxSelectionChangingEventArgs e, bool cancel);

    /// <summary>
    /// Gets the length of the text selection.
    /// </summary>
    /// <param name="e">The requested <see cref="RichEditBoxSelectionChangingEventArgs"/>.</param>
    /// <returns>The length of the text selection.</returns>
    int SelectionLength(RichEditBoxSelectionChangingEventArgs e);

    /// <summary>
    /// Gets the starting index of the text selection.
    /// </summary>
    /// <param name="e">The requested <see cref="RichEditBoxSelectionChangingEventArgs"/>.</param>
    /// <returns>The starting index of the text selection.</returns>
    int SelectionStart(RichEditBoxSelectionChangingEventArgs e);
}