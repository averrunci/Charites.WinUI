// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="KeyboardAcceleratorInvokedEventArgs"/>
/// resolved by <see cref="IKeyboardAcceleratorInvokedEventArgsResolver"/>.
/// </summary>
public static class KeyboardAcceleratorInvokedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IKeyboardAcceleratorInvokedEventArgsResolver"/>
    /// that resolves data of the <see cref="KeyboardAcceleratorInvokedEventArgs"/>.
    /// </summary>
    public static IKeyboardAcceleratorInvokedEventArgsResolver Resolver { get; set; } = new DefaultKeyboardAcceleratorInvokedEventArgsResolver();

    /// <summary>
    /// Gets the object associated with the keyboard shortcut (or accelerator).
    /// </summary>
    /// <param name="e">The requested <see cref="KeyboardAcceleratorInvokedEventArgs"/>.</param>
    /// <returns>A reference to the object associated with the keyboard shortcut (or accelerator).</returns>
    public static DependencyObject Element(this KeyboardAcceleratorInvokedEventArgs e) => Resolver.Element(e);

    /// <summary>
    /// Gets a value that marks the event as handled.
    /// </summary>
    /// <param name="e">The requested <see cref="KeyboardAcceleratorInvokedEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> to mark the event handled; <c>false</c> to leave the event unhandled,
    /// which permits the event to potentially route further.
    /// </returns>
    public static bool Handled(this KeyboardAcceleratorInvokedEventArgs e) => Resolver.Handled(e);

    /// <summary>
    /// Sets a value that marks the event as handled.
    /// </summary>
    /// <param name="e">The requested <see cref="KeyboardAcceleratorInvokedEventArgs"/>.</param>
    /// <param name="handled">
    /// <c>true</c> to mark the event handled; <c>false</c> to leave the event unhandled,
    /// which permits the event to potentially route further.
    /// </param>
    public static void Handled(this KeyboardAcceleratorInvokedEventArgs e, bool handled) => Resolver.Handled(e, handled);

    /// <summary>
    /// Gets the keyboard shortcut (or accelerator) object associated with the <see cref="Microsoft.UI.Xaml.Input.KeyboardAccelerator.Invoked"/> event.
    /// </summary>
    /// <param name="e">The requested <see cref="KeyboardAcceleratorInvokedEventArgs"/>.</param>
    /// <returns>The keyboard shortcut (or accelerator) object associated with the <see cref="Microsoft.UI.Xaml.Input.KeyboardAccelerator.Invoked"/> event.</returns>
    public static KeyboardAccelerator KeyboardAccelerator(this KeyboardAcceleratorInvokedEventArgs e) => Resolver.KeyboardAccelerator(e);

    private sealed class DefaultKeyboardAcceleratorInvokedEventArgsResolver : IKeyboardAcceleratorInvokedEventArgsResolver
    {
        DependencyObject IKeyboardAcceleratorInvokedEventArgsResolver.Element(KeyboardAcceleratorInvokedEventArgs e) => e.Element;
        bool IKeyboardAcceleratorInvokedEventArgsResolver.Handled(KeyboardAcceleratorInvokedEventArgs e) => e.Handled;
        void IKeyboardAcceleratorInvokedEventArgsResolver.Handled(KeyboardAcceleratorInvokedEventArgs e, bool handled) => e.Handled = handled;
        KeyboardAccelerator IKeyboardAcceleratorInvokedEventArgsResolver.KeyboardAccelerator(KeyboardAcceleratorInvokedEventArgs e) => e.KeyboardAccelerator;
    }
}

/// <summary>
/// Resolves data of the <see cref="KeyboardAcceleratorInvokedEventArgs"/>.
/// </summary>
public interface IKeyboardAcceleratorInvokedEventArgsResolver
{
    /// <summary>
    /// Gets the object associated with the keyboard shortcut (or accelerator).
    /// </summary>
    /// <param name="e">The requested <see cref="KeyboardAcceleratorInvokedEventArgs"/>.</param>
    /// <returns>A reference to the object associated with the keyboard shortcut (or accelerator).</returns>
    DependencyObject Element(KeyboardAcceleratorInvokedEventArgs e);

    /// <summary>
    /// Gets a value that marks the event as handled.
    /// </summary>
    /// <param name="e">The requested <see cref="KeyboardAcceleratorInvokedEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> to mark the event handled; <c>false</c> to leave the event unhandled,
    /// which permits the event to potentially route further.
    /// </returns>
    bool Handled(KeyboardAcceleratorInvokedEventArgs e);

    /// <summary>
    /// Sets a value that marks the event as handled.
    /// </summary>
    /// <param name="e">The requested <see cref="KeyboardAcceleratorInvokedEventArgs"/>.</param>
    /// <param name="handled">
    /// <c>true</c> to mark the event handled; <c>false</c> to leave the event unhandled,
    /// which permits the event to potentially route further.
    /// </param>
    void Handled(KeyboardAcceleratorInvokedEventArgs e, bool handled);

    /// <summary>
    /// Gets the keyboard shortcut (or accelerator) object associated with the <see cref="Microsoft.UI.Xaml.Input.KeyboardAccelerator.Invoked"/> event.
    /// </summary>
    /// <param name="e">The requested <see cref="KeyboardAcceleratorInvokedEventArgs"/>.</param>
    /// <returns>The keyboard shortcut (or accelerator) object associated with the <see cref="Microsoft.UI.Xaml.Input.KeyboardAccelerator.Invoked"/> event.</returns>
    KeyboardAccelerator KeyboardAccelerator(KeyboardAcceleratorInvokedEventArgs e);
}