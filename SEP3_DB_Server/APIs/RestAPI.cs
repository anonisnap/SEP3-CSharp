using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SEP3_DB_Server.APIs.Controllers;

namespace SEP3_DB_Server.APIs
{
	public class RestAPI
	{
		private List<ControllerBase> _controllers;

		public RestAPI(IServer server)
		{
			_controllers = new();

			_controllers.Add(new SpikeController(server));
		}
	}
}