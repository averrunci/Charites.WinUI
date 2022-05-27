// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="NumberBoxValueChangedEventArgs"/>
/// resolved by <see cref="INumberBoxValueChangedEventArgsResolver"/>.
/// </summary>
public static class NumberBoxValueChangedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="INumberBoxValueChangedEventArgsResolver"/>
    /// that resolves data of the <see cref="NumberBoxValueChangedEventArgs"/>.
    /// </summary>
    public static INumberBoxValueChangedEventArgsResolver Resolver { get; set; } = new DefaultNumberBoxValueChangedEventArgsResolver();

    /// <summary>
    /// Gets the new <see cref="NumberBox.Value"/> to be set for a <see cref="NumberBox"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="NumberBoxValueChangedEventArgs"/>.</param>
    /// <returns>The new <see cref="NumberBox.Value"/> to be set for a <see cref="NumberBox"/>.</returns>
    public static double NewValue(this NumberBoxValueChangedEventArgs e) => Resolver.NewValue(e);

    /// <summary>
    /// Gets the old <see cref="NumberBox.Value"/> being replaced ins <see cref="NumberBox"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="NumberBoxValueChangedEventArgs"/>.</param>
    /// <returns>The old <see cref="NumberBox.Value"/> being replaced ins <see cref="NumberBox"/>.</returns>
    public static double OldValue(this NumberBoxValueChangedEventArgs e) => Resolver.OldValue(e);

    private sealed class DefaultNumberBoxValueChangedEventArgsResolver : INumberBoxValueChangedEventArgsResolver
    {
        double INumberBoxValueChangedEventArgsResolver.NewValue(NumberBoxValueChangedEventArgs e) => e.NewValue;
        double INumberBoxValueChangedEventArgsResolver.OldValue(NumberBoxValueChangedEventArgs e) => e.OldValue;
    }
}

/// <summary>
/// Resolves data of the <see cref="NumberBoxValueChangedEventArgs"/>.
/// </summary>
public interface INumberBoxValueChangedEventArgsResolver
{
    /// <summary>
    /// Gets the new <see cref="NumberBox.Value"/> to be set for a <see cref="NumberBox"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="NumberBoxValueChangedEventArgs"/>.</param>
    /// <returns>The new <see cref="NumberBox.Value"/> to be set for a <see cref="NumberBox"/>.</returns>
    double NewValue(NumberBoxValueChangedEventArgs e);

    /// <summary>
    /// Gets the old <see cref="NumberBox.Value"/> being replaced ins <see cref="NumberBox"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="NumberBoxValueChangedEventArgs"/>.</param>
    /// <returns>The old <see cref="NumberBox.Value"/> being replaced ins <see cref="NumberBox"/>.</returns>
    double OldValue(NumberBoxValueChangedEventArgs e);
}