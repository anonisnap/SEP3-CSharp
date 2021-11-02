using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SEP3_DB_Server.APIs
{
	public class RestAPI
	{
		private List<ControllerBase> _controllers;

		public RestAPI()
		{

			_controllers = new();
		}
	}
}