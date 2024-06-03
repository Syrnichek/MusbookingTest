namespace OrderService.Application.Exceptions;

public class OrderServiceExceptions
{
}

class EquipmentAmountNotEnoughException : Exception
{
    public EquipmentAmountNotEnoughException(string message)
        : base(message) { }
}