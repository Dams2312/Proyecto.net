using System;
using MediatR;
using SpareCategoryEntity = Domain.Entities.SpareCategory.SpareCategory;

namespace Application.UseCase.SpareCategory;

public sealed record GetSpareCategoryById(Guid Id) : IRequest<SpareCategoryEntity>;
