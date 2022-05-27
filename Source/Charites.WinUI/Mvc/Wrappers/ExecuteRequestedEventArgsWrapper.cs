// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Input;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="ExecuteRequestedEventArgs"/>
/// resolved by <see cref="IExecuteRequestedEventArgsResolver"/>.
/// </summary>
public static class ExecuteRequestedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IExecuteRequestedEventArgsResolver"/>
    /// that resolves data of the <see cref="ExecuteRequestedEventArgs"/>.
    /// </summary>
    public static IExecuteRequestedEventArgsResolver Resolver { get; set; } = new DefaultExecuteRequestedEventArgsResolver();

    /// <summary>
    /// Gets the command parameter passed into the Execute method that raised this event.
    /// </summary>
    /// <param name="e">The requested <see cref="ExecuteRequestedEventArgs"/>.</param>
    /// <returns>The command parameter passed into the Execute method that raised this event.</returns>
    public static object? Parameter(this ExecuteRequestedEventArgs e) => Resolver.Parameter(e);

    private sealed class DefaultExecuteRequestedEventArgsResolver : IExecuteRequestedEventArgsResolver
    {
        object? IExecuteRequestedEventArgsResolver.Parameter(ExecuteRequestedEventArgs e) => e.Parameter;
    }
}

/// <summary>
/// Resolves data of the <see cref="ExecuteRequestedEventArgs"/>.
/// </summary>
public interface IExecuteRequestedEventArgsResolver
{
    /// <summary>
    /// Gets the command parameter passed into the Execute method that raised this event.
    /// </summary>
    /// <param name="e">The requested <see cref="ExecuteRequestedEventArgs"/>.</param>
    /// <returns>The command parameter passed into the Execute method that raised this event.</returns>
    object? Parameter(ExecuteRequestedEventArgs e);
}