using System;
using System.Collections.Generic;

namespace Retort.Core
{
	public abstract class Command : ICommand
	{

		public abstract string Name { get; }
		public abstract string Desc { get; }
		public List<string> Aliases { get; set; }
		public List<ICommand> Commands { get; set; }

		public Command() {
			Aliases = new List<string>();
			Commands = new List<ICommand>();
		}

		public abstract void Execute(List<string> args);

		public ICommand GetCommand(string name)
		{
			return Commands
				.Find(c => c.Name.ToLower().StartsWith(name, StringComparison.Ordinal)
				      || c.Aliases.FindAll(s => s.ToLower().StartsWith(name, StringComparison.Ordinal)).Count > 0);
		}

		public void RegisterCommand(ICommand command)
		{
			Commands.Add(command);
		}

		public void DeregisterCommand(ICommand command)
		{
			Commands.Remove(command);
		}

	}
}
