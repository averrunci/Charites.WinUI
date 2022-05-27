// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="DatePickerSelectedValueChangedEventArgs"/>
/// resolved by <see cref="IDatePickerSelectedValueChangedEventArgsResolver"/>.
/// </summary>
public static class DatePickerSelectedValueChangedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IDatePickerSelectedValueChangedEventArgsResolver"/>
    /// that resolves data of the <see cref="DatePickerSelectedValueChangedEventArgs"/>.
    /// </summary>
    public static IDatePickerSelectedValueChangedEventArgsResolver Resolver { get; set; } = new DefaultDatePickerSelectedValueChangedEventArgsResolver();

    /// <summary>
    /// Gets the new date selected in the picker.
    /// </summary>
    /// <param name="e">The requested <see cref="DatePickerSelectedValueChangedEventArgs"/>.</param>
    /// <returns>The new date selected in the picker.</returns>
    public static DateTimeOffset? NewDate(this DatePickerSelectedValueChangedEventArgs e) => Resolver.NewDate(e);

    /// <summary>
    /// Gets the date previously selected in the picker.
    /// </summary>
    /// <param name="e">The requested <see cref="DatePickerSelectedValueChangedEventArgs"/>.</param>
    /// <returns>The date previously selected in the picker.</returns>
    public static DateTimeOffset? OldDate(this DatePickerSelectedValueChangedEventArgs e) => Resolver.OldDate(e);

    private sealed class DefaultDatePickerSelectedValueChangedEventArgsResolver : IDatePickerSelectedValueChangedEventArgsResolver
    {
        DateTimeOffset? IDatePickerSelectedValueChangedEventArgsResolver.NewDate(DatePickerSelectedValueChangedEventArgs e) => e.NewDate;
        DateTimeOffset? IDatePickerSelectedValueChangedEventArgsResolver.OldDate(DatePickerSelectedValueChangedEventArgs e) => e.OldDate;
    }
}

/// <summary>
/// Resolves data of the <see cref="DatePickerSelectedValueChangedEventArgs"/>.
/// </summary>
public interface IDatePickerSelectedValueChangedEventArgsResolver
{
    /// <summary>
    /// Gets the new date selected in the picker.
    /// </summary>
    /// <param name="e">The requested <see cref="DatePickerSelectedValueChangedEventArgs"/>.</param>
    /// <returns>The new date selected in the picker.</returns>
    DateTimeOffset? NewDate(DatePickerSelectedValueChangedEventArgs e);

    /// <summary>
    /// Gets the date previously selected in the picker.
    /// </summary>
    /// <param name="e">The requested <see cref="DatePickerSelectedValueChangedEventArgs"/>.</param>
    /// <returns>The date previously selected in the picker.</returns>
    DateTimeOffset? OldDate(DatePickerSelectedValueChangedEventArgs e);
}