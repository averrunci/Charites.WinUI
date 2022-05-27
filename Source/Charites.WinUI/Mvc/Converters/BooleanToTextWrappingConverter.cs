// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;

namespace Charites.Windows.Mvc.Converters;

internal sealed class BooleanToTextWrappingConverter : IValueConverter
{
    public object Convert(object? value, Type? targetType, object? parameter, string? language)
        => value is not null && (bool)value ? TextWrapping.Wrap : TextWrapping.NoWrap;

    public object ConvertBack(object? value, Type? targetType, object? parameter, string? language)
        => value is not null && (TextWrapping)value == TextWrapping.Wrap;
}
