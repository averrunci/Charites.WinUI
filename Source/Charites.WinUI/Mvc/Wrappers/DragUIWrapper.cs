// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.Foundation;
using Windows.Graphics.Imaging;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media.Imaging;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="DragUI"/>
/// resolved by <see cref="IDragUIResolver"/>.
/// </summary>
public static class DragUIWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IDragUIResolver"/>
    /// that resolves data of the <see cref="DragUI"/>.
    /// </summary>
    public static IDragUIResolver Resolver { get; set; } = new DefaultDragUIResolver();

    /// <summary>
    /// Creates a visual element from a provided BitmapImage to represent the dragged data in a drag-and-drop operation.
    /// </summary>
    /// <param name="dragUI">The requested <see cref="DragUI"/>.</param>
    /// <param name="bitmapImage">The source image used to create the drag visual.</param>
    public static void SetContentFromBitmapImageWrapped(this DragUI dragUI, BitmapImage bitmapImage) => Resolver.SetContentFromBitmapImage(dragUI, bitmapImage);

    /// <summary>
    /// Creates a visual element from a provided BitmapImage to represent the dragged data in a drag-and-drop operation, and sets the relative position of the visual from the pointer.
    /// </summary>
    /// <param name="dragUI">The requested <see cref="DragUI"/>.</param>
    /// <param name="bitmapImage">The source image used to create the drag visual.</param>
    /// <param name="anchorPoint">The relative position of the drag visual from the pointer.</param>
    public static void SetContentFromBitmapImageWrapped(this DragUI dragUI, BitmapImage bitmapImage, Point anchorPoint) => Resolver.SetContentFromBitmapImage(dragUI, bitmapImage, anchorPoint);

    /// <summary>
    /// Creates a visual element from a provided SoftwareBitmap to represent the dragged data in a drag-and-drop operation.
    /// </summary>
    /// <param name="dragUI">The requested <see cref="DragUI"/>.</param>
    /// <param name="softwareBitmap">The source image used to create the drag visual.</param>
    public static void SetContentFromSoftwareBitmapWrapped(this DragUI dragUI, SoftwareBitmap softwareBitmap) => Resolver.SetContentFromSoftwareBitmap(dragUI, softwareBitmap);

    /// <summary>
    /// Creates a visual element from a provided SoftwareBitmap to represent the dragged data in a drag-and-drop operation, and sets the relative position of the visual from the pointer.
    /// </summary>
    /// <param name="dragUI">The requested <see cref="DragUI"/>.</param>
    /// <param name="softwareBitmap">The source image used to create the drag visual.</param>
    /// <param name="anchorPoint">The relative position of the drag visual from the pointer.</param>
    public static void SetContentFromSoftwareBitmapWrapped(this DragUI dragUI, SoftwareBitmap softwareBitmap, Point anchorPoint) => Resolver.SetContentFromSoftwareBitmap(dragUI, softwareBitmap, anchorPoint);

    /// <summary>
    /// Creates a system provided visual element that represents the format of the dragged data in a drag-and-drop operation, typically the icon of the default handler for the file format.
    /// </summary>
    /// <param name="dragUI">The requested <see cref="DragUI"/>.</param>
    public static void SetContentFromDataPackageWrapped(this DragUI dragUI) => Resolver.SetContentFromDataPackage(dragUI);

    private sealed class DefaultDragUIResolver : IDragUIResolver
    {
        void IDragUIResolver.SetContentFromBitmapImage(DragUI dragUI, BitmapImage bitmapImage) => dragUI.SetContentFromBitmapImage(bitmapImage);
        void IDragUIResolver.SetContentFromBitmapImage(DragUI dragUI, BitmapImage bitmapImage, Point anchorPoint) => dragUI.SetContentFromBitmapImage(bitmapImage, anchorPoint);
        void IDragUIResolver.SetContentFromSoftwareBitmap(DragUI dragUI, SoftwareBitmap softwareBitmap) => dragUI.SetContentFromSoftwareBitmap(softwareBitmap);
        void IDragUIResolver.SetContentFromSoftwareBitmap(DragUI dragUI, SoftwareBitmap softwareBitmap, Point anchorPoint) => dragUI.SetContentFromSoftwareBitmap(softwareBitmap, anchorPoint);
        void IDragUIResolver.SetContentFromDataPackage(DragUI dragUI) => dragUI.SetContentFromDataPackage();
    }
}

/// <summary>
/// Resolves data of the <see cref="DragUI"/>.
/// </summary>
public interface IDragUIResolver
{
    /// <summary>
    /// Creates a visual element from a provided BitmapImage to represent the dragged data in a drag-and-drop operation.
    /// </summary>
    /// <param name="dragUI">The requested <see cref="DragUI"/>.</param>
    /// <param name="bitmapImage">The source image used to create the drag visual.</param>
    void SetContentFromBitmapImage(DragUI dragUI, BitmapImage bitmapImage);

    /// <summary>
    /// Creates a visual element from a provided BitmapImage to represent the dragged data in a drag-and-drop operation, and sets the relative position of the visual from the pointer.
    /// </summary>
    /// <param name="dragUI">The requested <see cref="DragUI"/>.</param>
    /// <param name="bitmapImage">The source image used to create the drag visual.</param>
    /// <param name="anchorPoint">The relative position of the drag visual from the pointer.</param>
    void SetContentFromBitmapImage(DragUI dragUI, BitmapImage bitmapImage, Point anchorPoint);

    /// <summary>
    /// Creates a visual element from a provided SoftwareBitmap to represent the dragged data in a drag-and-drop operation.
    /// </summary>
    /// <param name="dragUI">The requested <see cref="DragUI"/>.</param>
    /// <param name="softwareBitmap">The source image used to create the drag visual.</param>
    void SetContentFromSoftwareBitmap(DragUI dragUI, SoftwareBitmap softwareBitmap);

    /// <summary>
    /// Creates a visual element from a provided SoftwareBitmap to represent the dragged data in a drag-and-drop operation, and sets the relative position of the visual from the pointer.
    /// </summary>
    /// <param name="dragUI">The requested <see cref="DragUI"/>.</param>
    /// <param name="softwareBitmap">The source image used to create the drag visual.</param>
    /// <param name="anchorPoint">The relative position of the drag visual from the pointer.</param>
    void SetContentFromSoftwareBitmap(DragUI dragUI, SoftwareBitmap softwareBitmap, Point anchorPoint);

    /// <summary>
    /// Creates a system provided visual element that represents the format of the dragged data in a drag-and-drop operation, typically the icon of the default handler for the file format.
    /// </summary>
    /// <param name="dragUI">The requested <see cref="DragUI"/>.</param>
    void SetContentFromDataPackage(DragUI dragUI);
}