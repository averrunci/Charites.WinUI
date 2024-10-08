﻿// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="CalendarDatePickerDateChangedEventArgs"/>
/// resolved by <see cref="ICalendarDatePickerDateChangedEventArgsResolver"/>.
/// </summary>
public static class CalendarDatePickerDateChangedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ICalendarDatePickerDateChangedEventArgsResolver"/>
    /// that resolves data of the <see cref="CalendarDatePickerDateChangedEventArgs"/>.
    /// </summary>
    public static ICalendarDatePickerDateChangedEventArgsResolver Resolver { get; set; } = new DefaultCalendarDatePickerDateChangedEventArgsResolver();

    /// <summary>
    /// Gets the date that is currently selected in the <see cref="CalendarDatePicker"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="CalendarDatePickerDateChangedEventArgs"/>.</param>
    /// <returns>The date that is currently selected in the <see cref="CalendarDatePicker"/>.</returns>
    public static DateTimeOffset? NewDate(this CalendarDatePickerDateChangedEventArgs e) => Resolver.NewDate(e);

    /// <summary>
    /// Gets the date that was previously selected in the <see cref="CalendarDatePicker"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="CalendarDatePickerDateChangedEventArgs"/>.</param>
    /// <returns>The date that was previously selected in the <see cref="CalendarDatePicker"/>.</returns>
    public static DateTimeOffset? OldDate(this CalendarDatePickerDateChangedEventArgs e) => Resolver.OldDate(e);

    private sealed class DefaultCalendarDatePickerDateChangedEventArgsResolver : ICalendarDatePickerDateChangedEventArgsResolver
    {
        DateTimeOffset? ICalendarDatePickerDateChangedEventArgsResolver.NewDate(CalendarDatePickerDateChangedEventArgs e) => e.NewDate;
        DateTimeOffset? ICalendarDatePickerDateChangedEventArgsResolver.OldDate(CalendarDatePickerDateChangedEventArgs e) => e.OldDate;
    }
}

/// <summary>
/// Resolves data of the <see cref="CalendarDatePickerDateChangedEventArgs"/>.
/// </summary>
public interface ICalendarDatePickerDateChangedEventArgsResolver
{
    /// <summary>
    /// Gets the date that is currently selected in the <see cref="CalendarDatePicker"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="CalendarDatePickerDateChangedEventArgs"/>.</param>
    /// <returns>The date that is currently selected in the <see cref="CalendarDatePicker"/>.</returns>
    DateTimeOffset? NewDate(CalendarDatePickerDateChangedEventArgs e);

    /// <summary>
    /// Gets the date that was previously selected in the <see cref="CalendarDatePicker"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="CalendarDatePickerDateChangedEventArgs"/>.</param>
    /// <returns>The date that was previously selected in the <see cref="CalendarDatePicker"/>.</returns>
    DateTimeOffset? OldDate(CalendarDatePickerDateChangedEventArgs e);
}