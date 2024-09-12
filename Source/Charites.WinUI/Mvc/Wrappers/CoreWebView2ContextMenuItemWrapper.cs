// Copyright (C) 2022-2024 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.Storage.Streams;
using Microsoft.Web.WebView2.Core;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="CoreWebView2ContextMenuItem"/>
/// resolved by <see cref="ICoreWebView2ContextMenuItemResolver"/>.
/// </summary>
public static class CoreWebView2ContextMenuItemWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ICoreWebView2ContextMenuItemResolver"/>
    /// that resolves data of the <see cref="CoreWebView2ContextMenuItem"/>.
    /// </summary>
    public static ICoreWebView2ContextMenuItemResolver Resolver { get; set; } = new DefaultCoreWebView2ContextMenuItemResolver();

    /// <summary>
    /// Gets the list of children menu items if the kind is <see cref="CoreWebView2ContextMenuItemKind.Submenu"/>.
    /// </summary>
    /// <param name="menuItem">The requested <see cref="CoreWebView2ContextMenuItem"/>.</param>
    /// <returns>The list of children menu items.</returns>
    public static IList<CoreWebView2ContextMenuItem> Children(this CoreWebView2ContextMenuItem menuItem) => Resolver.Children(menuItem);

    /// <summary>
    /// Gets the Command ID for the <see cref="CoreWebView2ContextMenuItem"/>.
    /// </summary>
    /// <param name="menuItem">The requested <see cref="CoreWebView2ContextMenuItem"/>.</param>
    /// <returns>The Command ID for the <see cref="CoreWebView2ContextMenuItem"/>.</returns>
    public static int CommandId(this CoreWebView2ContextMenuItem menuItem) => Resolver.CommandId(menuItem);

    /// <summary>
    /// Gets the Icon for the <see cref="CoreWebView2ContextMenuItem"/> in PNG, Bitmap or SVG formats
    /// in the form of an IStream.
    /// </summary>
    /// <param name="menuItem">The requested <see cref="CoreWebView2ContextMenuItem"/>.</param>
    /// <returns>
    /// The Icon for the <see cref="CoreWebView2ContextMenuItem"/> in PNG, Bitmap or SVG formats
    /// in the form of an IStream.
    /// </returns>
    public static Stream Icon(this CoreWebView2ContextMenuItem menuItem) => Resolver.Icon(menuItem);

    /// <summary>
    /// Gets a value that indicates whether the checked property of the <see cref="CoreWebView2ContextMenuItem"/>.
    /// </summary>
    /// <param name="menuItem">The requested <see cref="CoreWebView2ContextMenuItem"/>.</param>
    /// <returns>
    /// <c>true</c> if the <see cref="CoreWebView2ContextMenuItem"/> is checked; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsChecked(this CoreWebView2ContextMenuItem menuItem) => Resolver.IsChecked(menuItem);

    /// <summary>
    /// Sets a value that indicates whether the checked property of the <see cref="CoreWebView2ContextMenuItem"/>.
    /// </summary>
    /// <param name="menuItem">The requested <see cref="CoreWebView2ContextMenuItem"/>.</param>
    /// <param name="isChecked">
    /// <c>true</c> if the <see cref="CoreWebView2ContextMenuItem"/> is checked; otherwise, <c>false</c>.
    /// </param>
    public static void IsChecked(this CoreWebView2ContextMenuItem menuItem, bool isChecked) => Resolver.IsChecked(menuItem, isChecked);

    /// <summary>
    /// Gets a value that indicates whether the enabled property of the <see cref="CoreWebView2ContextMenuItem"/>.
    /// </summary>
    /// <param name="menuItem">The requested <see cref="CoreWebView2ContextMenuItem"/>.</param>
    /// <returns>
    /// <c>true</c> if the <see cref="CoreWebView2ContextMenuItem"/> is enabled; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsEnabled(this CoreWebView2ContextMenuItem menuItem) => Resolver.IsEnabled(menuItem);

    /// <summary>
    /// Sets a value that indicates whether the enabled property of the <see cref="CoreWebView2ContextMenuItem"/>.
    /// </summary>
    /// <param name="menuItem">The requested <see cref="CoreWebView2ContextMenuItem"/>.</param>
    /// <param name="isEnabled">
    /// <c>true</c> if the <see cref="CoreWebView2ContextMenuItem"/> is enabled; otherwise, <c>false</c>.
    /// </param>
    public static void IsEnabled(this CoreWebView2ContextMenuItem menuItem, bool isEnabled) => Resolver.IsEnabled(menuItem, isEnabled);

    /// <summary>
    /// Gets the kind of <see cref="CoreWebView2ContextMenuItem"/> as <see cref="CoreWebView2ContextMenuItemKind"/>.
    /// </summary>
    /// <param name="menuItem">The requested <see cref="CoreWebView2ContextMenuItem"/>.</param>
    /// <returns>
    /// The kind of <see cref="CoreWebView2ContextMenuItem"/> as <see cref="CoreWebView2ContextMenuItemKind"/>.
    /// </returns>
    public static CoreWebView2ContextMenuItemKind Kind(this CoreWebView2ContextMenuItem menuItem) => Resolver.Kind(menuItem);

    /// <summary>
    /// Gets the localized label for the <see cref="CoreWebView2ContextMenuItem"/>.
    /// </summary>
    /// <param name="menuItem">The requested <see cref="CoreWebView2ContextMenuItem"/>.</param>
    /// <returns>The localized label for the <see cref="CoreWebView2ContextMenuItem"/>.</returns>
    public static string Label(this CoreWebView2ContextMenuItem menuItem) => Resolver.Label(menuItem);

    /// <summary>
    /// Gets the unlocalized name for the <see cref="CoreWebView2ContextMenuItem"/>.
    /// </summary>
    /// <param name="menuItem">The requested <see cref="CoreWebView2ContextMenuItem"/>.</param>
    /// <returns>The unlocalized name for the <see cref="CoreWebView2ContextMenuItem"/>.</returns>
    public static string Name(this CoreWebView2ContextMenuItem menuItem) => Resolver.Name(menuItem);

    /// <summary>
    /// Gets the localized keyboard shortcut for the <see cref="CoreWebView2ContextMenuItem"/>.
    /// </summary>
    /// <param name="menuItem">The requested <see cref="CoreWebView2ContextMenuItem"/>.</param>
    /// <returns>The localized keyboard shortcut for the <see cref="CoreWebView2ContextMenuItem"/>.</returns>
    public static string ShortcutKeyDescription(this CoreWebView2ContextMenuItem menuItem) => Resolver.ShortcutKeyDescription(menuItem);

    private sealed class DefaultCoreWebView2ContextMenuItemResolver : ICoreWebView2ContextMenuItemResolver
    {
        IList<CoreWebView2ContextMenuItem> ICoreWebView2ContextMenuItemResolver.Children(CoreWebView2ContextMenuItem menuItem) => menuItem.Children;
        int ICoreWebView2ContextMenuItemResolver.CommandId(CoreWebView2ContextMenuItem menuItem) => menuItem.CommandId;
        Stream ICoreWebView2ContextMenuItemResolver.Icon(CoreWebView2ContextMenuItem menuItem) => menuItem.Icon;
        bool ICoreWebView2ContextMenuItemResolver.IsChecked(CoreWebView2ContextMenuItem menuItem) => menuItem.IsChecked;
        void ICoreWebView2ContextMenuItemResolver.IsChecked(CoreWebView2ContextMenuItem menuItem, bool isChecked) => menuItem.IsChecked = isChecked;
        bool ICoreWebView2ContextMenuItemResolver.IsEnabled(CoreWebView2ContextMenuItem menuItem) => menuItem.IsEnabled;
        void ICoreWebView2ContextMenuItemResolver.IsEnabled(CoreWebView2ContextMenuItem menuItem, bool isEnabled) => menuItem.IsEnabled = isEnabled;
        CoreWebView2ContextMenuItemKind ICoreWebView2ContextMenuItemResolver.Kind(CoreWebView2ContextMenuItem menuItem) => menuItem.Kind;
        string ICoreWebView2ContextMenuItemResolver.Label(CoreWebView2ContextMenuItem menuItem) => menuItem.Label;
        string ICoreWebView2ContextMenuItemResolver.Name(CoreWebView2ContextMenuItem menuItem) => menuItem.Name;
        string ICoreWebView2ContextMenuItemResolver.ShortcutKeyDescription(CoreWebView2ContextMenuItem menuItem) => menuItem.ShortcutKeyDescription;
    }
}

