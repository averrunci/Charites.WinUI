// Copyright (C) 2025 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.Web.WebView2.Core;

namespace Charites.Windows.Mvc.Wrappers
{
    /// <summary>
    /// Provides data of the <see cref="CoreWebView2ScreenCaptureStartingEventArgs"/>
    /// resolved by <see cref="ICoreWebView2ScreenCaptureStartingEventArgsResolver"/>.
    /// </summary>
    public static class CoreWebView2ScreenCaptureStartingEventArgsWrapper
    {
        /// <summary>
        /// Gets or sets the <see cref="ICoreWebView2ScreenCaptureStartingEventArgsResolver"/>
        /// that resolves data of the <see cref="CoreWebView2ScreenCaptureStartingEventArgs"/>.
        /// </summary>
        public static ICoreWebView2ScreenCaptureStartingEventArgsResolver Resolver { get; set; } = new DefaultCoreWebView2ScreenCaptureStartingEventArgsResolver();

        /// <summary>
        /// Gets a value that indicates whether the screen capture is canceled.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2ScreenCaptureStartingEventArgs"/>.</param>
        /// <returns>
        /// <c>true</c> if the screen capture is canceled; otherwise, <c>false</c>.
        /// </returns>
        public static bool Cancel(this CoreWebView2ScreenCaptureStartingEventArgs e) => Resolver.Cancel(e);

        /// <summary>
        /// Sets a value that indicates whether the screen capture is canceled.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2ScreenCaptureStartingEventArgs"/>.</param>
        /// <param name="cancel">
        /// <c>true</c> if the screen capture is canceled; otherwise, <c>false</c>.
        /// </param>
        public static void Cancel(this CoreWebView2ScreenCaptureStartingEventArgs e, bool cancel) => Resolver.Cancel(e, cancel);

        /// <summary>
        /// Gets a value that indicates whether the <see cref="CoreWebView2.ScreenCaptureStarting"/> event
        /// from firing on the <see cref="CoreWebView2"/> is canceled.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2ScreenCaptureStartingEventArgs"/>.</param>
        /// <returns>
        /// <c>true</c> if the <see cref="CoreWebView2.ScreenCaptureStarting"/> event from firing
        /// on the <see cref="CoreWebView2"/> is canceled; otherwise, <c>false</c>.
        /// </returns>
        public static bool Handled(this CoreWebView2ScreenCaptureStartingEventArgs e) => Resolver.Handled(e);

        /// <summary>
        /// Sets a value that indicates whether the <see cref="CoreWebView2.ScreenCaptureStarting"/> event
        /// from firing on the <see cref="CoreWebView2"/> is canceled.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2ScreenCaptureStartingEventArgs"/>.</param>
        /// <param name="handled">
        /// <c>true</c> if the <see cref="CoreWebView2.ScreenCaptureStarting"/> event from firing
        /// on the <see cref="CoreWebView2"/> is canceled; otherwise, <c>false</c>.
        /// </param>
        public static void Handled(this CoreWebView2ScreenCaptureStartingEventArgs e, bool handled) => Resolver.Handled(e, handled);

        /// <summary>
        /// Gets the frame info of the frame where the screen capture starting request originated.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2ScreenCaptureStartingEventArgs"/>.</param>
        /// <returns>The frame info of the frame where the screen capture starting request originated.</returns>
        public static CoreWebView2FrameInfo OriginalSourceFrameInfo(this CoreWebView2ScreenCaptureStartingEventArgs e) => Resolver.OriginalSourceFrameInfo(e);

        /// <summary>
        /// Gets a <see cref="CoreWebView2Deferral"/> object.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2ScreenCaptureStartingEventArgs"/>.</param>
        /// <returns>A <see cref="CoreWebView2Deferral"/> object.</returns>
        public static CoreWebView2Deferral GetDeferralWrapped(this CoreWebView2ScreenCaptureStartingEventArgs e) => Resolver.GetDeferral(e);

