// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Carna;

namespace Charites.Windows.Mvc;

[Specification("WinUIController Spec")]
class WinUIControllerSpec
{
    [Context]
    WinUIControllerSpec_EventHandlerDataContextElementInjection EventHandlerDataContextElementInjection => default!;

    [Context]
    WinUIControllerSpec_AttachingAndDetachingController AttachingAndDetachingController => default!;

    [Context]
    WinUIControllerSpec_ExecuteHandler ExecuteHandler => default!;

    [Context]
    WinUIControllerSpec_WinUIControllerExtension WinUIControllerExtension => default!;

    [Context]
    WinUIControllerSpec_UnhandledException UnhandledException => default!;
}