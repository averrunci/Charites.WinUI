// Copyright (C) 2024 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.Web.WebView2.Core;

namespace Charites.Windows.Mvc.Wrappers
{
    /// <summary>
    /// Provides data of the <see cref="CoreWebView2FrameInfo"/>
    /// resolved by <see cref="ICoreWebView2FrameInfoResolver"/>.
    /// </summary>
    public static class CoreWebView2FrameInfoWrapper
    {
        /// <summary>
        /// Gets or sets the <see cref="ICoreWebView2FrameInfoResolver"/>
        /// that resolves data of the <see cref="CoreWebView2FrameInfo"/>.
        /// </summary>
        public static ICoreWebView2FrameInfoResolver Resolver { get; set; } = new DefaultCoreWebView2FrameInfoResolver();

        /// <summary>
        /// Gets the unique identifier of the frame associated with the current <see cref="CoreWebView2FrameInfo"/>.
        /// </summary>
        /// <param name="frameInfo">The requested <see cref="CoreWebView2FrameInfo"/>.</param>
        /// <returns>The unique identifier of the frame associated with the current <see cref="CoreWebView2FrameInfo"/>.</returns>
        public static uint FrameId(this CoreWebView2FrameInfo frameInfo) => Resolver.FrameId(frameInfo);

        /// <summary>
        /// Gets the kind of the frame.
        /// </summary>
        /// <param name="frameInfo">The requested <see cref="CoreWebView2FrameInfo"/>.</param>
        /// <returns>The kind of the frame.</returns>
        public static CoreWebView2FrameKind FrameKind(this CoreWebView2FrameInfo frameInfo) => Resolver.FrameKind(frameInfo);

        /// <summary>
        /// Gets the value of the frame's <c>window.name</c> property.
        /// </summary>
        /// <param name="frameInfo">The requested <see cref="CoreWebView2FrameInfo"/>.</param>
        /// <returns>The value of the frames <c>window.name</c> property.</returns>
        public static string Name(this CoreWebView2FrameInfo frameInfo) => Resolver.Name(frameInfo);

        /// <summary>
        /// Gets this parent frame's <see cref="CoreWebView2FrameInfo"/>.
        /// </summary>
        /// <param name="frameInfo">The requested <see cref="CoreWebView2FrameInfo"/>.</param>
        /// <returns>This parent frame's <see cref="CoreWebView2FrameInfo"/>.</returns>
        public static CoreWebView2FrameInfo ParentFrameInfo(this CoreWebView2FrameInfo frameInfo) => Resolver.ParentFrameInfo(frameInfo);

        /// <summary>
        /// Gets the URI of the document in the frame.
        /// </summary>
        /// <param name="frameInfo">The requested <see cref="CoreWebView2FrameInfo"/>.</param>
        /// <returns>The URI of the document in the frame.</returns>
        public static string Source(this CoreWebView2FrameInfo frameInfo) => Resolver.Source(frameInfo);

        private sealed class DefaultCoreWebView2FrameInfoResolver : ICoreWebView2FrameInfoResolver
        {
            uint ICoreWebView2FrameInfoResolver.FrameId(CoreWebView2FrameInfo frameInfo) => frameInfo.FrameId;
            CoreWebView2FrameKind ICoreWebView2FrameInfoResolver.FrameKind(CoreWebView2FrameInfo frameInfo) => frameInfo.FrameKind;
            string ICoreWebView2FrameInfoResolver.Name(CoreWebView2FrameInfo frameInfo) => frameInfo.Name;
            CoreWebView2FrameInfo ICoreWebView2FrameInfoResolver.ParentFrameInfo(CoreWebView2FrameInfo frameInfo) => frameInfo.ParentFrameInfo;
            string ICoreWebView2FrameInfoResolver.Source(CoreWebView2FrameInfo frameInfo) => frameInfo.Source;
        }
    }

    /// <summary>
    /// Resolves data of the <see cref="CoreWebView2FrameInfo"/>.
    /// </summary>
    public interface ICoreWebView2FrameInfoResolver
    {
        /// <summary>
        /// Gets the unique identifier of the frame associated with the current <see cref="CoreWebView2FrameInfo"/>.
        /// </summary>
        /// <param name="frameInfo">The requested <see cref="CoreWebView2FrameInfo"/>.</param>
        /// <returns>The unique identifier of the frame associated with the current <see cref="CoreWebView2FrameInfo"/>.</returns>
        uint FrameId(CoreWebView2FrameInfo frameInfo);

        /// <summary>
        /// Gets the kind of the frame.
        /// </summary>
        /// <param name="frameInfo">The requested <see cref="CoreWebView2FrameInfo"/>.</param>
        /// <returns>The kind of the frame.</returns>
        CoreWebView2FrameKind FrameKind(CoreWebView2FrameInfo frameInfo);

        /// <summary>
        /// Gets the value of the frame's <c>window.name</c> property.
        /// </summary>
        /// <param name="frameInfo">The requested <see cref="CoreWebView2FrameInfo"/>.</param>
        /// <returns>The value of the frames <c>window.name</c> property.</returns>
        string Name(CoreWebView2FrameInfo frameInfo);

        /// <summary>
        /// Gets this parent frame's <see cref="CoreWebView2FrameInfo"/>.
        /// </summary>
        /// <param name="frameInfo">The requested <see cref="CoreWebView2FrameInfo"/>.</param>
        /// <returns>This parent frame's <see cref="CoreWebView2FrameInfo"/>.</returns>
        CoreWebView2FrameInfo ParentFrameInfo(CoreWebView2FrameInfo frameInfo);

        /// <summary>
        /// Gets the URI of the document in the frame.
        /// </summary>
        /// <param name="frameInfo">The requested <see cref="CoreWebView2FrameInfo"/>.</param>
        /// <returns>The URI of the document in the frame.</returns>
        string Source(CoreWebView2FrameInfo frameInfo);
    }
}