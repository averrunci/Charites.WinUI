// Copyright (C) 2023 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="ScrollingBringingIntoViewEventArgs"/>
/// resolved by <see cref="IScrollingBringingIntoViewEventArgsResolver"/>.
/// </summary>
public static class ScrollingBringingIntoViewEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IScrollingBringingIntoViewEventArgsResolver"/>
    /// that resolves data of the <see cref="ScrollingBringingIntoViewEventArgs"/>.
    /// </summary>
    public static IScrollingBringingIntoViewEventArgsResolver Resolver { get; set; } = new DefaultScrollingBringingIntoViewEventArgsResolver();

    /// <summary>
    /// Gets a value that indicates whether to cancel the participation in the bring-into-view request.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingBringingIntoViewEventArgs"/>.</param>
    /// <returns><c>true</c> if the participation in the bring-into-view request is canceled; otherwise, <c>false</c>.</returns>
    public static bool Cancel(this ScrollingBringingIntoViewEventArgs e) => Resolver.Cancel(e);

    /// <summary>
    /// Sets a value that indicates whether to cancel the participation in the bring-into-view request.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingBringingIntoViewEventArgs"/>.</param>
    /// <param name="cancel"><c>true</c> if the participation in the bring-into-view request is canceled.</param>
    public static void Cancel(this ScrollingBringingIntoViewEventArgs e, bool cancel) => Resolver.Cancel(e, cancel);

    /// <summary>
    /// Gets the correlation ID for the imminent scroll offset change participation.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingBringingIntoViewEventArgs"/>.</param>
    /// <returns>The correlation ID for the imminent scroll offset change participation.</returns>
    public static int CorrelationId(this ScrollingBringingIntoViewEventArgs e) => Resolver.CorrelationId(e);

    /// <summary>
    /// Gets the <see cref="BringIntoViewRequestedEventArgs"/> argument
    /// from the <see cref="UIElement.BringIntoViewRequested"/> event that is being processed.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingBringingIntoViewEventArgs"/>.</param>
    /// <returns>
    /// The <see cref="BringIntoViewRequestedEventArgs"/> argument from the <see cref="UIElement.BringIntoViewRequested"/> event
    /// that is being processed.
    /// </returns>
    public static BringIntoViewRequestedEventArgs RequestEventArgs(this ScrollingBringingIntoViewEventArgs e) => Resolver.RequestEventArgs(e);

    /// <summary>
    /// Gets the snap points mode used during the <see cref="ScrollView"/>'s participation in the bring-into-view request.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingBringingIntoViewEventArgs"/>.</param>
    /// <returns>
    /// The snap points mode used during the <see cref="ScrollView"/>'s participation in the bring-into-view request.
    /// </returns>
    public static ScrollingSnapPointsMode SnapPointsMode(this ScrollingBringingIntoViewEventArgs e) => Resolver.SnapPointsMode(e);

    /// <summary>
    /// Sets the snap points mode used during the <see cref="ScrollView"/>'s participation in the bring-into-view request.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingBringingIntoViewEventArgs"/>.</param>
    /// <param name="snapPointsMode">
    /// The snap points mode used during the <see cref="ScrollView"/>'s participation in the bring-into-view request.
    /// </param>
    public static void SnapPointsMode(this ScrollingBringingIntoViewEventArgs e, ScrollingSnapPointsMode snapPointsMode) => Resolver.SnapPointsMode(e, snapPointsMode);

    /// <summary>
    /// Gets the target <see cref="ScrollView.HorizontalOffset"/> for the default participation.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingBringingIntoViewEventArgs"/>.</param>
    /// <returns>The target <see cref="ScrollView.HorizontalOffset"/> fort the default participation.</returns>
    public static double TargetHorizontalOffset(this ScrollingBringingIntoViewEventArgs e) => Resolver.TargetHorizontalOffset(e);

    /// <summary>
    /// Gets the target <see cref="ScrollView.VerticalOffset"/> for the default participation.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingBringingIntoViewEventArgs"/>.</param>
    /// <returns>The target <see cref="ScrollView.VerticalOffset"/> fort the default participation.</returns>
    public static double TargetVerticalOffset(this ScrollingBringingIntoViewEventArgs e) => Resolver.TargetVerticalOffset(e);

    private sealed class DefaultScrollingBringingIntoViewEventArgsResolver : IScrollingBringingIntoViewEventArgsResolver
    {
        bool IScrollingBringingIntoViewEventArgsResolver.Cancel(ScrollingBringingIntoViewEventArgs e) => e.Cancel;
        void IScrollingBringingIntoViewEventArgsResolver.Cancel(ScrollingBringingIntoViewEventArgs e, bool cancel) => e.Cancel = cancel;
        int IScrollingBringingIntoViewEventArgsResolver.CorrelationId(ScrollingBringingIntoViewEventArgs e) => e.CorrelationId;
        BringIntoViewRequestedEventArgs IScrollingBringingIntoViewEventArgsResolver.RequestEventArgs(ScrollingBringingIntoViewEventArgs e) => e.RequestEventArgs;
        ScrollingSnapPointsMode IScrollingBringingIntoViewEventArgsResolver.SnapPointsMode(ScrollingBringingIntoViewEventArgs e) => e.SnapPointsMode;
        void IScrollingBringingIntoViewEventArgsResolver.SnapPointsMode(ScrollingBringingIntoViewEventArgs e, ScrollingSnapPointsMode snapPointsMode) => e.SnapPointsMode = snapPointsMode;
        double IScrollingBringingIntoViewEventArgsResolver.TargetHorizontalOffset(ScrollingBringingIntoViewEventArgs e) => e.TargetHorizontalOffset;
        double IScrollingBringingIntoViewEventArgsResolver.TargetVerticalOffset(ScrollingBringingIntoViewEventArgs e) => e.TargetVerticalOffset;
    }
}

