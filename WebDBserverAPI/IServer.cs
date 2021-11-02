using System.Threading.Tasks;
using WebDBserverAPI.Models;

namespace WebDBserverAPI
{
	public interface IServer
	{
		Task AddSpikeAsync(Spike spike);
		Task<Spike> GetSpikeAsync();
	}
}