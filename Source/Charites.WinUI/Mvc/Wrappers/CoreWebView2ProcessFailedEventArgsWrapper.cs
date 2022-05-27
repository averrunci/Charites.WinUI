// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.Web.WebView2.Core;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="CoreWebView2ProcessFailedEventArgs"/>
/// resolved by <see cref="ICoreWebView2ProcessFailedEventArgsResolver"/>.
/// </summary>
public static class CoreWebView2ProcessFailedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ICoreWebView2ProcessFailedEventArgsResolver"/>
    /// that resolves data of the <see cref="CoreWebView2ProcessFailedEventArgs"/>.
    /// </summary>
    public static ICoreWebView2ProcessFailedEventArgsResolver Resolver { get; set; } = new DefaultCoreWebView2ProcessFailedEventArgsResolver();

    /// <summary>
    /// Gets the exit code of the failing process, for telemetry purposes.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ProcessFailedEventArgs"/>.</param>
    /// <returns>The exit code of the failing process, for telemetry purposes.</returns>
    public static int ExitCode(this CoreWebView2ProcessFailedEventArgs e) => Resolver.ExitCode(e);

    /// <summary>
    /// Gets the collection of <see cref="CoreWebView2FrameInfo"/> for frames in the <see cref="CoreWebView2"/>
    /// that were being rendered by the failed process.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ProcessFailedEventArgs"/>.</param>
    /// <returns>
    /// The collection of <see cref="CoreWebView2FrameInfo"/> for frames in the <see cref="CoreWebView2"/>
    /// that were being rendered by the failed process.
    /// </returns>
    public static IReadOnlyList<CoreWebView2FrameInfo> FrameInfosForFailedProcess(this CoreWebView2ProcessFailedEventArgs e) => Resolver.FrameInfosForFailedProcess(e);

    /// <summary>
    /// Gets a description of the failing process, assigned by the WebView2 runtime.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ProcessFailedEventArgs"/>.</param>
    /// <returns>A description of the failing process, assigned by the WebView2 runtime.</returns>
    public static string ProcessDescription(this CoreWebView2ProcessFailedEventArgs e) => Resolver.ProcessDescription(e);

    /// <summary>
    /// Gets the kind of process failure that has occurred.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ProcessFailedEventArgs"/>.</param>
    /// <returns>The kind of process failure that has occurred.</returns>
    public static CoreWebView2ProcessFailedKind ProcessFailedKind(this CoreWebView2ProcessFailedEventArgs e) => Resolver.ProcessFailedKind(e);

    /// <summary>
    /// Gets the reason for the process failure.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ProcessFailedEventArgs"/>.</param>
    /// <returns>The reason for the process failure.</returns>
    public static CoreWebView2ProcessFailedReason Reason(this CoreWebView2ProcessFailedEventArgs e) => Resolver.Reason(e);

    private sealed class DefaultCoreWebView2ProcessFailedEventArgsResolver : ICoreWebView2ProcessFailedEventArgsResolver
    {
        int ICoreWebView2ProcessFailedEventArgsResolver.ExitCode(CoreWebView2ProcessFailedEventArgs e) => e.ExitCode;
        IReadOnlyList<CoreWebView2FrameInfo> ICoreWebView2ProcessFailedEventArgsResolver.FrameInfosForFailedProcess(CoreWebView2ProcessFailedEventArgs e) => e.FrameInfosForFailedProcess;
        string ICoreWebView2ProcessFailedEventArgsResolver.ProcessDescription(CoreWebView2ProcessFailedEventArgs e) => e.ProcessDescription;
        CoreWebView2ProcessFailedKind ICoreWebView2ProcessFailedEventArgsResolver.ProcessFailedKind(CoreWebView2ProcessFailedEventArgs e) => e.ProcessFailedKind;
        CoreWebView2ProcessFailedReason ICoreWebView2ProcessFailedEventArgsResolver.Reason(CoreWebView2ProcessFailedEventArgs e) => e.Reason;
    }
}

/// <summary>
/// Resolves data of the <see cref="CoreWebView2ProcessFailedEventArgs"/>.
/// </summary>
public interface ICoreWebView2ProcessFailedEventArgsResolver
{
    /// <summary>
    /// Gets the exit code of the failing process, for telemetry purposes.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ProcessFailedEventArgs"/>.</param>
    /// <returns>The exit code of the failing process, for telemetry purposes.</returns>
    int ExitCode(CoreWebView2ProcessFailedEventArgs e);

    /// <summary>
    /// Gets the collection of <see cref="CoreWebView2FrameInfo"/> for frames in the <see cref="CoreWebView2"/>
    /// that were being rendered by the failed process.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ProcessFailedEventArgs"/>.</param>
    /// <returns>
    /// The collection of <see cref="CoreWebView2FrameInfo"/> for frames in the <see cref="CoreWebView2"/>
    /// that were being rendered by the failed process.
    /// </returns>
    IReadOnlyList<CoreWebView2FrameInfo> FrameInfosForFailedProcess(CoreWebView2ProcessFailedEventArgs e);

    /// <summary>
    /// Gets a description of the failing process, assigned by the WebView2 runtime.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ProcessFailedEventArgs"/>.</param>
    /// <returns>A description of the failing process, assigned by the WebView2 runtime.</returns>
    string ProcessDescription(CoreWebView2ProcessFailedEventArgs e);

    /// <summary>
    /// Gets the kind of process failure that has occurred.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ProcessFailedEventArgs"/>.</param>
    /// <returns>The kind of process failure that has occurred.</returns>
    CoreWebView2ProcessFailedKind ProcessFailedKind(CoreWebView2ProcessFailedEventArgs e);

    /// <summary>
    /// Gets the reason for the process failure.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ProcessFailedEventArgs"/>.</param>
    /// <returns>The reason for the process failure.</returns>
    CoreWebView2ProcessFailedReason Reason(CoreWebView2ProcessFailedEventArgs e);
}