// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.System;
using Charites.Windows.Mvc.Bindings;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;

namespace Charites.Windows.Mvc;

[View(Key = "Charites.Windows.Mvc.Bindings.EditableEditText")]
internal sealed class EditableEditTextController
{
    [DataContext]
    private IEditableEditText? EditText { get; set; }

    [Element]
    private TextBox? EditTextBox { get; set; }

    [EventHandler(Event = nameof(FrameworkElement.Loaded))]
    private void OnLoaded()
    {
        EditTextBox?.SelectAll();
        EditTextBox?.Focus(FocusState.Pointer);
    }

    [EventHandler(Event = nameof(FrameworkElement.LostFocus))]
    private void OnLostFocus()
    {
        if (EditText is null) return;

        if (EditText.Validate())
        {
            EditText.CompleteEdit();
        }
        else
        {
            EditTextBox?.Focus(FocusState.Keyboard);
        }
    }

    [EventHandler(Event = nameof(UIElement.KeyDown))]
    private void OnKeyDown(KeyRoutedEventArgs e)
    {
        if (EditText is null) return;

        if (e.Key == VirtualKey.Escape)
        {
            EditText.CancelEdit();
        }
        else if (e.Key == VirtualKey.Enter && !EditText.IsMultiLine.Value && EditText.Validate())
        {
            EditText.CompleteEdit();
        }
    }
}