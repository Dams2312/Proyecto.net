using System;
using Domain.Entities.InventoryLog;
using MediatR;

namespace Application.UseCases.InventoryLog;

public sealed record GetInventoryLogById(
    Guid Id
) : IRequest<InventoryLog>;
