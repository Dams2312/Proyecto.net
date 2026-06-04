using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.ValueObject.SpareCategory;
using MediatR;
using SpareCategoryEntity = Domain.Entities.SpareCategory.SpareCategory;

namespace Application.UseCase.SpareCategory;

public sealed class CreateSpareCategoryHandler : IRequestHandler<CreateSpareCategory, Guid>
{
    private readonly IUnitOfWork _uow;
    public CreateSpareCategoryHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Guid> Handle(CreateSpareCategory request, CancellationToken ct)
    {
        var name   = SpareCategoryName.Create(request.Name);
        var desc   = SpareCategoryDescription.Create(request.Description);
        var entity = new SpareCategoryEntity(name, desc);
        await _uow.SpareCategories.AddAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);
        return entity.Id;
    }
}