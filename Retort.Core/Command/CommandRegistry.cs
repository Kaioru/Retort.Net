using System;
using System.Collections.Generic;

namespace Retort.Core
{
	public class CommandRegistry : Command
	{
		public override string Name => "registry";

		public override string Desc => "The default registry";

		public override void Execute(List<string> args)
		{
			// Do nothing
		}

	}
}
