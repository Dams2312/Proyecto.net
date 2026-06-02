using System;
using MediatR;
using InventoryLogEntity = Domain.Entities.InventoryLog.InventoryLog;

namespace Application.UseCase.InventoryLog;

public sealed record GetInventoryLogById(
    Guid Id
) : IRequest<InventoryLogEntity>;

