using System;
using Domain.Entities.Payment;
using MediatR;

namespace Application.UseCases.Payment;

public sealed record GetPaymentById(
    Guid Id
) : IRequest<Payment>;
