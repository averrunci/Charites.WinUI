// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.Foundation;
using Microsoft.UI.Input;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="PointerPoint"/>
/// resolved by <see cref="IPointerPointResolver"/>.
/// </summary>
public static class PointerPointWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IPointerPointResolver"/>
    /// that resolves data of the <see cref="PointerPoint"/>.
    /// </summary>
    public static IPointerPointResolver Resolver { get; set; } = new DefaultPointerPointResolver();

    /// <summary>
    /// Gets the ID of an input frame.
    /// </summary>
    /// <param name="pointerPoint">The requested <see cref="PointerPoint"/>.</param>
    /// <returns>The frame ID.</returns>
    public static uint FrameId(this PointerPoint pointerPoint) => Resolver.FrameId(pointerPoint);

    /// <summary>
    /// Gets a value that indicates whether the input device (touch, pen/stylus) is pressing down on (touching) the digitizer surface,
    /// or a mouse button is pressed down
    /// </summary>
    /// <param name="pointerPoint">The requested <see cref="PointerPoint"/>.</param>
    /// <returns><c>true</c> if pressed down; otherwise, <c>false</c>.</returns>
    public static bool IsInContact(this PointerPoint pointerPoint) => Resolver.IsInContact(pointerPoint);

    /// <summary>
    /// Gets the input device type associated with the input pointer.
    /// </summary>
    /// <param name="pointerPoint">The requested <see cref="PointerPoint"/>.</param>
    /// <returns>The input device type.</returns>
    public static PointerDeviceType PointerDeviceType(this PointerPoint pointerPoint) => Resolver.PointerDeviceType(pointerPoint);

    /// <summary>
    /// Gets a unique identifier for the input pointer.
    /// </summary>
    /// <param name="pointerPoint">The requested <see cref="PointerPoint"/>.</param>
    /// <returns>A unique value that identifies the input pointer.</returns>
    public static uint PointerId(this PointerPoint pointerPoint) => Resolver.PointerId(pointerPoint);

    /// <summary>
    /// Gets the location of the input pointer.
    /// </summary>
    /// <param name="pointerPoint">The requested <see cref="PointerPoint"/>.</param>
    /// <returns>The coordinates, in device-independent pixels (DIPs).</returns>
    public static Point Position(this PointerPoint pointerPoint) => Resolver.Position(pointerPoint);

    /// <summary>
    /// Gets extended information about the input pointer.
    /// </summary>
    /// <param name="pointerPoint">The requested <see cref="PointerPoint"/>.</param>
    /// <returns>The extended properties exposed by the input device.</returns>
    public static PointerPointProperties Properties(this PointerPoint pointerPoint) => Resolver.Properties(pointerPoint);

    /// <summary>
    /// Gets the time when the input occurred.
    /// </summary>
    /// <param name="pointerPoint">The requested <see cref="PointerPoint"/>.</param>
    /// <returns>The time, relative to the system boot time, in microseconds.</returns>
    public static ulong Timestamp(this PointerPoint pointerPoint) => Resolver.Timestamp(pointerPoint);

    /// <summary>
    /// gets the transformed point.
    /// </summary>
    /// <param name="pointerPoint">The requested <see cref="PointerPoint"/>.</param>
    /// <param name="transform">The <see cref="IPointerPointTransform"/>.</param>
    /// <returns>The transformed point.</returns>
    public static PointerPoint GetTransformedPointWrapped(this PointerPoint pointerPoint, IPointerPointTransform transform) => Resolver.GetTransformedPoint(pointerPoint, transform);

    private sealed class DefaultPointerPointResolver : IPointerPointResolver
    {
        uint IPointerPointResolver.FrameId(PointerPoint pointerPoint) => pointerPoint.FrameId;
        bool IPointerPointResolver.IsInContact(PointerPoint pointerPoint) => pointerPoint.IsInContact;
        PointerDeviceType IPointerPointResolver.PointerDeviceType(PointerPoint pointerPoint) => pointerPoint.PointerDeviceType;
        uint IPointerPointResolver.PointerId(PointerPoint pointerPoint) => pointerPoint.PointerId;
        Point IPointerPointResolver.Position(PointerPoint pointerPoint) => pointerPoint.Position;
        PointerPointProperties IPointerPointResolver.Properties(PointerPoint pointerPoint) => pointerPoint.Properties;
        ulong IPointerPointResolver.Timestamp(PointerPoint pointerPoint) => pointerPoint.Timestamp;
        PointerPoint IPointerPointResolver.GetTransformedPoint(PointerPoint pointerPoint, IPointerPointTransform transform) => pointerPoint.GetTransformedPoint(transform);
    }
}

/// <summary>
/// Resolves data of the <see cref="PointerPoint"/>.
/// </summary>
public interface IPointerPointResolver
{
    /// <summary>
    /// Gets the ID of an input frame.
    /// </summary>
    /// <param name="pointerPoint">The requested <see cref="PointerPoint"/>.</param>
    /// <returns>The frame ID.</returns>
    uint FrameId(PointerPoint pointerPoint);

    /// <summary>
    /// Gets a value that indicates whether the input device (touch, pen/stylus) is pressing down on (touching) the digitizer surface,
    /// or a mouse button is pressed down
    /// </summary>
    /// <param name="pointerPoint">The requested <see cref="PointerPoint"/>.</param>
    /// <returns><c>true</c> if pressed down; otherwise, <c>false</c>.</returns>
    bool IsInContact(PointerPoint pointerPoint);

    /// <summary>
    /// Gets the input device type associated with the input pointer.
    /// </summary>
    /// <param name="pointerPoint">The requested <see cref="PointerPoint"/>.</param>
    /// <returns>The input device type.</returns>
    PointerDeviceType PointerDeviceType(PointerPoint pointerPoint);

    /// <summary>
    /// Gets a unique identifier for the input pointer.
    /// </summary>
    /// <param name="pointerPoint">The requested <see cref="PointerPoint"/>.</param>
    /// <returns>A unique value that identifies the input pointer.</returns>
    uint PointerId(PointerPoint pointerPoint);

    /// <summary>
    /// Gets the location of the input pointer.
    /// </summary>
    /// <param name="pointerPoint">The requested <see cref="PointerPoint"/>.</param>
    /// <returns>The coordinates, in device-independent pixels (DIPs).</returns>
    Point Position(PointerPoint pointerPoint);

    /// <summary>
    /// Gets extended information about the input pointer.
    /// </summary>
    /// <param name="pointerPoint">The requested <see cref="PointerPoint"/>.</param>
    /// <returns>The extended properties exposed by the input device.</returns>
    PointerPointProperties Properties(PointerPoint pointerPoint);

    /// <summary>
    /// Gets the time when the input occurred.
    /// </summary>
    /// <param name="pointerPoint">The requested <see cref="PointerPoint"/>.</param>
    /// <returns>The time, relative to the system boot time, in microseconds.</returns>
    ulong Timestamp(PointerPoint pointerPoint);

    /// <summary>
    /// gets the transformed point.
    /// </summary>
    /// <param name="pointerPoint">The requested <see cref="PointerPoint"/>.</param>
    /// <param name="transform">The <see cref="IPointerPointTransform"/>.</param>
    /// <returns>The transformed point.</returns>
    PointerPoint GetTransformedPoint(PointerPoint pointerPoint, IPointerPointTransform transform);
}