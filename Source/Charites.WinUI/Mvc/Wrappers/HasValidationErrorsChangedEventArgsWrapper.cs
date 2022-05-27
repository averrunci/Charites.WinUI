// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="HasValidationErrorsChangedEventArgs"/>
/// resolved by <see cref="IHasValidationErrorsChangedEventArgsResolver"/>.
/// </summary>
public static class HasValidationErrorsChangedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IHasValidationErrorsChangedEventArgsResolver"/>
    /// that resolves data of the <see cref="HasValidationErrorsChangedEventArgs"/>.
    /// </summary>
    public static IHasValidationErrorsChangedEventArgsResolver Resolver { get; set; } = new DefaultHasValidationErrorsChangedEventArgsResolver();

    /// <summary>
    /// Gets the new validation error value.
    /// </summary>
    /// <param name="e">The requested <see cref="HasValidationErrorsChangedEventArgs"/>.</param>
    /// <returns><c>true</c> if the content is valid; otherwise, <c>false</c>.</returns>
    public static bool NewValue(this HasValidationErrorsChangedEventArgs e) => Resolver.NewValue(e);

    private sealed class DefaultHasValidationErrorsChangedEventArgsResolver : IHasValidationErrorsChangedEventArgsResolver
    {
        bool IHasValidationErrorsChangedEventArgsResolver.NewValue(HasValidationErrorsChangedEventArgs e) => e.NewValue;
    }
}

/// <summary>
/// Resolves data of the <see cref="HasValidationErrorsChangedEventArgs"/>.
/// </summary>
public interface IHasValidationErrorsChangedEventArgsResolver
{
    /// <summary>
    /// Gets the new validation error value.
    /// </summary>
    /// <param name="e">The requested <see cref="HasValidationErrorsChangedEventArgs"/>.</param>
    /// <returns><c>true</c> if the content is valid; otherwise, <c>false</c>.</returns>
    bool NewValue(HasValidationErrorsChangedEventArgs e);
}