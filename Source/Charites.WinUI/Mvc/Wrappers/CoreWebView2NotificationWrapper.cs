// Copyright (C) 2025 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.Web.WebView2.Core;

namespace Charites.Windows.Mvc.Wrappers
{
    /// <summary>
    /// Provides data of the <see cref="CoreWebView2Notification"/>
    /// resolved by <see cref="ICoreWebView2NotificationResolver"/>.
    /// </summary>
    public static class CoreWebView2NotificationWrapper
    {
        /// <summary>
        /// Gets or sets the <see cref="ICoreWebView2NotificationResolver"/>
        /// that resolves data of the <see cref="CoreWebView2Notification"/>.
        /// </summary>
        public static ICoreWebView2NotificationResolver Resolver { get; set; } = new DefaultCoreWebView2NotificationResolver();

        /// <summary>
        /// Gets a string containing the URI of the image used to represent the notification
        /// when there isn't enough space to display the notification itself.
        /// </summary>
        /// <param name="notification">The requested <see cref="CoreWebView2Notification"/>.</param>
        /// <returns> A string containing the URI of the image used to represent the notification. </returns>
        public static string BadgeUri(this CoreWebView2Notification notification) => Resolver.BadgeUri(notification);

        /// <summary>
        /// Gets a string representing the body text of the notification.
        /// </summary>
        /// <param name="notification">The requested <see cref="CoreWebView2Notification"/>.</param>
        /// <returns>A string representing the body text of the notification.</returns>
        public static string Body(this CoreWebView2Notification notification) => Resolver.Body(notification);

        /// <summary>
        /// Gets a string containing the URI of an image to be displayed in the notification.
        /// </summary>
        /// <param name="notification">The requested <see cref="CoreWebView2Notification"/>.</param>
        /// <returns>A string containing the URI of the image to be displayed in the notification.</returns>
        public static string BodyImageUri(this CoreWebView2Notification notification) => Resolver.BodyImageUri(notification);

        /// <summary>
        /// Gets the text direction in which to display the notification.
        /// </summary>
        /// <param name="notification">The requested <see cref="CoreWebView2Notification"/>.</param>
        /// <returns>The direction in which ot display the notification.</returns>
        public static CoreWebView2TextDirectionKind Direction(this CoreWebView2Notification notification) => Resolver.Direction(notification);

        /// <summary>
        /// Gets a string containing the URI of an icon to be displayed in the notification.
        /// </summary>
        /// <param name="notification">The requested <see cref="CoreWebView2Notification"/>.</param>
        /// <returns>A string containing the URI of an icon to be displayed in the notification.</returns>
        public static string IconUri(this CoreWebView2Notification notification) => Resolver.IconUri(notification);

        /// <summary>
        /// Gets a value that indicates whether the notification should be silent -- i.e.,
        /// no sounds or vibrations should be issued, regardless of the device settings.
        /// </summary>
        /// <param name="notification">The requested <see cref="CoreWebView2Notification"/>.</param>
        /// <returns>
        /// <c>true</c> if the notification should be silent; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsSilent(this CoreWebView2Notification notification) => Resolver.IsSilent(notification);

        /// <summary>
        /// Gets the notification's language, as intended to be specified using a string representing
        /// a language tag (such as <c>en-US</c>) according to [BCP47](https://datatracker.ietf.org/doc/html/rfc5646).
        /// </summary>
        /// <param name="notification">The requested <see cref="CoreWebView2Notification"/>.</param>
        /// <returns>
        /// The notification's language, as intended to be specified using a string representing a language tag.
        /// </returns>
        public static string Language(this CoreWebView2Notification notification) => Resolver.Language(notification);

        /// <summary>
        /// Gets a value that indicates whether a notification should remain active until the user clicks or dismisses it,
        /// rather than closing automatically.
        /// </summary>
        /// <param name="notification">The requested <see cref="CoreWebView2Notification"/>.</param>
        /// <returns>
        /// <c>true</c> if a notification should remain active until user clicks or dismisses it; otherwise, <c>false</c>.
        /// </returns>
        public static bool RequiresInteraction(this CoreWebView2Notification notification) => Resolver.RequiresInteraction(notification);

