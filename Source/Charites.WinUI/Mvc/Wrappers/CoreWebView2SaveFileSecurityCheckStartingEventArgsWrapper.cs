// Copyright (C) 2025 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.Web.WebView2.Core;

namespace Charites.Windows.Mvc.Wrappers
{
    /// <summary>
    /// Provides data of the <see cref="CoreWebView2SaveFileSecurityCheckStartingEventArgs"/>
    /// resolved by <see cref="ICoreWebView2SaveFileSecurityCheckStartingEventArgsResolver"/>.
    /// </summary>
    public static class CoreWebView2SaveFileSecurityCheckStartingEventArgsWrapper
    {
        /// <summary>
        /// Gets or sets the <see cref="ICoreWebView2SaveFileSecurityCheckStartingEventArgsResolver"/>
        /// that resolves data of the <see cref="CoreWebView2SaveFileSecurityCheckStartingEventArgs"/>.
        /// </summary>
        public static ICoreWebView2SaveFileSecurityCheckStartingEventArgsResolver Resolver { get; set; } = new DefaultCoreWebView2SaveFileSecurityCheckStartingEventArgsResolver();

        /// <summary>
        /// Gets a value that indicates whether to cancel the upcoming save/download.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveFileSecurityCheckStartingEventArgs"/>.</param>
        /// <returns>
        /// <c>true</c> if the upcoming save/download is canceled; otherwise, <c>false</c>.
        /// </returns>
        public static bool CancelSave(this CoreWebView2SaveFileSecurityCheckStartingEventArgs e) => Resolver.CancelSave(e);

        /// <summary>
        /// Sets a value that indicates whether to cancel the upcoming save/download.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveFileSecurityCheckStartingEventArgs"/>.</param>
        /// <param name="cancelSave">
        /// <c>true</c> if the upcoming save/download is canceled; otherwise, <c>false</c>.
        /// </param>
        public static void CancelSave(this CoreWebView2SaveFileSecurityCheckStartingEventArgs e, bool cancelSave) => Resolver.CancelSave(e, cancelSave);

        /// <summary>
        /// Gets the document origin URI of this file save operation.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveFileSecurityCheckStartingEventArgs"/>.</param>
        /// <returns>The document origin URI of the file save operation.</returns>
        public static string DocumentOriginUri(this CoreWebView2SaveFileSecurityCheckStartingEventArgs e) => Resolver.DocumentOriginUri(e);

        /// <summary>
        /// Gets the extension of file to be saved.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveFileSecurityCheckStartingEventArgs"/>.</param>
        /// <returns>The extension of file to be saved.</returns>
        public static string FileExtension(this CoreWebView2SaveFileSecurityCheckStartingEventArgs e) => Resolver.FileExtension(e);

        /// <summary>
        /// Gets the full path of file to be saved. This includes the file name and extension.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveFileSecurityCheckStartingEventArgs"/>.</param>
        /// <returns>The full path of file to be saved.</returns>
        public static string FilePath(this CoreWebView2SaveFileSecurityCheckStartingEventArgs e) => Resolver.FilePath(e);

        /// <summary>
        /// Gets a value that indicates whether the default policy is checked and security warning will be suppressed.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveFileSecurityCheckStartingEventArgs"/>.</param>
        /// <returns>
        /// <c>true</c> if the default policy is checked and security warning will be suppressed; otherwise, <c>false</c>.
        /// </returns>
        public static bool SuppressDefaultPolicy(this CoreWebView2SaveFileSecurityCheckStartingEventArgs e) => Resolver.SuppressDefaultPolicy(e);

        /// <summary>
        /// Sets a value that indicates whether the default policy is checked and security warning will be suppressed.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveFileSecurityCheckStartingEventArgs"/>.</param>
        /// <param name="suppressDefaultPolicy">
        /// <c>true</c> if the default policy is checked and security warning will be suppressed; otherwise, <c>false</c>.
        /// </param>
        public static void SuppressDefaultPolicy(this CoreWebView2SaveFileSecurityCheckStartingEventArgs e, bool suppressDefaultPolicy) => Resolver.SuppressDefaultPolicy(e, suppressDefaultPolicy);

        /// <summary>
        /// Gets a <see cref="CoreWebView2Deferral"/> object.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveFileSecurityCheckStartingEventArgs"/>.</param>
        /// <returns>A <see cref="CoreWebView2Deferral"/> object.</returns>
        public static CoreWebView2Deferral GetDeferralWrapped(this CoreWebView2SaveFileSecurityCheckStartingEventArgs e) => Resolver.GetDeferral(e);

