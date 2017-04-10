using System;
using System.Collections.Generic;

namespace Retort.Core.Tests
{
	public class PingCommand : Command
	{

		public override string Name => "ping";
		public override string Desc => "Ping command!";

		public override void Execute(List<string> args)
		{
			Console.WriteLine("Pong!");
		}

	}
}
