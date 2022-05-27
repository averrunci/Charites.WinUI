// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.Foundation;
using Microsoft.UI.Input;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="PointerPointProperties"/>
/// resolved by <see cref="IPointerPointPropertiesResolver"/>.
/// </summary>
public static class PointerPointPropertiesWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IPointerPointPropertiesResolver"/>
    /// that resolves data of the <see cref="PointerPointProperties"/>.
    /// </summary>
    public static IPointerPointPropertiesResolver Resolver { get; set; } = new DefaultPointerPointPropertiesResolver();

    /// <summary>
    /// Gets the bounding rectangle of the contact area (typically from touch input).
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns>
    /// The bounding rectangle of the contact area, using client window coordinates in device-independent pixels (DIPs).
    /// </returns>
    public static Rect ContactRect(this PointerPointProperties pointerPointProperties) => Resolver.ContactRect(pointerPointProperties);

    /// <summary>
    /// Gets a value that indicates whether the barrel button of the pen/stylus device is pressed.
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns><c>true</c> if the barrel button is pressed; otherwise, <c>false</c>.</returns>
    public static bool IsBarrelButtonPressed(this PointerPointProperties pointerPointProperties) => Resolver.IsBarrelButtonPressed(pointerPointProperties);

    /// <summary>
    /// Gets a value that indicates whether the input was canceled by the pointer device.
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns><c>true</c> if the input was canceled; otherwise, <c>false</c>.</returns>
    public static bool IsCanceled(this PointerPointProperties pointerPointProperties) => Resolver.IsCanceled(pointerPointProperties);

    /// <summary>
    /// Gets a value that indicates whether the input is from a pen eraser.
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns><c>true</c> if the input is from a pen eraser; otherwise, <c>false</c>.</returns>
    public static bool IsEraser(this PointerPointProperties pointerPointProperties) => Resolver.IsEraser(pointerPointProperties);

    /// <summary>
    /// Gets a value that indicates whether the input is from a mouse tilt wheel.
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns><c>true</c> if the input is from a mouse tilt wheel; otherwise, <c>false</c>.</returns>
    public static bool IsHorizontalMouseWheel(this PointerPointProperties pointerPointProperties) => Resolver.IsHorizontalMouseWheel(pointerPointProperties);

    /// <summary>
    /// Gets a value that indicates whether the pointer device is within detection range of a sensor or
    /// digitizer (the pointer continues to exist).
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns><c>true</c> if touch or pen is within detection range or mouse is over; otherwise, <c>false</c>.</returns>
    public static bool IsInRange(this PointerPointProperties pointerPointProperties) => Resolver.IsInRange(pointerPointProperties);

    /// <summary>
    /// Gets a value that indicates whether the digitizer pen is inverted.
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns><c>true</c> if inverted; otherwise, <c>false</c>.</returns>
    public static bool IsInverted(this PointerPointProperties pointerPointProperties) => Resolver.IsInverted(pointerPointProperties);

    /// <summary>
    /// Gets a value that indicates whether the pointer input was triggered by the primary action mode of an input device.
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns><c>true</c> if the primary action mode; otherwise, <c>false</c>.</returns>
    public static bool IsLeftButtonPressed(this PointerPointProperties pointerPointProperties) => Resolver.IsLeftButtonPressed(pointerPointProperties);

    /// <summary>
    /// Gets a value that indicates whether the pointer input was triggered by the tertiary action mode of
    /// an input device (such as the mouse wheel button).
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns><c>true</c> if the pointer input was triggered by the tertiary action mode; otherwise, <c>false</c>.</returns>
    public static bool IsMiddleButtonPressed(this PointerPointProperties pointerPointProperties) => Resolver.IsMiddleButtonPressed(pointerPointProperties);

    /// <summary>
    /// Gets a value that indicates whether the input is from the primary pointer when multiple pointers are registered.
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns><c>true</c> if the input is from the primary pointer; otherwise, <c>false</c>.</returns>
    public static bool IsPrimary(this PointerPointProperties pointerPointProperties) => Resolver.IsPrimary(pointerPointProperties);

    /// <summary>
    /// Gets a value that indicates whether the pointer input was triggered by the secondary action mode (if supported)
    /// of an input device.
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns><c>true</c> if the secondary action mode; otherwise, <c>false</c>.</returns>
    public static bool IsRightButtonPressed(this PointerPointProperties pointerPointProperties) => Resolver.IsRightButtonPressed(pointerPointProperties);

    /// <summary>
    /// Gets a value that indicates whether the pointer input was triggered by the first extended mouse button (XButton1).
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns><c>true</c> if the first extended mouse button is pressed; otherwise, <c>false</c>.</returns>
    public static bool IsXButton1Pressed(this PointerPointProperties pointerPointProperties) => Resolver.IsXButton1Pressed(pointerPointProperties);

    /// <summary>
    /// Gets a value that indicates whether the pointer input was triggered by the second extended mouse button (XButton2).
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns><c>true</c> if the second extended mouse button is pressed; otherwise, <c>false</c>.</returns>
    public static bool IsXButton2Pressed(this PointerPointProperties pointerPointProperties) => Resolver.IsXButton2Pressed(pointerPointProperties);

    /// <summary>
    /// Gets a value (the raw value reported by the device) that indicates the change in wheel button input
    /// from the last pointer event.
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns>The number of notches or distance thresholds crossed since the last pointer event.</returns>
    public static int MouseWheelDelta(this PointerPointProperties pointerPointProperties) => Resolver.MouseWheelDelta(pointerPointProperties);

    /// <summary>
    /// Gets the counter-clockwise angle of rotation around the major axis of the pointer device (the z-axis,
    /// perpendicular to the surface of the digitizer). A value of 0.0 degrees indicates the device is oriented
    /// towards the top of the digitizer.
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns>A value between 0.0 and 359.0 in degrees of rotation.</returns>
    public static float Orientation(this PointerPointProperties pointerPointProperties) => Resolver.Orientation(pointerPointProperties);

    /// <summary>
    /// Gets the type of pointer state change.
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns>The type of pointer state change.</returns>
    public static PointerUpdateKind PointerUpdateKind(this PointerPointProperties pointerPointProperties) => Resolver.PointerUpdateKind(pointerPointProperties);

    /// <summary>
    /// Gets a value that indicates the force that the pointer device (typically a pen/stylus) exerts on the surface of the digitizer.
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns>A value from 0 to 1.0.</returns>
    public static float Pressure(this PointerPointProperties pointerPointProperties) => Resolver.Pressure(pointerPointProperties);

    /// <summary>
    /// Gets a value that indicates whether the pointer device rejected the touch contact.
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns><c>true</c> if the touch contact was accepted; otherwise, <c>false</c>.</returns>
    public static bool TouchConfidence(this PointerPointProperties pointerPointProperties) => Resolver.TouchConfidence(pointerPointProperties);

    /// <summary>
    /// Gets the clockwise rotation in degrees of a pen device around its own major axis (such as
    /// when the user spins the pen in their fingers).
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns>A value between 0.0 and 359.0 in degrees of rotation.</returns>
    public static float Twist(this PointerPointProperties pointerPointProperties) => Resolver.Twist(pointerPointProperties);

    /// <summary>
    /// Gets the plane angle between the Y-Z plane and the plane that contains the Y axis and
    /// the axis of the input device (typically a pen/stylus).
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns>
    /// The value is 0.0 when the finger or pen is perpendicular to the digitizer surface, between 0.0 and 90.0
    /// when tilted to the right of perpendicular, and between 0.0 and -90.0 when tilted to the left of perpendicular.
    /// </returns>
    public static float XTilt(this PointerPointProperties pointerPointProperties) => Resolver.XTilt(pointerPointProperties);

    /// <summary>
    /// Gets the plane angle between the X-Z plane and the plane that contains the X axis and
    /// the axis of the input device (typically a pen/stylus).
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns>
    /// The value is 0.0 when the finger or pen is perpendicular to the digitizer surface, between 0.0 and 90.0
    /// when tilted towards the user, and between 0.0 and -90.0 when tilted away from the user.
    /// </returns>
    public static float YTilt(this PointerPointProperties pointerPointProperties) => Resolver.YTilt(pointerPointProperties);

    private sealed class DefaultPointerPointPropertiesResolver : IPointerPointPropertiesResolver
    {
        Rect IPointerPointPropertiesResolver.ContactRect(PointerPointProperties pointerPointProperties) => pointerPointProperties.ContactRect;
        bool IPointerPointPropertiesResolver.IsBarrelButtonPressed(PointerPointProperties pointerPointProperties) => pointerPointProperties.IsBarrelButtonPressed;
        bool IPointerPointPropertiesResolver.IsCanceled(PointerPointProperties pointerPointProperties) => pointerPointProperties.IsCanceled;
        bool IPointerPointPropertiesResolver.IsEraser(PointerPointProperties pointerPointProperties) => pointerPointProperties.IsEraser;
        bool IPointerPointPropertiesResolver.IsHorizontalMouseWheel(PointerPointProperties pointerPointProperties) => pointerPointProperties.IsHorizontalMouseWheel;
        bool IPointerPointPropertiesResolver.IsInRange(PointerPointProperties pointerPointProperties) => pointerPointProperties.IsInRange;
        bool IPointerPointPropertiesResolver.IsInverted(PointerPointProperties pointerPointProperties) => pointerPointProperties.IsInverted;
        bool IPointerPointPropertiesResolver.IsLeftButtonPressed(PointerPointProperties pointerPointProperties) => pointerPointProperties.IsLeftButtonPressed;
        bool IPointerPointPropertiesResolver.IsMiddleButtonPressed(PointerPointProperties pointerPointProperties) => pointerPointProperties.IsMiddleButtonPressed;
        bool IPointerPointPropertiesResolver.IsPrimary(PointerPointProperties pointerPointProperties) => pointerPointProperties.IsPrimary;
        bool IPointerPointPropertiesResolver.IsRightButtonPressed(PointerPointProperties pointerPointProperties) => pointerPointProperties.IsRightButtonPressed;
        bool IPointerPointPropertiesResolver.IsXButton1Pressed(PointerPointProperties pointerPointProperties) => pointerPointProperties.IsXButton1Pressed;
        bool IPointerPointPropertiesResolver.IsXButton2Pressed(PointerPointProperties pointerPointProperties) => pointerPointProperties.IsXButton2Pressed;
        int IPointerPointPropertiesResolver.MouseWheelDelta(PointerPointProperties pointerPointProperties) => pointerPointProperties.MouseWheelDelta;
        float IPointerPointPropertiesResolver.Orientation(PointerPointProperties pointerPointProperties) => pointerPointProperties.Orientation;
        PointerUpdateKind IPointerPointPropertiesResolver.PointerUpdateKind(PointerPointProperties pointerPointProperties) => pointerPointProperties.PointerUpdateKind;
        float IPointerPointPropertiesResolver.Pressure(PointerPointProperties pointerPointProperties) => pointerPointProperties.Pressure;
        bool IPointerPointPropertiesResolver.TouchConfidence(PointerPointProperties pointerPointProperties) => pointerPointProperties.TouchConfidence;
        float IPointerPointPropertiesResolver.Twist(PointerPointProperties pointerPointProperties) => pointerPointProperties.Twist;
        float IPointerPointPropertiesResolver.XTilt(PointerPointProperties pointerPointProperties) => pointerPointProperties.XTilt;
        float IPointerPointPropertiesResolver.YTilt(PointerPointProperties pointerPointProperties) => pointerPointProperties.YTilt;
    }
}

