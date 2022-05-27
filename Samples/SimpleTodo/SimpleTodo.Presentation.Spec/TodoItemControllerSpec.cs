// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.System;
using Carna;
using Carna.WinUIRunner;
using Charites.Windows.Mvc;
using Charites.Windows.Mvc.Wrappers;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Markup;
using NSubstitute;

namespace Charites.Windows.Samples.SimpleTodo.Presentation;

[Specification("TodoItemController Spec")]
class TodoItemControllerSpec : FixtureSteppable
{
    TodoItemController Controller { get; } = new();
    TodoItem TodoItem { get; }

    string InitialContent => "Todo Item";
    string ModifiedContent => "Todo Item Modified";

    EventHandler RemovedRequestedHandler { get; } = Substitute.For<EventHandler>();

    public TodoItemControllerSpec()
    {
        TodoItem = new TodoItem(InitialContent);
        TodoItem.RemoveRequested += RemovedRequestedHandler;
        WinUIController.SetDataContext(TodoItem, Controller);
    }

    [Example("Changes the visual state when the pointer is over an element")]
    async Task Ex01()
    {
        await CarnaWinUIRunner.Window.DispatcherQueue.RunAsync(() =>
        {
            Grid element = default!;
            Given("an element with a visual state", () =>
            {
                element = new Grid { Name = "TodoItemContainer" };
                VisualStateManager.GetVisualStateGroups(element).Add(XamlReader.Load(@"
<VisualStateGroup xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
                  xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"">
    <VisualState x:Name=""Normal"" />
    <VisualState x:Name=""PointerOver"" />
</VisualStateGroup>
") as VisualStateGroup);
            });
            WinUIController.SetElement(new UserControl { Name = "Root", Content = element }, Controller);
            When("a pointer enters into the element", () =>
                WinUIController.EventHandlersOf(Controller)
                    .GetBy(element.Name)
                    .From(element)
                    .Raise(nameof(UIElement.PointerEntered))
            );
            Then("the current state of the element should be 'PointerOver'", () =>
                VisualStateManager.GetVisualStateGroups(element)[0].CurrentState.Name == "PointerOver"
            );
            When("a pointer exits the element", () =>
                WinUIController.EventHandlersOf(Controller)
                    .GetBy(element.Name)
                    .From(element)
                    .Raise(nameof(UIElement.PointerExited))
            );
            Then("the current state of the element should be 'Normal'", () =>
                VisualStateManager.GetVisualStateGroups(element)[0].CurrentState.Name == "Normal"
            );
        });
    }

    [Example("Switches a content to an edit mode when the element is double tapped")]
    void Ex02()
    {
        When("the element is double tapped", () =>
            WinUIController.EventHandlersOf(Controller)
                .GetBy("TodoItemContainer")
                .Raise(nameof(UIElement.DoubleTapped))
        );
        Then("the to-do item should be editing", () => TodoItem.Editing.Value);
        Then("the edit content of the to-do item should be the initial content", () => TodoItem.EditContent.Value == InitialContent);
    }

    [Example("Completes an edit when the Enter key is pressed")]
    void Ex03()
    {
        When("the element is double tapped", () =>
            WinUIController.EventHandlersOf(Controller)
                .GetBy("TodoItemContainer")
                .Raise(nameof(UIElement.DoubleTapped))
        );
        When("the content is modified", () => TodoItem.EditContent.Value = ModifiedContent);
        When("the Enter key is pressed", () =>
            WinUIController.Using(Substitute.For<IKeyRoutedEventArgsResolver>(), typeof(KeyRoutedEventArgsWrapper))
                .Apply(resolver => resolver.Key(Arg.Any<KeyRoutedEventArgs>()).Returns(VirtualKey.Enter))
                .EventHandlersOf(Controller)
                .GetBy("TodoContentTextBox")
                .Raise(nameof(UIElement.KeyDown))
        );
        Then("the to-do item should not be editing", () => !TodoItem.Editing.Value);
        Then("the content of the to-do item should be the modified content", () => TodoItem.Content.Value == ModifiedContent);
    }

    [Example("Completes an edit when the focus is lost")]
    void Ex04()
    {
        When("the element is double tapped", () =>
            WinUIController.EventHandlersOf(Controller)
                .GetBy("TodoItemContainer")
                .Raise(nameof(UIElement.DoubleTapped))
        );
        When("the content is modified", () => TodoItem.EditContent.Value = ModifiedContent);
        When("the focus is lost", () =>
            WinUIController.EventHandlersOf(Controller)
                .GetBy("TodoContentTextBox")
                .Raise(nameof(UIElement.LostFocus))
        );
        Then("the to-do item should not be editing", () => !TodoItem.Editing.Value);
        Then("the content of the to-do item should be the modified content", () => TodoItem.Content.Value == ModifiedContent);
    }

    [Example("Cancels an edit when the Esc key is pressed")]
    void Ex05()
    {
        When("the element is double tapped", () =>
            WinUIController.EventHandlersOf(Controller)
                .GetBy("TodoItemContainer")
                .Raise(nameof(UIElement.DoubleTapped))
        );
        When("the content is modified", () => TodoItem.EditContent.Value = ModifiedContent);
        When("the Esc key is pressed", () =>
            WinUIController.Using(Substitute.For<IKeyRoutedEventArgsResolver>(), typeof(KeyRoutedEventArgsWrapper))
                .Apply(resolver => resolver.Key(Arg.Any<KeyRoutedEventArgs>()).Returns(VirtualKey.Escape))
                .EventHandlersOf(Controller)
                .GetBy("TodoContentTextBox")
                .Raise(nameof(UIElement.KeyDown))
        );
        Then("the to-do item should not be editing", () => !TodoItem.Editing.Value);
        Then("the content of the to-do item should be the initial content", () => TodoItem.Content.Value == InitialContent);
    }

    [Example("Removes a to-do item when the delete button is clicked")]
    void Ex06()
    {
        When("the delete button is clicked", () =>
            WinUIController.EventHandlersOf(Controller)
                .GetBy("DeleteButton")
                .Raise(nameof(ButtonBase.Click))
        );
        Then("it should be requested to remove the to-do item", () =>
            RemovedRequestedHandler.Received(1).Invoke(TodoItem, EventArgs.Empty)
        );
    }
}