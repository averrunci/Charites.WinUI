// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Data;

namespace Charites.Windows.Samples.SimpleTodo.Presentation.Converters;

public class TodoItemStateToBooleanConverter : IValueConverter
{
    public object Convert(object? value, Type? targetType, object? parameter, string? language)
        => value is TodoItemState.Completed;

    public object ConvertBack(object? value, Type? targetType, object? parameter, string? language)
        => value is true ? TodoItemState.Completed : TodoItemState.Active;
}