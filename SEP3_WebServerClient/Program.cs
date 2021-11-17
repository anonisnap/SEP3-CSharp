using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ServerCommunication.SocketCommunication;

namespace SEP3_WebServerClient {
	public class Program {
		public static void Main2(string[ ] args)
		{
			Thread t = new Thread(() => new SocketClient());
			
			//CreateHostBuilder(args).Build( ).Run( );
		}

		public static IHostBuilder CreateHostBuilder(string[ ] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder => {
					webBuilder.UseStartup<Startup>( );
				});
	}
}