/// <summary>
/// Resolves data of the <see cref="PointerPointProperties"/>.
/// </summary>
public interface IPointerPointPropertiesResolver
{
    /// <summary>
    /// Gets the bounding rectangle of the contact area (typically from touch input).
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns>
    /// The bounding rectangle of the contact area, using client window coordinates in device-independent pixels (DIPs).
    /// </returns>
    Rect ContactRect(PointerPointProperties pointerPointProperties);

    /// <summary>
    /// Gets a value that indicates whether the barrel button of the pen/stylus device is pressed.
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns><c>true</c> if the barrel button is pressed; otherwise, <c>false</c>.</returns>
    bool IsBarrelButtonPressed(PointerPointProperties pointerPointProperties);

    /// <summary>
    /// Gets a value that indicates whether the input was canceled by the pointer device.
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns><c>true</c> if the input was canceled; otherwise, <c>false</c>.</returns>
    bool IsCanceled(PointerPointProperties pointerPointProperties);

    /// <summary>
    /// Gets a value that indicates whether the input is from a pen eraser.
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns><c>true</c> if the input is from a pen eraser; otherwise, <c>false</c>.</returns>
    bool IsEraser(PointerPointProperties pointerPointProperties);

    /// <summary>
    /// Gets a value that indicates whether the input is from a mouse tilt wheel.
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns><c>true</c> if the input is from a mouse tilt wheel; otherwise, <c>false</c>.</returns>
    bool IsHorizontalMouseWheel(PointerPointProperties pointerPointProperties);

