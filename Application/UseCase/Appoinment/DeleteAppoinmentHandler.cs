using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;

namespace Application.UseCases.Appoinment;

public sealed class DeleteAppoinmentHandler
    : IRequestHandler<DeleteAppoinment, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteAppoinmentHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeleteAppoinment request,
        CancellationToken ct)
    {
        var appointment = await _uow.Appointments.GetByIdAsync(request.Id, ct);

        if (appointment is null)
            throw new KeyNotFoundException("Cita no encontrada.");

        await _uow.Appointments.RemoveAsync(appointment, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
