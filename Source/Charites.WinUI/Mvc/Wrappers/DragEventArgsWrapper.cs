﻿// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.DataTransfer.DragDrop;
using Windows.Foundation;
using Microsoft.UI.Xaml;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="DragEventArgs"/>
/// resolved by <see cref="IDragEventArgsResolver"/>.
/// </summary>
public static class DragEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IDragEventArgsResolver"/>
    /// that resolves data of the <see cref="DragEventArgs"/>.
    /// </summary>
    public static IDragEventArgsResolver Resolver { get; set; } = new DefaultDragEventArgsResolver();

    /// <summary>
    /// Gets a value that specifies which operations are allowed by the originator of the drag event.
    /// </summary>
    /// <param name="e">The requested <see cref="DragEventArgs"/>.</param>
    /// <returns>
    /// A member of the DataPackageOperation enumeration that specifies which operations are allowed by the originator of the drag event.
    /// </returns>
    public static DataPackageOperation AcceptedOperation(this DragEventArgs e) => Resolver.AcceptedOperation(e);

    /// <summary>
    /// Sets a value that specifies which operations are allowed by the originator of the drag event.
    /// </summary>
    /// <param name="e">The requested <see cref="DragEventArgs"/>.</param>
    /// <param name="acceptedOperation">
    /// A member of the DataPackageOperation enumeration that specifies which operations are allowed by the originator of the drag event.
    /// </param>
    public static void AcceptedOperation(this DragEventArgs e, DataPackageOperation acceptedOperation) => Resolver.AcceptedOperation(e, acceptedOperation);

    /// <summary>
    /// Gets the allowed data package operations (none, move, copy, and/or link) for the drag and drop operation.
    /// </summary>
    /// <param name="e">The requested <see cref="DragEventArgs"/>.</param>
    /// <returns>The allowed data operations.</returns>
    public static DataPackageOperation AllowedOperations(this DragEventArgs e) => Resolver.AllowedOperations(e);

    /// <summary>
    /// Gets a data object (<see cref="DataPackage"/>) that contains the data associated with the corresponding drag event.
    /// This value is not useful in all event cases; specifically, the event must be handled by a valid drop target.
    /// </summary>
    /// <param name="e">The requested <see cref="DragEventArgs"/>.</param>
    /// <returns>The data object that contains data payload that is associated with the corresponding drag event.</returns>
    public static DataPackage Data(this DragEventArgs e) => Resolver.Data(e);

    /// <summary>
    /// Sets a data object (<see cref="DataPackage"/>) that contains the data associated with the corresponding drag event.
    /// This value is not useful in all event cases; specifically, the event must be handled by a valid drop target.
    /// </summary>
    /// <param name="e">The requested <see cref="DragEventArgs"/>.</param>
    /// <param name="data">The data object that contains data payload that is associated with the corresponding drag event.</param>
    public static void Data(this DragEventArgs e, DataPackage data) => Resolver.Data(e, data);

    /// <summary>
    /// Gets a read-only copy of the Data object.
    /// </summary>
    /// <param name="e">The requested <see cref="DragEventArgs"/>.</param>
    /// <returns>A read-only copy of the Data object.</returns>
    public static DataPackageView DataView(this DragEventArgs e) => Resolver.DataView(e);

    /// <summary>
    /// Gets the visual representation of the data being dragged.
    /// </summary>
    /// <param name="e">The requested <see cref="DragEventArgs"/>.</param>
    /// <returns>The visual representation of the data being dragged.</returns>
    public static DragUIOverride? DragUIOverride(this DragEventArgs e) => Resolver.DragUIOverride(e);

    /// <summary>
    /// Gets a value that indicates the present state of the event handling for a routed event as it travels the route.
    /// </summary>
    /// <param name="e">The requested <see cref="DragEventArgs"/>.</param>
    /// <returns><c>true</c> if the event is marked handled; otherwise, <c>false</c>.</returns>
    public static bool Handled(this DragEventArgs e) => Resolver.Handled(e);

    /// <summary>
    /// Sets a value that indicates the present state of the event handling for a routed event as it travels the route.
    /// </summary>
    /// <param name="e">The requested <see cref="DragEventArgs"/>.</param>
    /// <param name="handled"><c>true</c> if the event is marked handled; otherwise, <c>false</c>.</param>
    public static void Handled(this DragEventArgs e, bool handled) => Resolver.Handled(e, handled);

    /// <summary>
    /// Gets a flag enumeration indicating the current state of the SHIFT, CTRL, and ALT keys, as well as the state of the mouse buttons.
    /// </summary>
    /// <param name="e">The requested <see cref="DragEventArgs"/>.</param>
    /// <returns>One or more members of the DragDropModifiers flag enumeration.</returns>
    public static DragDropModifiers Modifiers(this DragEventArgs e) => Resolver.Modifiers(e);

    /// <summary>
    /// Gets a reference to the object that raised the event.
    /// This is often a template part of a control rather than an element that was declared in your app UI.
    /// </summary>
    /// <param name="e">The requested <see cref="RoutedEventArgs"/>.</param>
    /// <returns>The object that raised the event.</returns>
    public static object? OriginalSource(this RoutedEventArgs e) => Resolver.OriginalSource(e);

    /// <summary>
    /// Supports asynchronous drag-and-drop operations by creating and returning a DragOperationDeferral object.
    /// </summary>
    /// <param name="e">The requested <see cref="DragEventArgs"/>.</param>
    /// <returns>A deferral object that you can use to identify when the generation of the data package is complete.</returns>
    public static DragOperationDeferral GetDeferralWrapped(this DragEventArgs e) => Resolver.GetDeferral(e);

    /// <summary>
    /// Returns a drop point that is relative to a specified UIElement.
    /// </summary>
    /// <param name="e">The requested <see cref="DragEventArgs"/>.</param>
    /// <param name="relativeTo">The UIElement for which to get a relative drop point.</param>
    /// <returns>A point in the coordinate system that is relative to the element specified in *relativeTo*.</returns>
    public static Point GetPositionWrapped(this DragEventArgs e, UIElement relativeTo) => Resolver.GetPosition(e, relativeTo);

    private sealed class DefaultDragEventArgsResolver : IDragEventArgsResolver
    {
        DataPackageOperation IDragEventArgsResolver.AcceptedOperation(DragEventArgs e) => e.AcceptedOperation;
        void IDragEventArgsResolver.AcceptedOperation(DragEventArgs e, DataPackageOperation acceptedOperation) => e.AcceptedOperation = acceptedOperation;
        DataPackageOperation IDragEventArgsResolver.AllowedOperations(DragEventArgs e) => e.AllowedOperations;
        DataPackage IDragEventArgsResolver.Data(DragEventArgs e) => e.Data;
        void IDragEventArgsResolver.Data(DragEventArgs e, DataPackage data) => e.Data = data;
        DataPackageView IDragEventArgsResolver.DataView(DragEventArgs e) => e.DataView;
        DragUIOverride? IDragEventArgsResolver.DragUIOverride(DragEventArgs e) => e.DragUIOverride;
        bool IDragEventArgsResolver.Handled(DragEventArgs e) => e.Handled;
        void IDragEventArgsResolver.Handled(DragEventArgs e, bool handled) => e.Handled = handled;
        DragDropModifiers IDragEventArgsResolver.Modifiers(DragEventArgs e) => e.Modifiers;
        object? IDragEventArgsResolver.OriginalSource(RoutedEventArgs e) => e.OriginalSource;
        DragOperationDeferral IDragEventArgsResolver.GetDeferral(DragEventArgs e) => e.GetDeferral();
        Point IDragEventArgsResolver.GetPosition(DragEventArgs e, UIElement relativeTo) => e.GetPosition(relativeTo);
    }
}

