// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="TimePickedEventArgs"/>
/// resolved by <see cref="ITimePickedEventArgsResolver"/>.
/// </summary>
public static class TimePickedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ITimePickedEventArgsResolver"/>
    /// that resolves data of the <see cref="TimePickedEventArgs"/>.
    /// </summary>
    public static ITimePickedEventArgsResolver Resolver { get; set; } = new DefaultTimePickedEventArgsResolver();

    /// <summary>
    /// Gets the time that was selected by the user.
    /// </summary>
    /// <param name="e">The requested <see cref="TimePickedEventArgs"/>.</param>
    /// <returns>The time that was selected by the user.</returns>
    public static TimeSpan NewTime(this TimePickedEventArgs e) => Resolver.NewTime(e);

    /// <summary>
    /// Gets the old time value.
    /// </summary>
    /// <param name="e">The requested <see cref="TimePickedEventArgs"/>.</param>
    /// <returns>The old time value.</returns>
    public static TimeSpan OldTime(this TimePickedEventArgs e) => Resolver.OldTime(e);

    private sealed class DefaultTimePickedEventArgsResolver : ITimePickedEventArgsResolver
    {
        TimeSpan ITimePickedEventArgsResolver.NewTime(TimePickedEventArgs e) => e.NewTime;
        TimeSpan ITimePickedEventArgsResolver.OldTime(TimePickedEventArgs e) => e.OldTime;
    }
}

/// <summary>
/// Resolves data of the <see cref="TimePickedEventArgs"/>.
/// </summary>
public interface ITimePickedEventArgsResolver
{
    /// <summary>
    /// Gets the time that was selected by the user.
    /// </summary>
    /// <param name="e">The requested <see cref="TimePickedEventArgs"/>.</param>
    /// <returns>The time that was selected by the user.</returns>
    TimeSpan NewTime(TimePickedEventArgs e);

    /// <summary>
    /// Gets the old time value.
    /// </summary>
    /// <param name="e">The requested <see cref="TimePickedEventArgs"/>.</param>
    /// <returns>The old time value.</returns>
    TimeSpan OldTime(TimePickedEventArgs e);
}