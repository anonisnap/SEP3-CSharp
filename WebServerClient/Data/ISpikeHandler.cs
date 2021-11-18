using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_WebServerClient.Models;

namespace SEP3_WebServerClient.Data
{
    public interface ISpikeHandler
    {
        Task NewSpike(Spike newSpike);

        Task<IList<Spike>> GetSpikes();
    }
}