    /// <summary>
    /// Gets a value that indicates whether the pointer device is within detection range of a sensor or
    /// digitizer (the pointer continues to exist).
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns><c>true</c> if touch or pen is within detection range or mouse is over; otherwise, <c>false</c>.</returns>
    bool IsInRange(PointerPointProperties pointerPointProperties);

    /// <summary>
    /// Gets a value that indicates whether the digitizer pen is inverted.
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns><c>true</c> if inverted; otherwise, <c>false</c>.</returns>
    bool IsInverted(PointerPointProperties pointerPointProperties);

    /// <summary>
    /// Gets a value that indicates whether the pointer input was triggered by the primary action mode of an input device.
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns><c>true</c> if the primary action mode; otherwise, <c>false</c>.</returns>
    bool IsLeftButtonPressed(PointerPointProperties pointerPointProperties);

    /// <summary>
    /// Gets a value that indicates whether the pointer input was triggered by the tertiary action mode of
    /// an input device (such as the mouse wheel button).
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns><c>true</c> if the pointer input was triggered by the tertiary action mode; otherwise, <c>false</c>.</returns>
    bool IsMiddleButtonPressed(PointerPointProperties pointerPointProperties);

    /// <summary>
    /// Gets a value that indicates whether the input is from the primary pointer when multiple pointers are registered.
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns><c>true</c> if the input is from the primary pointer; otherwise, <c>false</c>.</returns>
    bool IsPrimary(PointerPointProperties pointerPointProperties);

