using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;

namespace Application.UseCase.SpareCategory;

public sealed class DeleteSpareCategoryHandler : IRequestHandler<DeleteSpareCategory, Unit>
{
    private readonly IUnitOfWork _uow;
    public DeleteSpareCategoryHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Unit> Handle(DeleteSpareCategory request, CancellationToken ct)
    {
        var entity = await _uow.SpareCategories.GetByIdAsync(request.Id, ct)
            ?? throw new KeyNotFoundException($"SpareCategory '{request.Id}' no encontrado.");
        await _uow.SpareCategories.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);
        return Unit.Value;
    }
}