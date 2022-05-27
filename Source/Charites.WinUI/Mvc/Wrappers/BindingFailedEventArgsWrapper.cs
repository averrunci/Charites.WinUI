// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="BindingFailedEventArgs"/>
/// resolved by <see cref="IBindingFailedEventArgsResolver"/>.
/// </summary>
public static class BindingFailedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IBindingFailedEventArgsResolver"/>
    /// that resolves data of the <see cref="BindingFailedEventArgs"/>.
    /// </summary>
    public static IBindingFailedEventArgsResolver Resolver { get; set; } = new DefaultBindingFailedEventArgsResolver();

    /// <summary>
    /// Gets the explanation of the binding failure.
    /// </summary>
    /// <param name="e">The requested <see cref="BindingFailedEventArgs"/>.</param>
    /// <returns>The reason the binding failed.</returns>
    public static string Message(this BindingFailedEventArgs e) => Resolver.Message(e);

    private sealed class DefaultBindingFailedEventArgsResolver : IBindingFailedEventArgsResolver
    {
        string IBindingFailedEventArgsResolver.Message(BindingFailedEventArgs e) => e.Message;
    }
}

/// <summary>
/// Resolves data of the <see cref="BindingFailedEventArgs"/>.
/// </summary>
public interface IBindingFailedEventArgsResolver
{
    /// <summary>
    /// Gets the explanation of the binding failure.
    /// </summary>
    /// <param name="e">The requested <see cref="BindingFailedEventArgs"/>.</param>
    /// <returns>The reason the binding failed.</returns>
    string Message(BindingFailedEventArgs e);
}