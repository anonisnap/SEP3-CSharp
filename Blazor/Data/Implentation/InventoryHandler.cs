using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Entities.Models;
using ServerCommunication;
using T1Contracts.ServerCommunicationInterfaces;

namespace Blazor.Data
{
    public class InventoryHandler : IInventoryHandler
    {
        private IInventoryDataServerComm _inventoryDataServerComm;

        public InventoryHandler(IInventoryDataServerComm inventoryDataServerComm)
        {
            _inventoryDataServerComm = inventoryDataServerComm;
        }


        public async void CallBackBroardcast(object itemLocation)
        {
        }

        public async Task<Inventory> RegisterAsync(Inventory inventory)
        {
            return await _inventoryDataServerComm.RegisterAsync(inventory);
        }

        public Task<bool> RemoveAsync(int entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Inventory> UpdateAsync(Inventory inventory)
        {
            return await _inventoryDataServerComm.UpdateAsync(inventory);
        }

        public async Task<IList<Inventory>> GetAllAsync()
        {
            return await _inventoryDataServerComm.GetAllAsync();
        }

        public async Task<Inventory> GetAsync(int entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Inventory>> GetAllByLocationIdAsync(int locationId)
        {
            return await _inventoryDataServerComm.GetAllByLocationIdAsync(locationId);
        }

        public async Task<IList<Inventory>> GetAllByItemIdAsync(int itemId)
        {
            return await _inventoryDataServerComm.GetAllByItemIdAsync(itemId);
        }

        public async Task<IList<Inventory>> GetInventoryStockAsync()
        {
            return await _inventoryDataServerComm.GetInventoryStockAsync();
        }
    }
}