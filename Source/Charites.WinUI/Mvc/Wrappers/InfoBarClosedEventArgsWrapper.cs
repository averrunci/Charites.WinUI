// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="InfoBarClosedEventArgs"/>
/// resolved by <see cref="IInfoBarClosedEventArgsResolver"/>.
/// </summary>
public static class InfoBarClosedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IInfoBarClosedEventArgsResolver"/>
    /// that resolves data of the <see cref="InfoBarClosedEventArgs"/>.
    /// </summary>
    public static IInfoBarClosedEventArgsResolver Resolver { get; set; } = new DefaultInfoBarClosedEventArgsResolver();

    /// <summary>
    /// Gets a constant that specifies whether the cause of the <see cref="InfoBar.Closed"/> event was
    /// due to user interaction (Close button click) or programmatic closure.
    /// </summary>
    /// <param name="e">The requested <see cref="InfoBarClosedEventArgs"/>.</param>
    /// <returns>
    /// A constant that specifies whether the cause of the <see cref="InfoBar.Closed"/> event was
    /// due to user interaction (Close button click) or programmatic closure.
    /// </returns>
    public static InfoBarCloseReason Reason(this InfoBarClosedEventArgs e) => Resolver.Reason(e);

    private sealed class DefaultInfoBarClosedEventArgsResolver : IInfoBarClosedEventArgsResolver
    {
        InfoBarCloseReason IInfoBarClosedEventArgsResolver.Reason(InfoBarClosedEventArgs e) => e.Reason;
    }
}

/// <summary>
/// Resolves data of the <see cref="InfoBarClosedEventArgs"/>.
/// </summary>
public interface IInfoBarClosedEventArgsResolver
{
    /// <summary>
    /// Gets a constant that specifies whether the cause of the <see cref="InfoBar.Closed"/> event was
    /// due to user interaction (Close button click) or programmatic closure.
    /// </summary>
    /// <param name="e">The requested <see cref="InfoBarClosedEventArgs"/>.</param>
    /// <returns>
    /// A constant that specifies whether the cause of the <see cref="InfoBar.Closed"/> event was
    /// due to user interaction (Close button click) or programmatic closure.
    /// </returns>
    InfoBarCloseReason Reason(InfoBarClosedEventArgs e);
}