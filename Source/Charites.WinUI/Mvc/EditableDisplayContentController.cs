// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Charites.Windows.Mvc.Bindings;
using Microsoft.UI.Xaml;

namespace Charites.Windows.Mvc;

[View(Key = "Charites.Windows.Mvc.Bindings.EditableDisplayContent`1")]
[View(Key = "Charites.Windows.Mvc.Bindings.EditableDisplayContent`1[System.String]")]
internal sealed class EditableDisplayContentController
{
    [DataContext]
    private IEditableDisplayContent? Content { get; set; }

    [EventHandler(Event = nameof(UIElement.Tapped))]
    private void OnTapped() => Content?.StartEdit();
}