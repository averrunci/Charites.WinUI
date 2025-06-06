// Copyright (C) 2025 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.Web.WebView2.Core;

namespace Charites.Windows.Mvc.Wrappers
{
    /// <summary>
    /// Provides data of the <see cref="CoreWebView2SaveAsUIShowingEventArgs"/>
    /// resolved by <see cref="ICoreWebView2SaveAsUIShowingEventArgsResolver"/>.
    /// </summary>
    public static class CoreWebView2SaveAsUIShowingEventArgsWrapper
    {
        /// <summary>
        /// Gets or sets the <see cref="ICoreWebView2SaveAsUIShowingEventArgsResolver"/>
        /// that resolves data of the <see cref="CoreWebView2SaveAsUIShowingEventArgs"/>.
        /// </summary>
        public static ICoreWebView2SaveAsUIShowingEventArgsResolver Resolver { get; set; } = new DefaultCoreWebView2SaveAsUIShowingEventArgsResolver();

        /// <summary>
        /// Gets a value that indicates whether to allow to replace old file when it already exists in the target save file path.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveAsUIShowingEventArgs"/>.</param>
        /// <returns>
        /// <c>true</c> if the old file is allowed to replace when it already exists in the target save file path; otherwise, <c>false</c>.
        /// </returns>
        public static bool AllowReplace(this CoreWebView2SaveAsUIShowingEventArgs e) => Resolver.AllowReplace(e);

        /// <summary>
        /// Sets a value that indicates whether to allow to replace old file when it already exists in the target save file path.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveAsUIShowingEventArgs"/>.</param>
        /// <param name="allowReplace">
        /// <c>true</c> if the old file is allowed to replace when it already exists in the target save file path; otherwise, <c>false</c>.
        /// </param>
        public static void AllowReplace(this CoreWebView2SaveAsUIShowingEventArgs e, bool allowReplace) => Resolver.AllowReplace(e, allowReplace);

        /// <summary>
        /// Gets a value that indicates whether to cancel the save as before download.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveAsUIShowingEventArgs"/>.</param>
        /// <returns>
        /// <c>true</c> if the save is canceled as before download; otherwise, <c>false</c>.
        /// </returns>
        public static bool Cancel(this CoreWebView2SaveAsUIShowingEventArgs e) => Resolver.Cancel(e);

        /// <summary>
        /// Sets a value that indicates whether to cancel the save as before download.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveAsUIShowingEventArgs"/>.</param>
        /// <param name="cancel">
        /// <c>true</c> if the save is canceled as before download; otherwise, <c>false</c>.
        /// </param>
        public static void Cancel(this CoreWebView2SaveAsUIShowingEventArgs e, bool cancel) => Resolver.Cancel(e, cancel);

        /// <summary>
        /// Gets the Mime type of content to be saved.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveAsUIShowingEventArgs"/>.</param>
        /// <returns>The Mime type of content to be saved.</returns>
        public static string ContentMimeType(this CoreWebView2SaveAsUIShowingEventArgs e) => Resolver.ContentMimeType(e);

        /// <summary>
        /// Gets the option to save content to different document.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveAsUIShowingEventArgs"/>.</param>
        /// <returns>The option to save content to different document.</returns>
        public static CoreWebView2SaveAsKind Kind(this CoreWebView2SaveAsUIShowingEventArgs e) => Resolver.Kind(e);

        /// <summary>
        /// Sets the option to save content to different document.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveAsUIShowingEventArgs"/>.</param>
        /// <param name="kind">The option to save content to different document.</param>
        public static void Kind(this CoreWebView2SaveAsUIShowingEventArgs e, CoreWebView2SaveAsKind kind) => Resolver.Kind(e, kind);

        /// <summary>
        /// Gets the absolute full path of save as location.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveAsUIShowingEventArgs"/>.</param>
        /// <returns>The absolute full path of save as location.</returns>
        public static string SaveAsFilePath(this CoreWebView2SaveAsUIShowingEventArgs e) => Resolver.SaveAsFilePath(e);

        /// <summary>
        /// Sets the absolute full path of save as location.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveAsUIShowingEventArgs"/>.</param>
        /// <param name="filePath">The absolute full path of save as location.</param>
        public static void SaveAsFilePath(this CoreWebView2SaveAsUIShowingEventArgs e, string filePath) => Resolver.SaveAsFilePath(e, filePath);
        
