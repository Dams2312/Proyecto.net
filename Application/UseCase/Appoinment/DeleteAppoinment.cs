using System;
using MediatR;

namespace Application.UseCases.Appoinment;

public sealed record DeleteAppoinment(
    Guid Id
) : IRequest<Unit>;
