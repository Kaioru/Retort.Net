using System;
using System.Collections.Generic;

namespace Retort.Core
{
	public interface ICommand : ICommandExecutable
	{
		
		String Name { get; }

		String Desc { get; }

		List<String> Aliases { get; set; }

		List<ICommand> Commands { get; set; }

		ICommand GetCommand(String name);

	}
}