/// <summary>
/// Resolves data of the <see cref="DragEventArgs"/>.
/// </summary>
public interface IDragEventArgsResolver
{
    /// <summary>
    /// Gets a value that specifies which operations are allowed by the originator of the drag event.
    /// </summary>
    /// <param name="e">The requested <see cref="DragEventArgs"/>.</param>
    /// <returns>
    /// A member of the DataPackageOperation enumeration that specifies which operations are allowed by the originator of the drag event.
    /// </returns>
    DataPackageOperation AcceptedOperation(DragEventArgs e);

    /// <summary>
    /// Sets a value that specifies which operations are allowed by the originator of the drag event.
    /// </summary>
    /// <param name="e">The requested <see cref="DragEventArgs"/>.</param>
    /// <param name="acceptedOperation">
    /// A member of the DataPackageOperation enumeration that specifies which operations are allowed by the originator of the drag event.
    /// </param>
    void AcceptedOperation(DragEventArgs e, DataPackageOperation acceptedOperation);

    /// <summary>
    /// Gets the allowed data package operations (none, move, copy, and/or link) for the drag and drop operation.
    /// </summary>
    /// <param name="e">The requested <see cref="DragEventArgs"/>.</param>
    /// <returns>The allowed data operations.</returns>
    DataPackageOperation AllowedOperations(DragEventArgs e);

