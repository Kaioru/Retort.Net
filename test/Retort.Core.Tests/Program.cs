using System;

namespace Retort.Core.Tests
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			CommandRegistry registry = new CommandRegistry();
			ICommand command = new PingCommand();

			registry.RegisterCommand(command);

			CommandUtil.ExecuteCommand(registry, "p", new Object[0]);
		}
	}
}
