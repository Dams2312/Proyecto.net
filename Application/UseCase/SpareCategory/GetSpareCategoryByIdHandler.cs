using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using SpareCategoryEntity = Domain.Entities.SpareCategory.SpareCategory;

namespace Application.UseCase.SpareCategory;

public sealed class GetSpareCategoryByIdHandler : IRequestHandler<GetSpareCategoryById, SpareCategoryEntity>
{
    private readonly IUnitOfWork _uow;
    public GetSpareCategoryByIdHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<SpareCategoryEntity> Handle(GetSpareCategoryById request, CancellationToken ct)
        => await _uow.SpareCategories.GetByIdAsync(request.Id, ct)
            ?? throw new KeyNotFoundException($"SpareCategory '{request.Id}' no encontrado.");
}