// Copyright (C) 2022-2024 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.Web.WebView2.Core;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="CoreWebView2AcceleratorKeyPressedEventArgs"/>
/// resolved by <see cref="ICoreWebView2AcceleratorKeyPressedEventArgsResolver"/>.
/// </summary>
public static class CoreWebView2AcceleratorKeyPressedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ICoreWebView2AcceleratorKeyPressedEventArgsResolver"/>
    /// that resolves data of the <see cref="CoreWebView2AcceleratorKeyPressedEventArgs"/>.
    /// </summary>
    public static ICoreWebView2AcceleratorKeyPressedEventArgsResolver Resolver { get; set; } = new DefaultCoreWebView2AcceleratorKeyPressedEventArgsResolver();

    /// <summary>
    /// Gets a value that indicates whether the <see cref="CoreWebView2Controller.AcceleratorKeyPressed"/> event is handled by host.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2AcceleratorKeyPressedEventArgs"/>.</param>
    /// <returns><c>true</c> if the event is handled by host; otherwise, <c>false</c>.</returns>
    public static bool Handled(this CoreWebView2AcceleratorKeyPressedEventArgs e) => Resolver.Handled(e);

    /// <summary>
    /// Sets a value that indicates whether the <see cref="CoreWebView2Controller.AcceleratorKeyPressed"/> event is handled by host.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2AcceleratorKeyPressedEventArgs"/>.</param>
    /// <param name="handled"><c>true</c> if the event is handled by host; otherwise, <c>false</c>.</param>
    public static void Handled(this CoreWebView2AcceleratorKeyPressedEventArgs e, bool handled) => Resolver.Handled(e, handled);

    /// <summary>
    /// Gets a value that indicates whether the browser handles accelerator keys such as Ctrl+P or F3, etc.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2AcceleratorKeyPressedEventArgs"/>.</param>
    /// <returns><c>true</c> if the browser handles accelerator keys; otherwise, <c>false</c>.</returns>
    public static bool IsBrowserAcceleratorKeyEnabled(this CoreWebView2AcceleratorKeyPressedEventArgs e) => Resolver.IsBrowserAcceleratorKeyEnabled(e);

    /// <summary>
    /// Sets a value that indicates whether the browser handles accelerator keys such as Ctrl+P or F3, etc.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2AcceleratorKeyPressedEventArgs"/>.</param>
    /// <param name="isBrowserAcceleratorKeyEnabled"><c>true</c> if the browser handles accelerator keys; otherwise, <c>false</c>.</param>
    public static void IsBrowserAcceleratorKeyEnabled(this CoreWebView2AcceleratorKeyPressedEventArgs e, bool isBrowserAcceleratorKeyEnabled) => Resolver.IsBrowserAcceleratorKeyEnabled(e, isBrowserAcceleratorKeyEnabled);

    /// <summary>
    /// Gets the key event kind that caused the event to run.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2AcceleratorKeyPressedEventArgs"/>.</param>
    /// <returns>The key event kind that caused the event to run.</returns>
    public static CoreWebView2KeyEventKind KeyEventKind(CoreWebView2AcceleratorKeyPressedEventArgs e) => Resolver.KeyEventKind(e);

    /// <summary>
    /// Gets the LPARAM value that accompanied the window message.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2AcceleratorKeyPressedEventArgs"/>.</param>
    /// <returns>The LPARAM value that accompanied the window message.</returns>
    public static int KeyEventLParam(this CoreWebView2AcceleratorKeyPressedEventArgs e) => Resolver.KeyEventLParam(e);

    /// <summary>
    /// Gets a <see cref="CoreWebView2PhysicalKeyStatus"/> representing the information passed in the LPARAM of the window message.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2AcceleratorKeyPressedEventArgs"/>.</param>
    /// <returns>
    /// A <see cref="CoreWebView2PhysicalKeyStatus"/> representing the information passed in the LPARAM of the window message.
    /// </returns>
    public static CoreWebView2PhysicalKeyStatus PhysicalKeyStatus(this CoreWebView2AcceleratorKeyPressedEventArgs e) => Resolver.PhysicalKeyStatus(e);

    /// <summary>
    /// Gets the Win32 virtual key code of the key that was pressed or released.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2AcceleratorKeyPressedEventArgs"/>.</param>
    /// <returns>The Win32 virtual key code of the key that was pressed or released.</returns>
    public static uint VirtualKey(this CoreWebView2AcceleratorKeyPressedEventArgs e) => Resolver.VirtualKey(e);

    private sealed class DefaultCoreWebView2AcceleratorKeyPressedEventArgsResolver : ICoreWebView2AcceleratorKeyPressedEventArgsResolver
    {
        bool ICoreWebView2AcceleratorKeyPressedEventArgsResolver.Handled(CoreWebView2AcceleratorKeyPressedEventArgs e) => e.Handled;
        void ICoreWebView2AcceleratorKeyPressedEventArgsResolver.Handled(CoreWebView2AcceleratorKeyPressedEventArgs e, bool handled) => e.Handled = handled;
        bool ICoreWebView2AcceleratorKeyPressedEventArgsResolver.IsBrowserAcceleratorKeyEnabled(CoreWebView2AcceleratorKeyPressedEventArgs e) => e.IsBrowserAcceleratorKeyEnabled;
        void ICoreWebView2AcceleratorKeyPressedEventArgsResolver.IsBrowserAcceleratorKeyEnabled(CoreWebView2AcceleratorKeyPressedEventArgs e, bool isBrowserAcceleratorKeyEnabled) => e.IsBrowserAcceleratorKeyEnabled = isBrowserAcceleratorKeyEnabled;
        CoreWebView2KeyEventKind ICoreWebView2AcceleratorKeyPressedEventArgsResolver.KeyEventKind(CoreWebView2AcceleratorKeyPressedEventArgs e) => e.KeyEventKind;
        int ICoreWebView2AcceleratorKeyPressedEventArgsResolver.KeyEventLParam(CoreWebView2AcceleratorKeyPressedEventArgs e) => e.KeyEventLParam;
        CoreWebView2PhysicalKeyStatus ICoreWebView2AcceleratorKeyPressedEventArgsResolver.PhysicalKeyStatus(CoreWebView2AcceleratorKeyPressedEventArgs e) => e.PhysicalKeyStatus;
        uint ICoreWebView2AcceleratorKeyPressedEventArgsResolver.VirtualKey(CoreWebView2AcceleratorKeyPressedEventArgs e) => e.VirtualKey;
    }
}

