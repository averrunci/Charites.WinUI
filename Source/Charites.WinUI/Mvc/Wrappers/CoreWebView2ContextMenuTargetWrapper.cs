// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.Web.WebView2.Core;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="CoreWebView2ContextMenuTarget"/>
/// resolved by <see cref="ICoreWebView2ContextMenuTargetResolver"/>.
/// </summary>
public static class CoreWebView2ContextMenuTargetWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ICoreWebView2ContextMenuTargetResolver"/>
    /// that resolves data of the <see cref="CoreWebView2ContextMenuTarget"/>.
    /// </summary>
    public static ICoreWebView2ContextMenuTargetResolver Resolver { get; set; } = new DefaultCoreWebView2ContextMenuTargetResolver();

    /// <summary>
    /// Gets the uri of the frame. Will match the <see cref="CoreWebView2ContextMenuTarget.PageUri"/>
    /// if <see cref="CoreWebView2ContextMenuTarget.IsRequestedForMainFrame"/> is <c>true</c>.
    /// </summary>
    /// <param name="target">The requested <see cref="CoreWebView2ContextMenuTarget"/>.</param>
    /// <returns>The uri of the frame.</returns>
    public static string FrameUri(this CoreWebView2ContextMenuTarget target) => Resolver.FrameUri(target);

    /// <summary>
    /// Gets a value that indicates whether the context menu is requested on text element
    /// that contains an anchor tag.
    /// </summary>
    /// <param name="target">The requested <see cref="CoreWebView2ContextMenuTarget"/>.</param>
    /// <returns>
    /// <c>true</c> if the context menu is requested on text element that contains an anchor tag; otherwise, <c>false</c>.
    /// </returns>
    public static bool HasLinkText(this CoreWebView2ContextMenuTarget target) => Resolver.HasLinkText(target);

    /// <summary>
    /// Gets a value that indicates whether the context menu is requested on HTML containing an anchor tag.
    /// </summary>
    /// <param name="target">The requested <see cref="CoreWebView2ContextMenuTarget"/>.</param>
    /// <returns>
    /// <c>true</c> if the context menu is requested on HTML containing an anchor tag; otherwise, <c>false</c>.
    /// </returns>
    public static bool HasLinkUri(this CoreWebView2ContextMenuTarget target) => Resolver.HasLinkUri(target);

    /// <summary>
    /// Gets a value that indicates whether the context menu is requested on a selection.
    /// </summary>
    /// <param name="target">The requested <see cref="CoreWebView2ContextMenuTarget"/>.</param>
    /// <returns>
    /// <c>true</c> if the context menu is requested on a selection; otherwise, <c>false</c>.
    /// </returns>
    public static bool HasSelection(this CoreWebView2ContextMenuTarget target) => Resolver.HasSelection(target);

    /// <summary>
    /// Gets a value that indicates whether the context menu is requested on HTML containing a source uri.
    /// </summary>
    /// <param name="target">The requested <see cref="CoreWebView2ContextMenuTarget"/>.</param>
    /// <returns>
    /// <c>true</c> if the context menu is requested on HTML containing a source uri; otherwise, <c>false</c>.
    /// </returns>
    public static bool HasSourceUri(this CoreWebView2ContextMenuTarget target) => Resolver.HasSourceUri(target);

    /// <summary>
    /// Gets a value that indicates whether the context menu is requested on an editable component.
    /// </summary>
    /// <param name="target">The requested <see cref="CoreWebView2ContextMenuTarget"/>.</param>
    /// <returns>
    /// <c>true</c> if the context menu is requested on an editable component; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsEditable(this CoreWebView2ContextMenuTarget target) => Resolver.IsEditable(target);

    /// <summary>
    /// Gets a value that indicates whether the context menu was requested on the main frame.
    /// </summary>
    /// <param name="target">The requested <see cref="CoreWebView2ContextMenuTarget"/>.</param>
    /// <returns>
    /// <c>true</c> if the context menu was requested on the main frame; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsRequestedForMainFrame(this CoreWebView2ContextMenuTarget target) => Resolver.IsRequestedForMainFrame(target);

    /// <summary>
    /// Gets the kind of context that the user selected as <see cref="CoreWebView2ContextMenuTargetKind"/>.
    /// </summary>
    /// <param name="target">The requested <see cref="CoreWebView2ContextMenuTarget"/>.</param>
    /// <returns>The kind of context that the user selected as <see cref="CoreWebView2ContextMenuTargetKind"/>.</returns>
    public static CoreWebView2ContextMenuTargetKind Kind(this CoreWebView2ContextMenuTarget target) => Resolver.Kind(target);

    /// <summary>
    /// Gets the text of the link (if <see cref="CoreWebView2ContextMenuTarget.HasLinkText"/> is <c>true</c>, <c>null</c> otherwise).
    /// </summary>
    /// <param name="target">The requested <see cref="CoreWebView2ContextMenuTarget"/>.</param>
    /// <returns>The text of the link.</returns>
    public static string LinkText(this CoreWebView2ContextMenuTarget target) => Resolver.LinkText(target);

    /// <summary>
    /// Gets the uri of the link (if <see cref="CoreWebView2ContextMenuTarget.HasLinkUri"/> is <c>true</c>, <c>null</c> otherwise).
    /// </summary>
    /// <param name="target">The requested <see cref="CoreWebView2ContextMenuTarget"/>.</param>
    /// <returns>The uri of the link.</returns>
    public static string LinkUri(this CoreWebView2ContextMenuTarget target) => Resolver.LinkUri(target);

    /// <summary>
    /// Gets the uri of the page.
    /// </summary>
    /// <param name="target">The requested <see cref="CoreWebView2ContextMenuTarget"/>.</param>
    /// <returns>The uri of the page.</returns>
    public static string PageUri(this CoreWebView2ContextMenuTarget target) => Resolver.PageUri(target);

    /// <summary>
    /// Gets the selected text (if <see cref="CoreWebView2ContextMenuTarget.HasSelection"/> is <c>true</c>, <c>null</c> otherwise).
    /// </summary>
    /// <param name="target">The requested <see cref="CoreWebView2ContextMenuTarget"/>.</param>
    /// <returns>The selected text.</returns>
    public static string SelectionText(this CoreWebView2ContextMenuTarget target) => Resolver.SelectionText(target);

    /// <summary>
    /// Gets the active source uri of element (if <see cref="CoreWebView2ContextMenuTarget.HasSourceUri"/> is <c>true</c>, <c>null</c> otherwise).
    /// </summary>
    /// <param name="target">The requested <see cref="CoreWebView2ContextMenuTarget"/>.</param>
    /// <returns>The active source uri of element.</returns>
    public static string SourceUri(this CoreWebView2ContextMenuTarget target) => Resolver.SourceUri(target);

    private sealed class DefaultCoreWebView2ContextMenuTargetResolver : ICoreWebView2ContextMenuTargetResolver
    {
        string ICoreWebView2ContextMenuTargetResolver.FrameUri(CoreWebView2ContextMenuTarget target) => target.FrameUri;
        bool ICoreWebView2ContextMenuTargetResolver.HasLinkText(CoreWebView2ContextMenuTarget target) => target.HasLinkText;
        bool ICoreWebView2ContextMenuTargetResolver.HasLinkUri(CoreWebView2ContextMenuTarget target) => target.HasLinkUri;
        bool ICoreWebView2ContextMenuTargetResolver.HasSelection(CoreWebView2ContextMenuTarget target) => target.HasSelection;
        bool ICoreWebView2ContextMenuTargetResolver.HasSourceUri(CoreWebView2ContextMenuTarget target) => target.HasSourceUri;
        bool ICoreWebView2ContextMenuTargetResolver.IsEditable(CoreWebView2ContextMenuTarget target) => target.IsEditable;
        bool ICoreWebView2ContextMenuTargetResolver.IsRequestedForMainFrame(CoreWebView2ContextMenuTarget target) => target.IsRequestedForMainFrame;
        CoreWebView2ContextMenuTargetKind ICoreWebView2ContextMenuTargetResolver.Kind(CoreWebView2ContextMenuTarget target) => target.Kind;
        string ICoreWebView2ContextMenuTargetResolver.LinkText(CoreWebView2ContextMenuTarget target) => target.LinkText;
        string ICoreWebView2ContextMenuTargetResolver.LinkUri(CoreWebView2ContextMenuTarget target) => target.LinkUri;
        string ICoreWebView2ContextMenuTargetResolver.PageUri(CoreWebView2ContextMenuTarget target) => target.PageUri;
        string ICoreWebView2ContextMenuTargetResolver.SelectionText(CoreWebView2ContextMenuTarget target) => target.SelectionText;
        string ICoreWebView2ContextMenuTargetResolver.SourceUri(CoreWebView2ContextMenuTarget target) => target.SourceUri;
    }
}

