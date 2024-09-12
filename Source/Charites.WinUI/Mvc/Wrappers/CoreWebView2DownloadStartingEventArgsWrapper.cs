// Copyright (C) 2022-2024 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.Web.WebView2.Core;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="CoreWebView2DownloadStartingEventArgs"/>
/// resolved by <see cref="ICoreWebView2DownloadStartingEventArgsResolver"/>.
/// </summary>
public static class CoreWebView2DownloadStartingEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ICoreWebView2DownloadStartingEventArgsResolver"/>
    /// that resolves data of the <see cref="CoreWebView2DownloadStartingEventArgs"/>.
    /// </summary>
    public static ICoreWebView2DownloadStartingEventArgsResolver Resolver { get; set; } = new DefaultCoreWebView2DownloadStartingEventArgsResolver();

    /// <summary>
    /// Gets a value that indicates whether to cancel the download.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2DownloadStartingEventArgs"/>.</param>
    /// <returns><c>true</c> if the download is canceled; otherwise, <c>false</c>.</returns>
    public static bool Cancel(this CoreWebView2DownloadStartingEventArgs e) => Resolver.Cancel(e);

    /// <summary>
    /// Sets a value that indicates whether to cancel the download.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2DownloadStartingEventArgs"/>.</param>
    /// <param name="cancel"><c>true</c> if the download is canceled; otherwise, <c>false</c>.</param>
    public static void Cancel(this CoreWebView2DownloadStartingEventArgs e, bool cancel) => Resolver.Cancel(e, cancel);

    /// <summary>
    /// Gets the <see cref="CoreWebView2DownloadOperation"/> for the download that has started.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2DownloadStartingEventArgs"/>.</param>
    /// <returns>The <see cref="CoreWebView2DownloadOperation"/> for the download that has started.</returns>
    public static CoreWebView2DownloadOperation DownloadOperation(this CoreWebView2DownloadStartingEventArgs e) => Resolver.DownloadOperation(e);

    /// <summary>
    /// Gets a value that indicates whether to hide the default download dialog.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2DownloadStartingEventArgs"/>.</param>
    /// <returns><c>true</c> if the default download dialog is hidden; otherwise, <c>false</c>.</returns>
    public static bool Handled(this CoreWebView2DownloadStartingEventArgs e) => Resolver.Handled(e);

    /// <summary>
    /// Sets a value that indicates whether to hide the default download dialog.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2DownloadStartingEventArgs"/>.</param>
    /// <param name="handled"><c>true</c> if the default download dialog is hidden; otherwise, <c>false</c>.</param>
    public static void Handled(this CoreWebView2DownloadStartingEventArgs e, bool handled) => Resolver.Handled(e, handled);

    /// <summary>
    /// Gets the path to the file.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2DownloadStartingEventArgs"/>.</param>
    /// <returns>The path to the file.</returns>
    public static string ResultFilePath(this CoreWebView2DownloadStartingEventArgs e) => Resolver.ResultFilePath(e);

    /// <summary>
    /// Sets the path to the file.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2DownloadStartingEventArgs"/>.</param>
    /// <param name="resultFilePath">The path to the file.</param>
    public static void ResultFilePath(this CoreWebView2DownloadStartingEventArgs e, string resultFilePath) => Resolver.ResultFilePath(e, resultFilePath);

    /// <summary>
    /// Gets a <see cref="CoreWebView2Deferral"/> object.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2DownloadStartingEventArgs"/>.</param>
    /// <returns>A <see cref="CoreWebView2Deferral"/> object.</returns>
    public static CoreWebView2Deferral GetDeferralWrapped(this CoreWebView2DownloadStartingEventArgs e) => Resolver.GetDeferral(e);

    private sealed class DefaultCoreWebView2DownloadStartingEventArgsResolver : ICoreWebView2DownloadStartingEventArgsResolver
    {
        bool ICoreWebView2DownloadStartingEventArgsResolver.Cancel(CoreWebView2DownloadStartingEventArgs e) => e.Cancel;
        void ICoreWebView2DownloadStartingEventArgsResolver.Cancel(CoreWebView2DownloadStartingEventArgs e, bool cancel) => e.Cancel = cancel;
        CoreWebView2DownloadOperation ICoreWebView2DownloadStartingEventArgsResolver.DownloadOperation(CoreWebView2DownloadStartingEventArgs e) => e.DownloadOperation;
        bool ICoreWebView2DownloadStartingEventArgsResolver.Handled(CoreWebView2DownloadStartingEventArgs e) => e.Handled;
        void ICoreWebView2DownloadStartingEventArgsResolver.Handled(CoreWebView2DownloadStartingEventArgs e, bool handled) => e.Handled = handled;
        string ICoreWebView2DownloadStartingEventArgsResolver.ResultFilePath(CoreWebView2DownloadStartingEventArgs e) => e.ResultFilePath;
        void ICoreWebView2DownloadStartingEventArgsResolver.ResultFilePath(CoreWebView2DownloadStartingEventArgs e, string resultFilePath) => e.ResultFilePath = resultFilePath;
        CoreWebView2Deferral ICoreWebView2DownloadStartingEventArgsResolver.GetDeferral(CoreWebView2DownloadStartingEventArgs e) => e.GetDeferral();
    }
}

