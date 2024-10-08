﻿// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="NavigationEventArgs"/>
/// resolved by <see cref="INavigationEventArgsResolver"/>.
/// </summary>
public static class NavigationEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="INavigationEventArgsResolver"/>
    /// that resolves data of the <see cref="NavigationEventArgs"/>.
    /// </summary>
    public static INavigationEventArgsResolver Resolver { get; set; } = new DefaultNavigationEventArgsResolver();

    /// <summary>
    /// Gets the root node of the target page's content.
    /// </summary>
    /// <param name="e">The requested <see cref="NavigationEventArgs"/>.</param>
    /// <returns>The root node of the target page's content.</returns>
    public static object Content(this NavigationEventArgs e) => Resolver.Content(e);

    /// <summary>
    /// Gets a value that indicates the direction of movement during navigation.
    /// </summary>
    /// <param name="e">The requested <see cref="NavigationEventArgs"/>.</param>
    /// <returns>A value of the enumeration.</returns>
    public static NavigationMode NavigationMode(this NavigationEventArgs e) => Resolver.NavigationMode(e);

    /// <summary>
    /// Gets a value that indicates the animated transition associated with the navigation.
    /// </summary>
    /// <param name="e">The requested <see cref="NavigationEventArgs"/>.</param>
    /// <returns>Info about the animated transition.</returns>
    public static NavigationTransitionInfo NavigationTransitionInfo(this NavigationEventArgs e) => Resolver.NavigationTransitionInfo(e);

    /// <summary>
    /// Gets any "Parameter" object passed to the target page for the navigation.
    /// </summary>
    /// <param name="e">The requested <see cref="NavigationEventArgs"/>.</param>
    /// <returns>An object that potentially passes parameters to the navigation target. May be <c>null</c>.</returns>
    public static object? Parameter(this NavigationEventArgs e) => Resolver.Parameter(e);

    /// <summary>
    /// Gets the data type of the source page.
    /// </summary>
    /// <param name="e">The requested <see cref="NavigationEventArgs"/>.</param>
    /// <returns>The data type of the source page, represented as namespace.type or simply type.</returns>
    public static Type SourcePageType(this NavigationEventArgs e) => Resolver.SourcePageType(e);

    /// <summary>
    /// Gets the Uniform Resource Identifier (URI) of the target.
    /// </summary>
    /// <param name="e">The requested <see cref="NavigationEventArgs"/>.</param>
    /// <returns>A value that represents the Uniform Resource Identifier (URI).</returns>
    public static Uri Uri(this NavigationEventArgs e) => Resolver.Uri(e);

    /// <summary>
    /// Sets the Uniform Resource Identifier (URI) of the target.
    /// </summary>
    /// <param name="e">The requested <see cref="NavigationEventArgs"/>.</param>
    /// <param name="uri">A value that represents the Uniform Resource Identifier (URI).</param>
    public static void Uri(this NavigationEventArgs e, Uri uri) => Resolver.Uri(e, uri);

    private sealed class DefaultNavigationEventArgsResolver : INavigationEventArgsResolver
    {
        object INavigationEventArgsResolver.Content(NavigationEventArgs e) => e.Content;
        NavigationMode INavigationEventArgsResolver.NavigationMode(NavigationEventArgs e) => e.NavigationMode;
        NavigationTransitionInfo INavigationEventArgsResolver.NavigationTransitionInfo(NavigationEventArgs e) => e.NavigationTransitionInfo;
        object? INavigationEventArgsResolver.Parameter(NavigationEventArgs e) => e.Parameter;
        Type INavigationEventArgsResolver.SourcePageType(NavigationEventArgs e) => e.SourcePageType;
        Uri INavigationEventArgsResolver.Uri(NavigationEventArgs e) => e.Uri;
        void INavigationEventArgsResolver.Uri(NavigationEventArgs e, Uri uri) => e.Uri = uri;
    }
}

/// <summary>
/// Resolves data of the <see cref="NavigationEventArgs"/>.
/// </summary>
public interface INavigationEventArgsResolver
{
    /// <summary>
    /// Gets the root node of the target page's content.
    /// </summary>
    /// <param name="e">The requested <see cref="NavigationEventArgs"/>.</param>
    /// <returns>The root node of the target page's content.</returns>
    object Content(NavigationEventArgs e);

    /// <summary>
    /// Gets a value that indicates the direction of movement during navigation.
    /// </summary>
    /// <param name="e">The requested <see cref="NavigationEventArgs"/>.</param>
    /// <returns>A value of the enumeration.</returns>
    NavigationMode NavigationMode(NavigationEventArgs e);

    /// <summary>
    /// Gets a value that indicates the animated transition associated with the navigation.
    /// </summary>
    /// <param name="e">The requested <see cref="NavigationEventArgs"/>.</param>
    /// <returns>Info about the animated transition.</returns>
    NavigationTransitionInfo NavigationTransitionInfo(NavigationEventArgs e);

    /// <summary>
    /// Gets any "Parameter" object passed to the target page for the navigation.
    /// </summary>
    /// <param name="e">The requested <see cref="NavigationEventArgs"/>.</param>
    /// <returns>An object that potentially passes parameters to the navigation target. May be <c>null</c>.</returns>
    object? Parameter(NavigationEventArgs e);

    /// <summary>
    /// Gets the data type of the source page.
    /// </summary>
    /// <param name="e">The requested <see cref="NavigationEventArgs"/>.</param>
    /// <returns>The data type of the source page, represented as namespace.type or simply type.</returns>
    Type SourcePageType(NavigationEventArgs e);

    /// <summary>
    /// Gets the Uniform Resource Identifier (URI) of the target.
    /// </summary>
    /// <param name="e">The requested <see cref="NavigationEventArgs"/>.</param>
    /// <returns>A value that represents the Uniform Resource Identifier (URI).</returns>
    Uri Uri(NavigationEventArgs e);

    /// <summary>
    /// Sets the Uniform Resource Identifier (URI) of the target.
    /// </summary>
    /// <param name="e">The requested <see cref="NavigationEventArgs"/>.</param>
    /// <param name="uri">A value that represents the Uniform Resource Identifier (URI).</param>
    void Uri(NavigationEventArgs e, Uri uri);
}