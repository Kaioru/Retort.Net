using System;
using System.Collections.Generic;

namespace Retort.Core
{
	public interface ICommandExecutable
	{

		void Execute(List<String> args);

	}
}
