// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="FocusManagerGotFocusEventArgs"/>
/// resolved by <see cref="IFocusManagerGotFocusEventArgsResolver"/>.
/// </summary>
public static class FocusManagerGotFocusEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IFocusManagerGotFocusEventArgsResolver"/>
    /// that resolves data of the <see cref="FocusManagerGotFocusEventArgs"/>.
    /// </summary>
    public static IFocusManagerGotFocusEventArgsResolver Resolver { get; set; } = new DefaultFocusManagerGotFocusEventArgsResolver();

    /// <summary>
    /// Gets the unique ID generated when a focus movement event is initiated.
    /// </summary>
    /// <param name="e">The requested <see cref="FocusManagerGotFocusEventArgs"/>.</param>
    /// <returns>The unique ID.</returns>
    public static Guid CorrelationId(this FocusManagerGotFocusEventArgs e) => Resolver.CorrelationId(e);

    /// <summary>
    /// Gets the most recent focused element.
    /// </summary>
    /// <param name="e">The requested <see cref="FocusManagerGotFocusEventArgs"/>.</param>
    /// <returns>The most recent focused element.</returns>
    public static DependencyObject NewFocusedElement(this FocusManagerGotFocusEventArgs e) => Resolver.NewFocusedElement(e);

    private sealed class DefaultFocusManagerGotFocusEventArgsResolver : IFocusManagerGotFocusEventArgsResolver
    {
        Guid IFocusManagerGotFocusEventArgsResolver.CorrelationId(FocusManagerGotFocusEventArgs e) => e.CorrelationId;
        DependencyObject IFocusManagerGotFocusEventArgsResolver.NewFocusedElement(FocusManagerGotFocusEventArgs e) => e.NewFocusedElement;
    }
}

/// <summary>
/// Resolves data of the <see cref="FocusManagerGotFocusEventArgs"/>.
/// </summary>
public interface IFocusManagerGotFocusEventArgsResolver
{
    /// <summary>
    /// Gets the unique ID generated when a focus movement event is initiated.
    /// </summary>
    /// <param name="e">The requested <see cref="FocusManagerGotFocusEventArgs"/>.</param>
    /// <returns>The unique ID.</returns>
    Guid CorrelationId(FocusManagerGotFocusEventArgs e);

    /// <summary>
    /// Gets the most recent focused element.
    /// </summary>
    /// <param name="e">The requested <see cref="FocusManagerGotFocusEventArgs"/>.</param>
    /// <returns>The most recent focused element.</returns>
    DependencyObject NewFocusedElement(FocusManagerGotFocusEventArgs e);
}