        private sealed class DefaultCoreWebView2SaveFileSecurityCheckStartingEventArgsResolver : ICoreWebView2SaveFileSecurityCheckStartingEventArgsResolver
        {
            bool ICoreWebView2SaveFileSecurityCheckStartingEventArgsResolver.CancelSave(CoreWebView2SaveFileSecurityCheckStartingEventArgs e) => e.CancelSave;
            void ICoreWebView2SaveFileSecurityCheckStartingEventArgsResolver.CancelSave(CoreWebView2SaveFileSecurityCheckStartingEventArgs e, bool cancelSave) => e.CancelSave = cancelSave;
            string ICoreWebView2SaveFileSecurityCheckStartingEventArgsResolver.DocumentOriginUri(CoreWebView2SaveFileSecurityCheckStartingEventArgs e) => e.DocumentOriginUri;
            string ICoreWebView2SaveFileSecurityCheckStartingEventArgsResolver.FileExtension(CoreWebView2SaveFileSecurityCheckStartingEventArgs e) => e.FileExtension;
            string ICoreWebView2SaveFileSecurityCheckStartingEventArgsResolver.FilePath(CoreWebView2SaveFileSecurityCheckStartingEventArgs e) => e.FilePath;
            bool ICoreWebView2SaveFileSecurityCheckStartingEventArgsResolver.SuppressDefaultPolicy(CoreWebView2SaveFileSecurityCheckStartingEventArgs e) => e.SuppressDefaultPolicy;
            void ICoreWebView2SaveFileSecurityCheckStartingEventArgsResolver.SuppressDefaultPolicy(CoreWebView2SaveFileSecurityCheckStartingEventArgs e, bool suppressDefaultPolicy) => e.SuppressDefaultPolicy = suppressDefaultPolicy;
            CoreWebView2Deferral ICoreWebView2SaveFileSecurityCheckStartingEventArgsResolver.GetDeferral(CoreWebView2SaveFileSecurityCheckStartingEventArgs e) => e.GetDeferral();
        }
    }

    /// <summary>
    /// Resolves data of the <see cref="CoreWebView2SaveFileSecurityCheckStartingEventArgs"/>.
    /// </summary>
    public interface ICoreWebView2SaveFileSecurityCheckStartingEventArgsResolver
    {
        /// <summary>
        /// Gets a value that indicates whether to cancel the upcoming save/download.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveFileSecurityCheckStartingEventArgs"/>.</param>
        /// <returns>
        /// <c>true</c> if the upcoming save/download is canceled; otherwise, <c>false</c>.
        /// </returns>
        bool CancelSave(CoreWebView2SaveFileSecurityCheckStartingEventArgs e);

        /// <summary>
        /// Sets a value that indicates whether to cancel the upcoming save/download.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveFileSecurityCheckStartingEventArgs"/>.</param>
        /// <param name="cancelSave">
        /// <c>true</c> if the upcoming save/download is canceled; otherwise, <c>false</c>.
        /// </param>
        void CancelSave(CoreWebView2SaveFileSecurityCheckStartingEventArgs e, bool cancelSave);

        /// <summary>
        /// Gets the document origin URI of this file save operation.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveFileSecurityCheckStartingEventArgs"/>.</param>
        /// <returns>The document origin URI of the file save operation.</returns>
        string DocumentOriginUri(CoreWebView2SaveFileSecurityCheckStartingEventArgs e);

        /// <summary>
        /// Gets the extension of file to be saved.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveFileSecurityCheckStartingEventArgs"/>.</param>
        /// <returns>The extension of file to be saved.</returns>
        string FileExtension(CoreWebView2SaveFileSecurityCheckStartingEventArgs e);

        /// <summary>
        /// Gets the full path of file to be saved. This includes the file name and extension.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveFileSecurityCheckStartingEventArgs"/>.</param>
        /// <returns>The full path of file to be saved.</returns>
        string FilePath(CoreWebView2SaveFileSecurityCheckStartingEventArgs e);

        /// <summary>
        /// Gets a value that indicates whether the default policy is checked and security warning will be suppressed.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveFileSecurityCheckStartingEventArgs"/>.</param>
        /// <returns>
        /// <c>true</c> if the default policy is checked and security warning will be suppressed; otherwise, <c>false</c>.
        /// </returns>
        bool SuppressDefaultPolicy(CoreWebView2SaveFileSecurityCheckStartingEventArgs e);

        /// <summary>
        /// Sets a value that indicates whether the default policy is checked and security warning will be suppressed.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveFileSecurityCheckStartingEventArgs"/>.</param>
        /// <param name="suppressDefaultPolicy">
        /// <c>true</c> if the default policy is checked and security warning will be suppressed; otherwise, <c>false</c>.
        /// </param>
        void SuppressDefaultPolicy(CoreWebView2SaveFileSecurityCheckStartingEventArgs e, bool suppressDefaultPolicy);

        /// <summary>
        /// Gets a <see cref="CoreWebView2Deferral"/> object.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveFileSecurityCheckStartingEventArgs"/>.</param>
        /// <returns>A <see cref="CoreWebView2Deferral"/> object.</returns>
        CoreWebView2Deferral GetDeferral(CoreWebView2SaveFileSecurityCheckStartingEventArgs e);
    }
}