/// <summary>
/// Resolves data of the <see cref="CoreWebView2DownloadStartingEventArgs"/>.
/// </summary>
public interface ICoreWebView2DownloadStartingEventArgsResolver
{
    /// <summary>
    /// Gets a value that indicates whether to cancel the download.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2DownloadStartingEventArgs"/>.</param>
    /// <returns><c>true</c> if the download is canceled; otherwise, <c>false</c>.</returns>
    bool Cancel(CoreWebView2DownloadStartingEventArgs e);

    /// <summary>
    /// Sets a value that indicates whether to cancel the download.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2DownloadStartingEventArgs"/>.</param>
    /// <param name="cancel"><c>true</c> if the download is canceled; otherwise, <c>false</c>.</param>
    void Cancel(CoreWebView2DownloadStartingEventArgs e, bool cancel);

    /// <summary>
    /// Gets the <see cref="CoreWebView2DownloadOperation"/> for the download that has started.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2DownloadStartingEventArgs"/>.</param>
    /// <returns>The <see cref="CoreWebView2DownloadOperation"/> for the download that has started.</returns>
    CoreWebView2DownloadOperation DownloadOperation(CoreWebView2DownloadStartingEventArgs e);

    /// <summary>
    /// Gets a value that indicates whether to hide the default download dialog.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2DownloadStartingEventArgs"/>.</param>
    /// <returns><c>true</c> if the default download dialog is hidden; otherwise, <c>false</c>.</returns>
    bool Handled(CoreWebView2DownloadStartingEventArgs e);

    /// <summary>
    /// Sets a value that indicates whether to hide the default download dialog.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2DownloadStartingEventArgs"/>.</param>
    /// <param name="handled"><c>true</c> if the default download dialog is hidden; otherwise, <c>false</c>.</param>
    void Handled(CoreWebView2DownloadStartingEventArgs e, bool handled);

    /// <summary>
    /// Gets the path to the file.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2DownloadStartingEventArgs"/>.</param>
    /// <returns>The path to the file.</returns>
    string ResultFilePath(CoreWebView2DownloadStartingEventArgs e);

    /// <summary>
    /// Sets the path to the file.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2DownloadStartingEventArgs"/>.</param>
    /// <param name="resultFilePath">The path to the file.</param>
    void ResultFilePath(CoreWebView2DownloadStartingEventArgs e, string resultFilePath);

    /// <summary>
    /// Gets a <see cref="CoreWebView2Deferral"/> object.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2DownloadStartingEventArgs"/>.</param>
    /// <returns>A <see cref="CoreWebView2Deferral"/> object.</returns>
    CoreWebView2Deferral GetDeferral(CoreWebView2DownloadStartingEventArgs e);
}