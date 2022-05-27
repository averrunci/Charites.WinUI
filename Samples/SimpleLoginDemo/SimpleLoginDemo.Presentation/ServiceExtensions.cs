// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Charites.Windows.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Charites.Windows.Samples.SimpleLoginDemo.Presentation;

public static class ServiceExtensions
{
    public static IServiceCollection AddControllers(this IServiceCollection services)
        => typeof(WinUIController).Assembly.DefinedTypes
            .Concat(typeof(ServiceExtensions).Assembly.DefinedTypes)
            .Where(t => t.GetCustomAttributes<ViewAttribute>(true).Any())
            .Aggregate(services, (s, t) => s.AddTransient(t.AsType()));
}