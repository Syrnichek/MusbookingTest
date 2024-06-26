using MediatR;

namespace OrderService.Application.Commands;

public class DeleteOrderCommand : IRequest<bool>
{
    public int Id { get; set; }
}