using MediatR;
using Newtonsoft.Json;

namespace FL.Shared.Mediator
{
    internal static class BackgroundRequestSerializer
    {
        public static string Serialize(this IRequest request)
        {
            return JsonConvert.SerializeObject(request,  new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

        }

        public static IRequest Deserialize(this string serializedRequest)
        {
            return JsonConvert
                .DeserializeObject<IRequest>(serializedRequest, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
        }
    }
}