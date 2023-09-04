// Copyright (C) 2023 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="LinedFlowLayoutItemsInfoRequestedEventArgs"/>
/// resolved by <see cref="ILinedFlowLayoutItemsInfoRequestedEventArgsResolver"/>.
/// </summary>
public static class LinedFlowLayoutItemsInfoRequestedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ILinedFlowLayoutItemsInfoRequestedEventArgsResolver"/>
    /// that resolves data of the <see cref="LinedFlowLayoutItemsInfoRequestedEventArgs"/>.
    /// </summary>
    public static ILinedFlowLayoutItemsInfoRequestedEventArgsResolver Resolver { get; set; } = new DefaultLinedFlowLayoutItemsInfoRequestedEventArgsResolver();

    /// <summary>
    /// Gets the length requested items range.
    /// </summary>
    /// <param name="e">The requested <see cref="LinedFlowLayoutItemsInfoRequestedEventArgs"/>.</param>
    /// <returns>The length requested items range.</returns>
    public static int ItemsRangeRequestedLength(this LinedFlowLayoutItemsInfoRequestedEventArgs e) => Resolver.ItemsRangeRequestedLength(e);

    /// <summary>
    /// Gets the start index of items range.
    /// </summary>
    /// <param name="e">The requested <see cref="LinedFlowLayoutItemsInfoRequestedEventArgs"/>.</param>
    /// <returns>The start index of items range.</returns>
    public static int ItemsRangeStartIndex(this LinedFlowLayoutItemsInfoRequestedEventArgs e) => Resolver.ItemsRangeStartIndex(e);

    /// <summary>
    /// Sets the start index of items range.
    /// </summary>
    /// <param name="e">The requested <see cref="LinedFlowLayoutItemsInfoRequestedEventArgs"/>.</param>
    /// <param name="index">The start index of items range.</param>
    public static void ItemsRangeStartIndex(this LinedFlowLayoutItemsInfoRequestedEventArgs e, int index) => Resolver.ItemsRangeStartIndex(e, index);

    /// <summary>
    /// Gets the max width.
    /// </summary>
    /// <param name="e">The requested <see cref="LinedFlowLayoutItemsInfoRequestedEventArgs"/>.</param>
    /// <returns>The max width.</returns>
    public static double MaxWidth(this LinedFlowLayoutItemsInfoRequestedEventArgs e) => Resolver.MaxWidth(e);

    /// <summary>
    /// Sets the max width.
    /// </summary>
    /// <param name="e">The requested <see cref="LinedFlowLayoutItemsInfoRequestedEventArgs"/>.</param>
    /// <param name="maxWidth">The max width.</param>
    public static void MaxWidth(this LinedFlowLayoutItemsInfoRequestedEventArgs e, double maxWidth) => Resolver.MaxWidth(e, maxWidth);

    /// <summary>
    /// Gets the min width.
    /// </summary>
    /// <param name="e">The requested <see cref="LinedFlowLayoutItemsInfoRequestedEventArgs"/>.</param>
    /// <returns>The min width.</returns>
    public static double MinWidth(this LinedFlowLayoutItemsInfoRequestedEventArgs e) => Resolver.MinWidth(e);

    /// <summary>
    /// Sets the min width.
    /// </summary>
    /// <param name="e">The requested <see cref="LinedFlowLayoutItemsInfoRequestedEventArgs"/>.</param>
    /// <param name="minWidth">The min width.</param>
    public static void MinWidth(this LinedFlowLayoutItemsInfoRequestedEventArgs e, double minWidth) => Resolver.MinWidth(e, minWidth);

    /// <summary>
    /// Sets the desired aspect ratios.
    /// </summary>
    /// <param name="e">The requested <see cref="LinedFlowLayoutItemsInfoRequestedEventArgs"/>.</param>
    /// <param name="values">The desired aspect ratios.</param>
    public static void SetDesiredAspectRatiosWrapped(this LinedFlowLayoutItemsInfoRequestedEventArgs e, double[] values) => Resolver.SetDesiredAspectRatiosWrapped(e, values);

    /// <summary>
    /// Sets the max widths.
    /// </summary>
    /// <param name="e">The requested <see cref="LinedFlowLayoutItemsInfoRequestedEventArgs"/>.</param>
    /// <param name="values">The max widths.</param>
    public static void SetMaxWidthsWrapped(this LinedFlowLayoutItemsInfoRequestedEventArgs e, double[] values) => Resolver.SetMaxWidthsWrapped(e, values);

    /// <summary>
    /// Sets the min widths.
    /// </summary>
    /// <param name="e">The requested <see cref="LinedFlowLayoutItemsInfoRequestedEventArgs"/>.</param>
    /// <param name="values">The min widths.</param>
    public static void SetMinWidthsWrapped(this LinedFlowLayoutItemsInfoRequestedEventArgs e, double[] values) => Resolver.SetMinWidthsWrapped(e, values);

    private sealed class DefaultLinedFlowLayoutItemsInfoRequestedEventArgsResolver : ILinedFlowLayoutItemsInfoRequestedEventArgsResolver
    {
        int ILinedFlowLayoutItemsInfoRequestedEventArgsResolver.ItemsRangeRequestedLength(LinedFlowLayoutItemsInfoRequestedEventArgs e) => e.ItemsRangeRequestedLength;
        int ILinedFlowLayoutItemsInfoRequestedEventArgsResolver.ItemsRangeStartIndex(LinedFlowLayoutItemsInfoRequestedEventArgs e) => e.ItemsRangeStartIndex;
        void ILinedFlowLayoutItemsInfoRequestedEventArgsResolver.ItemsRangeStartIndex(LinedFlowLayoutItemsInfoRequestedEventArgs e, int index) => e.ItemsRangeStartIndex = index;
        double ILinedFlowLayoutItemsInfoRequestedEventArgsResolver.MaxWidth(LinedFlowLayoutItemsInfoRequestedEventArgs e) => e.MaxWidth;
        void ILinedFlowLayoutItemsInfoRequestedEventArgsResolver.MaxWidth(LinedFlowLayoutItemsInfoRequestedEventArgs e, double maxWidth) => e.MaxWidth = maxWidth;
        double ILinedFlowLayoutItemsInfoRequestedEventArgsResolver.MinWidth(LinedFlowLayoutItemsInfoRequestedEventArgs e) => e.MinWidth;
        void ILinedFlowLayoutItemsInfoRequestedEventArgsResolver.MinWidth(LinedFlowLayoutItemsInfoRequestedEventArgs e, double minWidth) => e.MinWidth = minWidth;
        void ILinedFlowLayoutItemsInfoRequestedEventArgsResolver.SetDesiredAspectRatiosWrapped(LinedFlowLayoutItemsInfoRequestedEventArgs e, double[] values) => e.SetDesiredAspectRatios(values);
        void ILinedFlowLayoutItemsInfoRequestedEventArgsResolver.SetMaxWidthsWrapped(LinedFlowLayoutItemsInfoRequestedEventArgs e, double[] values) => e.SetMaxWidths(values);
        void ILinedFlowLayoutItemsInfoRequestedEventArgsResolver.SetMinWidthsWrapped(LinedFlowLayoutItemsInfoRequestedEventArgs e, double[] values) => e.SetMinWidths(values);
    }
}

