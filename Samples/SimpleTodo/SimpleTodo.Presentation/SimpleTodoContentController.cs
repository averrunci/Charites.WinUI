﻿// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.System;
using Charites.Windows.Mvc;
using Charites.Windows.Mvc.Bindings;
using Charites.Windows.Mvc.Wrappers;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;

namespace Charites.Windows.Samples.SimpleTodo.Presentation;

[View(Key = nameof(SimpleTodoContent))]
public class SimpleTodoContentController
{
    private void SetDataContext(SimpleTodoContent? content)
    {
        if (this.content is not null) UnsubscribeFromEvents(this.content);
        this.content = content;
        if (this.content is not null) SubscribeToEvents(this.content);
    }
    private SimpleTodoContent? content;

    [Element]
    private void SetAllCompletedCheckBox(CheckBox? allCompletedCheckBox) => this.allCompletedCheckBox = allCompletedCheckBox;
    private CheckBox? allCompletedCheckBox;

    private void SubscribeToEvents(SimpleTodoContent content)
    {
        content.AllCompleted.PropertyValueChanged += OnAllCompletedChanged;
    }

    private void UnsubscribeFromEvents(SimpleTodoContent content)
    {
        content.AllCompleted.PropertyValueChanged -= OnAllCompletedChanged;
    }

    private void OnAllCompletedChanged(object? sender, PropertyValueChangedEventArgs<bool?> e)
    {
        if (e.NewValue.HasValue) return;
        if (allCompletedCheckBox is null) return;

        allCompletedCheckBox.IsChecked = null;
    }

    private void TodoContentTextBox_KeyDown(KeyRoutedEventArgs e)
    {
        if (e.Key() is not VirtualKey.Enter) return;

        content?.AddCurrentTodoContent();
    }
}