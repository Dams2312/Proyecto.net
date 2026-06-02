using System;
using MediatR;
using InventoryLogEntity = Domain.Entities.InventoryLog.InventoryLog;

namespace Application.UseCase.InventoryLog;

public sealed record DeleteInventoryLog(
    Guid Id
) : IRequest<Unit>;

