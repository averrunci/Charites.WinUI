// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Carna.Assertions;

namespace Charites.Windows.Samples.SimpleTodo.Presentation.AssertionObjects;

internal class TodoItemAssertion : AssertionObject
{
    [AssertionProperty]
    public string Content { get; set; }

    [AssertionProperty]
    public TodoItemState State { get; set; }

    protected TodoItemAssertion(string content, TodoItemState state)
    {
        Content = content;
        State = state;
    }

    public static TodoItemAssertion Of(string content, TodoItemState state) => new(content, state);
    public static TodoItemAssertion Of(TodoItem todoItem) => new(todoItem.Content.Value, todoItem.State.Value);
}