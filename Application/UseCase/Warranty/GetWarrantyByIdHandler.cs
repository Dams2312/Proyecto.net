using Application.Abstractions;
using MediatR;
using WarrantyEntity = Domain.Entities.Warranty.Warranty;

namespace Application.UseCase.Warranty;

public sealed class GetWarrantyByIdHandler : IRequestHandler<GetWarrantyById, WarrantyEntity>
{
    private readonly IUnitOfWork _uow;

    public GetWarrantyByIdHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<WarrantyEntity> Handle(GetWarrantyById request, CancellationToken ct)
    {
        return await _uow.Warranties.GetByIdAsync(request.Id, ct)
            ?? throw new KeyNotFoundException($"Garantía con id {request.Id} no encontrada.");
    }
}