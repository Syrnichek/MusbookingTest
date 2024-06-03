using EquipmentService.Application;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace OrderService.Infrastructure.Communicators;

public class EquipmentCommunicator(EquipmentService.Application.equipmentService.equipmentServiceClient equipmentClient)
{
    public async Task<EquipmentResponse?> AddEquipmentAsync(AddEquipmentRequest request)
    {
        try
        {
            return await equipmentClient.AddEquipmentAsync(request);

        }
        catch (RpcException)
        {
            return null;
        }
    }
    
    public async Task<EquipmentResponseList?> GetEquipmentAllAsync(Empty request)
    {
        try
        {
            return await equipmentClient.GetEquipmentAllAsync(request);

        }
        catch (RpcException)
        {
            return null;
        }
    }
    
    public async Task<EquipmentResponse?> GetEquipmentByNameAsync(GetEquipmentByNameRequest request)
    {
        try
        {
            return await equipmentClient.GetEquipmentByNameAsync(request);

        }
        catch (RpcException)
        {
            return null;
        }
    }
    
    public async Task<UpdateAmountResponse?> UpdateAmountAsync(UpdateAmountRequest request)
    {
        try
        {
            return await equipmentClient.UpdateAmountAsync(request);

        }
        catch (RpcException)
        {
            return null;
        }
    }
}