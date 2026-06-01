using System;
using MediatR;

namespace Application.UseCases.MileageHistory;

public sealed record DeleteMileageHistory(
    Guid Id
) : IRequest<Unit>;
