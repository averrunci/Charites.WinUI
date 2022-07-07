// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Charites.Windows.Mvc;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Samples.SimpleTodo.Presentation;

[View(Key = nameof(SimpleTodoHost))]
public class SimpleTodoHostController
{
    [EventHandler(Event = nameof(FrameworkElement.Loaded))]
    private void SimpleTodoHost_Loaded([FromElement(Name = "HeaderGrid")] Grid headerGrid, [FromDI] ISimpleTodoWindowProvider windowProvider)
    {
        windowProvider.Window.SetTitleBar(headerGrid);
    }
}