// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="WindowActivatedEventArgs"/>
/// resolved by <see cref="IWindowActivatedEventArgsResolver"/>.
/// </summary>
public static class WindowActivatedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IWindowActivatedEventArgsResolver"/>
    /// that resolves data of the <see cref="WindowActivatedEventArgs"/>.
    /// </summary>
    public static IWindowActivatedEventArgsResolver Resolver { get; set; } = new DefaultWindowActivatedEventArgsResolver();

    /// <summary>
    /// Gets a value that indicates whether the <see cref="Window.Activated"/> event was handled.
    /// </summary>
    /// <param name="e">The requested <see cref="WindowActivatedEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> if the event has been handled by the appropriate delegate; otherwise, <c>false</c>.
    /// </returns>
    public static bool Handled(this WindowActivatedEventArgs e) => Resolver.Handled(e);

    /// <summary>
    /// Sets a value that indicates whether the <see cref="Window.Activated"/> event was handled.
    /// </summary>
    /// <param name="e">The requested <see cref="WindowActivatedEventArgs"/>.</param>
    /// <param name="handled">
    /// <c>true</c> if the event has been handled by the appropriate delegate; otherwise, <c>false</c>.
    /// </param>
    public static void Handled(this WindowActivatedEventArgs e, bool handled) => Resolver.Handled(e, handled);

    /// <summary>
    /// Gets the <see cref="WindowActivationState"/> at the time the event was raised.
    /// </summary>
    /// <param name="e">The requested <see cref="WindowActivatedEventArgs"/>.</param>
    /// <returns>The activation state of the window.</returns>
    public static WindowActivationState WindowActivationState(this WindowActivatedEventArgs e) => Resolver.WindowActivationState(e);

    private sealed class DefaultWindowActivatedEventArgsResolver : IWindowActivatedEventArgsResolver
    {
        bool IWindowActivatedEventArgsResolver.Handled(WindowActivatedEventArgs e) => e.Handled;
        void IWindowActivatedEventArgsResolver.Handled(WindowActivatedEventArgs e, bool handled) => e.Handled = handled;
        WindowActivationState IWindowActivatedEventArgsResolver.WindowActivationState(WindowActivatedEventArgs e) => e.WindowActivationState;
    }
}

/// <summary>
/// Resolves data of the <see cref="WindowActivatedEventArgs"/>.
/// </summary>
public interface IWindowActivatedEventArgsResolver
{
    /// <summary>
    /// Gets a value that indicates whether the <see cref="Window.Activated"/> event was handled.
    /// </summary>
    /// <param name="e">The requested <see cref="WindowActivatedEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> if the event has been handled by the appropriate delegate; otherwise, <c>false</c>.
    /// </returns>
    bool Handled(WindowActivatedEventArgs e);

    /// <summary>
    /// Sets a value that indicates whether the <see cref="Window.Activated"/> event was handled.
    /// </summary>
    /// <param name="e">The requested <see cref="WindowActivatedEventArgs"/>.</param>
    /// <param name="handled">
    /// <c>true</c> if the event has been handled by the appropriate delegate; otherwise, <c>false</c>.
    /// </param>
    void Handled(WindowActivatedEventArgs e, bool handled);

    /// <summary>
    /// Gets the <see cref="WindowActivationState"/> at the time the event was raised.
    /// </summary>
    /// <param name="e">The requested <see cref="WindowActivatedEventArgs"/>.</param>
    /// <returns>The activation state of the window.</returns>
    WindowActivationState WindowActivationState(WindowActivatedEventArgs e);
}