        /// <summary>
        /// Gets a value that indicates whether the user should be notified after a new notification replaces an old one.
        /// </summary>
        /// <param name="notification">The requested <see cref="CoreWebView2Notification"/>.</param>
        /// <returns>
        /// <c>true</c> if the user should be notified after a new notification replaces an old one; otherwise, <c>false</c>.
        /// </returns>
        public static bool ShouldRenotify(this CoreWebView2Notification notification) => Resolver.ShouldRenotify(notification);

        /// <summary>
        /// Gets a string representing an identifying tag for the notification.
        /// </summary>
        /// <param name="notification">The requested <see cref="CoreWebView2Notification"/>.</param>
        /// <returns>A string representing an identifying tag for the notification.</returns>
        public static string Tag(this CoreWebView2Notification notification) => Resolver.Tag(notification);

        /// <summary>
        /// Gets the time at which a notification is created or applicable (past, present, or future).
        /// </summary>
        /// <param name="notification">The requested <see cref="CoreWebView2Notification"/>.</param>
        /// <returns>The time at which a notification is created or applicable (past, present, or future).</returns>
        public static DateTime Timestamp(this CoreWebView2Notification notification) => Resolver.Timestamp(notification);

        /// <summary>
        /// Gets the title of the notification.
        /// </summary>
        /// <param name="notification">The requested <see cref="CoreWebView2Notification"/>.</param>
        /// <returns>The title of the notification.</returns>
        public static string Title(this CoreWebView2Notification notification) => Resolver.Title(notification);

        /// <summary>
        /// Gets the vibration pattern for devices with vibration hardware to emit.
        /// </summary>
        /// <param name="notification">The requested <see cref="CoreWebView2Notification"/>.</param>
        /// <returns>The vibration pattern for devices with vibration hardware to emit.</returns>
        public static IReadOnlyList<ulong> VibrationPattern(this CoreWebView2Notification notification) => Resolver.VibrationPattern(notification);

        /// <summary>
        /// Reports the notification has been clicked, and it will cause
        /// the [click](https://developer.mozilla.org/docs/Web/API/Notification/click_event) event
        /// to be raised for non-persistent notifications.
        /// </summary>
        /// <param name="notification">The requested <see cref="CoreWebView2Notification"/>.</param>
        public static void ReportClickedWrapped(CoreWebView2Notification notification) => Resolver.ReportClicked(notification);

        /// <summary>
        /// Reports the notification was dismissed, and it will cause
        /// the [close](https://developer.mozilla.org/docs/Web/API/Notification/close_event) event
        /// to be raised for non-persistent notifications.
        /// </summary>
        /// <param name="notification">The requested <see cref="CoreWebView2Notification"/>.</param>
        public static void ReportClosedWrapped(this CoreWebView2Notification notification) => Resolver.ReportClosed(notification);

        /// <summary>
        /// Reports the notification has been displayed and it will cause
        /// the [show](https://developer.mozilla.org/docs/Web/API/Notification/show_event) event
        /// to be raised for non-persistent notifications.
        /// </summary>
        /// <param name="notification">The requested <see cref="CoreWebView2Notification"/>.</param>
        public static void ReportShownWrapped(this CoreWebView2Notification notification) => Resolver.ReportShown(notification);

