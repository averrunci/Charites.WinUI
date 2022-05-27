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
    private void SetDataContext(TodoItem? todoItem) => this.todoItem = todoItem;
    private TodoItem? todoItem;

    [Element]
    private void SetRoot(UserControl? root) => this.root = root;
    private UserControl? root;

    [Element]
    private void SetTodoContentTextBox(TextBox? todoContentTextBox) => this.todoContentTextBox = todoContentTextBox;
    private TextBox? todoContentTextBox;

    private void TodoItemContainer_PointerEntered()
    {
        VisualStateManager.GoToState(root, "PointerOver", false);
    }

    private void TodoItemContainer_PointerExited()
    {
        VisualStateManager.GoToState(root, "Normal", false);
    }

    private void TodoItemContainer_DoubleTapped()
    {
        todoItem?.StartEdit();

        todoContentTextBox?.Focus(FocusState.Pointer);
        todoContentTextBox?.SelectAll();
    }

    private void TodoContentTextBox_KeyDown(KeyRoutedEventArgs e)
    {
        switch (e.Key())
        {
            case VirtualKey.Enter:
                todoItem?.CompleteEdit();
                break;
            case VirtualKey.Escape:
                todoItem?.CancelEdit();
                break;
        }
    }

    private void TodoContentTextBox_LostFocus()
    {
        if (todoItem is null) return;
        if (!todoItem.Editing.Value) return;

        todoItem.CompleteEdit();
    }

    private void DeleteButton_Click()
    {
        todoItem?.Remove();
    }
}