using System.Threading.Tasks;
using SEP3_DB_Server.APIs;
using SEP3_DB_Server.DataAccess;
using SEP3_DB_Server.Models;

namespace SEP3_DB_Server
{
	public class ServerBrains : IServer
	{
		private RestAPI _rest;
		private SEP_DBContext _dbContext;

		public ServerBrains()
		{
			_rest = new(this);
			_dbContext = new();
		}


		public async Task AddSpikeAsync(Spike spike)
		{
			await _dbContext.AddAsync(spike);
		}

		public async Task<Spike> GetSpikeAsync()
		{
			return await _dbContext.FindAsync<Spike>();
		}
	}
}