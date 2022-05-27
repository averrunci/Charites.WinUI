// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Charites.Windows.Mvc;
using Charites.Windows.Samples.SimpleLoginDemo.Adapter;
using Charites.Windows.Samples.SimpleLoginDemo.Presentation;
using Microsoft.Extensions.DependencyInjection;

namespace Charites.Windows.Samples.SimpleLoginDemo;

internal sealed class SimpleLoginDemoControllerFactory : IWinUIControllerFactory
{
    private readonly IServiceProvider services;

    public SimpleLoginDemoControllerFactory(ISimpleLoginDemoWindowProvider windowProvider)
    {
        services = new ServiceCollection()
            .AddSingleton(windowProvider)
            .AddSingleton<IContentNavigator, ContentNavigator>(_ =>
            {
                IContentNavigator navigator = new ContentNavigator();
                navigator.IsNavigationStackEnabled = false;
                return (ContentNavigator)navigator;
            })
            .AddFeatures()
            .AddCommands()
            .AddControllers()
            .BuildServiceProvider();
    }

    public object Create(Type controllerType) => services.GetRequiredService(controllerType);
}