    /// <summary>
    /// Gets a data object (<see cref="DataPackage"/>) that contains the data associated with the corresponding drag event.
    /// This value is not useful in all event cases; specifically, the event must be handled by a valid drop target.
    /// </summary>
    /// <param name="e">The requested <see cref="DragEventArgs"/>.</param>
    /// <returns>The data object that contains data payload that is associated with the corresponding drag event.</returns>
    DataPackage Data(DragEventArgs e);

    /// <summary>
    /// Sets a data object (<see cref="DataPackage"/>) that contains the data associated with the corresponding drag event.
    /// This value is not useful in all event cases; specifically, the event must be handled by a valid drop target.
    /// </summary>
    /// <param name="e">The requested <see cref="DragEventArgs"/>.</param>
    /// <param name="data">The data object that contains data payload that is associated with the corresponding drag event.</param>
    void Data(DragEventArgs e, DataPackage data);

    /// <summary>
    /// Gets a read-only copy of the Data object.
    /// </summary>
    /// <param name="e">The requested <see cref="DragEventArgs"/>.</param>
    /// <returns>A read-only copy of the Data object.</returns>
    DataPackageView DataView(DragEventArgs e);

    /// <summary>
    /// Gets the visual representation of the data being dragged.
    /// </summary>
    /// <param name="e">The requested <see cref="DragEventArgs"/>.</param>
    /// <returns>The visual representation of the data being dragged.</returns>
    DragUIOverride? DragUIOverride(DragEventArgs e);

    /// <summary>
    /// Gets a value that indicates the present state of the event handling for a routed event as it travels the route.
    /// </summary>
    /// <param name="e">The requested <see cref="DragEventArgs"/>.</param>
    /// <returns><c>true</c> if the event is marked handled; otherwise, <c>false</c>.</returns>
    bool Handled(DragEventArgs e);

    /// <summary>
    /// Sets a value that indicates the present state of the event handling for a routed event as it travels the route.
    /// </summary>
    /// <param name="e">The requested <see cref="DragEventArgs"/>.</param>
    /// <param name="handled"><c>true</c> if the event is marked handled; otherwise, <c>false</c>.</param>
    void Handled(DragEventArgs e, bool handled);

    /// <summary>
    /// Gets a flag enumeration indicating the current state of the SHIFT, CTRL, and ALT keys, as well as the state of the mouse buttons.
    /// </summary>
    /// <param name="e">The requested <see cref="DragEventArgs"/>.</param>
    /// <returns>One or more members of the DragDropModifiers flag enumeration.</returns>
    DragDropModifiers Modifiers(DragEventArgs e);

    /// <summary>
    /// Gets a reference to the object that raised the event.
    /// This is often a template part of a control rather than an element that was declared in your app UI.
    /// </summary>
    /// <param name="e">The requested <see cref="RoutedEventArgs"/>.</param>
    /// <returns>The object that raised the event.</returns>
    object? OriginalSource(RoutedEventArgs e);

    /// <summary>
    /// Supports asynchronous drag-and-drop operations by creating and returning a DragOperationDeferral object.
    /// </summary>
    /// <param name="e">The requested <see cref="DragEventArgs"/>.</param>
    /// <returns>A deferral object that you can use to identify when the generation of the data package is complete.</returns>
    DragOperationDeferral GetDeferral(DragEventArgs e);

    /// <summary>
    /// Returns a drop point that is relative to a specified UIElement.
    /// </summary>
    /// <param name="e">The requested <see cref="DragEventArgs"/>.</param>
    /// <param name="relativeTo">The UIElement for which to get a relative drop point.</param>
    /// <returns>A point in the coordinate system that is relative to the element specified in *relativeTo*.</returns>
    Point GetPosition(DragEventArgs e, UIElement relativeTo);
}