// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="TextControlCuttingToClipboardEventArgs"/>
/// resolved by <see cref="ITextControlCuttingToClipboardEventArgsResolver"/>.
/// </summary>
public static class TextControlCuttingToClipboardEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ITextControlCuttingToClipboardEventArgsResolver"/>
    /// that resolves data of the <see cref="TextControlCuttingToClipboardEventArgs"/>.
    /// </summary>
    public static ITextControlCuttingToClipboardEventArgsResolver Resolver { get; set; } = new DefaultTextControlCuttingToClipboardEventArgsResolver();

    /// <summary>
    /// Gets a value that marks the routed event as handled.
    /// A <c>true</c> value for Handled prevents most handlers along the event route from handling the same event again.
    /// </summary>
    /// <param name="e">The requested <see cref="TextControlCuttingToClipboardEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> to mark the routed event handled. <c>false</c> to leave the routed event unhandled,
    /// which causes the default cut action to be performed.
    /// </returns>
    public static bool Handled(this TextControlCuttingToClipboardEventArgs e) => Resolver.Handled(e);

    /// <summary>
    /// Sets a value that marks the routed event as handled.
    /// A <c>true</c> value for Handled prevents most handlers along the event route from handling the same event again.
    /// </summary>
    /// <param name="e">The requested <see cref="TextControlCuttingToClipboardEventArgs"/>.</param>
    /// <param name="handled">
    /// <c>true</c> to mark the routed event handled. <c>false</c> to leave the routed event unhandled,
    /// which causes the default cut action to be performed.
    /// </param>
    public static void Handled(this TextControlCuttingToClipboardEventArgs e, bool handled) => Resolver.Handled(e, handled);

    private sealed class DefaultTextControlCuttingToClipboardEventArgsResolver : ITextControlCuttingToClipboardEventArgsResolver
    {
        bool ITextControlCuttingToClipboardEventArgsResolver.Handled(TextControlCuttingToClipboardEventArgs e) => e.Handled;
        void ITextControlCuttingToClipboardEventArgsResolver.Handled(TextControlCuttingToClipboardEventArgs e, bool handled) => e.Handled = handled;
    }
}

/// <summary>
/// Resolves data of the <see cref="TextControlCuttingToClipboardEventArgs"/>.
/// </summary>
public interface ITextControlCuttingToClipboardEventArgsResolver
{
    /// <summary>
    /// Gets a value that marks the routed event as handled.
    /// A <c>true</c> value for Handled prevents most handlers along the event route from handling the same event again.
    /// </summary>
    /// <param name="e">The requested <see cref="TextControlCuttingToClipboardEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> to mark the routed event handled. <c>false</c> to leave the routed event unhandled,
    /// which causes the default cut action to be performed.
    /// </returns>
    bool Handled(TextControlCuttingToClipboardEventArgs e);

    /// <summary>
    /// Sets a value that marks the routed event as handled.
    /// A <c>true</c> value for Handled prevents most handlers along the event route from handling the same event again.
    /// </summary>
    /// <param name="e">The requested <see cref="TextControlCuttingToClipboardEventArgs"/>.</param>
    /// <param name="handled">
    /// <c>true</c> to mark the routed event handled. <c>false</c> to leave the routed event unhandled,
    /// which causes the default cut action to be performed.
    /// </param>
    void Handled(TextControlCuttingToClipboardEventArgs e, bool handled);
}