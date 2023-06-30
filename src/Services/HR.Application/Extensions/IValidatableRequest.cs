using MediatR;

namespace HR.Application.Extensions;

internal interface IValidatableRequest<out TResponse> : IRequest<TResponse>, IValidatableRequest { }

internal interface IValidatableRequest { }