    /// <summary>
    /// Gets a value that indicates whether the pointer input was triggered by the secondary action mode (if supported)
    /// of an input device.
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns><c>true</c> if the secondary action mode; otherwise, <c>false</c>.</returns>
    bool IsRightButtonPressed(PointerPointProperties pointerPointProperties);

    /// <summary>
    /// Gets a value that indicates whether the pointer input was triggered by the first extended mouse button (XButton1).
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns><c>true</c> if the first extended mouse button is pressed; otherwise, <c>false</c>.</returns>
    bool IsXButton1Pressed(PointerPointProperties pointerPointProperties);

    /// <summary>
    /// Gets a value that indicates whether the pointer input was triggered by the second extended mouse button (XButton2).
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns><c>true</c> if the second extended mouse button is pressed; otherwise, <c>false</c>.</returns>
    bool IsXButton2Pressed(PointerPointProperties pointerPointProperties);

    /// <summary>
    /// Gets a value (the raw value reported by the device) that indicates the change in wheel button input
    /// from the last pointer event.
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns>The number of notches or distance thresholds crossed since the last pointer event.</returns>
    int MouseWheelDelta(PointerPointProperties pointerPointProperties);

    /// <summary>
    /// Gets the counter-clockwise angle of rotation around the major axis of the pointer device (the z-axis,
    /// perpendicular to the surface of the digitizer). A value of 0.0 degrees indicates the device is oriented
    /// towards the top of the digitizer.
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns>A value between 0.0 and 359.0 in degrees of rotation.</returns>
    float Orientation(PointerPointProperties pointerPointProperties);

    /// <summary>
    /// Gets the type of pointer state change.
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns>The type of pointer state change.</returns>
    PointerUpdateKind PointerUpdateKind(PointerPointProperties pointerPointProperties);

    /// <summary>
    /// Gets a value that indicates the force that the pointer device (typically a pen/stylus) exerts on the surface of the digitizer.
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns>A value from 0 to 1.0.</returns>
    float Pressure(PointerPointProperties pointerPointProperties);

    /// <summary>
    /// Gets a value that indicates whether the pointer device rejected the touch contact.
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns><c>true</c> if the touch contact was accepted; otherwise, <c>false</c>.</returns>
    bool TouchConfidence(PointerPointProperties pointerPointProperties);

    /// <summary>
    /// Gets the clockwise rotation in degrees of a pen device around its own major axis (such as
    /// when the user spins the pen in their fingers).
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns>A value between 0.0 and 359.0 in degrees of rotation.</returns>
    float Twist(PointerPointProperties pointerPointProperties);

    /// <summary>
    /// Gets the plane angle between the Y-Z plane and the plane that contains the Y axis and
    /// the axis of the input device (typically a pen/stylus).
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns>
    /// The value is 0.0 when the finger or pen is perpendicular to the digitizer surface, between 0.0 and 90.0
    /// when tilted to the right of perpendicular, and between 0.0 and -90.0 when tilted to the left of perpendicular.
    /// </returns>
    float XTilt(PointerPointProperties pointerPointProperties);

    /// <summary>
    /// Gets the plane angle between the X-Z plane and the plane that contains the X axis and
    /// the axis of the input device (typically a pen/stylus).
    /// </summary>
    /// <param name="pointerPointProperties">The requested <see cref="PointerPointProperties"/>.</param>
    /// <returns>
    /// The value is 0.0 when the finger or pen is perpendicular to the digitizer surface, between 0.0 and 90.0
    /// when tilted towards the user, and between 0.0 and -90.0 when tilted away from the user.
    /// </returns>
    float YTilt(PointerPointProperties pointerPointProperties);
}