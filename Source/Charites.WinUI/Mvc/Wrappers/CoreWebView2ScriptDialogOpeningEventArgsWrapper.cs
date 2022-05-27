// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.Foundation;
using Microsoft.Web.WebView2.Core;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="CoreWebView2ScriptDialogOpeningEventArgs"/>
/// resolved by <see cref="ICoreWebView2ScriptDialogOpeningEventArgsResolver"/>.
/// </summary>
public static class CoreWebView2ScriptDialogOpeningEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ICoreWebView2ScriptDialogOpeningEventArgsResolver"/>
    /// that resolves data of the <see cref="CoreWebView2ScriptDialogOpeningEventArgs"/>.
    /// </summary>
    public static ICoreWebView2ScriptDialogOpeningEventArgsResolver Resolver { get; set; } = new DefaultCoreWebView2ScriptDialogOpeningEventArgsResolver();

    /// <summary>
    /// Gets the default value to use for the result of the <c>prompt</c> JavaScript function.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ScriptDialogOpeningEventArgs"/>.</param>
    /// <returns>The default value to use for the result of the <c>prompt</c> JavaScript function.</returns>
    public static string DefaultText(this CoreWebView2ScriptDialogOpeningEventArgs e) => Resolver.DefaultText(e);

    /// <summary>
    /// Gets the kind of JavaScript dialog box.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ScriptDialogOpeningEventArgs"/>.</param>
    /// <returns>The kind of JavaScript dialog box.</returns>
    public static CoreWebView2ScriptDialogKind Kind(this CoreWebView2ScriptDialogOpeningEventArgs e) => Resolver.Kind(e);

    /// <summary>
    /// Gets the message of the dialog box.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ScriptDialogOpeningEventArgs"/>.</param>
    /// <returns>The message of the dialog box.</returns>
    public static string Message(this CoreWebView2ScriptDialogOpeningEventArgs e) => Resolver.Message(e);

    /// <summary>
    /// Gets the return value from the JavaScript <c>prompt</c> function if <see cref="CoreWebView2ScriptDialogOpeningEventArgs.Accept"/> is run.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ScriptDialogOpeningEventArgs"/>.</param>
    /// <returns>The return value from the JavaScript <c>prompt</c> function.</returns>
    public static string ResultText(this CoreWebView2ScriptDialogOpeningEventArgs e) => Resolver.ResultText(e);

    /// <summary>
    /// Sets the return value from the JavaScript <c>prompt</c> function if <see cref="CoreWebView2ScriptDialogOpeningEventArgs.Accept"/> is run.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ScriptDialogOpeningEventArgs"/>.</param>
    /// <param name="resultText">The return value from the JavaScript <c>prompt</c> function.</param>
    public static void ResultText(this CoreWebView2ScriptDialogOpeningEventArgs e, string resultText) => Resolver.ResultText(e, resultText);

    /// <summary>
    /// Gets the URI of the page that requested the dialog box.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ScriptDialogOpeningEventArgs"/>.</param>
    /// <returns>The URI of the page that requested the dialog box.</returns>
    public static string Uri(this CoreWebView2ScriptDialogOpeningEventArgs e) => Resolver.Uri(e);

    /// <summary>
    /// Responds with OK to <c>confirm</c>, <c>prompt</c>, and <c>beforeunload</c> dialogs.
    /// Not run this method to indicate cancel.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ScriptDialogOpeningEventArgs"/>.</param>
    public static void AcceptWrapped(this CoreWebView2ScriptDialogOpeningEventArgs e) => Resolver.Accept(e);

    /// <summary>
    /// Gets a <see cref="Deferral"/> object.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ScriptDialogOpeningEventArgs"/>.</param>
    /// <returns>A <see cref="Deferral"/> object.</returns>
    public static Deferral GetDeferralWrapped(this CoreWebView2ScriptDialogOpeningEventArgs e) => Resolver.GetDeferral(e);

    private sealed class DefaultCoreWebView2ScriptDialogOpeningEventArgsResolver : ICoreWebView2ScriptDialogOpeningEventArgsResolver
    {
        string ICoreWebView2ScriptDialogOpeningEventArgsResolver.DefaultText(CoreWebView2ScriptDialogOpeningEventArgs e) => e.DefaultText;
        CoreWebView2ScriptDialogKind ICoreWebView2ScriptDialogOpeningEventArgsResolver.Kind(CoreWebView2ScriptDialogOpeningEventArgs e) => e.Kind;
        string ICoreWebView2ScriptDialogOpeningEventArgsResolver.Message(CoreWebView2ScriptDialogOpeningEventArgs e) => e.Message;
        string ICoreWebView2ScriptDialogOpeningEventArgsResolver.ResultText(CoreWebView2ScriptDialogOpeningEventArgs e) => e.ResultText;
        void ICoreWebView2ScriptDialogOpeningEventArgsResolver.ResultText(CoreWebView2ScriptDialogOpeningEventArgs e, string resultText) => e.ResultText = resultText;
        string ICoreWebView2ScriptDialogOpeningEventArgsResolver.Uri(CoreWebView2ScriptDialogOpeningEventArgs e) => e.Uri;
        void ICoreWebView2ScriptDialogOpeningEventArgsResolver.Accept(CoreWebView2ScriptDialogOpeningEventArgs e) => e.Accept();
        Deferral ICoreWebView2ScriptDialogOpeningEventArgsResolver.GetDeferral(CoreWebView2ScriptDialogOpeningEventArgs e) => e.GetDeferral();
    }
}

