using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using T1Contracts.ServerCommunicationInterfaces;

namespace Blazor.Data.Implementation {
	public class ItemHandler : IItemHandler {
		//TODO: Jeg mangler i astah ;(
		
		private IItemDataServerComm _itemDataServerComm;

		public ItemHandler(IItemDataServerComm itemDataServerComm) {
			_itemDataServerComm = itemDataServerComm;
		}

		
		public void CallBackBroardcast(object item)
		{
			throw new NotImplementedException();
		}

		public async Task<Item> RegisterAsync(Item item)
		{
			return await _itemDataServerComm.RegisterAsync(item);
		}

		public Task<bool> RemoveAsync(int item)
		{
			throw new NotImplementedException();
		}

		public Task<Item> UpdateAsync(Item item)
		{
			throw new NotImplementedException();
		}

		public async Task<IList<Item>> GetAllAsync()
		{
			return await _itemDataServerComm.GetAllAsync();
		}

		public async Task<Item> GetAsync(int item)
		{
			return await _itemDataServerComm.GetAsync(item);
		}
	}
}