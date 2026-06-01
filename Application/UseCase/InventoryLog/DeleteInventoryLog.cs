using System;
using MediatR;

namespace Application.UseCases.InventoryLog;

public sealed record DeleteInventoryLog(
    Guid Id
) : IRequest<Unit>;
