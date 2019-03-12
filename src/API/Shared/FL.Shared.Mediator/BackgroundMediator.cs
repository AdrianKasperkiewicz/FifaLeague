using MediatR;

namespace FL.Shared.Mediator
{
    internal class BackgroundMediator
    {
        private readonly IMediator mediator;

        public BackgroundMediator(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public void Send(SerializedRequest serializedRequest)
        {
            var request = serializedRequest.Deserialize();

            this.mediator.Send(request);
        }
    }
}