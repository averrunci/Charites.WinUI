// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Data;

namespace Charites.Windows.Samples.SimpleTodo.Presentation.Converters;

public class TodoItemDisplayStateToBooleanConverter : IValueConverter
{
    public object Convert(object? value, Type? targetType, object? parameter, string? language)
    {
        if (!Enum.TryParse(parameter?.ToString(), out TodoItemState state)) throw new ArgumentException(nameof(parameter));

        return value is TodoItemState todoItemState && todoItemState == state;
    }

    public object ConvertBack(object? value, Type? targetType, object? parameter, string? language)
    {
        if (!Enum.TryParse(parameter?.ToString(), out TodoItemState state)) throw new ArgumentException(nameof(parameter));

        return value is true ? state : TodoItemState.All;
    }
}