// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Charites.Windows.Samples.SimpleLoginDemo.Adapter.Commands;
using Charites.Windows.Samples.SimpleLoginDemo.Presentation.Login;
using Microsoft.Extensions.DependencyInjection;
using SimpleLoginDemo.Core.Features.Users;

namespace Charites.Windows.Samples.SimpleLoginDemo.Adapter
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddFeatures(this IServiceCollection services)
            => services.AddTransient<IUserAuthentication, UserAuthentication>();

        public static IServiceCollection AddCommands(this IServiceCollection services)
            => services.AddTransient<ILoginCommand, LoginCommand>();
    }
}
