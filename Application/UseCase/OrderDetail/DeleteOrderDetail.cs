using System;
using MediatR;

namespace Application.UseCases.OrderDetail;

public sealed record DeleteOrderDetail(
    Guid Id
) : IRequest<Unit>;
