using System;
using System.Threading.Tasks;
using SEP3_DB_Server.APIs.Controllers;
using SEP3_DB_Server.Models;

namespace SEP3_DB_Server
{
	public interface IServer
	{
		Task AddSpikeAsync(Spike spike);
		Task<Spike> GetSpikeAsync();
	}
}