/// <summary>
/// Resolves data of the <see cref="LinedFlowLayoutItemsInfoRequestedEventArgs"/>.
/// </summary>
public interface ILinedFlowLayoutItemsInfoRequestedEventArgsResolver
{
    /// <summary>
    /// Gets the length requested items range.
    /// </summary>
    /// <param name="e">The requested <see cref="LinedFlowLayoutItemsInfoRequestedEventArgs"/>.</param>
    /// <returns>The length requested items range.</returns>
    int ItemsRangeRequestedLength(LinedFlowLayoutItemsInfoRequestedEventArgs e);

    /// <summary>
    /// Gets the start index of items range.
    /// </summary>
    /// <param name="e">The requested <see cref="LinedFlowLayoutItemsInfoRequestedEventArgs"/>.</param>
    /// <returns>The start index of items range.</returns>
    int ItemsRangeStartIndex(LinedFlowLayoutItemsInfoRequestedEventArgs e);

    /// <summary>
    /// Sets the start index of items range.
    /// </summary>
    /// <param name="e">The requested <see cref="LinedFlowLayoutItemsInfoRequestedEventArgs"/>.</param>
    /// <param name="index">The start index of items range.</param>
    void ItemsRangeStartIndex(LinedFlowLayoutItemsInfoRequestedEventArgs e, int index);

    /// <summary>
    /// Gets the max width.
    /// </summary>
    /// <param name="e">The requested <see cref="LinedFlowLayoutItemsInfoRequestedEventArgs"/>.</param>
    /// <returns>The max width.</returns>
    double MaxWidth(LinedFlowLayoutItemsInfoRequestedEventArgs e);

    /// <summary>
    /// Sets the max width.
    /// </summary>
    /// <param name="e">The requested <see cref="LinedFlowLayoutItemsInfoRequestedEventArgs"/>.</param>
    /// <param name="maxWidth">The max width.</param>
    void MaxWidth(LinedFlowLayoutItemsInfoRequestedEventArgs e, double maxWidth);

    /// <summary>
    /// Gets the min width.
    /// </summary>
    /// <param name="e">The requested <see cref="LinedFlowLayoutItemsInfoRequestedEventArgs"/>.</param>
    /// <returns>The min width.</returns>
    double MinWidth(LinedFlowLayoutItemsInfoRequestedEventArgs e);

    /// <summary>
    /// Sets the min width.
    /// </summary>
    /// <param name="e">The requested <see cref="LinedFlowLayoutItemsInfoRequestedEventArgs"/>.</param>
    /// <param name="minWidth">The min width.</param>
    void MinWidth(LinedFlowLayoutItemsInfoRequestedEventArgs e, double minWidth);

    /// <summary>
    /// Sets the desired aspect ratios.
    /// </summary>
    /// <param name="e">The requested <see cref="LinedFlowLayoutItemsInfoRequestedEventArgs"/>.</param>
    /// <param name="values">The desired aspect ratios.</param>
    void SetDesiredAspectRatiosWrapped(LinedFlowLayoutItemsInfoRequestedEventArgs e, double[] values);

    /// <summary>
    /// Sets the max widths.
    /// </summary>
    /// <param name="e">The requested <see cref="LinedFlowLayoutItemsInfoRequestedEventArgs"/>.</param>
    /// <param name="values">The max widths.</param>
    void SetMaxWidthsWrapped(LinedFlowLayoutItemsInfoRequestedEventArgs e, double[] values);

    /// <summary>
    /// Sets the min widths.
    /// </summary>
    /// <param name="e">The requested <see cref="LinedFlowLayoutItemsInfoRequestedEventArgs"/>.</param>
    /// <param name="values">The min widths.</param>
    void SetMinWidthsWrapped(LinedFlowLayoutItemsInfoRequestedEventArgs e, double[] values);
}