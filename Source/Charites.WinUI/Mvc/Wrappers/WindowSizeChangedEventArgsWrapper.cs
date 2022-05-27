// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.Foundation;
using Microsoft.UI.Xaml;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="WindowSizeChangedEventArgs"/>
/// resolved by <see cref="IWindowSizeChangedEventArgsResolver"/>.
/// </summary>
public static class WindowSizeChangedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IWindowSizeChangedEventArgsResolver"/>
    /// that resolves data of the <see cref="WindowSizeChangedEventArgs"/>.
    /// </summary>
    public static IWindowSizeChangedEventArgsResolver Resolver { get; set; } = new DefaultWindowSizeChangedEventArgsResolver();

    /// <summary>
    /// Gets a value that indicates whether the <see cref="Window.SizeChanged"/> event was handled.
    /// </summary>
    /// <param name="e">The requested <see cref="WindowSizeChangedEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> if the event has been handled by the appropriate delegate; otherwise, <c>false</c>.
    /// </returns>
    public static bool Handled(this WindowSizeChangedEventArgs e) => Resolver.Handled(e);

    /// <summary>
    /// Sets a value that indicates whether the <see cref="Window.SizeChanged"/> event was handled.
    /// </summary>
    /// <param name="e">The requested <see cref="WindowSizeChangedEventArgs"/>.</param>
    /// <param name="handled">
    /// <c>true</c> if the event has been handled by the appropriate delegate; otherwise, <c>false</c>.
    /// </param>
    public static void Handled(this WindowSizeChangedEventArgs e, bool handled) => Resolver.Handled(e, handled);

    /// <summary>
    /// Gets a value that indicates the size of the window in units of effective (view) pixels.
    /// </summary>
    /// <param name="e">The requested <see cref="WindowSizeChangedEventArgs"/>.</param>
    /// <returns>A value that indicates the size of the window in units of effective (view) pixels.</returns>
    public static Size Size(this WindowSizeChangedEventArgs e) => Resolver.Size(e);

    private sealed class DefaultWindowSizeChangedEventArgsResolver : IWindowSizeChangedEventArgsResolver
    {
        bool IWindowSizeChangedEventArgsResolver.Handled(WindowSizeChangedEventArgs e) => e.Handled;
        void IWindowSizeChangedEventArgsResolver.Handled(WindowSizeChangedEventArgs e, bool handled) => e.Handled = handled;
        Size IWindowSizeChangedEventArgsResolver.Size(WindowSizeChangedEventArgs e) => e.Size;
    }
}

/// <summary>
/// Resolves data of the <see cref="WindowSizeChangedEventArgs"/>.
/// </summary>
public interface IWindowSizeChangedEventArgsResolver
{
    /// <summary>
    /// Gets a value that indicates whether the <see cref="Window.SizeChanged"/> event was handled.
    /// </summary>
    /// <param name="e">The requested <see cref="WindowSizeChangedEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> if the event has been handled by the appropriate delegate; otherwise, <c>false</c>.
    /// </returns>
    bool Handled(WindowSizeChangedEventArgs e);

    /// <summary>
    /// Sets a value that indicates whether the <see cref="Window.SizeChanged"/> event was handled.
    /// </summary>
    /// <param name="e">The requested <see cref="WindowSizeChangedEventArgs"/>.</param>
    /// <param name="handled">
    /// <c>true</c> if the event has been handled by the appropriate delegate; otherwise, <c>false</c>.
    /// </param>
    void Handled(WindowSizeChangedEventArgs e, bool handled);

    /// <summary>
    /// Gets a value that indicates the size of the window in units of effective (view) pixels.
    /// </summary>
    /// <param name="e">The requested <see cref="WindowSizeChangedEventArgs"/>.</param>
    /// <returns>A value that indicates the size of the window in units of effective (view) pixels.</returns>
    Size Size(WindowSizeChangedEventArgs e);
}