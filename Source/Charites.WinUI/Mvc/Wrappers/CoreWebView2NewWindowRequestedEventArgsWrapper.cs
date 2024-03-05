// Copyright (C) 2022-2024 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.Foundation;
using Microsoft.Web.WebView2.Core;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="CoreWebView2NewWindowRequestedEventArgs"/>
/// resolved by <see cref="ICoreWebView2NewWindowRequestedEventArgsResolver"/>.
/// </summary>
public static class CoreWebView2NewWindowRequestedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ICoreWebView2NewWindowRequestedEventArgsResolver"/>
    /// that resolves data of the <see cref="CoreWebView2NewWindowRequestedEventArgs"/>.
    /// </summary>
    public static ICoreWebView2NewWindowRequestedEventArgsResolver Resolver { get; set; } = new DefaultCoreWebView2NewWindowRequestedEventArgsResolver();

    /// <summary>
    /// Gets a value that indicates whether the <see cref="CoreWebView2.NewWindowRequested"/> event is handled by host.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NewWindowRequestedEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> if the <see cref="CoreWebView2.NewWindowRequested"/> event is handled by host; otherwise, <c>false</c>.
    /// </returns>
    public static bool Handled(this CoreWebView2NewWindowRequestedEventArgs e) => Resolver.Handled(e);

    /// <summary>
    /// Sets a value that indicates whether the <see cref="CoreWebView2.NewWindowRequested"/> event is handled by host.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NewWindowRequestedEventArgs"/>.</param>
    /// <param name="handled">
    /// <c>true</c> if the <see cref="CoreWebView2.NewWindowRequested"/> event is handled by host; otherwise, <c>false</c>.
    /// </param>
    public static void Handled(this CoreWebView2NewWindowRequestedEventArgs e, bool handled) => Resolver.Handled(e, handled);

    /// <summary>
    /// Gets a value that indicates whether the new window request is initiated through a user gesture
    /// such as selecting an anchor tag with target.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NewWindowRequestedEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> when the new window request was initiated through a user gesture such as selecting
    /// an anchor tag with target; otherwise <c>false</c>.
    /// </returns>
    public static bool IsUserInitiated(this CoreWebView2NewWindowRequestedEventArgs e) => Resolver.IsUserInitiated(e);

    /// <summary>
    /// Gets the name of the new window.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NewWindowRequestedEventArgs"/>.</param>
    /// <returns>The name of the new window.</returns>
    public static string Name(this CoreWebView2NewWindowRequestedEventArgs e) => Resolver.Name(e);

    /// <summary>
    /// Gets the new window as a result of the new window requested.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NewWindowRequestedEventArgs"/>.</param>
    /// <returns>The new window as a result of the new window requested.</returns>
    public static CoreWebView2 NewWindow(this CoreWebView2NewWindowRequestedEventArgs e) => Resolver.NewWindow(e);

    /// <summary>
    /// Sets the new window as a result of the new window requested.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NewWindowRequestedEventArgs"/>.</param>
    /// <param name="newWindow">The new window as a result of the new window requested.</param>
    public static void NewWindow(this CoreWebView2NewWindowRequestedEventArgs e, CoreWebView2 newWindow) => Resolver.NewWindow(e, newWindow);

    /// <summary>
    /// Gets the frame info of the frame where the new window requested originated.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NewWindowRequestedEventArgs"/>.</param>
    /// <returns>The frame info of the frame where the new window requested originated.</returns>
    public static CoreWebView2FrameInfo OriginalSourceFrameInfo(this CoreWebView2NewWindowRequestedEventArgs e) => Resolver.OriginalSourceFrameInfo(e);

    /// <summary>
    /// Gets the target uri of the new window request.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NewWindowRequestedEventArgs"/>.</param>
    /// <returns>The target uri of the new window request.</returns>
    public static string Uri(this CoreWebView2NewWindowRequestedEventArgs e) => Resolver.Uri(e);

    /// <summary>
    /// Gets the window features specified by the <c>window.open()</c> call.
    /// These features should be considered for positioning and sizing of new WebView windows.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NewWindowRequestedEventArgs"/>.</param>
    /// <returns>The window features specified by the <c>window.open()</c> call.</returns>
    public static CoreWebView2WindowFeatures WindowFeatures(this CoreWebView2NewWindowRequestedEventArgs e) => Resolver.WindowFeatures(e);

    /// <summary>
    /// Gets a <see cref="Deferral"/> object.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NewWindowRequestedEventArgs"/>.</param>
    /// <returns>A <see cref="Deferral"/> object.</returns>
    public static Deferral GetDeferralWrapped(this CoreWebView2NewWindowRequestedEventArgs e) => Resolver.GetDeferral(e);

    private sealed class DefaultCoreWebView2NewWindowRequestedEventArgsResolver : ICoreWebView2NewWindowRequestedEventArgsResolver
    {
        bool ICoreWebView2NewWindowRequestedEventArgsResolver.Handled(CoreWebView2NewWindowRequestedEventArgs e) => e.Handled;
        void ICoreWebView2NewWindowRequestedEventArgsResolver.Handled(CoreWebView2NewWindowRequestedEventArgs e, bool handled) => e.Handled = handled;
        bool ICoreWebView2NewWindowRequestedEventArgsResolver.IsUserInitiated(CoreWebView2NewWindowRequestedEventArgs e) => e.IsUserInitiated;
        string ICoreWebView2NewWindowRequestedEventArgsResolver.Name(CoreWebView2NewWindowRequestedEventArgs e) => e.Name;
        CoreWebView2 ICoreWebView2NewWindowRequestedEventArgsResolver.NewWindow(CoreWebView2NewWindowRequestedEventArgs e) => e.NewWindow;
        void ICoreWebView2NewWindowRequestedEventArgsResolver.NewWindow(CoreWebView2NewWindowRequestedEventArgs e, CoreWebView2 newWindow) => e.NewWindow = newWindow;
        CoreWebView2FrameInfo ICoreWebView2NewWindowRequestedEventArgsResolver.OriginalSourceFrameInfo(CoreWebView2NewWindowRequestedEventArgs e) => e.OriginalSourceFrameInfo;
        string ICoreWebView2NewWindowRequestedEventArgsResolver.Uri(CoreWebView2NewWindowRequestedEventArgs e) => e.Uri;
        CoreWebView2WindowFeatures ICoreWebView2NewWindowRequestedEventArgsResolver.WindowFeatures(CoreWebView2NewWindowRequestedEventArgs e) => e.WindowFeatures;
        Deferral ICoreWebView2NewWindowRequestedEventArgsResolver.GetDeferral(CoreWebView2NewWindowRequestedEventArgs e) => e.GetDeferral();
    }
}

