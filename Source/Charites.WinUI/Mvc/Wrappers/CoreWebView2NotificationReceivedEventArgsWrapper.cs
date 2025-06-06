// Copyright (C) 2025 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.Web.WebView2.Core;

namespace Charites.Windows.Mvc.Wrappers
{
    /// <summary>
    /// Provides data of the <see cref="CoreWebView2NotificationReceivedEventArgs"/>
    /// resolved by <see cref="ICoreWebView2NotificationReceivedEventArgsResolver"/>.
    /// </summary>
    public static class CoreWebView2NotificationReceivedEventArgsWrapper
    {
        /// <summary>
        /// Gets or sets the <see cref="ICoreWebView2NotificationReceivedEventArgsResolver"/>
        /// that resolves data of the <see cref="CoreWebView2NotificationReceivedEventArgs"/>.
        /// </summary>
        public static ICoreWebView2NotificationReceivedEventArgsResolver Resolver { get; set; } = new DefaultCoreWebView2NotificationReceivedEventArgsResolver();

        /// <summary>
        /// Gets a value that indicates whether the <see cref="CoreWebView2.NotificationReceived" /> is handled by the host
        /// after the event handler completes or if there is a deferral then after the deferral is completed.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2NotificationReceivedEventArgs"/>.</param>
        /// <returns>
        /// <c>true </c> if  then WebView will not display the notification with the default UI, and the host will be responsible
        /// for handling the notification and for letting the web content know that the notification has been displayed, clicked,
        /// or closed; otherwise, <c>false</c>.
        /// </returns>
        public static bool Handled(this CoreWebView2NotificationReceivedEventArgs e) => Resolver.Handled(e);

        /// <summary>
        /// Sets a value that indicates whether the <see cref="CoreWebView2.NotificationReceived" /> is handled by the host
        /// after the event handler completes or if there is a deferral then after the deferral is completed.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2NotificationReceivedEventArgs"/>.</param>
        /// <param name="handled">
        /// <c>true </c> if  then WebView will not display the notification with the default UI, and the host will be responsible
        /// for handling the notification and for letting the web content know that the notification has been displayed, clicked,
        /// or closed; otherwise, <c>false</c>.
        /// </param>
        public static void Handled(this CoreWebView2NotificationReceivedEventArgs e, bool handled) => Resolver.Handled(e, handled);

        /// <summary>
        /// Gets the notification that was received.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2NotificationReceivedEventArgs"/>.</param>
        /// <returns>The notification that was received.</returns>
        public static CoreWebView2Notification Notification(this CoreWebView2NotificationReceivedEventArgs e) => Resolver.Notification(e);

        /// <summary>
        /// Gets the origin of the web content that sends the notification, such as <c>https://example.com/</c> or <c>https://www.example.com/</c>.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2NotificationReceivedEventArgs"/>.</param>
        /// <returns>The origin of the web content that sends the notification.</returns>
        public static string SenderOrigin(this CoreWebView2NotificationReceivedEventArgs e) => Resolver.SenderOrigin(e);

        /// <summary>
        /// Gets a <see cref="CoreWebView2Deferral"/> object.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2NotificationReceivedEventArgs"/>.</param>
        /// <returns>A <see cref="CoreWebView2Deferral"/> object.</returns>
        public static CoreWebView2Deferral GetDeferralWrapped(this CoreWebView2NotificationReceivedEventArgs e) => Resolver.GetDeferral(e);

        private sealed class DefaultCoreWebView2NotificationReceivedEventArgsResolver : ICoreWebView2NotificationReceivedEventArgsResolver
        {
            bool ICoreWebView2NotificationReceivedEventArgsResolver.Handled(CoreWebView2NotificationReceivedEventArgs e) => e.Handled;
            void ICoreWebView2NotificationReceivedEventArgsResolver.Handled(CoreWebView2NotificationReceivedEventArgs e, bool handled) => e.Handled = handled;
            CoreWebView2Notification ICoreWebView2NotificationReceivedEventArgsResolver.Notification(CoreWebView2NotificationReceivedEventArgs e) => e.Notification;
            string ICoreWebView2NotificationReceivedEventArgsResolver.SenderOrigin(CoreWebView2NotificationReceivedEventArgs e) => e.SenderOrigin;
            CoreWebView2Deferral ICoreWebView2NotificationReceivedEventArgsResolver.GetDeferral(CoreWebView2NotificationReceivedEventArgs e) => e.GetDeferral();
        }
    }

    /// <summary>
    /// Resolves data of the <see cref="CoreWebView2NotificationReceivedEventArgs"/>.
    /// </summary>
    public interface ICoreWebView2NotificationReceivedEventArgsResolver
    {
        /// <summary>
        /// Gets a value that indicates whether the <see cref="CoreWebView2.NotificationReceived" /> is handled by the host
        /// after the event handler completes or if there is a deferral then after the deferral is completed.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2NotificationReceivedEventArgs"/>.</param>
        /// <returns>
        /// <c>true </c> if  then WebView will not display the notification with the default UI, and the host will be responsible
        /// for handling the notification and for letting the web content know that the notification has been displayed, clicked,
        /// or closed; otherwise, <c>false</c>.
        /// </returns>
        bool Handled(CoreWebView2NotificationReceivedEventArgs e);

        /// <summary>
        /// Sets a value that indicates whether the <see cref="CoreWebView2.NotificationReceived" /> is handled by the host
        /// after the event handler completes or if there is a deferral then after the deferral is completed.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2NotificationReceivedEventArgs"/>.</param>
        /// <param name="handled">
        /// <c>true </c> if  then WebView will not display the notification with the default UI, and the host will be responsible
        /// for handling the notification and for letting the web content know that the notification has been displayed, clicked,
        /// or closed; otherwise, <c>false</c>.
        /// </param>
        void Handled(CoreWebView2NotificationReceivedEventArgs e, bool handled);

        /// <summary>
        /// Gets the notification that was received.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2NotificationReceivedEventArgs"/>.</param>
        /// <returns>The notification that was received.</returns>
        CoreWebView2Notification Notification(CoreWebView2NotificationReceivedEventArgs e);

        /// <summary>
        /// Gets the origin of the web content that sends the notification, such as <c>https://example.com/</c> or <c>https://www.example.com/</c>.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2NotificationReceivedEventArgs"/>.</param>
        /// <returns>The origin of the web content that sends the notification.</returns>
        string SenderOrigin(CoreWebView2NotificationReceivedEventArgs e);

        /// <summary>
        /// Gets a <see cref="CoreWebView2Deferral"/> object.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2NotificationReceivedEventArgs"/>.</param>
        /// <returns>A <see cref="CoreWebView2Deferral"/> object.</returns>
        CoreWebView2Deferral GetDeferral(CoreWebView2NotificationReceivedEventArgs e);
    }
}