// Copyright (C) 2022-2025 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Charites.Windows.Mvc;
using Charites.Windows.Samples.SimpleTodo.Presentation;
using Microsoft.Extensions.DependencyInjection;

namespace Charites.Windows.Samples.SimpleTodo;

internal sealed class SimpleTodoControllerFactory(ISimpleTodoWindowProvider windowProvider) : IWinUIControllerFactory
{
    private readonly IServiceProvider services = new ServiceCollection()
        .AddSingleton(windowProvider)
        .AddControllers()
        .BuildServiceProvider();

    public object Create(Type controllerType) => services.GetRequiredService(controllerType);
}