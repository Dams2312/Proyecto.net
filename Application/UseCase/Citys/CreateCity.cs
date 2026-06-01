using System;
using MediatR;

namespace Application.UseCases.Citys;

public sealed record CreateCity(
    string Name,
    Guid DepartmentId,
    string Code
) : IRequest<Guid>;
