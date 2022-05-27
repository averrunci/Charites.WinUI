// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="TeachingTipClosedEventArgs"/>
/// resolved by <see cref="ITeachingTipClosedEventArgsResolver"/>.
/// </summary>
public static class TeachingTipClosedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ITeachingTipClosedEventArgsResolver"/>
    /// that resolves data of the <see cref="TeachingTipClosedEventArgs"/>.
    /// </summary>
    public static ITeachingTipClosedEventArgsResolver Resolver { get; set; } = new DefaultTeachingTipClosedEventArgsResolver();

    /// <summary>
    /// Gets a constant that specifies whether the cause of the <see cref="TeachingTip.Closed"/> event was
    /// due to user interaction (Close button click), light-dismissal, or programmatic closure.
    /// </summary>
    /// <param name="e">The requested <see cref="TeachingTipClosedEventArgs"/>.</param>
    /// <returns>
    /// A constant that specifies whether the cause of the <see cref="TeachingTip.Closed"/> event was
    /// due to user interaction (Close button click), light-dismissal, or programmatic closure.
    /// </returns>
    public static TeachingTipCloseReason Reason(this TeachingTipClosedEventArgs e) => Resolver.Reason(e);

    private sealed class DefaultTeachingTipClosedEventArgsResolver : ITeachingTipClosedEventArgsResolver
    {
        TeachingTipCloseReason ITeachingTipClosedEventArgsResolver.Reason(TeachingTipClosedEventArgs e) => e.Reason;
    }
}

/// <summary>
/// Resolves data of the <see cref="TeachingTipClosedEventArgs"/>.
/// </summary>
public interface ITeachingTipClosedEventArgsResolver
{
    /// <summary>
    /// Gets a constant that specifies whether the cause of the <see cref="TeachingTip.Closed"/> event was
    /// due to user interaction (Close button click), light-dismissal, or programmatic closure.
    /// </summary>
    /// <param name="e">The requested <see cref="TeachingTipClosedEventArgs"/>.</param>
    /// <returns>
    /// A constant that specifies whether the cause of the <see cref="TeachingTip.Closed"/> event was
    /// due to user interaction (Close button click), light-dismissal, or programmatic closure.
    /// </returns>
    TeachingTipCloseReason Reason(TeachingTipClosedEventArgs e);
}