using System;
using MediatR;

namespace Application.UseCases.PurchaseDetail;

public sealed record DeletePurchaseDetail(
    Guid Id
) : IRequest<Unit>;
