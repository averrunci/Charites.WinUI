// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
namespace Charites.Windows.Mvc;

internal sealed class EventArgsResolverScope : IDisposable
{
    private static readonly SemaphoreSlim Semaphore = new(1, 1);
    private readonly IEnumerable<IEventArgsResolver> eventArgsResolvers;

    public EventArgsResolverScope(IEnumerable<IEventArgsResolver> eventArgsResolvers)
    {
        this.eventArgsResolvers = eventArgsResolvers;

        Semaphore.Wait();

        this.eventArgsResolvers.ForEach(context => context.Configure());
    }

    public void ApplyResolver()
    {
        eventArgsResolvers.ForEach(context => context.Apply());
    }

    public void Dispose()
    {
        eventArgsResolvers.ForEach(context => context.Dispose());

        Semaphore.Release();
    }
}