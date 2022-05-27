// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using System.Windows.Input;
using Microsoft.UI.Xaml.Input;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="CanExecuteRequestedEventArgs"/>
/// resolved by <see cref="ICanExecuteRequestedEventArgsResolver"/>.
/// </summary>
public static class CanExecuteRequestedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ICanExecuteRequestedEventArgsResolver"/>
    /// that resolves data of the <see cref="CanExecuteRequestedEventArgs"/>.
    /// </summary>
    public static ICanExecuteRequestedEventArgsResolver Resolver { get; set; } = new DefaultCanExecuteRequestedEventArgsResolver();

    /// <summary>
    /// Gets a value indicating whether the <see cref="ICommand"/> that raised this event is able to execute.
    /// </summary>
    /// <param name="e">The requested <see cref="CanExecuteRequestedEventArgs"/>.</param>
    /// <returns><c>true</c> if the <see cref="ICommand"/> is able to execute; otherwise, <c>false</c>.</returns>
    public static bool CanExecute(this CanExecuteRequestedEventArgs e) => Resolver.CanExecute(e);

    /// <summary>
    /// Sets a value indicating whether the ICommand that raised this event is able to execute.
    /// </summary>
    /// <param name="e">The requested <see cref="CanExecuteRequestedEventArgs"/>.</param>
    /// <param name="canExecute"><c>true</c> if the ICommand is able to execute; otherwise, <c>false</c>.</param>
    public static void CanExecute(this CanExecuteRequestedEventArgs e, bool canExecute) => Resolver.CanExecute(e, canExecute);

    /// <summary>
    /// Gets the command parameter passed into the <see cref="ICommand.CanExecute"/> method that raised this event.
    /// </summary>
    /// <param name="e">The requested <see cref="CanExecuteRequestedEventArgs"/>.</param>
    /// <returns>The command parameter passed into the <see cref="ICommand.CanExecute"/> method that raised this event.</returns>
    public static object? Parameter(this CanExecuteRequestedEventArgs e) => Resolver.Parameter(e);

    private sealed class DefaultCanExecuteRequestedEventArgsResolver : ICanExecuteRequestedEventArgsResolver
    {
        bool ICanExecuteRequestedEventArgsResolver.CanExecute(CanExecuteRequestedEventArgs e) => e.CanExecute;
        void ICanExecuteRequestedEventArgsResolver.CanExecute(CanExecuteRequestedEventArgs e, bool canExecute) => e.CanExecute = canExecute;
        object? ICanExecuteRequestedEventArgsResolver.Parameter(CanExecuteRequestedEventArgs e) => e.Parameter;
    }
}

/// <summary>
/// Resolves data of the <see cref="CanExecuteRequestedEventArgs"/>.
/// </summary>
public interface ICanExecuteRequestedEventArgsResolver
{
    /// <summary>
    /// Gets a value indicating whether the <see cref="ICommand"/> that raised this event is able to execute.
    /// </summary>
    /// <param name="e">The requested <see cref="CanExecuteRequestedEventArgs"/>.</param>
    /// <returns><c>true</c> if the <see cref="ICommand"/> is able to execute; otherwise, <c>false</c>.</returns>
    bool CanExecute(CanExecuteRequestedEventArgs e);

    /// <summary>
    /// Sets a value indicating whether the ICommand that raised this event is able to execute.
    /// </summary>
    /// <param name="e">The requested <see cref="CanExecuteRequestedEventArgs"/>.</param>
    /// <param name="canExecute"><c>true</c> if the ICommand is able to execute; otherwise, <c>false</c>.</param>
    void CanExecute(CanExecuteRequestedEventArgs e, bool canExecute);

    /// <summary>
    /// Gets the command parameter passed into the <see cref="ICommand.CanExecute"/> method that raised this event.
    /// </summary>
    /// <param name="e">The requested <see cref="CanExecuteRequestedEventArgs"/>.</param>
    /// <returns>The command parameter passed into the <see cref="ICommand.CanExecute"/> method that raised this event.</returns>
    object? Parameter(CanExecuteRequestedEventArgs e);
}