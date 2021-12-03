using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Entities.Models;
using ServerCommunication;
using T1Contracts.ServerCommunicationInterfaces;

namespace Blazor.Data
{
    public class ItemLocationHandler : IItemLocationHandler
    {
        private IItemLocationDataServerComm _itemLocationDataServerComm;

        public ItemLocationHandler(IItemLocationDataServerComm itemLocationDataServerComm)
        {
            _itemLocationDataServerComm = itemLocationDataServerComm;
        }
        
        
        public async void CallBackBroardcast(object itemLocation)
        {
            
        }

        public async Task<ItemLocation> RegisterAsync(ItemLocation itemLocation)
        {
            return await _itemLocationDataServerComm.RegisterAsync(itemLocation);
        }

        public Task<ItemLocation> RemoveAsync(ItemLocation entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ItemLocation> UpdateAsync(ItemLocation itemLocation)
        {
            return await _itemLocationDataServerComm.UpdateAsync(itemLocation);
        }

        public async Task<IList<ItemLocation>> GetAllAsync()
        {
            return await _itemLocationDataServerComm.GetAllAsync();
        }

        public async Task<ItemLocation> GetAsync(ItemLocation entity)
        {
            throw new NotImplementedException();
        }
    }
}