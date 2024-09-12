// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Charites.Windows.Mvc.Bindings;

namespace Charites.Windows.Samples.SimpleTodo.Presentation;

public class SimpleTodoContent
{
    public ObservableProperty<bool?> AllCompleted { get; } = new(false);
    public ObservableProperty<bool> CanCompleteAllTodoItems { get; } = false.ToObservableProperty();

    public ObservableProperty<string> TodoContent { get; } = string.Empty.ToObservableProperty();

    public IEnumerable<TodoItem> TodoItems => todoItems;
    private readonly ObservableCollection<TodoItem> todoItems = new();
    private readonly List<TodoItem> underlyingTodoItems = new();

    public ObservableProperty<string> ItemsLeftMessage { get; } = string.Empty.ToObservableProperty();

    public ObservableProperty<TodoItemState> TodoItemDisplayState { get; } = TodoItemState.All.ToObservableProperty();

    public SimpleTodoContent()
    {
        AllCompleted.PropertyValueChanged += OnAllCompletedPropertyValueChanged;
        todoItems.CollectionChanged += OnTodoItemsChanged;
        TodoItemDisplayState.PropertyValueChanged += OnTodoItemDisplayStateChanged;

        UpdateItemsLeftMessage();
    }

    public void AddCurrentTodoContent()
    {
        if (string.IsNullOrWhiteSpace(TodoContent.Value)) return;

        var newTodoItem = new TodoItem(TodoContent.Value);
        newTodoItem.RemoveRequested += OnTodoItemRemoveRequested;
        newTodoItem.State.PropertyValueChanged += OnTodoItemStateChanged;
        underlyingTodoItems.Add(newTodoItem);
        todoItems.Add(newTodoItem);

        TodoContent.Value = string.Empty;
        UpdateAllTodoItemsCompletionState();
        ApplyFilter();
    }

    private void OnAllCompletedPropertyValueChanged(object? sender, PropertyValueChangedEventArgs<bool?> e)
    {
        UpdateAllTodoItemsState();
    }

    private void OnTodoItemsChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        UpdateAllTodoItemsCompletionState();
        UpdateAllTodoItemsCompletionEnabled();
        UpdateItemsLeftMessage();
    }

    private void OnTodoItemDisplayStateChanged(object? sender, PropertyValueChangedEventArgs<TodoItemState> e)
    {
        ApplyFilter();
    }

    private void OnTodoItemRemoveRequested(object? sender, EventArgs e)
    {
        if (sender is not TodoItem removedTodoItem) return;

        removedTodoItem.RemoveRequested -= OnTodoItemRemoveRequested;
        removedTodoItem.State.PropertyValueChanged -= OnTodoItemStateChanged;
        underlyingTodoItems.Remove(removedTodoItem);
        todoItems.Remove(removedTodoItem);
    }

    private void OnTodoItemStateChanged(object? sender, PropertyValueChangedEventArgs<TodoItemState> e)
    {
        UpdateAllTodoItemsCompletionState();
        UpdateItemsLeftMessage();
        ApplyFilter();
    }

    private void UpdateAllTodoItemsState()
    {
        if (!AllCompleted.Value.HasValue) return;

        foreach (var item in underlyingTodoItems)
        {
            item.State.PropertyValueChanged -= OnTodoItemStateChanged;
            try
            {
                item.State.Value = AllCompleted.Value.GetValueOrDefault() ? TodoItemState.Completed : TodoItemState.Active;
            }
            finally
            {
                item.State.PropertyValueChanged += OnTodoItemStateChanged;
            }
        }

        UpdateItemsLeftMessage();
        ApplyFilter();
    }

    private void UpdateAllTodoItemsCompletionState()
    {
        AllCompleted.PropertyValueChanged -= OnAllCompletedPropertyValueChanged;
        try
        {
            if (underlyingTodoItems.All(i => i.State.Value == TodoItemState.Active))
            {
                AllCompleted.Value = false;
            }
            else if (underlyingTodoItems.All(i => i.State.Value == TodoItemState.Completed))
            {
                AllCompleted.Value = true;
            }
            else
            {
                AllCompleted.Value = null;
            }
        }
        finally
        {
            AllCompleted.PropertyValueChanged += OnAllCompletedPropertyValueChanged;
        }
    }

    private void UpdateAllTodoItemsCompletionEnabled()
    {
        CanCompleteAllTodoItems.Value = TodoItems.Any();
    }

    private void UpdateItemsLeftMessage()
    {
        var activeCount = underlyingTodoItems.Count(i => i.State.Value == TodoItemState.Active);
        ItemsLeftMessage.Value = $"{activeCount} item{(activeCount == 1 ? string.Empty : "s")} left";
    }

    private void ApplyFilter()
    {
        todoItems.Clear();
        foreach (var item in TodoItemDisplayState.Value == TodoItemState.All ? underlyingTodoItems : underlyingTodoItems.Where(i => i.State.Value == TodoItemDisplayState.Value))
        {
            todoItems.Add(item);
        }
    }
}