        /// <summary>
        /// Gets a value that indicates if the system default dialog will be suppressed.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveAsUIShowingEventArgs"/>.</param>
        /// <returns>
        /// <c>true</c> if the system default dialog will be suppressed; otherwise, <c>false</c>.
        /// </returns>
        public static bool SuppressDefaultDialog(this CoreWebView2SaveAsUIShowingEventArgs e) => Resolver.SuppressDefaultDialog(e);

        /// <summary>
        /// Sets a value that indicates if the system default dialog will be suppressed.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveAsUIShowingEventArgs"/>.</param>
        /// <param name="suppressDefaultDialog">
        /// <c>true</c> if the system default dialog will be suppressed; otherwise, <c>false</c>.
        /// </param>
        public static void SuppressDefaultDialog(this CoreWebView2SaveAsUIShowingEventArgs e, bool suppressDefaultDialog) => Resolver.SuppressDefaultDialog(e, suppressDefaultDialog);

        /// <summary>
        /// Gets a <see cref="CoreWebView2Deferral"/> object.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveAsUIShowingEventArgs"/>.</param>
        /// <returns>A <see cref="CoreWebView2Deferral"/> object.</returns>
        public static CoreWebView2Deferral GetDeferralWrapped(this CoreWebView2SaveAsUIShowingEventArgs e) => Resolver.GetDeferral(e);

        private sealed class DefaultCoreWebView2SaveAsUIShowingEventArgsResolver : ICoreWebView2SaveAsUIShowingEventArgsResolver
        {
            bool ICoreWebView2SaveAsUIShowingEventArgsResolver.AllowReplace(CoreWebView2SaveAsUIShowingEventArgs e) => e.AllowReplace;
            void ICoreWebView2SaveAsUIShowingEventArgsResolver.AllowReplace(CoreWebView2SaveAsUIShowingEventArgs e, bool allowReplace) => e.AllowReplace = allowReplace;
            bool ICoreWebView2SaveAsUIShowingEventArgsResolver.Cancel(CoreWebView2SaveAsUIShowingEventArgs e) => e.Cancel;
            void ICoreWebView2SaveAsUIShowingEventArgsResolver.Cancel(CoreWebView2SaveAsUIShowingEventArgs e, bool cancel) => e.Cancel = cancel;
            string ICoreWebView2SaveAsUIShowingEventArgsResolver.ContentMimeType(CoreWebView2SaveAsUIShowingEventArgs e) => e.ContentMimeType;
            CoreWebView2SaveAsKind ICoreWebView2SaveAsUIShowingEventArgsResolver.Kind(CoreWebView2SaveAsUIShowingEventArgs e) => e.Kind;
            void ICoreWebView2SaveAsUIShowingEventArgsResolver.Kind(CoreWebView2SaveAsUIShowingEventArgs e, CoreWebView2SaveAsKind kind) => e.Kind = kind;
            string ICoreWebView2SaveAsUIShowingEventArgsResolver.SaveAsFilePath(CoreWebView2SaveAsUIShowingEventArgs e) => e.SaveAsFilePath;
            void ICoreWebView2SaveAsUIShowingEventArgsResolver.SaveAsFilePath(CoreWebView2SaveAsUIShowingEventArgs e, string filePath) => e.SaveAsFilePath = filePath;
            bool ICoreWebView2SaveAsUIShowingEventArgsResolver.SuppressDefaultDialog(CoreWebView2SaveAsUIShowingEventArgs e) => e.SuppressDefaultDialog;
            void ICoreWebView2SaveAsUIShowingEventArgsResolver.SuppressDefaultDialog(CoreWebView2SaveAsUIShowingEventArgs e, bool suppressDefaultDialog) => e.SuppressDefaultDialog = suppressDefaultDialog;
            CoreWebView2Deferral ICoreWebView2SaveAsUIShowingEventArgsResolver.GetDeferral(CoreWebView2SaveAsUIShowingEventArgs e) => e.GetDeferral();
        }
    }

