// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="WindowEventArgs"/>
/// resolved by <see cref="IWindowEventArgsResolver"/>.
/// </summary>
public static class WindowEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IWindowEventArgsResolver"/>
    /// that resolves data of the <see cref="WindowEventArgs"/>.
    /// </summary>
    public static IWindowEventArgsResolver Resolver { get; set; } = new DefaultWindowEventArgsResolver();

    /// <summary>
    /// Gets a value that indicates whether a <see cref="Window"/> event was handled.
    /// </summary>
    /// <param name="e">The requested <see cref="WindowEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> if the event has been handled by the appropriate delegate; otherwise, <c>false</c>.
    /// </returns>
    public static bool Handled(this WindowEventArgs e) => Resolver.Handled(e);

    /// <summary>
    /// Sets a value that indicates whether a <see cref="Window"/> event was handled.
    /// </summary>
    /// <param name="e">The requested <see cref="WindowEventArgs"/>.</param>
    /// <param name="handled">
    /// <c>true</c> if the event has been handled by the appropriate delegate; otherwise, <c>false</c>.
    /// </param>
    public static void Handled(this WindowEventArgs e, bool handled) => Resolver.Handled(e, handled);

    private sealed class DefaultWindowEventArgsResolver : IWindowEventArgsResolver
    {
        bool IWindowEventArgsResolver.Handled(WindowEventArgs e) => e.Handled;
        void IWindowEventArgsResolver.Handled(WindowEventArgs e, bool handled) => e.Handled = handled;
    }
}

/// <summary>
/// Resolves data of the <see cref="WindowEventArgs"/>.
/// </summary>
public interface IWindowEventArgsResolver
{
    /// <summary>
    /// Gets a value that indicates whether a <see cref="Window"/> event was handled.
    /// </summary>
    /// <param name="e">The requested <see cref="WindowEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> if the event has been handled by the appropriate delegate; otherwise, <c>false</c>.
    /// </returns>
    bool Handled(WindowEventArgs e);

    /// <summary>
    /// Sets a value that indicates whether a <see cref="Window"/> event was handled.
    /// </summary>
    /// <param name="e">The requested <see cref="WindowEventArgs"/>.</param>
    /// <param name="handled">
    /// <c>true</c> if the event has been handled by the appropriate delegate; otherwise, <c>false</c>.
    /// </param>
    void Handled(WindowEventArgs e, bool handled);
}