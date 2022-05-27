// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="InfoBarClosingEventArgs"/>
/// resolved by <see cref="IInfoBarClosingEventArgsResolver"/>.
/// </summary>
public static class InfoBarClosingEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IInfoBarClosingEventArgsResolver"/>
    /// that resolves data of the <see cref="InfoBarClosingEventArgs"/>.
    /// </summary>
    public static IInfoBarClosingEventArgsResolver Resolver { get; set; } = new DefaultInfoBarClosingEventArgsResolver();

    /// <summary>
    /// Gets a value that indicates whether the <see cref="InfoBar.Closing"/> event should be canceled in the <see cref="InfoBar"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="InfoBarClosingEventArgs"/>.</param>
    /// <returns><c>true</c> if the event is canceled; otherwise, <c>false</c>.</returns>
    public static bool Cancel(this InfoBarClosingEventArgs e) => Resolver.Cancel(e);

    /// <summary>
    /// Sets a value that indicates whether the <see cref="InfoBar.Closing"/> event should be canceled in the <see cref="InfoBar"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="InfoBarClosingEventArgs"/>.</param>
    /// <param name="cancel"><c>true</c> if the event is canceled; otherwise, <c>false</c>.</param>
    public static void Cancel(this InfoBarClosingEventArgs e, bool cancel) => Resolver.Cancel(e, cancel);

    /// <summary>
    /// Gets a constant that specifies whether the cause of the <see cref="InfoBar.Closing"/> event was
    /// due to user interaction (Close button click) or programmatic closure.
    /// </summary>
    /// <param name="e">The requested <see cref="InfoBarClosingEventArgs"/>.</param>
    /// <returns>
    /// A constant that specifies whether the cause of the <see cref="InfoBar.Closing"/> event was
    /// due to user interaction (Close button click) or programmatic closure.
    /// </returns>
    public static InfoBarCloseReason Reason(this InfoBarClosingEventArgs e) => Resolver.Reason(e);

    private sealed class DefaultInfoBarClosingEventArgsResolver : IInfoBarClosingEventArgsResolver
    {
        bool IInfoBarClosingEventArgsResolver.Cancel(InfoBarClosingEventArgs e) => e.Cancel;
        void IInfoBarClosingEventArgsResolver.Cancel(InfoBarClosingEventArgs e, bool cancel) => e.Cancel = cancel;
        InfoBarCloseReason IInfoBarClosingEventArgsResolver.Reason(InfoBarClosingEventArgs e) => e.Reason;
    }
}

/// <summary>
/// Resolves data of the <see cref="InfoBarClosingEventArgs"/>.
/// </summary>
public interface IInfoBarClosingEventArgsResolver
{
    /// <summary>
    /// Gets a value that indicates whether the <see cref="InfoBar.Closing"/> event should be canceled in the <see cref="InfoBar"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="InfoBarClosingEventArgs"/>.</param>
    /// <returns><c>true</c> if the event is canceled; otherwise, <c>false</c>.</returns>
    bool Cancel(InfoBarClosingEventArgs e);

    /// <summary>
    /// Sets a value that indicates whether the <see cref="InfoBar.Closing"/> event should be canceled in the <see cref="InfoBar"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="InfoBarClosingEventArgs"/>.</param>
    /// <param name="cancel"><c>true</c> if the event is canceled; otherwise, <c>false</c>.</param>
    void Cancel(InfoBarClosingEventArgs e, bool cancel);

    /// <summary>
    /// Gets a constant that specifies whether the cause of the <see cref="InfoBar.Closing"/> event was
    /// due to user interaction (Close button click) or programmatic closure.
    /// </summary>
    /// <param name="e">The requested <see cref="InfoBarClosingEventArgs"/>.</param>
    /// <returns>
    /// A constant that specifies whether the cause of the <see cref="InfoBar.Closing"/> event was
    /// due to user interaction (Close button click) or programmatic closure.
    /// </returns>
    InfoBarCloseReason Reason(InfoBarClosingEventArgs e);
}