// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Carna;

namespace Charites.Windows.Mvc;

[Specification(
    "WinUIController Spec",
    typeof(WinUIControllerSpec_EventHandlerDataContextElementInjection),
    typeof(WinUIControllerSpec_AttachingAndDetachingController),
    typeof(WinUIControllerSpec_ExecuteHandler),
    typeof(WinUIControllerSpec_WinUIControllerExtension),
    typeof(WinUIControllerSpec_UnhandledException)
)]
class WinUIControllerSpec
{
}