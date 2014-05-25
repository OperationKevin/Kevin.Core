using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Kevin.Core
{
	class WhosThere : Plugin
	{

		public override Result getResult(string mess) {
			if (Regex.IsMatch (mess, @"whos there\b")) {
				return new Result ((string message, Output output) => {
					output.send("me, Kevin.");
				});
			}

			return null;
		}
	}
}

