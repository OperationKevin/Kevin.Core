using System;
using System.Text.RegularExpressions;

namespace Kevin.Core
{
	public class Test : Plugin
	{
		public Test ()
		{
		}


		public override Result getResult(string mess) {
			if (Regex.IsMatch (mess, @"test\b")) {
				return new Result ((string message, Output output) => {
					output.send("Test Success");
				});
			}

			return null;
		}
	}
}

