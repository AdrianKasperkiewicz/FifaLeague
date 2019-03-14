using System;

using Hangfire;
using MediatR;

namespace FL.Shared.Mediator
{
    public static class MediatRExtensions
    {
        public static void Enqueue(this IMediator mediator, IRequest request)
        {
            var serializedRequest = request.Serialize();
            BackgroundJob.Enqueue<BackgroundMediator>(m => m.Send(serializedRequest));
        }

        public static void Defer(this IMediator mediator, IRequest request, DateTime deferUntil)
        {
            var serializedRequest = request.Serialize();
            BackgroundJob.Schedule<BackgroundMediator>(m => m.Send(serializedRequest), deferUntil);
        }

        public static void Defer(this IMediator mediator, IRequest request, TimeSpan delay)
        {
            var serializedRequest = request.Serialize();
            BackgroundJob.Schedule<BackgroundMediator>(m => m.Send(serializedRequest), delay);
        }
    }
}