/// <summary>
/// Resolves data of the <see cref="CoreWebView2ScriptDialogOpeningEventArgs"/>.
/// </summary>
public interface ICoreWebView2ScriptDialogOpeningEventArgsResolver
{
    /// <summary>
    /// Gets the default value to use for the result of the <c>prompt</c> JavaScript function.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ScriptDialogOpeningEventArgs"/>.</param>
    /// <returns>The default value to use for the result of the <c>prompt</c> JavaScript function.</returns>
    string DefaultText(CoreWebView2ScriptDialogOpeningEventArgs e);

    /// <summary>
    /// Gets the kind of JavaScript dialog box.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ScriptDialogOpeningEventArgs"/>.</param>
    /// <returns>The kind of JavaScript dialog box.</returns>
    CoreWebView2ScriptDialogKind Kind(CoreWebView2ScriptDialogOpeningEventArgs e);

    /// <summary>
    /// Gets the message of the dialog box.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ScriptDialogOpeningEventArgs"/>.</param>
    /// <returns>The message of the dialog box.</returns>
    string Message(CoreWebView2ScriptDialogOpeningEventArgs e);

    /// <summary>
    /// Gets the return value from the JavaScript <c>prompt</c> function if <see cref="CoreWebView2ScriptDialogOpeningEventArgs.Accept"/> is run.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ScriptDialogOpeningEventArgs"/>.</param>
    /// <returns>The return value from the JavaScript <c>prompt</c> function.</returns>
    string ResultText(CoreWebView2ScriptDialogOpeningEventArgs e);

    /// <summary>
    /// Sets the return value from the JavaScript <c>prompt</c> function if <see cref="CoreWebView2ScriptDialogOpeningEventArgs.Accept"/> is run.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ScriptDialogOpeningEventArgs"/>.</param>
    /// <param name="resultText">The return value from the JavaScript <c>prompt</c> function.</param>
    void ResultText(CoreWebView2ScriptDialogOpeningEventArgs e, string resultText);

    /// <summary>
    /// Gets the URI of the page that requested the dialog box.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ScriptDialogOpeningEventArgs"/>.</param>
    /// <returns>The URI of the page that requested the dialog box.</returns>
    string Uri(CoreWebView2ScriptDialogOpeningEventArgs e);

    /// <summary>
    /// Responds with OK to <c>confirm</c>, <c>prompt</c>, and <c>beforeunload</c> dialogs.
    /// Not run this method to indicate cancel.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ScriptDialogOpeningEventArgs"/>.</param>
    void Accept(CoreWebView2ScriptDialogOpeningEventArgs e);

    /// <summary>
    /// Gets a <see cref="Deferral"/> object.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ScriptDialogOpeningEventArgs"/>.</param>
    /// <returns>A <see cref="Deferral"/> object.</returns>
    Deferral GetDeferral(CoreWebView2ScriptDialogOpeningEventArgs e);
}