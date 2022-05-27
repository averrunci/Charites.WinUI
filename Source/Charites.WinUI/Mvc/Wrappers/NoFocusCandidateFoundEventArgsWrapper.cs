// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Input;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="NoFocusCandidateFoundEventArgs"/>
/// resolved by <see cref="INoFocusCandidateFoundEventArgsResolver"/>.
/// </summary>
public static class NoFocusCandidateFoundEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="INoFocusCandidateFoundEventArgsResolver"/>
    /// that resolves data of the <see cref="NoFocusCandidateFoundEventArgs"/>.
    /// </summary>
    public static INoFocusCandidateFoundEventArgsResolver Resolver { get; set; } = new DefaultNoFocusCandidateFoundEventArgsResolver();

    /// <summary>
    /// Gets the direction that focus moved from element to element within the app UI.
    /// </summary>
    /// <param name="e">The requested <see cref="NoFocusCandidateFoundEventArgs"/>.</param>
    /// <returns>The direction of focus movement.</returns>
    public static FocusNavigationDirection Direction(this NoFocusCandidateFoundEventArgs e) => Resolver.Direction(e);

    /// <summary>
    /// Gets a value that marks the routed event as handled.
    /// A <c>true</c> value for Handled prevents most handlers along the event route from handling the same event again.
    /// </summary>
    /// <param name="e">The requested <see cref="NoFocusCandidateFoundEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> to mark the routed event handled. <c>false</c> to leave the routed event unhandled,
    /// which permits the event to potentially route further and be acted on by other handlers.
    /// </returns>
    public static bool Handled(this NoFocusCandidateFoundEventArgs e) => Resolver.Handled(e);

    /// <summary>
    /// Sets a value that marks the routed event as handled.
    /// A <c>true</c> value for Handled prevents most handlers along the event route from handling the same event again.
    /// </summary>
    /// <param name="e">The requested <see cref="NoFocusCandidateFoundEventArgs"/>.</param>
    /// <param name="handled">
    /// <c>true</c> to mark the routed event handled. <c>false</c> to leave the routed event unhandled,
    /// which permits the event to potentially route further and be acted on by other handlers.
    /// </param>
    public static void Handled(this NoFocusCandidateFoundEventArgs e, bool handled) => Resolver.Handled(e, handled);

    /// <summary>
    /// Gets the input device type from which input events are received.
    /// </summary>
    /// <param name="e">The requested <see cref="NoFocusCandidateFoundEventArgs"/>.</param>
    /// <returns>The input device type.</returns>
    public static FocusInputDeviceKind InputDevice(this NoFocusCandidateFoundEventArgs e) => Resolver.InputDevice(e);

    /// <summary>
    /// Gets a reference to the object that raised the event.
    /// This is often a template part of a control rather than an element that was declared in your app UI.
    /// </summary>
    /// <param name="e">The requested <see cref="NoFocusCandidateFoundEventArgs"/>.</param>
    /// <returns>The object that raised the event.</returns>
    public static object? OriginalSource(this NoFocusCandidateFoundEventArgs e) => Resolver.OriginalSource(e);

    private sealed class DefaultNoFocusCandidateFoundEventArgsResolver : INoFocusCandidateFoundEventArgsResolver
    {
        FocusNavigationDirection INoFocusCandidateFoundEventArgsResolver.Direction(NoFocusCandidateFoundEventArgs e) => e.Direction;
        bool INoFocusCandidateFoundEventArgsResolver.Handled(NoFocusCandidateFoundEventArgs e) => e.Handled;
        void INoFocusCandidateFoundEventArgsResolver.Handled(NoFocusCandidateFoundEventArgs e, bool handled) => e.Handled = handled;
        FocusInputDeviceKind INoFocusCandidateFoundEventArgsResolver.InputDevice(NoFocusCandidateFoundEventArgs e) => e.InputDevice;
        object? INoFocusCandidateFoundEventArgsResolver.OriginalSource(NoFocusCandidateFoundEventArgs e) => e.OriginalSource;
    }
}

/// <summary>
/// Resolves data of the <see cref="NoFocusCandidateFoundEventArgs"/>.
/// </summary>
public interface INoFocusCandidateFoundEventArgsResolver
{
    /// <summary>
    /// Gets the direction that focus moved from element to element within the app UI.
    /// </summary>
    /// <param name="e">The requested <see cref="NoFocusCandidateFoundEventArgs"/>.</param>
    /// <returns>The direction of focus movement.</returns>
    FocusNavigationDirection Direction(NoFocusCandidateFoundEventArgs e);

    /// <summary>
    /// Gets a value that marks the routed event as handled.
    /// A <c>true</c> value for Handled prevents most handlers along the event route from handling the same event again.
    /// </summary>
    /// <param name="e">The requested <see cref="NoFocusCandidateFoundEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> to mark the routed event handled. <c>false</c> to leave the routed event unhandled,
    /// which permits the event to potentially route further and be acted on by other handlers.
    /// </returns>
    bool Handled(NoFocusCandidateFoundEventArgs e);

    /// <summary>
    /// Sets a value that marks the routed event as handled.
    /// A <c>true</c> value for Handled prevents most handlers along the event route from handling the same event again.
    /// </summary>
    /// <param name="e">The requested <see cref="NoFocusCandidateFoundEventArgs"/>.</param>
    /// <param name="handled">
    /// <c>true</c> to mark the routed event handled. <c>false</c> to leave the routed event unhandled,
    /// which permits the event to potentially route further and be acted on by other handlers.
    /// </param>
    void Handled(NoFocusCandidateFoundEventArgs e, bool handled);

    /// <summary>
    /// Gets the input device type from which input events are received.
    /// </summary>
    /// <param name="e">The requested <see cref="NoFocusCandidateFoundEventArgs"/>.</param>
    /// <returns>The input device type.</returns>
    FocusInputDeviceKind InputDevice(NoFocusCandidateFoundEventArgs e);

    /// <summary>
    /// Gets a reference to the object that raised the event.
    /// This is often a template part of a control rather than an element that was declared in your app UI.
    /// </summary>
    /// <param name="e">The requested <see cref="NoFocusCandidateFoundEventArgs"/>.</param>
    /// <returns>The object that raised the event.</returns>
    object? OriginalSource(NoFocusCandidateFoundEventArgs e);
}