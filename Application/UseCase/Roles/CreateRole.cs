using System;
using MediatR;

namespace Application.UseCase.Roles;

public sealed record CreateRole(
    string Name,
    string Description
) : IRequest<Guid>;