        private sealed class DefaultCoreWebView2ScreenCaptureStartingEventArgsResolver : ICoreWebView2ScreenCaptureStartingEventArgsResolver
        {
            bool ICoreWebView2ScreenCaptureStartingEventArgsResolver.Cancel(CoreWebView2ScreenCaptureStartingEventArgs e) => e.Cancel;
            void ICoreWebView2ScreenCaptureStartingEventArgsResolver.Cancel(CoreWebView2ScreenCaptureStartingEventArgs e, bool cancel) => e.Cancel = cancel;
            bool ICoreWebView2ScreenCaptureStartingEventArgsResolver.Handled(CoreWebView2ScreenCaptureStartingEventArgs e) => e.Handled;
            void ICoreWebView2ScreenCaptureStartingEventArgsResolver.Handled(CoreWebView2ScreenCaptureStartingEventArgs e, bool handled) => e.Handled = handled;
            CoreWebView2FrameInfo ICoreWebView2ScreenCaptureStartingEventArgsResolver.OriginalSourceFrameInfo(CoreWebView2ScreenCaptureStartingEventArgs e) => e.OriginalSourceFrameInfo;
            CoreWebView2Deferral ICoreWebView2ScreenCaptureStartingEventArgsResolver.GetDeferral(CoreWebView2ScreenCaptureStartingEventArgs e) => e.GetDeferral();
        }
    }

    /// <summary>
    /// Resolves data of the <see cref="CoreWebView2ScreenCaptureStartingEventArgs"/>.
    /// </summary>
    public interface ICoreWebView2ScreenCaptureStartingEventArgsResolver
    {
        /// <summary>
        /// Gets a value that indicates whether the screen capture is canceled.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2ScreenCaptureStartingEventArgs"/>.</param>
        /// <returns>
        /// <c>true</c> if the screen capture is canceled; otherwise, <c>false</c>.
        /// </returns>
        bool Cancel(CoreWebView2ScreenCaptureStartingEventArgs e);

        /// <summary>
        /// Sets a value that indicates whether the screen capture is canceled.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2ScreenCaptureStartingEventArgs"/>.</param>
        /// <param name="cancel">
        /// <c>true</c> if the screen capture is canceled; otherwise, <c>false</c>.
        /// </param>
        void Cancel(CoreWebView2ScreenCaptureStartingEventArgs e, bool cancel);

        /// <summary>
        /// Gets a value that indicates whether the <see cref="CoreWebView2.ScreenCaptureStarting"/> event
        /// from firing on the <see cref="CoreWebView2"/> is canceled.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2ScreenCaptureStartingEventArgs"/>.</param>
        /// <returns>
        /// <c>true</c> if the <see cref="CoreWebView2.ScreenCaptureStarting"/> event from firing
        /// on the <see cref="CoreWebView2"/> is canceled; otherwise, <c>false</c>.
        /// </returns>
        bool Handled(CoreWebView2ScreenCaptureStartingEventArgs e);

        /// <summary>
        /// Sets a value that indicates whether the <see cref="CoreWebView2.ScreenCaptureStarting"/> event
        /// from firing on the <see cref="CoreWebView2"/> is canceled.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2ScreenCaptureStartingEventArgs"/>.</param>
        /// <param name="handled">
        /// <c>true</c> if the <see cref="CoreWebView2.ScreenCaptureStarting"/> event from firing
        /// on the <see cref="CoreWebView2"/> is canceled; otherwise, <c>false</c>.
        /// </param>
        void Handled(CoreWebView2ScreenCaptureStartingEventArgs e, bool handled);

        /// <summary>
        /// Gets the frame info of the frame where the screen capture starting request originated.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2ScreenCaptureStartingEventArgs"/>.</param>
        /// <returns>The frame info of the frame where the screen capture starting request originated.</returns>
        CoreWebView2FrameInfo OriginalSourceFrameInfo(CoreWebView2ScreenCaptureStartingEventArgs e);

        /// <summary>
        /// Gets a <see cref="CoreWebView2Deferral"/> object.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2ScreenCaptureStartingEventArgs"/>.</param>
        /// <returns>A <see cref="CoreWebView2Deferral"/> object.</returns>
        CoreWebView2Deferral GetDeferral(CoreWebView2ScreenCaptureStartingEventArgs e);
    }
}