/// <summary>
/// Resolves data of the <see cref="CoreWebView2ContextMenuItem"/>.
/// </summary>
public interface ICoreWebView2ContextMenuItemResolver
{
    /// <summary>
    /// Gets the list of children menu items if the kind is <see cref="CoreWebView2ContextMenuItemKind.Submenu"/>.
    /// </summary>
    /// <param name="menuItem">The requested <see cref="CoreWebView2ContextMenuItem"/>.</param>
    /// <returns>The list of children menu items.</returns>
    IList<CoreWebView2ContextMenuItem> Children(CoreWebView2ContextMenuItem menuItem);

    /// <summary>
    /// Gets the Command ID for the <see cref="CoreWebView2ContextMenuItem"/>.
    /// </summary>
    /// <param name="menuItem">The requested <see cref="CoreWebView2ContextMenuItem"/>.</param>
    /// <returns>The Command ID for the <see cref="CoreWebView2ContextMenuItem"/>.</returns>
    int CommandId(CoreWebView2ContextMenuItem menuItem);

    /// <summary>
    /// Gets the Icon for the <see cref="CoreWebView2ContextMenuItem"/> in PNG, Bitmap or SVG formats
    /// in the form of an IStream.
    /// </summary>
    /// <param name="menuItem">The requested <see cref="CoreWebView2ContextMenuItem"/>.</param>
    /// <returns>
    /// The Icon for the <see cref="CoreWebView2ContextMenuItem"/> in PNG, Bitmap or SVG formats
    /// in the form of an IStream.
    /// </returns>
    Stream Icon(CoreWebView2ContextMenuItem menuItem);

