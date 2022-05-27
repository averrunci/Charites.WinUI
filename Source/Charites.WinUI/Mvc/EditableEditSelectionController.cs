// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.System;
using Charites.Windows.Mvc.Bindings;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Input;

namespace Charites.Windows.Mvc;

[View(Key = "Charites.Windows.Mvc.Bindings.EditableEditSelection`1")]
internal sealed class EditableEditSelectionController
{
    [DataContext]
    private IEditableEditSelection? EditSelection { get; set; }

    [EventHandler(Event = nameof(FrameworkElement.Loaded))]
    private void OnLoaded(object? sender, RoutedEventArgs e)
    {
        if (sender is not Control control) return;

        control.Focus(FocusState.Pointer);
    }

    [EventHandler(Event = nameof(FrameworkElement.Unloaded))]
    private void OnUnloaded(object? sender, RoutedEventArgs e)
    {
        if (sender is not Selector selector) return;

        selector.ItemsSource = null;
    }

    [EventHandler(Event = nameof(UIElement.LostFocus))]
    private void OnLostFocus()
    {
        if (EditSelection?.IsSelecting.Value ?? true) return;

        EditSelection.CompleteEdit();
    }

    [EventHandler(Event = nameof(UIElement.KeyDown))]
    private void OnKeyDown(KeyRoutedEventArgs e)
    {
        if (e.Key != VirtualKey.Escape) return;

        EditSelection?.CancelEdit();
    }
}