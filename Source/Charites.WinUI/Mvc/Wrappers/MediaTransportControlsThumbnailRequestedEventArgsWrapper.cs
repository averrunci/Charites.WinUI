// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.Foundation;
using Windows.Storage.Streams;
using Microsoft.UI.Xaml.Media;

namespace Charites.Windows.Mvc.Wrappers
{
    /// <summary>
    /// Provides data of the <see cref="MediaTransportControlsThumbnailRequestedEventArgs"/>
    /// resolved by <see cref="IMediaTransportControlsThumbnailRequestedEventArgsResolver"/>.
    /// </summary>
    public static class MediaTransportControlsThumbnailRequestedEventArgsWrapper
    {
        /// <summary>
        /// Gets or sets the <see cref="IMediaTransportControlsThumbnailRequestedEventArgsResolver"/>
        /// that resolves data of the <see cref="MediaTransportControlsThumbnailRequestedEventArgs"/>.
        /// </summary>
        public static IMediaTransportControlsThumbnailRequestedEventArgsResolver Resolver { get; set; } = new DefaultMediaTransportControlsThumbnailRequestedEventArgsResolver();

        /// <summary>
        /// Sets the source of the thumbnail image.
        /// </summary>
        /// <param name="e">The requested <see cref="MediaTransportControlsThumbnailRequestedEventArgs"/>.</param>
        /// <param name="source">The source of the thumbnail image.</param>
        public static void SetThumbnailImageWrapped(this MediaTransportControlsThumbnailRequestedEventArgs e, IInputStream source) => Resolver.SetThumbnailImage(e, source);

        /// <summary>
        /// Returns a deferral that can be used to defer the completion of the ThumbnailRequested event while the thumbnail is generated.
        /// </summary>
        /// <param name="e">The requested <see cref="MediaTransportControlsThumbnailRequestedEventArgs"/>.</param>
        /// <returns>A deferral object that you can use to identify when the thumbnail request is complete.</returns>
        public static Deferral GetDeferralWrapped(this MediaTransportControlsThumbnailRequestedEventArgs e) => Resolver.GetDeferral(e);

        private sealed class DefaultMediaTransportControlsThumbnailRequestedEventArgsResolver : IMediaTransportControlsThumbnailRequestedEventArgsResolver
        {
            void IMediaTransportControlsThumbnailRequestedEventArgsResolver.SetThumbnailImage(MediaTransportControlsThumbnailRequestedEventArgs e, IInputStream source) => e.SetThumbnailImage(source);
            Deferral IMediaTransportControlsThumbnailRequestedEventArgsResolver.GetDeferral(MediaTransportControlsThumbnailRequestedEventArgs e) => e.GetDeferral();
        }
    }

    /// <summary>
    /// Resolves data of the <see cref="MediaTransportControlsThumbnailRequestedEventArgs"/>.
    /// </summary>
    public interface IMediaTransportControlsThumbnailRequestedEventArgsResolver
    {
        /// <summary>
        /// Sets the source of the thumbnail image.
        /// </summary>
        /// <param name="e">The requested <see cref="MediaTransportControlsThumbnailRequestedEventArgs"/>.</param>
        /// <param name="source">The source of the thumbnail image.</param>
        void SetThumbnailImage(MediaTransportControlsThumbnailRequestedEventArgs e, IInputStream source);

        /// <summary>
        /// Returns a deferral that can be used to defer the completion of the ThumbnailRequested event while the thumbnail is generated.
        /// </summary>
        /// <param name="e">The requested <see cref="MediaTransportControlsThumbnailRequestedEventArgs"/>.</param>
        /// <returns>A deferral object that you can use to identify when the thumbnail request is complete.</returns>
        Deferral GetDeferral(MediaTransportControlsThumbnailRequestedEventArgs e);
    }
}