/// <summary>
/// Resolves data of the <see cref="ScrollingBringingIntoViewEventArgs"/>.
/// </summary>
public interface IScrollingBringingIntoViewEventArgsResolver
{
    /// <summary>
    /// Gets a value that indicates whether to cancel the participation in the bring-into-view request.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingBringingIntoViewEventArgs"/>.</param>
    /// <returns><c>true</c> if the participation in the bring-into-view request is canceled; otherwise, <c>false</c>.</returns>
    bool Cancel(ScrollingBringingIntoViewEventArgs e);

    /// <summary>
    /// Sets a value that indicates whether to cancel the participation in the bring-into-view request.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingBringingIntoViewEventArgs"/>.</param>
    /// <param name="cancel"><c>true</c> if the participation in the bring-into-view request is canceled.</param>
    void Cancel(ScrollingBringingIntoViewEventArgs e, bool cancel);

    /// <summary>
    /// Gets the correlation ID for the imminent scroll offset change participation.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingBringingIntoViewEventArgs"/>.</param>
    /// <returns>The correlation ID for the imminent scroll offset change participation.</returns>
    int CorrelationId(ScrollingBringingIntoViewEventArgs e);

    /// <summary>
    /// Gets the <see cref="BringIntoViewRequestedEventArgs"/> argument
    /// from the <see cref="UIElement.BringIntoViewRequested"/> event that is being processed.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingBringingIntoViewEventArgs"/>.</param>
    /// <returns>
    /// The <see cref="BringIntoViewRequestedEventArgs"/> argument from the <see cref="UIElement.BringIntoViewRequested"/> event
    /// that is being processed.
    /// </returns>
    BringIntoViewRequestedEventArgs RequestEventArgs(ScrollingBringingIntoViewEventArgs e);

    /// <summary>
    /// Gets the snap points mode used during the <see cref="ScrollView"/>'s participation in the bring-into-view request.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingBringingIntoViewEventArgs"/>.</param>
    /// <returns>
    /// The snap points mode used during the <see cref="ScrollView"/>'s participation in the bring-into-view request.
    /// </returns>
    ScrollingSnapPointsMode SnapPointsMode(ScrollingBringingIntoViewEventArgs e);

    /// <summary>
    /// Sets the snap points mode used during the <see cref="ScrollView"/>'s participation in the bring-into-view request.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingBringingIntoViewEventArgs"/>.</param>
    /// <param name="snapPointsMode">
    /// The snap points mode used during the <see cref="ScrollView"/>'s participation in the bring-into-view request.
    /// </param>
    void SnapPointsMode(ScrollingBringingIntoViewEventArgs e, ScrollingSnapPointsMode snapPointsMode);

    /// <summary>
    /// Gets the target <see cref="ScrollView.HorizontalOffset"/> for the default participation.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingBringingIntoViewEventArgs"/>.</param>
    /// <returns>The target <see cref="ScrollView.HorizontalOffset"/> fort the default participation.</returns>
    double TargetHorizontalOffset(ScrollingBringingIntoViewEventArgs e);

    /// <summary>
    /// Gets the target <see cref="ScrollView.VerticalOffset"/> for the default participation.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingBringingIntoViewEventArgs"/>.</param>
    /// <returns>The target <see cref="ScrollView.VerticalOffset"/> fort the default participation.</returns>
    double TargetVerticalOffset(ScrollingBringingIntoViewEventArgs e);
}