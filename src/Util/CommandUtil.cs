using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Retort.Core
{
	public class CommandUtil
	{
		
		public static List<String> GetArgs(String text)
		{
			Regex regex = new Regex("([\"'])(?:(?=(\\\\?))\\2.)*?\\1|([^\\s]+)");
			List<String> args = regex.Matches(text)
				.Cast<Match>()
				.Select(m => m.Value)
							 .ToList();
			return args;
		}

		public static MethodInfo GetMethod(Type type, String name, int paramsCount)
		{
			return type.GetRuntimeMethods()
					.Where(m => m.Name == name)
					.Where(m => m.GetParameters().Length == paramsCount)
						   .First();
		}

		public static void ExecuteCommand(ICommand command, String text, params Object[] parameters)
		{
			ExecuteCommand(command, GetArgs(text), parameters);
		}

		public static void ExecuteCommand(ICommand command, List<String> args, params Object[] parameters)
		{
			if (args.Count > 0)
			{
				String first = args[0];
				ICommand sub = command.GetCommand(first);

				if (sub != null)
				{
					args.Remove(first);
					ExecuteCommand(sub, args, parameters);
					return;
				}
			}

			if (parameters.Length == 0)
			{
				command.Execute(args);
			}
			else
			{
				MethodInfo info = GetMethod(command.GetType(), "Execute", parameters.Length + 1);

				if (info != null)
				{
					List<Object> temp = new List<Object>();
					temp.AddRange(parameters);
					temp.Add(args);
					info.Invoke(command, temp.ToArray());
				}
			}
		}

	}
}
