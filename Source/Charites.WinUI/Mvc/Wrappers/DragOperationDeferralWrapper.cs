// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="DragOperationDeferral"/>
/// resolved by <see cref="IDragOperationDeferralResolver"/>.
/// </summary>
public static class DragOperationDeferralWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IDragOperationDeferralResolver"/>
    /// that resolves data of the <see cref="DragOperationDeferral"/>.
    /// </summary>
    public static IDragOperationDeferralResolver Resolver { get; set; } = new DefaultDragOperationDeferralResolver();

    /// <summary>
    /// Indicates that the content for an asynchronous drag-and-drop operation is ready for a target app.
    /// </summary>
    /// <param name="dragOperationDeferral">The requested <see cref="DragOperationDeferral"/>.</param>
    public static void CompleteWrapped(this DragOperationDeferral dragOperationDeferral) => Resolver.Complete(dragOperationDeferral);

    private sealed class DefaultDragOperationDeferralResolver : IDragOperationDeferralResolver
    {
        void IDragOperationDeferralResolver.Complete(DragOperationDeferral dragOperationDeferral) => dragOperationDeferral.Complete();
    }
}

/// <summary>
/// Resolves data of the <see cref="DragOperationDeferral"/>.
/// </summary>
public interface IDragOperationDeferralResolver
{
    /// <summary>
    /// Indicates that the content for an asynchronous drag-and-drop operation is ready for a target app.
    /// </summary>
    /// <param name="dragOperationDeferral">The requested <see cref="DragOperationDeferral"/>.</param>
    void Complete(DragOperationDeferral dragOperationDeferral);
}