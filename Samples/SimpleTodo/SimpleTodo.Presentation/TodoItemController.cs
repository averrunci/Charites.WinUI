// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.System;
using Charites.Windows.Mvc;
using Charites.Windows.Mvc.Wrappers;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;

namespace Charites.Windows.Samples.SimpleTodo.Presentation;

[View(Key = nameof(TodoItem))]
public class TodoItemController
{
    private void TodoItemContainer_PointerEntered([FromElement(Name = "Root")] Control root)
    {
        VisualStateManager.GoToState(root, "PointerOver", false);
    }

    private void TodoItemContainer_PointerExited([FromElement(Name = "Root")] Control root)
    {
        VisualStateManager.GoToState(root, "Normal", false);
    }

    private void TodoItemContainer_DoubleTapped([FromDataContext] TodoItem todoItem, [FromElement(Name = "TodoContentTextBox")] TextBox todoContentTextBox)
    {
        todoItem.StartEdit();

        todoContentTextBox.Focus(FocusState.Pointer);
        todoContentTextBox.SelectAll();
    }

    private void TodoContentTextBox_KeyDown(KeyRoutedEventArgs e, [FromDataContext] TodoItem todoItem)
    {
        switch (e.Key())
        {
            case VirtualKey.Enter:
                todoItem.CompleteEdit();
                break;
            case VirtualKey.Escape:
                todoItem.CancelEdit();
                break;
        }
    }

    private void TodoContentTextBox_LostFocus([FromDataContext] TodoItem todoItem)
    {
        if (!todoItem.Editing.Value) return;

        todoItem.CompleteEdit();
    }

    private void DeleteButton_Click([FromDataContext] TodoItem todoItem)
    {
        todoItem.Remove();
    }
}