/// <summary>
/// Resolves data of the <see cref="CoreWebView2NewWindowRequestedEventArgs"/>.
/// </summary>
public interface ICoreWebView2NewWindowRequestedEventArgsResolver
{
    /// <summary>
    /// Gets a value that indicates whether the <see cref="CoreWebView2.NewWindowRequested"/> event is handled by host.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NewWindowRequestedEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> if the <see cref="CoreWebView2.NewWindowRequested"/> event is handled by host; otherwise, <c>false</c>.
    /// </returns>
    bool Handled(CoreWebView2NewWindowRequestedEventArgs e);

    /// <summary>
    /// Sets a value that indicates whether the <see cref="CoreWebView2.NewWindowRequested"/> event is handled by host.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NewWindowRequestedEventArgs"/>.</param>
    /// <param name="handled">
    /// <c>true</c> if the <see cref="CoreWebView2.NewWindowRequested"/> event is handled by host; otherwise, <c>false</c>.
    /// </param>
    void Handled(CoreWebView2NewWindowRequestedEventArgs e, bool handled);

    /// <summary>
    /// Gets a value that indicates whether the new window request is initiated through a user gesture
    /// such as selecting an anchor tag with target.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NewWindowRequestedEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> when the new window request was initiated through a user gesture such as selecting
    /// an anchor tag with target; otherwise <c>false</c>.
    /// </returns>
    bool IsUserInitiated(CoreWebView2NewWindowRequestedEventArgs e);

    /// <summary>
    /// Gets the name of the new window.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NewWindowRequestedEventArgs"/>.</param>
    /// <returns>The name of the new window.</returns>
    string Name(CoreWebView2NewWindowRequestedEventArgs e);

    /// <summary>
    /// Gets the new window as a result of the new window requested.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NewWindowRequestedEventArgs"/>.</param>
    /// <returns>The new window as a result of the new window requested.</returns>
    CoreWebView2 NewWindow(CoreWebView2NewWindowRequestedEventArgs e);

    /// <summary>
    /// Sets the new window as a result of the new window requested.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NewWindowRequestedEventArgs"/>.</param>
    /// <param name="newWindow">The new window as a result of the new window requested.</param>
    void NewWindow(CoreWebView2NewWindowRequestedEventArgs e, CoreWebView2 newWindow);

    /// <summary>
    /// Gets the frame info of the frame where the new window requested originated.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NewWindowRequestedEventArgs"/>.</param>
    /// <returns>The frame info of the frame where the new window requested originated.</returns>
    CoreWebView2FrameInfo OriginalSourceFrameInfo(CoreWebView2NewWindowRequestedEventArgs e);

    /// <summary>
    /// Gets the target uri of the new window request.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NewWindowRequestedEventArgs"/>.</param>
    /// <returns>The target uri of the new window request.</returns>
    string Uri(CoreWebView2NewWindowRequestedEventArgs e);

    /// <summary>
    /// Gets the window features specified by the <c>window.open()</c> call.
    /// These features should be considered for positioning and sizing of new WebView windows.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NewWindowRequestedEventArgs"/>.</param>
    /// <returns>The window features specified by the <c>window.open()</c> call.</returns>
    CoreWebView2WindowFeatures WindowFeatures(CoreWebView2NewWindowRequestedEventArgs e);

    /// <summary>
    /// Gets a <see cref="Deferral"/> object.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2NewWindowRequestedEventArgs"/>.</param>
    /// <returns>A <see cref="Deferral"/> object.</returns>
    Deferral GetDeferral(CoreWebView2NewWindowRequestedEventArgs e);
}