/// <summary>
/// Resolves data of the <see cref="CoreWebView2ContextMenuTarget"/>.
/// </summary>
public interface ICoreWebView2ContextMenuTargetResolver
{
    /// <summary>
    /// Gets the uri of the frame. Will match the <see cref="CoreWebView2ContextMenuTarget.PageUri"/>
    /// if <see cref="CoreWebView2ContextMenuTarget.IsRequestedForMainFrame"/> is <c>true</c>.
    /// </summary>
    /// <param name="target">The requested <see cref="CoreWebView2ContextMenuTarget"/>.</param>
    /// <returns>The uri of the frame.</returns>
    string FrameUri(CoreWebView2ContextMenuTarget target);

    /// <summary>
    /// Gets a value that indicates whether the context menu is requested on text element
    /// that contains an anchor tag.
    /// </summary>
    /// <param name="target">The requested <see cref="CoreWebView2ContextMenuTarget"/>.</param>
    /// <returns>
    /// <c>true</c> if the context menu is requested on text element that contains an anchor tag; otherwise, <c>false</c>.
    /// </returns>
    bool HasLinkText(CoreWebView2ContextMenuTarget target);

    /// <summary>
    /// Gets a value that indicates whether the context menu is requested on HTML containing an anchor tag.
    /// </summary>
    /// <param name="target">The requested <see cref="CoreWebView2ContextMenuTarget"/>.</param>
    /// <returns>
    /// <c>true</c> if the context menu is requested on HTML containing an anchor tag; otherwise, <c>false</c>.
    /// </returns>
    bool HasLinkUri(CoreWebView2ContextMenuTarget target);