    /// <summary>
    /// Resolves data of the <see cref="CoreWebView2SaveAsUIShowingEventArgs"/>.
    /// </summary>
    public interface ICoreWebView2SaveAsUIShowingEventArgsResolver
    {
        /// <summary>
        /// Gets a value that indicates whether to allow to replace old file when it already exists in the target save file path.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveAsUIShowingEventArgs"/>.</param>
        /// <returns>
        /// <c>true</c> if the old file is allowed to replace when it already exists in the target save file path; otherwise, <c>false</c>.
        /// </returns>
        bool AllowReplace(CoreWebView2SaveAsUIShowingEventArgs e);

        /// <summary>
        /// Sets a value that indicates whether to allow to replace old file when it already exists in the target save file path.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveAsUIShowingEventArgs"/>.</param>
        /// <param name="allowReplace">
        /// <c>true</c> if the old file is allowed to replace when it already exists in the target save file path; otherwise, <c>false</c>.
        /// </param>
        void AllowReplace(CoreWebView2SaveAsUIShowingEventArgs e, bool allowReplace);

        /// <summary>
        /// Gets a value that indicates whether to cancel the save as before download.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveAsUIShowingEventArgs"/>.</param>
        /// <returns>
        /// <c>true</c> if the save is canceled as before download; otherwise, <c>false</c>.
        /// </returns>
        bool Cancel(CoreWebView2SaveAsUIShowingEventArgs e);

        /// <summary>
        /// Sets a value that indicates whether to cancel the save as before download.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveAsUIShowingEventArgs"/>.</param>
        /// <param name="cancel">
        /// <c>true</c> if the save is canceled as before download; otherwise, <c>false</c>.
        /// </param>
        void Cancel(CoreWebView2SaveAsUIShowingEventArgs e, bool cancel);

        /// <summary>
        /// Gets the Mime type of content to be saved.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveAsUIShowingEventArgs"/>.</param>
        /// <returns>The Mime type of content to be saved.</returns>
        string ContentMimeType(CoreWebView2SaveAsUIShowingEventArgs e);

        /// <summary>
        /// Gets the option to save content to different document.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveAsUIShowingEventArgs"/>.</param>
        /// <returns>The option to save content to different document.</returns>
        CoreWebView2SaveAsKind Kind(CoreWebView2SaveAsUIShowingEventArgs e);

        /// <summary>
        /// Sets the option to save content to different document.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveAsUIShowingEventArgs"/>.</param>
        /// <param name="kind">The option to save content to different document.</param>
        void Kind(CoreWebView2SaveAsUIShowingEventArgs e, CoreWebView2SaveAsKind kind);

        /// <summary>
        /// Gets the absolute full path of save as location.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveAsUIShowingEventArgs"/>.</param>
        /// <returns>The absolute full path of save as location.</returns>
        string SaveAsFilePath(CoreWebView2SaveAsUIShowingEventArgs e);

        /// <summary>
        /// Sets the absolute full path of save as location.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveAsUIShowingEventArgs"/>.</param>
        /// <param name="filePath">The absolute full path of save as location.</param>
        void SaveAsFilePath(CoreWebView2SaveAsUIShowingEventArgs e, string filePath);
        
        /// <summary>
        /// Gets a value that indicates if the system default dialog will be suppressed.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveAsUIShowingEventArgs"/>.</param>
        /// <returns>
        /// <c>true</c> if the system default dialog will be suppressed; otherwise, <c>false</c>.
        /// </returns>
        bool SuppressDefaultDialog(CoreWebView2SaveAsUIShowingEventArgs e);

        /// <summary>
        /// Sets a value that indicates if the system default dialog will be suppressed.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveAsUIShowingEventArgs"/>.</param>
        /// <param name="suppressDefaultDialog">
        /// <c>true</c> if the system default dialog will be suppressed; otherwise, <c>false</c>.
        /// </param>
        void SuppressDefaultDialog(CoreWebView2SaveAsUIShowingEventArgs e, bool suppressDefaultDialog);

        /// <summary>
        /// Gets a <see cref="CoreWebView2Deferral"/> object.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2SaveAsUIShowingEventArgs"/>.</param>
        /// <returns>A <see cref="CoreWebView2Deferral"/> object.</returns>
        CoreWebView2Deferral GetDeferral(CoreWebView2SaveAsUIShowingEventArgs e);
    }
}