        private sealed class DefaultCoreWebView2NotificationResolver : ICoreWebView2NotificationResolver
        {
            string ICoreWebView2NotificationResolver.BadgeUri(CoreWebView2Notification notification) => notification.BadgeUri;
            string ICoreWebView2NotificationResolver.Body(CoreWebView2Notification notification) => notification.Body;
            string ICoreWebView2NotificationResolver.BodyImageUri(CoreWebView2Notification notification) => notification.BodyImageUri;
            CoreWebView2TextDirectionKind ICoreWebView2NotificationResolver.Direction(CoreWebView2Notification notification) => notification.Direction;
            string ICoreWebView2NotificationResolver.IconUri(CoreWebView2Notification notification) => notification.IconUri;
            bool ICoreWebView2NotificationResolver.IsSilent(CoreWebView2Notification notification) => notification.IsSilent;
            string ICoreWebView2NotificationResolver.Language(CoreWebView2Notification notification) => notification.Language;
            bool ICoreWebView2NotificationResolver.RequiresInteraction(CoreWebView2Notification notification) => notification.RequiresInteraction;
            bool ICoreWebView2NotificationResolver.ShouldRenotify(CoreWebView2Notification notification) => notification.ShouldRenotify;
            string ICoreWebView2NotificationResolver.Tag(CoreWebView2Notification notification) => notification.Tag;
            DateTime ICoreWebView2NotificationResolver.Timestamp(CoreWebView2Notification notification) => notification.Timestamp;
            string ICoreWebView2NotificationResolver.Title(CoreWebView2Notification notification) => notification.Title;
            IReadOnlyList<ulong> ICoreWebView2NotificationResolver.VibrationPattern(CoreWebView2Notification notification) => notification.VibrationPattern;
            void ICoreWebView2NotificationResolver.ReportClicked(CoreWebView2Notification notification) => notification.ReportClicked();
            void ICoreWebView2NotificationResolver.ReportClosed(CoreWebView2Notification notification) => notification.ReportClosed();
            void ICoreWebView2NotificationResolver.ReportShown(CoreWebView2Notification notification) => notification.ReportShown();
        }
    }

    /// <summary>
    /// Resolves data of the <see cref="CoreWebView2Notification"/>.
    /// </summary>
    public interface ICoreWebView2NotificationResolver
    {
        /// <summary>
        /// Gets a string containing the URI of the image used to represent the notification
        /// when there isn't enough space to display the notification itself.
        /// </summary>
        /// <param name="notification">The requested <see cref="CoreWebView2Notification"/>.</param>
        /// <returns> A string containing the URI of the image used to represent the notification. </returns>
        string BadgeUri(CoreWebView2Notification notification);

        /// <summary>
        /// Gets a string representing the body text of the notification.
        /// </summary>
        /// <param name="notification">The requested <see cref="CoreWebView2Notification"/>.</param>
        /// <returns>A string representing the body text of the notification.</returns>
        string Body(CoreWebView2Notification notification);

        /// <summary>
        /// Gets a string containing the URI of an image to be displayed in the notification.
        /// </summary>
        /// <param name="notification">The requested <see cref="CoreWebView2Notification"/>.</param>
        /// <returns>A string containing the URI of the image to be displayed in the notification.</returns>
        string BodyImageUri(CoreWebView2Notification notification);

        /// <summary>
        /// Gets the text direction in which to display the notification.
        /// </summary>
        /// <param name="notification">The requested <see cref="CoreWebView2Notification"/>.</param>
        /// <returns>The direction in which ot display the notification.</returns>
        CoreWebView2TextDirectionKind Direction(CoreWebView2Notification notification);

        /// <summary>
        /// Gets a string containing the URI of an icon to be displayed in the notification.
        /// </summary>
        /// <param name="notification">The requested <see cref="CoreWebView2Notification"/>.</param>
        /// <returns>A string containing the URI of an icon to be displayed in the notification.</returns>
        string IconUri(CoreWebView2Notification notification);

        /// <summary>
        /// Gets a value that indicates whether the notification should be silent -- i.e.,
        /// no sounds or vibrations should be issued, regardless of the device settings.
        /// </summary>
        /// <param name="notification">The requested <see cref="CoreWebView2Notification"/>.</param>
        /// <returns>
        /// <c>true</c> if the notification should be silent; otherwise, <c>false</c>.
        /// </returns>
        bool IsSilent(CoreWebView2Notification notification);

