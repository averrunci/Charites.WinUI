// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="FocusManagerLostFocusEventArgs"/>
/// resolved by <see cref="IFocusManagerLostFocusEventArgsResolver"/>.
/// </summary>
public static class FocusManagerLostFocusEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IFocusManagerLostFocusEventArgsResolver"/>
    /// that resolves data of the <see cref="FocusManagerLostFocusEventArgs"/>.
    /// </summary>
    public static IFocusManagerLostFocusEventArgsResolver Resolver { get; set; } = new DefaultFocusManagerLostFocusEventArgsResolver();

    /// <summary>
    /// Gets the unique ID generated when a focus movement event is initiated.
    /// </summary>
    /// <param name="e">The requested <see cref="FocusManagerLostFocusEventArgs"/>.</param>
    /// <returns>The unique ID.</returns>
    public static Guid CorrelationId(this FocusManagerLostFocusEventArgs e) => Resolver.CorrelationId(e);

    /// <summary>
    /// Gets the last focused element.
    /// </summary>
    /// <param name="e">The requested <see cref="FocusManagerLostFocusEventArgs"/>.</param>
    /// <returns>The last focused element.</returns>
    public static DependencyObject OldFocusedElement(this FocusManagerLostFocusEventArgs e) => Resolver.OldFocusedElement(e);

    private sealed class DefaultFocusManagerLostFocusEventArgsResolver : IFocusManagerLostFocusEventArgsResolver
    {
        Guid IFocusManagerLostFocusEventArgsResolver.CorrelationId(FocusManagerLostFocusEventArgs e) => e.CorrelationId;
        DependencyObject IFocusManagerLostFocusEventArgsResolver.OldFocusedElement(FocusManagerLostFocusEventArgs e) => e.OldFocusedElement;
    }
}

/// <summary>
/// Resolves data of the <see cref="FocusManagerLostFocusEventArgs"/>.
/// </summary>
public interface IFocusManagerLostFocusEventArgsResolver
{
    /// <summary>
    /// Gets the unique ID generated when a focus movement event is initiated.
    /// </summary>
    /// <param name="e">The requested <see cref="FocusManagerLostFocusEventArgs"/>.</param>
    /// <returns>The unique ID.</returns>
    Guid CorrelationId(FocusManagerLostFocusEventArgs e);

    /// <summary>
    /// Gets the last focused element.
    /// </summary>
    /// <param name="e">The requested <see cref="FocusManagerLostFocusEventArgs"/>.</param>
    /// <returns>The last focused element.</returns>
    DependencyObject OldFocusedElement(FocusManagerLostFocusEventArgs e);
}