/// <summary>
/// Resolves data of the <see cref="CoreWebView2AcceleratorKeyPressedEventArgs"/>.
/// </summary>
public interface ICoreWebView2AcceleratorKeyPressedEventArgsResolver
{
    /// <summary>
    /// Gets a value that indicates whether the <see cref="CoreWebView2Controller.AcceleratorKeyPressed"/> event is handled by host.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2AcceleratorKeyPressedEventArgs"/>.</param>
    /// <returns><c>true</c> if the event is handled by host; otherwise, <c>false</c>.</returns>
    bool Handled(CoreWebView2AcceleratorKeyPressedEventArgs e);

    /// <summary>
    /// Sets a value that indicates whether the <see cref="CoreWebView2Controller.AcceleratorKeyPressed"/> event is handled by host.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2AcceleratorKeyPressedEventArgs"/>.</param>
    /// <param name="handled"><c>true</c> if the event is handled by host; otherwise, <c>false</c>.</param>
    void Handled(CoreWebView2AcceleratorKeyPressedEventArgs e, bool handled);

    /// <summary>
    /// Gets a value that indicates whether the browser handles accelerator keys such as Ctrl+P or F3, etc.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2AcceleratorKeyPressedEventArgs"/>.</param>
    /// <returns><c>true</c> if the browser handles accelerator keys; otherwise, <c>false</c>.</returns>
    bool IsBrowserAcceleratorKeyEnabled(CoreWebView2AcceleratorKeyPressedEventArgs e);

    /// <summary>
    /// Sets a value that indicates whether the browser handles accelerator keys such as Ctrl+P or F3, etc.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2AcceleratorKeyPressedEventArgs"/>.</param>
    /// <param name="isBrowserAcceleratorKeyEnabled"><c>true</c> if the browser handles accelerator keys; otherwise, <c>false</c>.</param>
    void IsBrowserAcceleratorKeyEnabled(CoreWebView2AcceleratorKeyPressedEventArgs e, bool isBrowserAcceleratorKeyEnabled);

    /// <summary>
    /// Gets the key event kind that caused the event to run.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2AcceleratorKeyPressedEventArgs"/>.</param>
    /// <returns>The key event kind that caused the event to run.</returns>
    CoreWebView2KeyEventKind KeyEventKind(CoreWebView2AcceleratorKeyPressedEventArgs e);

    /// <summary>
    /// Gets the LPARAM value that accompanied the window message.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2AcceleratorKeyPressedEventArgs"/>.</param>
    /// <returns>The LPARAM value that accompanied the window message.</returns>
    int KeyEventLParam(CoreWebView2AcceleratorKeyPressedEventArgs e);

    /// <summary>
    /// Gets a <see cref="CoreWebView2PhysicalKeyStatus"/> representing the information passed in the LPARAM of the window message.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2AcceleratorKeyPressedEventArgs"/>.</param>
    /// <returns>
    /// A <see cref="CoreWebView2PhysicalKeyStatus"/> representing the information passed in the LPARAM of the window message.
    /// </returns>
    CoreWebView2PhysicalKeyStatus PhysicalKeyStatus(CoreWebView2AcceleratorKeyPressedEventArgs e);

    /// <summary>
    /// Gets the Win32 virtual key code of the key that was pressed or released.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2AcceleratorKeyPressedEventArgs"/>.</param>
    /// <returns>The Win32 virtual key code of the key that was pressed or released.</returns>
    uint VirtualKey(CoreWebView2AcceleratorKeyPressedEventArgs e);
}