        /// <summary>
        /// Gets the notification's language, as intended to be specified using a string representing
        /// a language tag (such as <c>en-US</c>) according to [BCP47](https://datatracker.ietf.org/doc/html/rfc5646).
        /// </summary>
        /// <param name="notification">The requested <see cref="CoreWebView2Notification"/>.</param>
        /// <returns>
        /// The notification's language, as intended to be specified using a string representing a language tag.
        /// </returns>
        string Language(CoreWebView2Notification notification);

        /// <summary>
        /// Gets a value that indicates whether a notification should remain active until the user clicks or dismisses it,
        /// rather than closing automatically.
        /// </summary>
        /// <param name="notification">The requested <see cref="CoreWebView2Notification"/>.</param>
        /// <returns>
        /// <c>true</c> if a notification should remain active until user clicks or dismisses it; otherwise, <c>false</c>.
        /// </returns>
        bool RequiresInteraction(CoreWebView2Notification notification);

        /// <summary>
        /// Gets a value that indicates whether the user should be notified after a new notification replaces an old one.
        /// </summary>
        /// <param name="notification">The requested <see cref="CoreWebView2Notification"/>.</param>
        /// <returns>
        /// <c>true</c> if the user should be notified after a new notification replaces an old one; otherwise, <c>false</c>.
        /// </returns>
        bool ShouldRenotify(CoreWebView2Notification notification);

        /// <summary>
        /// Gets a string representing an identifying tag for the notification.
        /// </summary>
        /// <param name="notification">The requested <see cref="CoreWebView2Notification"/>.</param>
        /// <returns>A string representing an identifying tag for the notification.</returns>
        string Tag(CoreWebView2Notification notification);

        /// <summary>
        /// Gets the time at which a notification is created or applicable (past, present, or future).
        /// </summary>
        /// <param name="notification">The requested <see cref="CoreWebView2Notification"/>.</param>
        /// <returns>The time at which a notification is created or applicable (past, present, or future).</returns>
        DateTime Timestamp(CoreWebView2Notification notification);

        /// <summary>
        /// Gets the title of the notification.
        /// </summary>
        /// <param name="notification">The requested <see cref="CoreWebView2Notification"/>.</param>
        /// <returns>The title of the notification.</returns>
        string Title(CoreWebView2Notification notification);

        /// <summary>
        /// Gets the vibration pattern for devices with vibration hardware to emit.
        /// </summary>
        /// <param name="notification">The requested <see cref="CoreWebView2Notification"/>.</param>
        /// <returns>The vibration pattern for devices with vibration hardware to emit.</returns>
        IReadOnlyList<ulong> VibrationPattern(CoreWebView2Notification notification);

        /// <summary>
        /// Reports the notification has been clicked, and it will cause
        /// the [click](https://developer.mozilla.org/docs/Web/API/Notification/click_event) event
        /// to be raised for non-persistent notifications.
        /// </summary>
        /// <param name="notification">The requested <see cref="CoreWebView2Notification"/>.</param>
        void ReportClicked(CoreWebView2Notification notification);

        /// <summary>
        /// Reports the notification was dismissed, and it will cause
        /// the [close](https://developer.mozilla.org/docs/Web/API/Notification/close_event) event
        /// to be raised for non-persistent notifications.
        /// </summary>
        /// <param name="notification">The requested <see cref="CoreWebView2Notification"/>.</param>
        void ReportClosed(CoreWebView2Notification notification);

        /// <summary>
        /// Reports the notification has been displayed and it will cause
        /// the [show](https://developer.mozilla.org/docs/Web/API/Notification/show_event) event
        /// to be raised for non-persistent notifications.
        /// </summary>
        /// <param name="notification">The requested <see cref="CoreWebView2Notification"/>.</param>
        void ReportShown(CoreWebView2Notification notification);
    }
}