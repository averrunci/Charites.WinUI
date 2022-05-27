// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="WindowVisibilityChangedEventArgs"/>
/// resolved by <see cref="IWindowVisibilityChangedEventArgsResolver"/>.
/// </summary>
public static class WindowVisibilityChangedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IWindowVisibilityChangedEventArgsResolver"/>
    /// that resolves data of the <see cref="WindowVisibilityChangedEventArgs"/>.
    /// </summary>
    public static IWindowVisibilityChangedEventArgsResolver Resolver { get; set; } = new DefaultWindowVisibilityChangedEventArgsResolver();

    /// <summary>
    /// Gets a value that indicates whether the <see cref="Window.VisibilityChanged"/> event was handled.
    /// </summary>
    /// <param name="e">The requested <see cref="WindowVisibilityChangedEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> if the event has been handled by the appropriate delegate; otherwise, <c>false</c>.
    /// </returns>
    public static bool Handled(this WindowVisibilityChangedEventArgs e) => Resolver.Handled(e);

    /// <summary>
    /// Sets a value that indicates whether the <see cref="Window.VisibilityChanged"/> event was handled.
    /// </summary>
    /// <param name="e">The requested <see cref="WindowVisibilityChangedEventArgs"/>.</param>
    /// <param name="handled">
    /// <c>true</c> if the event has been handled by the appropriate delegate; otherwise, <c>false</c>.
    /// </param>
    public static void Handled(this WindowVisibilityChangedEventArgs e, bool handled) => Resolver.Handled(e, handled);

    /// <summary>
    /// Gets a value that indicates whether the window is visible or not.
    /// </summary>
    /// <param name="e">The requested <see cref="WindowVisibilityChangedEventArgs"/>.</param>
    /// <returns><c>true</c> if the window is visible; otherwise, <c>false</c>.</returns>
    public static bool Visible(this WindowVisibilityChangedEventArgs e) => Resolver.Visible(e);

    private sealed class DefaultWindowVisibilityChangedEventArgsResolver : IWindowVisibilityChangedEventArgsResolver
    {
        bool IWindowVisibilityChangedEventArgsResolver.Handled(WindowVisibilityChangedEventArgs e) => e.Handled;
        void IWindowVisibilityChangedEventArgsResolver.Handled(WindowVisibilityChangedEventArgs e, bool handled) => e.Handled = handled;
        bool IWindowVisibilityChangedEventArgsResolver.Visible(WindowVisibilityChangedEventArgs e) => e.Visible;
    }
}

/// <summary>
/// Resolves data of the <see cref="WindowVisibilityChangedEventArgs"/>.
/// </summary>
public interface IWindowVisibilityChangedEventArgsResolver
{
    /// <summary>
    /// Gets a value that indicates whether the <see cref="Window.VisibilityChanged"/> event was handled.
    /// </summary>
    /// <param name="e">The requested <see cref="WindowVisibilityChangedEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> if the event has been handled by the appropriate delegate; otherwise, <c>false</c>.
    /// </returns>
    bool Handled(WindowVisibilityChangedEventArgs e);

    /// <summary>
    /// Sets a value that indicates whether the <see cref="Window.VisibilityChanged"/> event was handled.
    /// </summary>
    /// <param name="e">The requested <see cref="WindowVisibilityChangedEventArgs"/>.</param>
    /// <param name="handled">
    /// <c>true</c> if the event has been handled by the appropriate delegate; otherwise, <c>false</c>.
    /// </param>
    void Handled(WindowVisibilityChangedEventArgs e, bool handled);

    /// <summary>
    /// Gets a value that indicates whether the window is visible or not.
    /// </summary>
    /// <param name="e">The requested <see cref="WindowVisibilityChangedEventArgs"/>.</param>
    /// <returns><c>true</c> if the window is visible; otherwise, <c>false</c>.</returns>
    bool Visible(WindowVisibilityChangedEventArgs e);
}