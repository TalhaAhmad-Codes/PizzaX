using MediatR;
using System.Reflection;

namespace PizzaX.Common.Behaviors
{
    public sealed class TrimStringsBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
    {
        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            TrimObject(request);

            return await next(cancellationToken);
        }

        private static void TrimObject(object obj)
        {
            var properties = obj.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanRead && p.CanWrite);

            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(string))
                {
                    var value = property.GetValue(obj) as string;

                    if (value is not null)
                    {
                        property.SetValue(obj, value.Trim());
                    }
                }
            }
        }
    }
}
