using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using AuditEntity = Domain.Entities.Audit.Audit;
using MediatR;

namespace Application.UseCases.Audit;

public sealed class GetAuditsPagedHandler
    : IRequestHandler<GetAuditsPaged, IReadOnlyList<AuditEntity>>
{
    private readonly IUnitOfWork _uow;

    public GetAuditsPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<AuditEntity>> Handle(
        GetAuditsPaged request,
        CancellationToken ct)
    {
        return await _uow.Audits.GetPagedAsync(
            request.Page,
            request.PageSize,
            request.Search,
            ct);
    }
}
