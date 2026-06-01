using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.Customers;
using MediatR;

namespace Application.UseCases.Customers;

public sealed class GetCustomerByIdHandler
    : IRequestHandler<GetCustomerById, Customer>
{
    private readonly IUnitOfWork _uow;

    public GetCustomerByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Customer> Handle(
        GetCustomerById request,
        CancellationToken ct)
    {
        var entity = await _uow.Customers.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("Customer no encontrado.");

        return entity;
    }
}
