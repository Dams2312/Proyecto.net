using System;
using MediatR;

namespace Application.UseCase.Supplier;

public sealed record UpdateSupplier(
    Guid Id,
    string Name,
    string Nit,
    string Email,
    string Phone,
    Guid CityId,
    bool Active
) : IRequest<Unit>;
