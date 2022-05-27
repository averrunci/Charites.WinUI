// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="DatePickedEventArgs"/>
/// resolved by <see cref="IDatePickedEventArgsResolver"/>.
/// </summary>
public static class DatePickedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IDatePickedEventArgsResolver"/>
    /// that resolves data of the <see cref="DatePickedEventArgs"/>.
    /// </summary>
    public static IDatePickedEventArgsResolver Resolver { get; set; } = new DefaultDatePickedEventArgsResolver();

    /// <summary>
    /// Gets the date that was selected by the user.
    /// </summary>
    /// <param name="e">The requested <see cref="DatePickedEventArgs"/>.</param>
    /// <returns>The date that was selected by the user.</returns>
    public static DateTimeOffset NewDate(this DatePickedEventArgs e) => Resolver.NewDate(e);

    /// <summary>
    /// Gets the previous date.
    /// </summary>
    /// <param name="e">The requested <see cref="DatePickedEventArgs"/>.</param>
    /// <returns>The previous date.</returns>
    public static DateTimeOffset OldDate(this DatePickedEventArgs e) => Resolver.OldDate(e);

    private sealed class DefaultDatePickedEventArgsResolver : IDatePickedEventArgsResolver
    {
        DateTimeOffset IDatePickedEventArgsResolver.NewDate(DatePickedEventArgs e) => e.NewDate;
        DateTimeOffset IDatePickedEventArgsResolver.OldDate(DatePickedEventArgs e) => e.OldDate;
    }
}

/// <summary>
/// Resolves data of the <see cref="DatePickedEventArgs"/>.
/// </summary>
public interface IDatePickedEventArgsResolver
{
    /// <summary>
    /// Gets the date that was selected by the user.
    /// </summary>
    /// <param name="e">The requested <see cref="DatePickedEventArgs"/>.</param>
    /// <returns>The date that was selected by the user.</returns>
    DateTimeOffset NewDate(DatePickedEventArgs e);

    /// <summary>
    /// Gets the previous date.
    /// </summary>
    /// <param name="e">The requested <see cref="DatePickedEventArgs"/>.</param>
    /// <returns>The previous date.</returns>
    DateTimeOffset OldDate(DatePickedEventArgs e);
}