    /// <summary>
    /// Gets a value that indicates whether the context menu is requested on a selection.
    /// </summary>
    /// <param name="target">The requested <see cref="CoreWebView2ContextMenuTarget"/>.</param>
    /// <returns>
    /// <c>true</c> if the context menu is requested on a selection; otherwise, <c>false</c>.
    /// </returns>
    bool HasSelection(CoreWebView2ContextMenuTarget target);

    /// <summary>
    /// Gets a value that indicates whether the context menu is requested on HTML containing a source uri.
    /// </summary>
    /// <param name="target">The requested <see cref="CoreWebView2ContextMenuTarget"/>.</param>
    /// <returns>
    /// <c>true</c> if the context menu is requested on HTML containing a source uri; otherwise, <c>false</c>.
    /// </returns>
    bool HasSourceUri(CoreWebView2ContextMenuTarget target);

    /// <summary>
    /// Gets a value that indicates whether the context menu is requested on an editable component.
    /// </summary>
    /// <param name="target">The requested <see cref="CoreWebView2ContextMenuTarget"/>.</param>
    /// <returns>
    /// <c>true</c> if the context menu is requested on an editable component; otherwise, <c>false</c>.
    /// </returns>
    bool IsEditable(CoreWebView2ContextMenuTarget target);

    /// <summary>
    /// Gets a value that indicates whether the context menu was requested on the main frame.
    /// </summary>
    /// <param name="target">The requested <see cref="CoreWebView2ContextMenuTarget"/>.</param>
    /// <returns>
    /// <c>true</c> if the context menu was requested on the main frame; otherwise, <c>false</c>.
    /// </returns>
    bool IsRequestedForMainFrame(CoreWebView2ContextMenuTarget target);

    /// <summary>
    /// Gets the kind of context that the user selected as <see cref="CoreWebView2ContextMenuTargetKind"/>.
    /// </summary>
    /// <param name="target">The requested <see cref="CoreWebView2ContextMenuTarget"/>.</param>
    /// <returns>The kind of context that the user selected as <see cref="CoreWebView2ContextMenuTargetKind"/>.</returns>
    CoreWebView2ContextMenuTargetKind Kind(CoreWebView2ContextMenuTarget target);

    /// <summary>
    /// Gets the text of the link (if <see cref="CoreWebView2ContextMenuTarget.HasLinkText"/> is <c>true</c>, <c>null</c> otherwise).
    /// </summary>
    /// <param name="target">The requested <see cref="CoreWebView2ContextMenuTarget"/>.</param>
    /// <returns>The text of the link.</returns>
    string LinkText(CoreWebView2ContextMenuTarget target);

    /// <summary>
    /// Gets the uri of the link (if <see cref="CoreWebView2ContextMenuTarget.HasLinkUri"/> is <c>true</c>, <c>null</c> otherwise).
    /// </summary>
    /// <param name="target">The requested <see cref="CoreWebView2ContextMenuTarget"/>.</param>
    /// <returns>The uri of the link.</returns>
    string LinkUri(CoreWebView2ContextMenuTarget target);

    /// <summary>
    /// Gets the uri of the page.
    /// </summary>
    /// <param name="target">The requested <see cref="CoreWebView2ContextMenuTarget"/>.</param>
    /// <returns>The uri of the page.</returns>
    string PageUri(CoreWebView2ContextMenuTarget target);

    /// <summary>
    /// Gets the selected text (if <see cref="CoreWebView2ContextMenuTarget.HasSelection"/> is <c>true</c>, <c>null</c> otherwise).
    /// </summary>
    /// <param name="target">The requested <see cref="CoreWebView2ContextMenuTarget"/>.</param>
    /// <returns>The selected text.</returns>
    string SelectionText(CoreWebView2ContextMenuTarget target);

    /// <summary>
    /// Gets the active source uri of element (if <see cref="CoreWebView2ContextMenuTarget.HasSourceUri"/> is <c>true</c>, <c>null</c> otherwise).
    /// </summary>
    /// <param name="target">The requested <see cref="CoreWebView2ContextMenuTarget"/>.</param>
    /// <returns>The active source uri of element.</returns>
    string SourceUri(CoreWebView2ContextMenuTarget target);
}