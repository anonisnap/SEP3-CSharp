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
        private IItemLocationDataServerComm _itemLocationDataServerComm;

        public InventoryHandler(IItemLocationDataServerComm itemLocationDataServerComm)
        {
            _itemLocationDataServerComm = itemLocationDataServerComm;
        }


        public async void CallBackBroardcast(object itemLocation)
        {
        }

        public async Task<Inventory> RegisterAsync(Inventory inventory)
        {
            return await _itemLocationDataServerComm.RegisterAsync(inventory);
        }

        public Task<bool> RemoveAsync(int entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Inventory> UpdateAsync(Inventory inventory)
        {
            return await _itemLocationDataServerComm.UpdateAsync(inventory);
        }

        public async Task<IList<Inventory>> GetAllAsync()
        {
            return await _itemLocationDataServerComm.GetAllAsync();
        }

        public async Task<Inventory> GetAsync(int entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Inventory>> GetAllByLocationIdAsync(int locationId)
        {
            return await _itemLocationDataServerComm.GetAllByLocationIdAsync(locationId);
        }

        public async Task<IList<Inventory>> GetAllByItemIdAsync(int itemId)
        {
            return await _itemLocationDataServerComm.GetAllByItemIdAsync(itemId);
        }
    }
}