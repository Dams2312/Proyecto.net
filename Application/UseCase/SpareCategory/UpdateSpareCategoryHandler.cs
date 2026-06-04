using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.ValueObject.SpareCategory;
using MediatR;

namespace Application.UseCase.SpareCategory;

public sealed class UpdateSpareCategoryHandler : IRequestHandler<UpdateSpareCategory, Unit>
{
    private readonly IUnitOfWork _uow;
    public UpdateSpareCategoryHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Unit> Handle(UpdateSpareCategory request, CancellationToken ct)
    {
        var entity = await _uow.SpareCategories.GetByIdAsync(request.Id, ct)
            ?? throw new KeyNotFoundException($"SpareCategory '{request.Id}' no encontrado.");
        entity.UpdateName(SpareCategoryName.Create(request.Name));
        entity.UpdateDescription(SpareCategoryDescription.Create(request.Description));
        await _uow.SpareCategories.UpdateAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);
        return Unit.Value;
    }
}