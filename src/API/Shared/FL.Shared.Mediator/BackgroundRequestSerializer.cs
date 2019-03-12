using System;

using MediatR;
using Newtonsoft.Json;

namespace FL.Shared.Mediator
{
    internal static class BackgroundRequestSerializer
    {
        public static SerializedRequest Serialize(this IRequest request)
        {
            return new SerializedRequest
            {
                Type = request.GetType().AssemblyQualifiedName,
                Value = JsonConvert.SerializeObject(request)
            };
        }

        public static IRequest Deserialize(this SerializedRequest serializedRequest)
        {
          return JsonConvert
              .DeserializeObject(
                  serializedRequest.Value, Type.GetType(serializedRequest.Type)) as IRequest;
        }
    }
}
