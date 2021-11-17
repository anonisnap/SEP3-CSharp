using System.Threading.Tasks;
using SEP3_WebServerClient.Models;

namespace WebDBserverAPI
{
	public interface IServer
	{
		Task AddSpikeAsync(Spike spike);
		Task<Spike> GetSpikeAsync();
	}
}