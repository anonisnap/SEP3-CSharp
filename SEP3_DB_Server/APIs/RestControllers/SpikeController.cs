using Microsoft.AspNetCore.Mvc;

namespace SEP3_DB_Server.APIs.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class SpikeController : ControllerBase
	{
		private IServer _server;
		public SpikeController(IServer server)
		{
			_server = server;
		}
	}
}