    /// <summary>
    /// Gets a value that indicates whether the checked property of the <see cref="CoreWebView2ContextMenuItem"/>.
    /// </summary>
    /// <param name="menuItem">The requested <see cref="CoreWebView2ContextMenuItem"/>.</param>
    /// <returns>
    /// <c>true</c> if the <see cref="CoreWebView2ContextMenuItem"/> is checked; otherwise, <c>false</c>.
    /// </returns>
    bool IsChecked(CoreWebView2ContextMenuItem menuItem);

    /// <summary>
    /// Sets a value that indicates whether the checked property of the <see cref="CoreWebView2ContextMenuItem"/>.
    /// </summary>
    /// <param name="menuItem">The requested <see cref="CoreWebView2ContextMenuItem"/>.</param>
    /// <param name="isChecked">
    /// <c>true</c> if the <see cref="CoreWebView2ContextMenuItem"/> is checked; otherwise, <c>false</c>.
    /// </param>
    void IsChecked(CoreWebView2ContextMenuItem menuItem, bool isChecked);

    /// <summary>
    /// Gets a value that indicates whether the enabled property of the <see cref="CoreWebView2ContextMenuItem"/>.
    /// </summary>
    /// <param name="menuItem">The requested <see cref="CoreWebView2ContextMenuItem"/>.</param>
    /// <returns>
    /// <c>true</c> if the <see cref="CoreWebView2ContextMenuItem"/> is enabled; otherwise, <c>false</c>.
    /// </returns>
    bool IsEnabled(CoreWebView2ContextMenuItem menuItem);

    /// <summary>
    /// Sets a value that indicates whether the enabled property of the <see cref="CoreWebView2ContextMenuItem"/>.
    /// </summary>
    /// <param name="menuItem">The requested <see cref="CoreWebView2ContextMenuItem"/>.</param>
    /// <param name="isEnabled">
    /// <c>true</c> if the <see cref="CoreWebView2ContextMenuItem"/> is enabled; otherwise, <c>false</c>.
    /// </param>
    void IsEnabled(CoreWebView2ContextMenuItem menuItem, bool isEnabled);

    /// <summary>
    /// Gets the kind of <see cref="CoreWebView2ContextMenuItem"/> as <see cref="CoreWebView2ContextMenuItemKind"/>.
    /// </summary>
    /// <param name="menuItem">The requested <see cref="CoreWebView2ContextMenuItem"/>.</param>
    /// <returns>
    /// The kind of <see cref="CoreWebView2ContextMenuItem"/> as <see cref="CoreWebView2ContextMenuItemKind"/>.
    /// </returns>
    CoreWebView2ContextMenuItemKind Kind(CoreWebView2ContextMenuItem menuItem);

    /// <summary>
    /// Gets the localized label for the <see cref="CoreWebView2ContextMenuItem"/>.
    /// </summary>
    /// <param name="menuItem">The requested <see cref="CoreWebView2ContextMenuItem"/>.</param>
    /// <returns>The localized label for the <see cref="CoreWebView2ContextMenuItem"/>.</returns>
    string Label(CoreWebView2ContextMenuItem menuItem);

    /// <summary>
    /// Gets the unlocalized name for the <see cref="CoreWebView2ContextMenuItem"/>.
    /// </summary>
    /// <param name="menuItem">The requested <see cref="CoreWebView2ContextMenuItem"/>.</param>
    /// <returns>The unlocalized name for the <see cref="CoreWebView2ContextMenuItem"/>.</returns>
    string Name(CoreWebView2ContextMenuItem menuItem);

    /// <summary>
    /// Gets the localized keyboard shortcut for the <see cref="CoreWebView2ContextMenuItem"/>.
    /// </summary>
    /// <param name="menuItem">The requested <see cref="CoreWebView2ContextMenuItem"/>.</param>
    /// <returns>The localized keyboard shortcut for the <see cref="CoreWebView2ContextMenuItem"/>.</returns>
    string ShortcutKeyDescription(CoreWebView2ContextMenuItem menuItem);
}