using System;
using Domain.Entities.PurchaseDetail;
using MediatR;

namespace Application.UseCases.PurchaseDetail;

public sealed record GetPurchaseDetailById(
    Guid Id
) : IRequest<PurchaseDetail>;
