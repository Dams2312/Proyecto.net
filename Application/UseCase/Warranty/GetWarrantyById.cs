using System;
using MediatR;
using WarrantyEntity = Domain.Entities.Warranty.Warranty;

namespace Application.UseCase.Warranty;

public sealed record GetWarrantyById(Guid Id) : IRequest<WarrantyEntity>;
